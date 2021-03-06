﻿namespace Sadco.FamilyDoctor.Core.Controls
{
    partial class Dlg_EditorImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrl_LGroupValue = new System.Windows.Forms.Label();
            this.ctrl_LTitleGroup = new System.Windows.Forms.Label();
            this.ctrl_TBName = new System.Windows.Forms.TextBox();
            this.ctrl_LTitleName = new System.Windows.Forms.Label();
            this.ctrl_TBDecs = new System.Windows.Forms.TextBox();
            this.ctrl_LTitleDesc = new System.Windows.Forms.Label();
            this.ctrl_BCancel = new System.Windows.Forms.Button();
            this.ctrl_BOk = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrl_LGroupValue);
            this.panel2.Controls.Add(this.ctrl_LTitleGroup);
            this.panel2.Controls.Add(this.ctrl_TBName);
            this.panel2.Controls.Add(this.ctrl_LTitleName);
            this.panel2.Controls.Add(this.ctrl_TBDecs);
            this.panel2.Controls.Add(this.ctrl_LTitleDesc);
            this.panel2.Controls.Add(this.ctrl_BCancel);
            this.panel2.Controls.Add(this.ctrl_BOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 145);
            this.panel2.TabIndex = 64;
            // 
            // ctrl_LGroupValue
            // 
            this.ctrl_LGroupValue.AutoSize = true;
            this.ctrl_LGroupValue.Location = new System.Drawing.Point(188, 17);
            this.ctrl_LGroupValue.Name = "ctrl_LGroupValue";
            this.ctrl_LGroupValue.Size = new System.Drawing.Size(78, 13);
            this.ctrl_LGroupValue.TabIndex = 70;
            this.ctrl_LGroupValue.Text = "Неизвестно";
            // 
            // ctrl_LTitleGroup
            // 
            this.ctrl_LTitleGroup.AutoSize = true;
            this.ctrl_LTitleGroup.Location = new System.Drawing.Point(16, 17);
            this.ctrl_LTitleGroup.Name = "ctrl_LTitleGroup";
            this.ctrl_LTitleGroup.Size = new System.Drawing.Size(48, 13);
            this.ctrl_LTitleGroup.TabIndex = 69;
            this.ctrl_LTitleGroup.Text = "Группа";
            // 
            // ctrl_TBName
            // 
            this.ctrl_TBName.Location = new System.Drawing.Point(191, 43);
            this.ctrl_TBName.Name = "ctrl_TBName";
            this.ctrl_TBName.Size = new System.Drawing.Size(223, 20);
            this.ctrl_TBName.TabIndex = 0;
            // 
            // ctrl_LTitleName
            // 
            this.ctrl_LTitleName.AutoSize = true;
            this.ctrl_LTitleName.Location = new System.Drawing.Point(16, 46);
            this.ctrl_LTitleName.Name = "ctrl_LTitleName";
            this.ctrl_LTitleName.Size = new System.Drawing.Size(95, 13);
            this.ctrl_LTitleName.TabIndex = 67;
            this.ctrl_LTitleName.Text = "Наименование";
            // 
            // ctrl_TBDecs
            // 
            this.ctrl_TBDecs.Location = new System.Drawing.Point(191, 66);
            this.ctrl_TBDecs.Name = "ctrl_TBDecs";
            this.ctrl_TBDecs.Size = new System.Drawing.Size(224, 20);
            this.ctrl_TBDecs.TabIndex = 1;
            // 
            // ctrl_LTitleDesc
            // 
            this.ctrl_LTitleDesc.AutoSize = true;
            this.ctrl_LTitleDesc.Location = new System.Drawing.Point(16, 69);
            this.ctrl_LTitleDesc.Name = "ctrl_LTitleDesc";
            this.ctrl_LTitleDesc.Size = new System.Drawing.Size(65, 13);
            this.ctrl_LTitleDesc.TabIndex = 24;
            this.ctrl_LTitleDesc.Text = "Описание";
            // 
            // ctrl_BCancel
            // 
            this.ctrl_BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ctrl_BCancel.Location = new System.Drawing.Point(316, 108);
            this.ctrl_BCancel.Name = "ctrl_BCancel";
            this.ctrl_BCancel.Size = new System.Drawing.Size(87, 23);
            this.ctrl_BCancel.TabIndex = 4;
            this.ctrl_BCancel.Text = "Отмена";
            this.ctrl_BCancel.UseVisualStyleBackColor = true;
            // 
            // ctrl_BOk
            // 
            this.ctrl_BOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrl_BOk.Location = new System.Drawing.Point(212, 108);
            this.ctrl_BOk.Name = "ctrl_BOk";
            this.ctrl_BOk.Size = new System.Drawing.Size(87, 23);
            this.ctrl_BOk.TabIndex = 3;
            this.ctrl_BOk.Text = "ОК";
            this.ctrl_BOk.UseVisualStyleBackColor = true;
            // 
            // Dlg_EditorImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(432, 145);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Dlg_EditorImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dlg_EditorImage";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        protected internal System.Windows.Forms.TextBox ctrl_TBDecs;
        private System.Windows.Forms.Label ctrl_LTitleDesc;
        private System.Windows.Forms.Button ctrl_BCancel;
        private System.Windows.Forms.Button ctrl_BOk;
        protected internal System.Windows.Forms.Label ctrl_LGroupValue;
        private System.Windows.Forms.Label ctrl_LTitleGroup;
        protected internal System.Windows.Forms.TextBox ctrl_TBName;
        private System.Windows.Forms.Label ctrl_LTitleName;
    }
}