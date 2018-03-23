﻿using Sadco.FamilyDoctor.Core;
using Sadco.FamilyDoctor.Core.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Sadco.FamilyDoctor.Core.Entities.Cl_Element;

namespace Sadco.FamilyDoctor.MedicalChart.Forms.SubForms
{
    public partial class UC_EditorImage : UserControl, I_EditPanel
    {
        public Cl_Element p_EditingImage { get; private set; }

        public UC_EditorImage()
        {
            InitializeComponent();
        }

        private bool m_ReadOnly = true;
        public bool p_ReadOnly {
            get { return m_ReadOnly; }
            set {
                m_ReadOnly = value;
                Enabled = m_ReadOnly;
            }
        }

        public object f_ConfirmChanges()
        {
            Cl_Element el = null;
            if (p_EditingImage.p_Version == 0)
            {
                el = p_EditingImage;
                el.p_Version = 1;
            }
            else
            {
                el = new Cl_Element();
                el.p_Version = p_EditingImage.p_Version + 1;
                el.p_ParentGroupID = p_EditingImage.p_ParentGroupID;
                el.p_ParentGroup = p_EditingImage.p_ParentGroup;
                Cl_App.m_DataContext.p_Elements.Add(el);
            }
            el.p_ElementType = E_ElementsTypes.Image;
            el.p_ElementID = p_EditingImage.p_ElementID;
            el.p_Name = ctrl_Name.Text;
            el.p_Tag = ctrlTag.Text;
            el.p_Help = ctrl_Hint.Text;
            el.p_Default = ctrl_Default.Text;
            el.p_Comment = ctrl_Note.Text;

            Cl_App.m_DataContext.SaveChanges();
            f_SetElement(el);
            return el;
        }

        public void f_SetElement(Cl_Element a_Element)
        {
            if (a_Element == null || !a_Element.f_IsImage()) return;
            p_EditingImage = a_Element;
            if (p_EditingImage.p_Version == 0)
                ctrl_Version.Text = "Черновик";
            else
                ctrl_Version.Text = p_EditingImage.p_Version.ToString();
            ctrl_Name.Text = p_EditingImage.p_Name;
            ctrlTag.Text = p_EditingImage.p_Tag;
            ctrl_Hint.Text = p_EditingImage.p_Help;
            ctrl_Default.Text = p_EditingImage.p_Default;
            ctrl_Note.Text = p_EditingImage.p_Comment;
        }
    }
}