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
    public static class Cl_EntityValue
    {
        private static object lastValue = null;

        public static string f_GetValue(PropertyInfo pInfo, object value, object lastValue)
        {
            Cl_EntityValue.lastValue = lastValue;
            Type type = pInfo.PropertyType;
            string outValue = "";

            if (type == typeof(Cl_Group))
                outValue = f_GetGroupValue(value);
            else if (type == typeof(Cl_ElementParam))
                outValue = f_GetElementParamValue(value);
            else if (type == typeof(String))
                outValue = f_GetDefaultValue(value);
            else if (type == typeof(Byte))
                outValue = f_GetDefaultValue(value);
            else if (type == typeof(Boolean))
                outValue = f_GetBoolValue(value);
            else if (type == typeof(Decimal))
                outValue = f_GetDecimalValue(value);
            else if (type.GetInterface(nameof(System.Collections.IEnumerable)) != null)
                outValue = f_GetIEnumerableValue(pInfo, value);
            else
            {
                if (type.BaseType != null)
                {
                    if (type.BaseType == typeof(Enum))
                        outValue = f_GetEnumValue(value);
                    else
                    {
                        if (value != null)
                            return value.ToString();
                        else
                            return "";
                    }
                }
                else
                {
                    if (value != null)
                        return value.ToString();
                    else
                        return "";
                }
            }

            return outValue;
        }

        private static string f_GetIEnumerableValue(PropertyInfo pInfo, object value)
        {
            if (pInfo.PropertyType.IsArray || pInfo.PropertyType == typeof(Array))
                return f_GetArraysValue(value);
            else if (pInfo.PropertyType.IsGenericType)
                return f_GetCollectionValue(pInfo, value);
            else
                return "";
        }

        private static string f_GetCollectionValue(PropertyInfo pInfo, object value)
        {
            Type valType = pInfo.PropertyType.GetGenericArguments().Single();

            if (valType.Name == nameof(Cl_TemplateElement))
                return f_GetTemplateElementsValue(pInfo, value);
            else if (valType.Name == nameof(Cl_RecordValue))
                return f_GetRecordValueValue(pInfo, value);
            else
                throw new NotImplementedException();
        }

        private static string f_GetRecordValueValue(PropertyInfo pInfo, object value)
        {
            StringBuilder sBuilder = new StringBuilder();
            List<Cl_RecordValue> last = (List<Cl_RecordValue>)Cl_EntityValue.lastValue;
            List<Cl_RecordValue> current = (List<Cl_RecordValue>)value;

            if (last == null)
                last = new List<Cl_RecordValue>();
            if (current == null)
                current = new List<Cl_RecordValue>();

            for (int i = 0; i < current.Count; i++)
            {
                sBuilder.AppendLine(f_GetRecordValue(current.ElementAt(i), last.ElementAt(i)));
            }

            return sBuilder.ToString().Trim();
        }

        private static string f_GetRecordValue(Cl_RecordValue cur, Cl_RecordValue last)
        {
            StringBuilder sBuild = new StringBuilder();
            Cl_Element baseElement = cur.p_Element;

            if (baseElement.p_IsText)
            {
                if (baseElement.p_IsPartLocations)
                {
                    if (Cl_EntityCompare.f_IsCompare(typeof(Array), cur.p_PartLocations, last.p_PartLocations) == false)

                        sBuild.AppendLine("Локация \"" + baseElement.p_Name + "\". " + f_GetRecordParamsValue(cur.p_PartLocations, last.p_PartLocations));
                }

                if (baseElement.p_IsTextFromCatalog)
                {
                    if (Cl_EntityCompare.f_IsCompare(typeof(Array), cur.p_ValuesCatalog, last.p_ValuesCatalog) == false)
                        sBuild.AppendLine("Локация \"" + baseElement.p_Name + "\". " + f_GetRecordParamsValue(cur.p_ValuesCatalog, last.p_ValuesCatalog));

                    if (baseElement.p_Symmetrical && Cl_EntityCompare.f_IsCompare(typeof(Array), last.p_ValuesDopCatalog, cur.p_ValuesDopCatalog) == false)
                    {
                        sBuild.AppendLine("Локация \"" + baseElement.p_Name + "\". " + f_GetRecordParamsValue(cur.p_ValuesDopCatalog, last.p_ValuesDopCatalog));
                    }
                }
                else
                {
                    if (Cl_EntityCompare.f_IsCompare(typeof(String), last.p_ValueUser, cur.p_ValueUser) == false)
                        sBuild.AppendLine("Значение \"" + baseElement.p_Name + "\"" + (baseElement.p_Symmetrical ? " (" + baseElement.p_SymmetryParamLeft + ")" : "") + ". " + "Старое значение: \"" + last.p_ValueUser + "\". Новое значение: \"" + cur.p_ValueUser + "\"");

                    if (baseElement.p_Symmetrical && Cl_EntityCompare.f_IsCompare(typeof(String), last.p_ValueDopUser, cur.p_ValueDopUser) == false)
                        sBuild.AppendLine("Значение \"" + baseElement.p_Name + "\"" + (baseElement.p_Symmetrical ? " (" + baseElement.p_SymmetryParamRight + ")" : "") + ". " + "Старое значение: \"" + last.p_ValueDopUser + "\". Новое значение: \"" + cur.p_ValueDopUser + "\"");
                }
            }
            else if (baseElement.p_IsImage)
            {
                sBuild.Append("Картинка \"" + baseElement.p_Name + "\" изменилась");
            }
            else
                throw new NotImplementedException();

            return sBuild.ToString().Trim();
        }

        private static string f_GetRecordParamsValue(I_RecordParam[] elm1, I_RecordParam[] elm2)
        {
            StringBuilder sBuild = new StringBuilder();

            sBuild.Append("Старое значение: ");
            sBuild.Append(f_GetRecordParamValue(elm2));

            sBuild.Append("Новое значение: ");
            sBuild.Append(f_GetRecordParamValue(elm1));

            return sBuild.ToString().Trim();
        }

        private static string f_GetRecordParamValue(I_RecordParam[] elm1)
        {
            StringBuilder sBuild = new StringBuilder();

            if (elm1.Count() == 0)
                sBuild.Append("<пусто>. ");

            for (int i = 0; i < elm1.Count(); i++)
            {
                sBuild.Append("\"" + elm1.ElementAt(i).p_ElementParam.p_Value + "\"");
                if (i != elm1.Count() - 1)
                    sBuild.Append(", ");
            }

            sBuild.Append(". ");
            return sBuild.ToString();
        }

        private static string f_GetTemplateElementsValue(PropertyInfo pInfo, object value)
        {
            StringBuilder sBuilder = new StringBuilder();
            ICollection<Cl_TemplateElement> last = (ICollection<Cl_TemplateElement>)Cl_EntityValue.lastValue;
            ICollection<Cl_TemplateElement> current = (ICollection<Cl_TemplateElement>)value;
            bool flag = false;

            if (last == null)
                last = new List<Cl_TemplateElement>();
            if (current == null)
                current = new List<Cl_TemplateElement>();

            // new element
            foreach (Cl_TemplateElement cur in current)
            {
                flag = false;
                foreach (Cl_TemplateElement l in last)
                {
                    if (cur.p_ChildElement != null)
                    {
                        if (cur.p_ChildElementID == l.p_ChildElementID)
                        {
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        if (cur.p_ChildTemplateID == l.p_ChildTemplateID)
                        {
                            flag = true;
                            break;
                        }
                    }
                }

                if (flag == false)
                    if (cur.p_ChildElement != null)
                        sBuilder.AppendLine("Добавлен новый элемент \"" + cur.p_ChildElement.p_Name + "\" (" + cur.p_ChildElement.p_GetElementName + ")");
                    else
                        sBuilder.AppendLine("Добавлен новый блок \"" + cur.p_ChildTemplate.p_Name + "\" (" + cur.p_ChildTemplate.p_GetTypeName + ")");
            }

            // new position
            for (int x = 0; x < current.Count(); x++)
            {
                Cl_TemplateElement cur = current.ElementAt(x);
                flag = false;
                for (int y = 0; y < last.Count(); y++)
                {
                    Cl_TemplateElement l = last.ElementAt(y);

                    if (cur.p_ChildElement != null)
                    {
                        if (cur.p_ChildElementID == l.p_ChildElementID)
                        {
                            flag = (x != y);
                            break;
                        }
                    }
                    else
                    {
                        if (cur.p_ChildTemplateID == l.p_ChildTemplateID)
                        {
                            flag = (x != y);
                            break;
                        }
                    }
                }

                if (flag)
                    if (cur.p_ChildElement != null)
                        sBuilder.AppendLine("Изменилась позиция элемента \"" + cur.p_ChildElement.p_Name + "\" (" + cur.p_ChildElement.p_GetElementName + ")");
                    else
                        sBuilder.AppendLine("Изменилась позиция блока \"" + cur.p_ChildTemplate.p_Name + "\" (" + cur.p_ChildTemplate.p_GetTypeName + ")");
            }

            // delete element
            foreach (Cl_TemplateElement l in last)
            {
                flag = true;
                foreach (Cl_TemplateElement cur in current)
                {
                    if (cur.p_ChildElement != null)
                    {
                        if (cur.p_ChildElementID == l.p_ChildElementID)
                        {
                            flag = false;
                            break;
                        }
                    }
                    else
                    {
                        if (cur.p_ChildTemplateID == l.p_ChildTemplateID)
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag)
                    if (l.p_ChildElement != null)
                        sBuilder.AppendLine("Удален элемент \"" + l.p_ChildElement.p_Name + "\" (" + l.p_ChildElement.p_GetElementName + ")");
                    else
                        sBuilder.AppendLine("Удален элемент \"" + l.p_ChildTemplate.p_Name + "\" (" + l.p_ChildTemplate.p_GetTypeName + ")");
            }

            return sBuilder.ToString().Trim();
        }

        private static string f_GetGroupValue(object value)
        {
            if (value == null) return "";

            Cl_Group group = value as Cl_Group;
            return group.f_GetFullName();
        }

        private static string f_GetElementParamValue(object value)
        {
            if (value == null) return "";

            Cl_ElementParam group = value as Cl_ElementParam;
            return group.p_Value;
        }

        private static string f_GetEnumValue(object value)
        {
            if (value == null) return "";

            MemberInfo info = value.GetType().GetMember(value.ToString()).FirstOrDefault();

            if (info != null)
            {
                DescriptionAttribute attribute = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                return attribute.Description;
            }
            return value.ToString();
        }

        private static string f_GetBoolValue(object value)
        {
            if (value == null) return "";

            bool tmp = (bool)value;
            return tmp ? "Да" : "Нет";
        }

        private static string f_GetDecimalValue(object value)
        {
            if (value == null) return "";

            decimal dec = (decimal)value;
            if (dec == 0)
                return "0";
            else
                return dec.ToString();
        }

        private static string f_GetArraysValue(object value)
        {
            if (value == null) return "";

            Type type = value.GetType();
            Type elementType = type.GetElementType();
            string result = "";

            using (MD5 md5Hash = MD5.Create())
            {
                if (elementType == typeof(Cl_ElementParam))
                {
                    Cl_ElementParam[] elements = value as Cl_ElementParam[];
                    foreach (Cl_ElementParam item in elements)
                    {
                        //result = CalcStringHash(md5Hash, item.p_Value);
                        result += item.p_Value + "\r\n";
                    }
                    result = result.Trim();
                }
                else if (elementType == typeof(byte))
                {
                    byte[] bytes = value as byte[];
                    result = f_CalcByteHash(md5Hash, bytes);
                }
                else
                {
                    //result = CalcByteHash(md5Hash, bytes);
                }
            }

            return result;
        }

        private static string f_CalcStringHash(MD5 md5Hash, string input)
        {
            return f_CalcByteHash(md5Hash, Encoding.UTF8.GetBytes(input));
        }

        private static string f_CalcByteHash(MD5 md5Hash, byte[] source)
        {
            StringBuilder sBuilder = new StringBuilder();
            byte[] data = md5Hash.ComputeHash(source);

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static string f_GetDefaultValue(object value)
        {
            if (value == null) return "";
            return value.ToString();
        }
    }
}
