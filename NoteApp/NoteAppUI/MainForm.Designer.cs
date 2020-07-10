﻿namespace NoteAppUI
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NotesListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.HelpButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.FileButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RemoveNoteButton = new System.Windows.Forms.Button();
            this.EditNoteButton = new System.Windows.Forms.Button();
            this.AddNoteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NoteContentTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ModifiedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.CreatedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.CategoryTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.NoteTitleTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(4, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(811, 459);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.NotesListBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(264, 459);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // NotesListBox
            // 
            this.NotesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesListBox.FormattingEnabled = true;
            this.NotesListBox.Location = new System.Drawing.Point(2, 59);
            this.NotesListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NotesListBox.Name = "NotesListBox";
            this.NotesListBox.Size = new System.Drawing.Size(260, 366);
            this.NotesListBox.TabIndex = 2;
            this.NotesListBox.SelectedIndexChanged += new System.EventHandler(this.NotesListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CategoryComboBox);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.HelpButton);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.FileButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 53);
            this.panel1.TabIndex = 4;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(86, 25);
            this.CategoryComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(173, 21);
            this.CategoryComboBox.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(2, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(75, 13);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Show Category:";
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.SystemColors.Control;
            this.HelpButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Location = new System.Drawing.Point(80, 0);
            this.HelpButton.Margin = new System.Windows.Forms.Padding(0);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(38, 22);
            this.HelpButton.TabIndex = 2;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.FlatAppearance.BorderSize = 0;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Location = new System.Drawing.Point(42, 0);
            this.EditButton.Margin = new System.Windows.Forms.Padding(0);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(38, 22);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // FileButton
            // 
            this.FileButton.FlatAppearance.BorderSize = 0;
            this.FileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileButton.Location = new System.Drawing.Point(2, 0);
            this.FileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(38, 22);
            this.FileButton.TabIndex = 0;
            this.FileButton.Text = "File";
            this.FileButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RemoveNoteButton);
            this.panel2.Controls.Add(this.EditNoteButton);
            this.panel2.Controls.Add(this.AddNoteButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 429);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 28);
            this.panel2.TabIndex = 5;
            // 
            // RemoveNoteButton
            // 
            this.RemoveNoteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveNoteButton.Location = new System.Drawing.Point(46, 6);
            this.RemoveNoteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RemoveNoteButton.Name = "RemoveNoteButton";
            this.RemoveNoteButton.Size = new System.Drawing.Size(17, 19);
            this.RemoveNoteButton.TabIndex = 2;
            this.RemoveNoteButton.Text = "R";
            this.RemoveNoteButton.UseVisualStyleBackColor = true;
            this.RemoveNoteButton.Click += new System.EventHandler(this.RemoveNoteButton_Click);
            // 
            // EditNoteButton
            // 
            this.EditNoteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditNoteButton.Location = new System.Drawing.Point(24, 6);
            this.EditNoteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EditNoteButton.Name = "EditNoteButton";
            this.EditNoteButton.Size = new System.Drawing.Size(17, 19);
            this.EditNoteButton.TabIndex = 1;
            this.EditNoteButton.Text = "E";
            this.EditNoteButton.UseVisualStyleBackColor = true;
            this.EditNoteButton.Click += new System.EventHandler(this.EditNoteButton_Click);
            // 
            // AddNoteButton
            // 
            this.AddNoteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNoteButton.Location = new System.Drawing.Point(2, 6);
            this.AddNoteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddNoteButton.Name = "AddNoteButton";
            this.AddNoteButton.Size = new System.Drawing.Size(17, 19);
            this.AddNoteButton.TabIndex = 0;
            this.AddNoteButton.Text = "A";
            this.AddNoteButton.UseVisualStyleBackColor = true;
            this.AddNoteButton.Click += new System.EventHandler(this.AddNoteButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.NoteContentTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 459);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NoteContentTextBox
            // 
            this.NoteContentTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.NoteContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteContentTextBox.Location = new System.Drawing.Point(8, 103);
            this.NoteContentTextBox.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.NoteContentTextBox.Multiline = true;
            this.NoteContentTextBox.Name = "NoteContentTextBox";
            this.NoteContentTextBox.ReadOnly = true;
            this.NoteContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NoteContentTextBox.Size = new System.Drawing.Size(534, 354);
            this.NoteContentTextBox.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ModifiedDatePicker);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.CreatedDatePicker);
            this.panel3.Controls.Add(this.CategoryTextBox);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.NoteTitleTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(8, 26);
            this.panel3.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(534, 73);
            this.panel3.TabIndex = 5;
            // 
            // ModifiedDatePicker
            // 
            this.ModifiedDatePicker.Enabled = false;
            this.ModifiedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ModifiedDatePicker.Location = new System.Drawing.Point(213, 50);
            this.ModifiedDatePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModifiedDatePicker.Name = "ModifiedDatePicker";
            this.ModifiedDatePicker.Size = new System.Drawing.Size(98, 20);
            this.ModifiedDatePicker.TabIndex = 3;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(164, 53);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(75, 13);
            this.textBox6.TabIndex = 1;
            this.textBox6.Text = "Modified:";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(2, 53);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(46, 13);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "Created:";
            // 
            // CreatedDatePicker
            // 
            this.CreatedDatePicker.Enabled = false;
            this.CreatedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreatedDatePicker.Location = new System.Drawing.Point(54, 50);
            this.CreatedDatePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreatedDatePicker.Name = "CreatedDatePicker";
            this.CreatedDatePicker.Size = new System.Drawing.Size(98, 20);
            this.CreatedDatePicker.TabIndex = 2;
            // 
            // CategoryTextBox
            // 
            this.CategoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CategoryTextBox.Location = new System.Drawing.Point(53, 31);
            this.CategoryTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.ReadOnly = true;
            this.CategoryTextBox.Size = new System.Drawing.Size(75, 13);
            this.CategoryTextBox.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(2, 31);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(46, 13);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "Category:";
            // 
            // NoteTitleTextBox
            // 
            this.NoteTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NoteTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteTitleTextBox.Location = new System.Drawing.Point(2, 2);
            this.NoteTitleTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NoteTitleTextBox.Name = "NoteTitleTextBox";
            this.NoteTitleTextBox.ReadOnly = true;
            this.NoteTitleTextBox.Size = new System.Drawing.Size(530, 23);
            this.NoteTitleTextBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 461);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 2, 2);
            this.Text = "NoteApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.ListBox NotesListBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.DateTimePicker CreatedDatePicker;
        private System.Windows.Forms.DateTimePicker ModifiedDatePicker;
        private System.Windows.Forms.TextBox NoteContentTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox CategoryTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button RemoveNoteButton;
        private System.Windows.Forms.Button EditNoteButton;
        private System.Windows.Forms.Button AddNoteButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox NoteTitleTextBox;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button FileButton;
    }
}

