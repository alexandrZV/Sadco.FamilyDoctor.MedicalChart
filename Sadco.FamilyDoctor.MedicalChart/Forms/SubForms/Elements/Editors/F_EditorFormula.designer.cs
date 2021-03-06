﻿namespace Sadco.FamilyDoctor.MedicalChart.Forms.SubForms
{
    partial class F_EditorFormula
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Main = new System.Windows.Forms.Panel();
            this.panel_Editor = new System.Windows.Forms.Panel();
            this.ctrlRTBFormula = new System.Windows.Forms.RichTextBox();
            this.panel_Actions = new System.Windows.Forms.Panel();
            this.ctrlBClear = new System.Windows.Forms.Button();
            this.ctrlBDelLastAction = new System.Windows.Forms.Button();
            this.ctrlBAddTag = new System.Windows.Forms.Button();
            this.ctrlCBAddElement = new System.Windows.Forms.ComboBox();
            this.panel_Operators = new System.Windows.Forms.Panel();
            this.ctrlBAddValue = new System.Windows.Forms.Button();
            this.ctrlTBValue = new System.Windows.Forms.TextBox();
            this.ctrlBCarve = new System.Windows.Forms.Button();
            this.ctrlBPlus = new System.Windows.Forms.Button();
            this.ctrlBMultiply = new System.Windows.Forms.Button();
            this.ctrlBMinus = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ctrlBCancel = new System.Windows.Forms.Button();
            this.ctrlBEdit = new System.Windows.Forms.Button();
            this.panel_Main.SuspendLayout();
            this.panel_Editor.SuspendLayout();
            this.panel_Actions.SuspendLayout();
            this.panel_Operators.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Main
            // 
            this.panel_Main.Controls.Add(this.panel_Editor);
            this.panel_Main.Controls.Add(this.panel_Actions);
            this.panel_Main.Controls.Add(this.panel_Operators);
            this.panel_Main.Controls.Add(this.flowLayoutPanel1);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(5, 5);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Padding = new System.Windows.Forms.Padding(5);
            this.panel_Main.Size = new System.Drawing.Size(574, 251);
            this.panel_Main.TabIndex = 1;
            // 
            // panel_Editor
            // 
            this.panel_Editor.Controls.Add(this.ctrlRTBFormula);
            this.panel_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Editor.Location = new System.Drawing.Point(5, 34);
            this.panel_Editor.Name = "panel_Editor";
            this.panel_Editor.Size = new System.Drawing.Size(564, 150);
            this.panel_Editor.TabIndex = 0;
            // 
            // ctrlRTBFormula
            // 
            this.ctrlRTBFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRTBFormula.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlRTBFormula.Location = new System.Drawing.Point(0, 0);
            this.ctrlRTBFormula.Name = "ctrlRTBFormula";
            this.ctrlRTBFormula.ReadOnly = true;
            this.ctrlRTBFormula.Size = new System.Drawing.Size(564, 150);
            this.ctrlRTBFormula.TabIndex = 3;
            this.ctrlRTBFormula.Text = "";
            // 
            // panel_Actions
            // 
            this.panel_Actions.Controls.Add(this.ctrlBClear);
            this.panel_Actions.Controls.Add(this.ctrlBDelLastAction);
            this.panel_Actions.Controls.Add(this.ctrlBAddTag);
            this.panel_Actions.Controls.Add(this.ctrlCBAddElement);
            this.panel_Actions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Actions.Location = new System.Drawing.Point(5, 5);
            this.panel_Actions.Name = "panel_Actions";
            this.panel_Actions.Size = new System.Drawing.Size(564, 29);
            this.panel_Actions.TabIndex = 0;
            // 
            // ctrlBClear
            // 
            this.ctrlBClear.Location = new System.Drawing.Point(486, 3);
            this.ctrlBClear.Name = "ctrlBClear";
            this.ctrlBClear.Size = new System.Drawing.Size(75, 23);
            this.ctrlBClear.TabIndex = 13;
            this.ctrlBClear.Tag = "";
            this.ctrlBClear.Text = "очистить";
            this.ctrlBClear.UseVisualStyleBackColor = true;
            this.ctrlBClear.Click += new System.EventHandler(this.ctrlBClear_Click);
            // 
            // ctrlBDelLastAction
            // 
            this.ctrlBDelLastAction.Location = new System.Drawing.Point(405, 3);
            this.ctrlBDelLastAction.Name = "ctrlBDelLastAction";
            this.ctrlBDelLastAction.Size = new System.Drawing.Size(75, 23);
            this.ctrlBDelLastAction.TabIndex = 2;
            this.ctrlBDelLastAction.Text = "удалить";
            this.ctrlBDelLastAction.UseVisualStyleBackColor = true;
            this.ctrlBDelLastAction.Click += new System.EventHandler(this.ctrlBDelLastAction_Click);
            // 
            // ctrlBAddTag
            // 
            this.ctrlBAddTag.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.ctrlBAddTag.Location = new System.Drawing.Point(235, 2);
            this.ctrlBAddTag.Name = "ctrlBAddTag";
            this.ctrlBAddTag.Size = new System.Drawing.Size(75, 23);
            this.ctrlBAddTag.TabIndex = 1;
            this.ctrlBAddTag.Text = "добавить";
            this.ctrlBAddTag.UseVisualStyleBackColor = true;
            this.ctrlBAddTag.Click += new System.EventHandler(this.ctrlBAddTag_Click);
            // 
            // ctrlCBAddElement
            // 
            this.ctrlCBAddElement.FormattingEnabled = true;
            this.ctrlCBAddElement.Location = new System.Drawing.Point(3, 3);
            this.ctrlCBAddElement.Name = "ctrlCBAddElement";
            this.ctrlCBAddElement.Size = new System.Drawing.Size(226, 21);
            this.ctrlCBAddElement.TabIndex = 16;
            // 
            // panel_Operators
            // 
            this.panel_Operators.Controls.Add(this.ctrlBAddValue);
            this.panel_Operators.Controls.Add(this.ctrlTBValue);
            this.panel_Operators.Controls.Add(this.ctrlBCarve);
            this.panel_Operators.Controls.Add(this.ctrlBPlus);
            this.panel_Operators.Controls.Add(this.ctrlBMultiply);
            this.panel_Operators.Controls.Add(this.ctrlBMinus);
            this.panel_Operators.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Operators.Location = new System.Drawing.Point(5, 184);
            this.panel_Operators.Name = "panel_Operators";
            this.panel_Operators.Size = new System.Drawing.Size(564, 30);
            this.panel_Operators.TabIndex = 18;
            // 
            // ctrlBAddValue
            // 
            this.ctrlBAddValue.Location = new System.Drawing.Point(501, 3);
            this.ctrlBAddValue.Name = "ctrlBAddValue";
            this.ctrlBAddValue.Size = new System.Drawing.Size(60, 23);
            this.ctrlBAddValue.TabIndex = 10;
            this.ctrlBAddValue.Text = "число";
            this.ctrlBAddValue.UseVisualStyleBackColor = true;
            this.ctrlBAddValue.Click += new System.EventHandler(this.ctrlBAddValue_Click);
            // 
            // ctrlTBValue
            // 
            this.ctrlTBValue.Location = new System.Drawing.Point(446, 4);
            this.ctrlTBValue.Name = "ctrlTBValue";
            this.ctrlTBValue.Size = new System.Drawing.Size(49, 20);
            this.ctrlTBValue.TabIndex = 9;
            // 
            // ctrlBCarve
            // 
            this.ctrlBCarve.Location = new System.Drawing.Point(135, 3);
            this.ctrlBCarve.Name = "ctrlBCarve";
            this.ctrlBCarve.Size = new System.Drawing.Size(75, 23);
            this.ctrlBCarve.TabIndex = 6;
            this.ctrlBCarve.Tag = "";
            this.ctrlBCarve.Text = "разделить";
            this.ctrlBCarve.UseVisualStyleBackColor = true;
            this.ctrlBCarve.Click += new System.EventHandler(this.addAction_Click);
            // 
            // ctrlBPlus
            // 
            this.ctrlBPlus.Location = new System.Drawing.Point(3, 3);
            this.ctrlBPlus.Name = "ctrlBPlus";
            this.ctrlBPlus.Size = new System.Drawing.Size(60, 23);
            this.ctrlBPlus.TabIndex = 4;
            this.ctrlBPlus.Tag = "";
            this.ctrlBPlus.Text = "плюс";
            this.ctrlBPlus.UseVisualStyleBackColor = true;
            this.ctrlBPlus.Click += new System.EventHandler(this.addAction_Click);
            // 
            // ctrlBMultiply
            // 
            this.ctrlBMultiply.Location = new System.Drawing.Point(216, 3);
            this.ctrlBMultiply.Name = "ctrlBMultiply";
            this.ctrlBMultiply.Size = new System.Drawing.Size(75, 23);
            this.ctrlBMultiply.TabIndex = 7;
            this.ctrlBMultiply.Tag = "";
            this.ctrlBMultiply.Text = "умножить";
            this.ctrlBMultiply.UseVisualStyleBackColor = true;
            this.ctrlBMultiply.Click += new System.EventHandler(this.addAction_Click);
            // 
            // ctrlBMinus
            // 
            this.ctrlBMinus.Location = new System.Drawing.Point(69, 3);
            this.ctrlBMinus.Name = "ctrlBMinus";
            this.ctrlBMinus.Size = new System.Drawing.Size(60, 23);
            this.ctrlBMinus.TabIndex = 5;
            this.ctrlBMinus.Tag = "";
            this.ctrlBMinus.Text = "минус";
            this.ctrlBMinus.UseVisualStyleBackColor = true;
            this.ctrlBMinus.Click += new System.EventHandler(this.addAction_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ctrlBCancel);
            this.flowLayoutPanel1.Controls.Add(this.ctrlBEdit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 214);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(564, 32);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // ctrlBCancel
            // 
            this.ctrlBCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ctrlBCancel.Location = new System.Drawing.Point(480, 3);
            this.ctrlBCancel.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlBCancel.Name = "ctrlBCancel";
            this.ctrlBCancel.Size = new System.Drawing.Size(78, 25);
            this.ctrlBCancel.TabIndex = 12;
            this.ctrlBCancel.Text = "отмена";
            this.ctrlBCancel.UseVisualStyleBackColor = true;
            this.ctrlBCancel.Click += new System.EventHandler(this.ctrlBCancel_Click);
            // 
            // ctrlBEdit
            // 
            this.ctrlBEdit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrlBEdit.Location = new System.Drawing.Point(387, 3);
            this.ctrlBEdit.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.ctrlBEdit.Name = "ctrlBEdit";
            this.ctrlBEdit.Size = new System.Drawing.Size(78, 25);
            this.ctrlBEdit.TabIndex = 11;
            this.ctrlBEdit.Text = "изменить";
            this.ctrlBEdit.UseVisualStyleBackColor = true;
            // 
            // F_EditorFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.panel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1600, 1000);
            this.Name = "F_EditorFormula";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_EditorFormula";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_EditorFormula_FormClosing);
            this.panel_Main.ResumeLayout(false);
            this.panel_Editor.ResumeLayout(false);
            this.panel_Actions.ResumeLayout(false);
            this.panel_Operators.ResumeLayout(false);
            this.panel_Operators.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.ComboBox ctrlCBAddElement;
        private System.Windows.Forms.Button ctrlBClear;
        private System.Windows.Forms.Button ctrlBCancel;
        private System.Windows.Forms.Button ctrlBEdit;
        private System.Windows.Forms.Button ctrlBAddValue;
        private System.Windows.Forms.TextBox ctrlTBValue;
        private System.Windows.Forms.Button ctrlBMultiply;
        private System.Windows.Forms.Button ctrlBCarve;
        private System.Windows.Forms.Button ctrlBMinus;
        private System.Windows.Forms.Button ctrlBPlus;
        private System.Windows.Forms.RichTextBox ctrlRTBFormula;
        private System.Windows.Forms.Button ctrlBDelLastAction;
        private System.Windows.Forms.Button ctrlBAddTag;
		private System.Windows.Forms.Panel panel_Editor;
		private System.Windows.Forms.Panel panel_Actions;
		private System.Windows.Forms.Panel panel_Operators;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

