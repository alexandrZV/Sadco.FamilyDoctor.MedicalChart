﻿using Sadco.FamilyDoctor.Core.Entities;
using System.Drawing;
using System.Windows.Forms;

namespace Sadco.FamilyDoctor.Core.Controls
{
    public class Ctrl_TreeNodeElement : TreeNode, I_TreeNode
    {
        public Ctrl_TreeNodeElement(Cl_Group a_Group, Cl_Element a_Element)
        {
            p_Group = a_Group;
            p_Element = a_Element;
            ForeColor = Color.Blue;
        }

		public Cl_Group p_Group { get; private set; }

		private Cl_Element m_Element = null;
		public Cl_Element p_Element {
			get {
				return m_Element;
			}
			set {
				m_Element = value;
                f_Update();
            }
		}

        /// <summary>Обновление части дерева</summary>
        public void f_Update()
        {
            if (m_Element != null)
            {
                Text = m_Element.p_Name;
                Name = p_Element.p_ID.ToString();
                ImageKey = p_Element.p_IconName;
                SelectedImageKey = p_Element.p_IconName;
            }
            else
            {
                Text = "Элемент отсутствует";
                this.NodeFont = new Font(this.NodeFont, FontStyle.Bold);
                ForeColor = Color.Red;
            }
        }
    }
}
