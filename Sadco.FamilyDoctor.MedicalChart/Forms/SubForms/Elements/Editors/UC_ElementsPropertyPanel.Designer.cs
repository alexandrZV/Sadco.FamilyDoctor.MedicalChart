﻿namespace Sadco.FamilyDoctor.MedicalChart.Forms.SubForms.Elements.Editors
{
	partial class UC_ElementsPropertyPanel
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
            this.ctrl_P_Properties = new System.Windows.Forms.Panel();
            this.ctrl_P_ControlConteiner = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrl_BHistory = new System.Windows.Forms.Button();
            this.ctrl_BEdit = new System.Windows.Forms.Button();
            this.ctrl_BSave = new System.Windows.Forms.Button();
            this.ctrl_BCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ctrl_P_Properties.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrl_P_Properties
            // 
            this.ctrl_P_Properties.AutoSize = true;
            this.ctrl_P_Properties.Controls.Add(this.ctrl_P_ControlConteiner);
            this.ctrl_P_Properties.Controls.Add(this.panel2);
            this.ctrl_P_Properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrl_P_Properties.Location = new System.Drawing.Point(0, 0);
            this.ctrl_P_Properties.Name = "ctrl_P_Properties";
            this.ctrl_P_Properties.Size = new System.Drawing.Size(552, 196);
            this.ctrl_P_Properties.TabIndex = 1;
            // 
            // ctrl_P_ControlConteiner
            // 
            this.ctrl_P_ControlConteiner.AutoScroll = true;
            this.ctrl_P_ControlConteiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrl_P_ControlConteiner.Location = new System.Drawing.Point(0, 0);
            this.ctrl_P_ControlConteiner.Name = "ctrl_P_ControlConteiner";
            this.ctrl_P_ControlConteiner.Size = new System.Drawing.Size(552, 164);
            this.ctrl_P_ControlConteiner.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.ctrl_BHistory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 164);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(552, 32);
            this.panel2.TabIndex = 16;
            // 
            // ctrl_BHistory
            // 
            this.ctrl_BHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrl_BHistory.Location = new System.Drawing.Point(3, 3);
            this.ctrl_BHistory.Name = "ctrl_BHistory";
            this.ctrl_BHistory.Size = new System.Drawing.Size(75, 26);
            this.ctrl_BHistory.TabIndex = 7;
            this.ctrl_BHistory.Text = "история";
            this.ctrl_BHistory.UseVisualStyleBackColor = true;
            this.ctrl_BHistory.Click += new System.EventHandler(this.ctrl_BHistory_Click);
            // 
            // ctrl_BEdit
            // 
            this.ctrl_BEdit.Location = new System.Drawing.Point(0, 0);
            this.ctrl_BEdit.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.ctrl_BEdit.Name = "ctrl_BEdit";
            this.ctrl_BEdit.Size = new System.Drawing.Size(93, 25);
            this.ctrl_BEdit.TabIndex = 6;
            this.ctrl_BEdit.Text = "редактировать";
            this.ctrl_BEdit.UseVisualStyleBackColor = true;
            this.ctrl_BEdit.Click += new System.EventHandler(this.ctrl_BEdit_Click);
            // 
            // ctrl_BSave
            // 
            this.ctrl_BSave.Location = new System.Drawing.Point(108, 0);
            this.ctrl_BSave.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.ctrl_BSave.Name = "ctrl_BSave";
            this.ctrl_BSave.Size = new System.Drawing.Size(75, 25);
            this.ctrl_BSave.TabIndex = 5;
            this.ctrl_BSave.Text = "сохранить";
            this.ctrl_BSave.UseVisualStyleBackColor = true;
            this.ctrl_BSave.Click += new System.EventHandler(this.ctrl_BSave_Click);
            // 
            // ctrl_BCancel
            // 
            this.ctrl_BCancel.Location = new System.Drawing.Point(198, 0);
            this.ctrl_BCancel.Margin = new System.Windows.Forms.Padding(0);
            this.ctrl_BCancel.Name = "ctrl_BCancel";
            this.ctrl_BCancel.Size = new System.Drawing.Size(75, 25);
            this.ctrl_BCancel.TabIndex = 4;
            this.ctrl_BCancel.Text = "отмена";
            this.ctrl_BCancel.UseVisualStyleBackColor = true;
            this.ctrl_BCancel.Click += new System.EventHandler(this.ctrl_BCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.ctrl_BEdit);
            this.flowLayoutPanel1.Controls.Add(this.ctrl_BSave);
            this.flowLayoutPanel1.Controls.Add(this.ctrl_BCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(276, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(273, 26);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // UC_ElementsPropertyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ctrl_P_Properties);
            this.Name = "UC_ElementsPropertyPanel";
            this.Size = new System.Drawing.Size(552, 196);
            this.ctrl_P_Properties.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel ctrl_P_Properties;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button ctrl_BCancel;
		private System.Windows.Forms.Panel ctrl_P_ControlConteiner;
        private System.Windows.Forms.Button ctrl_BEdit;
        private System.Windows.Forms.Button ctrl_BSave;
		private System.Windows.Forms.Button ctrl_BHistory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
