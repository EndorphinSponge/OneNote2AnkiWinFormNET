﻿
namespace OneNote2AnkiWinFormNET
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBoxCLI = new System.Windows.Forms.CheckBox();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.checkBoxHtml = new System.Windows.Forms.CheckBox();
            this.checkBoxCards = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(10, 10);
            this.treeView1.Margin = new System.Windows.Forms.Padding(1);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(296, 388);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(318, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Process page(s)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.processPage);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(318, 67);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Generate XML only";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.genXmlOnly);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(318, 121);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 49);
            this.button3.TabIndex = 5;
            this.button3.Text = "Run Python only";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.runPythonOnly);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(318, 289);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 26);
            this.button4.TabIndex = 6;
            this.button4.Text = "Check Paths";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(318, 321);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 26);
            this.button5.TabIndex = 7;
            this.button5.Text = "Misc Button";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBoxCLI
            // 
            this.checkBoxCLI.AutoSize = true;
            this.checkBoxCLI.Location = new System.Drawing.Point(318, 354);
            this.checkBoxCLI.Name = "checkBoxCLI";
            this.checkBoxCLI.Size = new System.Drawing.Size(89, 20);
            this.checkBoxCLI.TabIndex = 8;
            this.checkBoxCLI.Text = "CLI Output";
            this.checkBoxCLI.UseVisualStyleBackColor = true;
            this.checkBoxCLI.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxDebug
            // 
            this.checkBoxDebug.AutoSize = true;
            this.checkBoxDebug.Location = new System.Drawing.Point(318, 376);
            this.checkBoxDebug.Name = "checkBoxDebug";
            this.checkBoxDebug.Size = new System.Drawing.Size(108, 20);
            this.checkBoxDebug.TabIndex = 9;
            this.checkBoxDebug.Text = "Debug mode";
            this.checkBoxDebug.UseVisualStyleBackColor = true;
            // 
            // checkBoxHtml
            // 
            this.checkBoxHtml.AutoSize = true;
            this.checkBoxHtml.Location = new System.Drawing.Point(319, 174);
            this.checkBoxHtml.Name = "checkBoxHtml";
            this.checkBoxHtml.Size = new System.Drawing.Size(107, 20);
            this.checkBoxHtml.TabIndex = 8;
            this.checkBoxHtml.Text = "HTML Output";
            this.checkBoxHtml.UseVisualStyleBackColor = true;
            this.checkBoxHtml.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxCards
            // 
            this.checkBoxCards.AutoSize = true;
            this.checkBoxCards.Checked = true;
            this.checkBoxCards.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCards.Location = new System.Drawing.Point(319, 196);
            this.checkBoxCards.Name = "checkBoxCards";
            this.checkBoxCards.Size = new System.Drawing.Size(93, 20);
            this.checkBoxCards.TabIndex = 9;
            this.checkBoxCards.Text = "Add Cards";
            this.checkBoxCards.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(436, 408);
            this.Controls.Add(this.checkBoxCards);
            this.Controls.Add(this.checkBoxDebug);
            this.Controls.Add(this.checkBoxHtml);
            this.Controls.Add(this.checkBoxCLI);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "O2A: Select pages to process";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBoxCLI;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.CheckBox checkBoxHtml;
        private System.Windows.Forms.CheckBox checkBoxCards;
    }
}

