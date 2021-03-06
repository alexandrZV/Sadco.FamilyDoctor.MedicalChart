﻿using FD.dat.mon.stb.lib;
using Sadco.FamilyDoctor.Core;
using Sadco.FamilyDoctor.Core.Entities;
using Sadco.FamilyDoctor.Core.EntityLogs;
using Sadco.FamilyDoctor.Core.Facades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Sadco.FamilyDoctor.MedicalChart.Forms.SubForms.Catalogs
{
    public partial class F_RecordsPatterns : Form
    {
        public F_RecordsPatterns()
        {
            this.Font = new System.Drawing.Font(ConfigurationManager.AppSettings["FontFamily"],
                    float.Parse(ConfigurationManager.AppSettings["FontSize"]),
                    (System.Drawing.FontStyle)int.Parse(ConfigurationManager.AppSettings["FontStyle"]),
                    System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            InitializeComponent();
            ctrlTablePatterns.Columns.Clear();
            m_UserId = Cl_SessionFacade.f_GetInstance().p_Doctor.p_UserID;
            f_Refresh();
        }

        private int m_UserId = 0;
        private List<Cl_RecordPattern> m_Patterns = null;

        private void f_Refresh()
        {
            try
            {
                m_Patterns = Cl_App.m_DataContext.p_RecordsPatterns.Include(p => p.p_Template).Include(p => p.p_CategoryClinic).Include(p => p.p_CategoryTotal)
                            .Include(p => p.p_Values).Include(r => r.p_Values.Select(v => v.p_Params)).Where(p => p.p_DoctorID == m_UserId).ToList();
                ctrlTablePatterns.DataSource = m_Patterns;
                foreach (DataGridViewColumn col in ctrlTablePatterns.Columns)
                {
                    if (col.Name == p_Name.Name)
                    {
                        col.Width = p_Name.Width;
                        col.HeaderText = p_Name.HeaderText;
                    }
                    else if (col.Name == "p_Template")
                    {
                        col.Width = p_TemplateName.Width;
                        col.HeaderText = p_TemplateName.HeaderText;
                    }
                    else
                        col.Visible = false;
                }
            }
            catch (Exception er)
            {
                MonitoringStub.Error("Error_Editor", "Не удалось обновить список патернов", er, null, null);
            }
        }


        private void ctrlAdd_Click(object sender, EventArgs e)
        {
            var dlg = new Dlg_RecordPatternSelectSource();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                if (dlg.p_SelectedTemplate != null)
                {
                    try
                    {
                        Cl_RecordPattern pattern = new Cl_RecordPattern();
                        pattern.p_ClinicName = Cl_SessionFacade.f_GetInstance().p_Doctor.p_ClinicName;
                        pattern.f_SetDoctor(Cl_SessionFacade.f_GetInstance().p_Doctor);
                        pattern.f_SetTemplate(dlg.p_SelectedTemplate);
                        var dlgPattern = new Dlg_RecordPattern();
                        dlgPattern.p_RecordPattern = pattern;
                        dlgPattern.e_Save += DlgPattern_e_Save;
                        dlgPattern.ShowDialog(this);
                    }
                    catch (Exception er)
                    {
                        MonitoringStub.Error("Error_Editor", "Не удалось добавить новый патерн", er, null, null);
                    }
                }
            }
        }

        private void DlgPattern_e_Save(object sender, EventArgs e)
        {
            f_Refresh();
        }

        private void ctrlDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить паттерн записей?", "Удаление паттерна записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            using (var transaction = Cl_App.m_DataContext.Database.BeginTransaction())
            {
                try
                {
                    if (ctrlTablePatterns.CurrentRow != null)
                    {
                        var pat = (Cl_RecordPattern)ctrlTablePatterns.CurrentRow.DataBoundItem;
                        if (pat != null)
                        {
                            var pattern = m_Patterns.FirstOrDefault(p => p.p_ID == pat.p_ID);

                            Cl_EntityLog.f_CustomMessageLog(E_EntityTypes.RecordsPatterns, string.Format("Удален патерн \"{0}\" по шаблону \"{1}\"", pattern.p_Name, pattern.p_Template.p_Name), pattern.p_Template.p_TemplateID);

                            foreach (Cl_RecordPatternValue val in pattern.p_Values)
                            {
                                Cl_App.m_DataContext.p_RecordsPatternsParams.RemoveRange(val.p_Params);
                            }
                            Cl_App.m_DataContext.p_RecordsPatternsValues.RemoveRange(pattern.p_Values);
                            Cl_App.m_DataContext.p_RecordsPatterns.Remove(pattern);
                            Cl_App.m_DataContext.SaveChanges();
                            transaction.Commit();
                            f_Refresh();
                        }
                    }
                }
                catch
                {
                    transaction.Rollback();
                    MonitoringStub.Error("Error_Tree", "Не удалось удалить паттерн записей", null, null, null);
                }
            }
        }

        private void ctrlTablePatterns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ctrlTablePatterns.CurrentRow != null)
            {
                var pattern = (Cl_RecordPattern)ctrlTablePatterns.CurrentRow.DataBoundItem;
                if (pattern != null)
                {
                    if (pattern.p_Template != null)
                    {
                        var dlgPattern = new Dlg_RecordPattern();
                        dlgPattern.p_RecordPattern = pattern;
                        dlgPattern.e_Save += DlgPattern_e_Save;
                        dlgPattern.ShowDialog(this);
                    }
                }
            }
        }

        private void ctrlHistory_Click(object sender, EventArgs e)
        {
            Dlg_HistoryViewer viewer = new Dlg_HistoryViewer();
            viewer.LoadHistory(false, E_EntityTypes.RecordsPatterns);
            viewer.ShowDialog(this);
        }
    }
}
