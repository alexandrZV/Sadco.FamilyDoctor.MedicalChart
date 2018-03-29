﻿using Sadco.FamilyDoctor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Sadco.FamilyDoctor.Core.EntityLogs
{
	public class EntityLog : IDisposable
	{
		private EntityTypes entityLogType = EntityTypes.Elements;
		private Dictionary<PropertyInfo, string> lastValues = null;
		private I_ELog logObject { get; set; }
		private int lastLogID { get; set; }

		/// <summary>
		/// Определяет был ли изменен объект
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public bool IsChanged(I_ELog obj)
		{
			bool isChanged = false;

			ELogClassAttribute classAtr = GetClassAttribute<ELogClassAttribute>(obj);

			if (classAtr == null) return isChanged;
			if (this.entityLogType != classAtr.EntityType) return isChanged;

			Dictionary<PropertyInfo, string> currentValues = GetValues(obj);

			foreach (KeyValuePair<PropertyInfo, string> item in currentValues)
			{
				if (!lastValues.ContainsKey(item.Key)) continue;
				if (!lastValues[item.Key].Equals(item.Value))
				{
					isChanged = true;
					break;
				}
			}

			return isChanged;
		}

		/// <summary>
		/// Установка первоначального объекта
		/// </summary>
		/// <param name="obj"></param>
		public void SetEntity(I_ELog obj)
		{
			if (logObject != null || obj == null) return;

			ELogClassAttribute classAtr = GetClassAttribute<ELogClassAttribute>(obj);
			if (classAtr == null) return;

			this.logObject = obj;
			this.entityLogType = classAtr.EntityType;

			lastValues = GetValues(logObject);

			Cl_Log prevEvent = Cl_App.m_DataContext.p_Logs.Where(l => l.p_ElementID == obj.p_ID).OrderByDescending(d => d.p_ChangeTime).FirstOrDefault();
			if (prevEvent == null)
				lastLogID = 0;
			else
				lastLogID = prevEvent.p_ID;
		}

		/// <summary>
		/// Вызывается после сохранения элемента, что бы определить какие изменения были сделаны
		/// </summary>
		/// <param name="obj"></param>
		public void SaveEntity(I_ELog obj)
		{
			if (obj == null) return;

			Cl_Log newEvent = null;
			Dictionary<PropertyInfo, string> currentValues = GetValues(obj);

			if (this.IsChanged(obj))
			{
				StringBuilder sbAction = new StringBuilder();

				if (lastLogID == 0)
					sbAction.AppendLine("Создан новый элемент");

				foreach (KeyValuePair<PropertyInfo, string> item in currentValues)
				{
					if (!lastValues.ContainsKey(item.Key)) continue;

					if (!lastValues[item.Key].Equals(item.Value))
					{
						ELogPropertyAttribute propAttr = item.Key.GetCustomAttributes(typeof(ELogPropertyAttribute), true).FirstOrDefault() as ELogPropertyAttribute;

						string action = "";

						if (propAttr.IsCustomDescription)
							action = propAttr.Description + ".";
						else
						{
							action = "Изменилось поле: \"";

							if (string.IsNullOrEmpty(propAttr.Description))
								action += item.Key.Name + "\".";
							else
								action += propAttr.Description + "\".";
						}

						if (!propAttr.IgnoreValue)
						{
							action += " Старое значение: \"" + lastValues[item.Key].ToString() + "\".";
							action += " Новое значение: \"" + item.Value.ToString() + "\".";
						}

						sbAction.AppendLine(action);
					}
				}

				newEvent = CreateEvent(obj, lastLogID, sbAction.ToString().Trim());
			}
			else
			{
				newEvent = CreateEvent(obj, lastLogID, "Без изменений");
			}


			Cl_App.m_DataContext.p_Logs.Add(newEvent);
			Cl_App.m_DataContext.SaveChanges();

			lastValues.Clear();
			lastValues = currentValues;

			logObject = obj;
			lastLogID = newEvent.p_ID;
		}

		private Cl_Log CreateEvent(I_ELog obj, int lastID, string action)
		{
			Cl_Log outEvent = new Cl_Log();

			outEvent.p_ElementID = obj.p_ID;
			outEvent.p_PrevID = lastID;
			outEvent.p_Version = obj.p_Version;
			outEvent.p_EntityType = this.entityLogType;
			outEvent.p_ChangeTime = DateTime.Now;
			outEvent.p_Event = action;
			outEvent.p_UserName = "TestUserName";

			return outEvent;
		}

		private Dictionary<PropertyInfo, string> GetValues(I_ELog obj)
		{
			Dictionary<PropertyInfo, string> values = new Dictionary<PropertyInfo, string>();
			Type type = obj.GetType();

			foreach (PropertyInfo mInfo in type.GetProperties())
			{
				foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
				{
					if (attr.GetType() == typeof(ELogPropertyAttribute))
					{
						values.Add(mInfo, NormalizeValue(mInfo.GetValue(obj, null)));
					}
				}
			}

			return values;
		}

		private T GetClassAttribute<T>(I_ELog obj)
		{
			Type type = obj.GetType();
			return (T)type.GetCustomAttributes(typeof(T), true).FirstOrDefault();
		}

		#region NormalizeValue
		private string NormalizeValue(object value)
		{
			string outValue = "";

			if (value != null)
			{
				if (value is Cl_Group)
				{
					outValue = GetGroupValue(value);
				}
				else if (value is Enum)
				{
					outValue = GetEnumValue(value);
				}
				else if (value is Boolean)
				{
					outValue = GetBoolValue(value);
				}
				else if (value is Decimal)
				{
					outValue = GetDecimalValue(value);
				}
				else if (value is Array)
				{
					outValue = GetArraysValue(value);
				}
				else
				{
					outValue = GetDefaultValue(value);
				}
			}

			return outValue;
		}

		private string GetGroupValue(object value)
		{
			Cl_Group group = value as Cl_Group;
			return group.f_GetFullName();
		}

		private string GetEnumValue(object value)
		{
			MemberInfo info = value.GetType().GetMember(value.ToString()).FirstOrDefault();

			if (info != null)
			{
				DescriptionAttribute attribute = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
				return attribute.Description;
			}
			return value.ToString();
		}

		private string GetBoolValue(object value)
		{
			bool tmp = (bool)value;
			return tmp ? "Да" : "Нет";
		}

		private string GetDecimalValue(object value)
		{
			decimal dec = (decimal)value;
			if (dec == 0)
				return "0";
			else
				return dec.ToString();
		}

		private string GetArraysValue(object value)
		{
			Type type = value.GetType();
			Type elementType = type.GetElementType();
			string salt = "1qaz2wsx3edc4rfv5tgb";
			string result = salt;

			using (MD5 md5Hash = MD5.Create())
			{
				if (elementType == typeof(Cl_ElementsParams))
				{
					Cl_ElementsParams[] elements = value as Cl_ElementsParams[];
					foreach (Cl_ElementsParams item in elements)
					{
						result = CalcStringHash(md5Hash, item.p_Value);
					}
				}
				else if (elementType == typeof(byte))
				{
					byte[] bytes = value as byte[];
					result = CalcByteHash(md5Hash, bytes);
				}
				else
				{
					//result = CalcByteHash(md5Hash, bytes);
				}
			}

			return result;
		}

		private string CalcStringHash(MD5 md5Hash, string input)
		{
			return CalcByteHash(md5Hash, Encoding.UTF8.GetBytes(input));
		}

		private string CalcByteHash(MD5 md5Hash, byte[] source)
		{
			StringBuilder sBuilder = new StringBuilder();
			byte[] data = md5Hash.ComputeHash(source);

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			return sBuilder.ToString();
		}

		private string GetDefaultValue(object value)
		{
			return value.ToString();
		}
		#endregion

		#region Disposable
		public void Dispose()
		{
			lastValues.Clear();
			lastValues = null;
			logObject = null;
		}
		#endregion
	}
}
