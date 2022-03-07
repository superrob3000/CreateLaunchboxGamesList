using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Unbroken.LaunchBox.Plugins.Data;

namespace RB_CreateGamesList
{
    partial class CreateGamelist_Form
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_OutputFile = new System.Windows.Forms.Button();
            this.textBox_OutputFile = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.checkBox_IncludePlaylists = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "game_list.txt";
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button_OutputFile
            // 
            this.button_OutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(129)))), ((int)(((byte)(162)))));
            this.button_OutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OutputFile.Location = new System.Drawing.Point(11, 106);
            this.button_OutputFile.Name = "button_OutputFile";
            this.button_OutputFile.Size = new System.Drawing.Size(98, 21);
            this.button_OutputFile.TabIndex = 0;
            this.button_OutputFile.Text = "Browse";
            this.button_OutputFile.UseVisualStyleBackColor = false;
            this.button_OutputFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_OutputFile
            // 
            this.textBox_OutputFile.Location = new System.Drawing.Point(115, 107);
            this.textBox_OutputFile.Name = "textBox_OutputFile";
            this.textBox_OutputFile.Size = new System.Drawing.Size(354, 20);
            this.textBox_OutputFile.TabIndex = 1;
            this.textBox_OutputFile.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(129)))), ((int)(((byte)(162)))));
            this.button_start.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_start.Location = new System.Drawing.Point(181, 142);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(120, 23);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Create Game List";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox_IncludePlaylists
            // 
            this.checkBox_IncludePlaylists.AutoSize = true;
            this.checkBox_IncludePlaylists.Checked = true;
            this.checkBox_IncludePlaylists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_IncludePlaylists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_IncludePlaylists.Location = new System.Drawing.Point(12, 22);
            this.checkBox_IncludePlaylists.Name = "checkBox_IncludePlaylists";
            this.checkBox_IncludePlaylists.Size = new System.Drawing.Size(123, 20);
            this.checkBox_IncludePlaylists.TabIndex = 14;
            this.checkBox_IncludePlaylists.Text = "Include Playlists";
            this.checkBox_IncludePlaylists.UseVisualStyleBackColor = true;
            this.checkBox_IncludePlaylists.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 40);
            this.label1.MaximumSize = new System.Drawing.Size(400, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "(Check this box to include the Playlists that are on the main wheel. Note that th" +
    "is will result in some games being listed in multiple places.)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Choose the Output File";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(180, 173);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(125, 13);
            this.Status.TabIndex = 17;
            this.Status.Text = "(Working, Please Wait...)";
            this.Status.Visible = false;
            // 
            // CreateGamelist_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(499, 204);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_IncludePlaylists);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.textBox_OutputFile);
            this.Controls.Add(this.button_OutputFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CreateGamelist_Form";
            this.Text = "Create Game List";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_OutputFile;
        private System.Windows.Forms.TextBox textBox_OutputFile;
        private System.Windows.Forms.Button button_start;
        private CheckBox checkBox_IncludePlaylists;
        private Label label1;
        private Label label2;
        private Label Status;
    }

}

