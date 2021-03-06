﻿namespace Sadco.FamilyDoctor.MedicalChart.Forms.SubForms
{
	partial class Dlg_RecordSelectPattern
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
            this.components = new System.ComponentModel.Container();
            this.ctrl_CMTemplate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctrl_MIGroupNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_MIGroupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_MIGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_MITemplateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_MITemplateEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_MITemplateDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ctrlTablePatterns = new System.Windows.Forms.DataGridView();
            this.p_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_TemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrl_CMTemplate.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlTablePatterns)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrl_CMTemplate
            // 
            this.ctrl_CMTemplate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrl_MIGroupNew,
            this.ctrl_MIGroupEdit,
            this.ctrl_MIGroupDelete,
            this.ctrl_MITemplateNew,
            this.ctrl_MITemplateEdit,
            this.ctrl_MITemplateDelete});
            this.ctrl_CMTemplate.Name = "ctrl_CMTemplate";
            this.ctrl_CMTemplate.Size = new System.Drawing.Size(177, 136);
            // 
            // ctrl_MIGroupNew
            // 
            this.ctrl_MIGroupNew.Name = "ctrl_MIGroupNew";
            this.ctrl_MIGroupNew.Size = new System.Drawing.Size(176, 22);
            this.ctrl_MIGroupNew.Tag = "MI_GroupNew";
            this.ctrl_MIGroupNew.Text = "Добавить группу";
            // 
            // ctrl_MIGroupEdit
            // 
            this.ctrl_MIGroupEdit.Name = "ctrl_MIGroupEdit";
            this.ctrl_MIGroupEdit.Size = new System.Drawing.Size(176, 22);
            this.ctrl_MIGroupEdit.Tag = "MI_GroupEdit";
            this.ctrl_MIGroupEdit.Text = "Изменить группу";
            // 
            // ctrl_MIGroupDelete
            // 
            this.ctrl_MIGroupDelete.Name = "ctrl_MIGroupDelete";
            this.ctrl_MIGroupDelete.Size = new System.Drawing.Size(176, 22);
            this.ctrl_MIGroupDelete.Tag = "MI_GroupDelete";
            this.ctrl_MIGroupDelete.Text = "Удалить группу";
            // 
            // ctrl_MITemplateNew
            // 
            this.ctrl_MITemplateNew.Name = "ctrl_MITemplateNew";
            this.ctrl_MITemplateNew.Size = new System.Drawing.Size(176, 22);
            this.ctrl_MITemplateNew.Tag = "MI_TemplateNew";
            this.ctrl_MITemplateNew.Text = "Добавить шаблон";
            // 
            // ctrl_MITemplateEdit
            // 
            this.ctrl_MITemplateEdit.Name = "ctrl_MITemplateEdit";
            this.ctrl_MITemplateEdit.Size = new System.Drawing.Size(176, 22);
            this.ctrl_MITemplateEdit.Tag = "MI_TemplateEdit";
            this.ctrl_MITemplateEdit.Text = "Изменить шаблон";
            // 
            // ctrl_MITemplateDelete
            // 
            this.ctrl_MITemplateDelete.Name = "ctrl_MITemplateDelete";
            this.ctrl_MITemplateDelete.Size = new System.Drawing.Size(176, 22);
            this.ctrl_MITemplateDelete.Tag = "MI_TemplateDelete";
            this.ctrl_MITemplateDelete.Text = "Удалить шаблон";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(505, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "выбрать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(625, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "отменить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 475);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(733, 32);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // ctrlTablePatterns
            // 
            this.ctrlTablePatterns.AllowUserToAddRows = false;
            this.ctrlTablePatterns.AllowUserToDeleteRows = false;
            this.ctrlTablePatterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlTablePatterns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_ID,
            this.p_Name,
            this.p_TemplateName});
            this.ctrlTablePatterns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTablePatterns.Location = new System.Drawing.Point(0, 0);
            this.ctrlTablePatterns.MultiSelect = false;
            this.ctrlTablePatterns.Name = "ctrlTablePatterns";
            this.ctrlTablePatterns.ReadOnly = true;
            this.ctrlTablePatterns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlTablePatterns.Size = new System.Drawing.Size(733, 475);
            this.ctrlTablePatterns.TabIndex = 4;
            this.ctrlTablePatterns.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctrlTablePatterns_CellDoubleClick);
            // 
            // p_ID
            // 
            this.p_ID.HeaderText = "p_ID";
            this.p_ID.Name = "p_ID";
            this.p_ID.ReadOnly = true;
            this.p_ID.Visible = false;
            // 
            // p_Name
            // 
            this.p_Name.HeaderText = "Название";
            this.p_Name.Name = "p_Name";
            this.p_Name.ReadOnly = true;
            this.p_Name.Width = 250;
            // 
            // p_TemplateName
            // 
            this.p_TemplateName.HeaderText = "Шаблон";
            this.p_TemplateName.Name = "p_TemplateName";
            this.p_TemplateName.ReadOnly = true;
            this.p_TemplateName.Width = 250;
            // 
            // Dlg_RecordSelectPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(733, 507);
            this.Controls.Add(this.ctrlTablePatterns);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(2128, 1000);
            this.Name = "Dlg_RecordSelectPattern";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ctrl_CMTemplate.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlTablePatterns)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip ctrl_CMTemplate;
		private System.Windows.Forms.ToolStripMenuItem ctrl_MIGroupNew;
		private System.Windows.Forms.ToolStripMenuItem ctrl_MIGroupDelete;
		private System.Windows.Forms.ToolStripMenuItem ctrl_MITemplateNew;
		private System.Windows.Forms.ToolStripMenuItem ctrl_MITemplateDelete;
		private System.Windows.Forms.ToolStripMenuItem ctrl_MIGroupEdit;
		private System.Windows.Forms.ToolStripMenuItem ctrl_MITemplateEdit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView ctrlTablePatterns;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_TemplateName;
    }
}
