﻿using Sadco.FamilyDoctor.Core.EntityLogs;
using Sadco.FamilyDoctor.Core.Permision;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sadco.FamilyDoctor.Core.Entities
{
    /// <summary>
    /// Класс сущности записи
    /// </summary>
    [Cl_ELogClass(E_EntityTypes.Records)]
    [Table("T_RECORDS")]
    public class Cl_Record : I_Version, I_Delete, I_ELog
    {
        /// <summary>Ключ записи</summary>
        [Key]
        [Column("F_ID")]
        public int p_ID { get; set; }

        /// <summary>ID записи для всех версий</summary>
        [Column("F_RECORD_ID")]
        public int p_RecordID { get; set; }

        /// <summary>Версия записи</summary>
        [Column("F_VERSION")]
        public int p_Version { get; set; }

        /// <summary>Флаг нахождения записи в удалении</summary>
        [Column("F_ISDEL")]
        [Cl_ELogProperty("Запись удалена", p_IsCustomDescription = true, p_IgnoreValue = true)]
        public bool p_IsDelete { get; set; }

        /// <summary>Возвращает уникальный ID записи</summary>
        int I_ELog.p_GetLogEntityID => this.p_RecordID;

        /// <summary>Пол пациента</summary>
        [Column("F_SEX")]
        public Permision.Cl_User.E_Sex p_Sex { get; set; }

        /// <summary>Дата рождения пациента</summary>
        [Column("F_DATEBIRTH", TypeName = "Date")]
        public DateTime p_DateBirth { get; set; }

        /// <summary>Время формирования записи</summary>
        [Column("F_DATEFORMING")]
        public DateTime p_DateForming { get; set; }

        /// <summary>Время создания записи</summary>
        [Column("F_DATECREATE")]
        public DateTime p_DateCreate { get; set; }

        /// <summary>Время последнего изменения записи</summary>
        [Column("F_DATELASTCHANGE")]
        public DateTime p_DateLastChange { get; set; }

        /// <summary>ID медицинской карты</summary>
        [Column("F_CARD_ID")]
        public int p_MedicalCardID { get; set; }

        /// <summary>Флаг архив</summary>
        [Column("F_ISARCHIVE")]
        public bool p_IsArchive { get; set; }

        /// <summary>Флаг печати</summary>
        [Column("F_ISPRINT")]
        public bool p_IsPrint { get; set; }

        /// <summary>Флаг автомата</summary>
        [Column("F_ISAUTIMATIC")]
        public bool p_IsAutimatic { get; set; }

        /// <summary>ID пользователя</summary>
        [Column("F_USER_ID")]
        public int p_UserID { get; set; }

        /// <summary>Имя пользователя</summary>
        [Column("F_USER_NAME")]
        public string p_UserName { get; set; }

        /// <summary>Фамиля пользователя</summary>
        [Column("F_USER_SURNAME")]
        public string p_UserSurName { get; set; }

        /// <summary>Отчество пользователя</summary>
        [Column("F_USER_LASTNAME")]
        public string p_UserLastName { get; set; }

        /// <summary>ID пациента</summary>
        [Column("F_PATIENT_ID")]
        public int p_PatientID { get; set; }

        /// <summary>Имя пациента</summary>
        [Column("F_PATIENT_NAME")]
        public string p_PatientName { get; set; }

        /// <summary>Фамиля пациента</summary>
        [Column("F_PATIENT_SURNAME")]
        public string p_PatientSurName { get; set; }

        /// <summary>Отчество пациента</summary>
        [Column("F_PATIENT_LASTNAME")]
        public string p_PatientLastName { get; set; }

        /// <summary>ID шаблона</summary>
        [Column("F_TEMPLATE_ID")]
        [ForeignKey("p_Template")]
        public int p_TemplateID { get; set; }
        /// <summary>Шаблон</summary>
        public Cl_Template p_Template { get; set; }

        private List<Cl_RecordValue> m_Values = new List<Cl_RecordValue>();
        /// <summary>Список значений элементов записи</summary>
        [ForeignKey("p_RecordID")]
        [Cl_ELogProperty(p_IsComputedLog = true)]
        public List<Cl_RecordValue> p_Values {
            get { return m_Values; }
            set { m_Values = value; }
        }

        /// <summary>Инициалы пользователя</summary>
        [NotMapped]
        public string p_UserFIO { get { return f_GetUserInitials(); } }
        /// <summary>Возвращает инициалы пользователя</summary>
        public string f_GetUserInitials()
        {
            return string.Format("{0} {1} {2}", p_UserSurName, string.IsNullOrWhiteSpace(p_UserName) ? "" : p_UserName[0].ToString() + ".", string.IsNullOrWhiteSpace(p_UserLastName) ? "" : p_UserLastName[0].ToString() + ".");
        }

        /// <summary>Инициалы пациента</summary>
        [NotMapped]
        public string p_PatientFIO { get { return f_GetPatientInitials(); } }
        /// <summary>Возвращает инициалы пациента</summary>
        public string f_GetPatientInitials()
        {
            return string.Format("{0} {1} {2}", p_PatientSurName, string.IsNullOrWhiteSpace(p_PatientName) ? "" : p_PatientName[0].ToString() + ".", string.IsNullOrWhiteSpace(p_PatientLastName) ? "" : p_PatientLastName[0].ToString() + ".");
        }

        /// <summary>Возвращает возраст пациента</summary>
        public byte f_GetPatientAge()
        {
            byte age = 0;
            if (p_DateBirth != null)
            {
                DateTime dateNow = DateTime.Now;
                byte year = (byte)(dateNow.Year - p_DateBirth.Year);
                if (dateNow.Month < p_DateBirth.Month ||
                    (dateNow.Month == p_DateBirth.Month && dateNow.Day < p_DateBirth.Day)) year--;
                return year;
            }
            return age;
        }

        /// <summary>Установка пользователя</summary>
        public void f_SetUser(Cl_User a_User)
        {
            p_UserID = a_User.p_UserID;
            p_UserSurName = a_User.p_UserSurName;
            p_UserName = a_User.p_UserName;
            p_UserLastName = a_User.p_UserLastName;
        }

        /// <summary>Установка пациента</summary>
        public void f_SetPatient(Cl_User a_User)
        {
            p_PatientID = a_User.p_UserID;
            p_PatientSurName = a_User.p_UserSurName;
            p_PatientName = a_User.p_UserName;
            p_PatientLastName = a_User.p_UserLastName;
            p_Sex = a_User.p_Sex;
            p_DateBirth = a_User.p_DateBirth;
        }
    }
}
