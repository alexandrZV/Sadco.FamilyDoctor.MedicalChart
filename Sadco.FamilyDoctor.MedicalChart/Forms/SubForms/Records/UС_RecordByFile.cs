﻿using FD.dat.mon.stb.lib;
using Sadco.FamilyDoctor.Core.Entities;
using Sadco.FamilyDoctor.Core.Facades;
using System;
using System.IO;
using System.Windows.Forms;

namespace Sadco.FamilyDoctor.MedicalChart.Forms.SubForms
{
    public partial class UС_RecordByFile : UserControl
    {
        public UС_RecordByFile()
        {
            InitializeComponent();
        }

        private E_RecordFileType m_FileType = E_RecordFileType.GIF;
        private byte[] m_FileBytes = null;
        private Cl_Record m_Record = null;

        /// <summary>Установка записи</summary>
        public void f_SetRecord(Cl_Record a_Record)
        {
            m_Record = a_Record;
            f_UpdateMKB();
        }

        /// <summary>Получение новой версии записи</summary>
        public Cl_Record f_GetNewRecord()
        {
            if (m_FileBytes == null || m_Record == null) return null;
            var record = new Cl_Record();
            record.p_Type = E_RecordType.FinishedFile;
            record.p_RecordID = m_Record.p_RecordID;
            record.p_MedicalCardID = m_Record.p_MedicalCardID;
            record.p_ClinicName = m_Record.p_ClinicName;
            record.p_DateLastChange = DateTime.Now;
            record.p_ClinicName = m_Record.p_ClinicName;
            record.p_Title = m_Record.p_Title;
            record.p_CategoryTotalID = m_Record.p_CategoryTotalID;
            record.p_CategoryTotal = m_Record.p_CategoryTotal;
            record.p_CategoryClinicID = m_Record.p_CategoryClinicID;
            record.p_CategoryClinic = m_Record.p_CategoryClinic;
            record.p_DoctorID = m_Record.p_DoctorID;
            record.p_DoctorSurName = m_Record.p_DoctorSurName;
            record.p_DoctorName = m_Record.p_DoctorName;
            record.p_DoctorLastName = m_Record.p_DoctorLastName;
            record.p_MedicalCard = m_Record.p_MedicalCard;
            record.p_DateCreate = m_Record.p_DateCreate;
            record.p_Version = m_Record.p_Version + 1;
            record.p_FileType = m_FileType;
            record.p_FileBytes = m_FileBytes;
            record.p_MKB1 = m_Record.p_MKB1;
            record.p_MKB2 = m_Record.p_MKB2;
            record.p_MKB3 = m_Record.p_MKB3;
            record.p_MKB4 = m_Record.p_MKB4;
            return record;
        }

        /// <summary>Обновление МКБ</summary>
        public void f_UpdateMKB()
        {
            if (m_Record != null)
            {
                ctrlLMKB.Text = $"MKБ: {m_Record.p_MKB1} - {m_Record.p_MKB2} - {m_Record.p_MKB3} - {m_Record.p_MKB4}";
            }
            else
            {
                ctrlLMKB.Text = "";
            }
        }

        private void ctrlBAdd_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Файлы изображений (.bmp, .jpg, .png)|*.bmp;*.jpg;*.png|PDF файл (.pdf)|*.pdf|Веб страницы (.htm, .html)|*.htm;*.html";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;
            var recordFileType = Cl_RecordsFacade.f_GetInstance().f_GetFileType(openFile.FileName);
            if (recordFileType != null)
            {
                m_FileType = (E_RecordFileType)recordFileType;
            }
            else
            {
                MonitoringStub.Message("Неизвестный формат файла записи " + openFile.FileName);
                return;
            }
            m_FileBytes = File.ReadAllBytes(openFile.FileName);
            ctrlLFilePath.Text = openFile.FileName;
        }

        private void ctrlBDel_Click(object sender, System.EventArgs e)
        {
            ctrlLFilePath.Text = "-";
            m_FileBytes = null;
        }
    }
}
