﻿using Sadco.FamilyDoctor.Core.Entities;
using System;
using System.Windows.Forms;

namespace Sadco.FamilyDoctor.MedicalChart
{
	public interface I_EditPanel
	{
		object f_ConfirmChanges();
		void f_SetElement(Cl_Element a_Element);
		bool p_ReadOnly { get; set; }
        Cl_Element p_EditingElement { get; }
    }

	public class UI_PanelManager
	{
		public UserControl p_ActiveControl { get; private set; }

		private Panel m_MainPanel = null;

		public UI_PanelManager(Panel panel)
		{
			m_MainPanel = panel ?? throw new ArgumentNullException("panel");
		}

		public T f_SetElement<T>() where T : UserControl
		{
			UserControl control = (UserControl)Activator.CreateInstance(typeof(T));
			this.f_DeleteElement();
			this.p_ActiveControl = control;
			this.m_MainPanel.Controls.Add(this.p_ActiveControl);
			this.p_ActiveControl.Dock = DockStyle.Fill;
			return (T)p_ActiveControl;
		}

		public void f_DeleteElement()
		{
			if (p_ActiveControl == null) return;
			this.m_MainPanel.Controls.Remove(p_ActiveControl);
        }
    }
}
