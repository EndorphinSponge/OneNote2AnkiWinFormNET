
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
            this.ButtonProcess = new System.Windows.Forms.Button();
            this.ButtonGenXml = new System.Windows.Forms.Button();
            this.ButtonPython = new System.Windows.Forms.Button();
            this.ButtonCheckPaths = new System.Windows.Forms.Button();
            this.ButtonUpdOutline = new System.Windows.Forms.Button();
            this.CheckBoxCLI = new System.Windows.Forms.CheckBox();
            this.CheckBoxDebug = new System.Windows.Forms.CheckBox();
            this.CheckBoxHtml = new System.Windows.Forms.CheckBox();
            this.CheckBoxCards = new System.Windows.Forms.CheckBox();
            this.ButtonMisc = new System.Windows.Forms.Button();
            this.ButtonRemCards = new System.Windows.Forms.Button();
            this.ButtonReport = new System.Windows.Forms.Button();
            this.CheckBoxNoDialogues = new System.Windows.Forms.CheckBox();
            this.CheckBoxReplace = new System.Windows.Forms.CheckBox();
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
            this.treeView1.Size = new System.Drawing.Size(319, 535);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ButtonProcess
            // 
            this.ButtonProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonProcess.Location = new System.Drawing.Point(342, 10);
            this.ButtonProcess.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonProcess.Name = "ButtonProcess";
            this.ButtonProcess.Size = new System.Drawing.Size(125, 45);
            this.ButtonProcess.TabIndex = 1;
            this.ButtonProcess.Text = "Process page(s)";
            this.ButtonProcess.UseVisualStyleBackColor = true;
            this.ButtonProcess.Click += new System.EventHandler(this.ButtonProcess_Click);
            // 
            // ButtonGenXml
            // 
            this.ButtonGenXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGenXml.Location = new System.Drawing.Point(342, 57);
            this.ButtonGenXml.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonGenXml.Name = "ButtonGenXml";
            this.ButtonGenXml.Size = new System.Drawing.Size(125, 45);
            this.ButtonGenXml.TabIndex = 2;
            this.ButtonGenXml.Text = "Generate XML only";
            this.ButtonGenXml.UseVisualStyleBackColor = true;
            this.ButtonGenXml.Click += new System.EventHandler(this.ButtonGenXml_Click);
            // 
            // ButtonPython
            // 
            this.ButtonPython.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPython.Location = new System.Drawing.Point(342, 104);
            this.ButtonPython.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonPython.Name = "ButtonPython";
            this.ButtonPython.Size = new System.Drawing.Size(125, 45);
            this.ButtonPython.TabIndex = 5;
            this.ButtonPython.Text = "Run Python only";
            this.ButtonPython.UseVisualStyleBackColor = true;
            this.ButtonPython.Click += new System.EventHandler(this.ButtonPython_Click);
            // 
            // ButtonCheckPaths
            // 
            this.ButtonCheckPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCheckPaths.Location = new System.Drawing.Point(342, 374);
            this.ButtonCheckPaths.Name = "ButtonCheckPaths";
            this.ButtonCheckPaths.Size = new System.Drawing.Size(125, 25);
            this.ButtonCheckPaths.TabIndex = 6;
            this.ButtonCheckPaths.Text = "Check Paths";
            this.ButtonCheckPaths.UseVisualStyleBackColor = true;
            this.ButtonCheckPaths.Click += new System.EventHandler(this.ButtonCheckPaths_Click);
            // 
            // ButtonUpdOutline
            // 
            this.ButtonUpdOutline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUpdOutline.Location = new System.Drawing.Point(342, 405);
            this.ButtonUpdOutline.Name = "ButtonUpdOutline";
            this.ButtonUpdOutline.Size = new System.Drawing.Size(125, 25);
            this.ButtonUpdOutline.TabIndex = 7;
            this.ButtonUpdOutline.Text = "Update Outline";
            this.ButtonUpdOutline.UseVisualStyleBackColor = true;
            this.ButtonUpdOutline.Click += new System.EventHandler(this.buttonUpdateOutline);
            // 
            // CheckBoxCLI
            // 
            this.CheckBoxCLI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxCLI.Location = new System.Drawing.Point(342, 498);
            this.CheckBoxCLI.Name = "CheckBoxCLI";
            this.CheckBoxCLI.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxCLI.TabIndex = 8;
            this.CheckBoxCLI.Text = "CLI Output";
            this.CheckBoxCLI.UseVisualStyleBackColor = true;
            this.CheckBoxCLI.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CheckBoxDebug
            // 
            this.CheckBoxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxDebug.Location = new System.Drawing.Point(342, 524);
            this.CheckBoxDebug.Name = "CheckBoxDebug";
            this.CheckBoxDebug.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxDebug.TabIndex = 9;
            this.CheckBoxDebug.Text = "Debug mode";
            this.CheckBoxDebug.UseVisualStyleBackColor = true;
            // 
            // CheckBoxHtml
            // 
            this.CheckBoxHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxHtml.Location = new System.Drawing.Point(342, 158);
            this.CheckBoxHtml.Name = "CheckBoxHtml";
            this.CheckBoxHtml.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxHtml.TabIndex = 8;
            this.CheckBoxHtml.Text = "HTML Output";
            this.CheckBoxHtml.UseVisualStyleBackColor = true;
            this.CheckBoxHtml.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CheckBoxCards
            // 
            this.CheckBoxCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxCards.Checked = true;
            this.CheckBoxCards.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxCards.Location = new System.Drawing.Point(342, 184);
            this.CheckBoxCards.Name = "CheckBoxCards";
            this.CheckBoxCards.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxCards.TabIndex = 9;
            this.CheckBoxCards.Text = "Add Cards";
            this.CheckBoxCards.UseVisualStyleBackColor = true;
            this.CheckBoxCards.CheckedChanged += new System.EventHandler(this.checkBoxCards_CheckedChanged);
            // 
            // ButtonMisc
            // 
            this.ButtonMisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMisc.Location = new System.Drawing.Point(342, 467);
            this.ButtonMisc.Name = "ButtonMisc";
            this.ButtonMisc.Size = new System.Drawing.Size(125, 25);
            this.ButtonMisc.TabIndex = 7;
            this.ButtonMisc.Text = "Misc Button";
            this.ButtonMisc.UseVisualStyleBackColor = true;
            this.ButtonMisc.Click += new System.EventHandler(this.ButtonMisc_Click);
            // 
            // ButtonRemCards
            // 
            this.ButtonRemCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRemCards.Location = new System.Drawing.Point(342, 436);
            this.ButtonRemCards.Name = "ButtonRemCards";
            this.ButtonRemCards.Size = new System.Drawing.Size(125, 25);
            this.ButtonRemCards.TabIndex = 10;
            this.ButtonRemCards.Text = "Rem Auto Cards";
            this.ButtonRemCards.UseVisualStyleBackColor = true;
            this.ButtonRemCards.Click += new System.EventHandler(this.ButtonRemCards_Click);
            // 
            // ButtonReport
            // 
            this.ButtonReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReport.Location = new System.Drawing.Point(342, 343);
            this.ButtonReport.Name = "ButtonReport";
            this.ButtonReport.Size = new System.Drawing.Size(125, 25);
            this.ButtonReport.TabIndex = 10;
            this.ButtonReport.Text = "Report Cards";
            this.ButtonReport.UseVisualStyleBackColor = true;
            this.ButtonReport.Click += new System.EventHandler(this.ButtonReport_Click);
            // 
            // CheckBoxNoDialogues
            // 
            this.CheckBoxNoDialogues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxNoDialogues.Location = new System.Drawing.Point(342, 236);
            this.CheckBoxNoDialogues.Name = "CheckBoxNoDialogues";
            this.CheckBoxNoDialogues.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxNoDialogues.TabIndex = 9;
            this.CheckBoxNoDialogues.Text = "Batch";
            this.CheckBoxNoDialogues.UseVisualStyleBackColor = true;
            this.CheckBoxNoDialogues.CheckedChanged += new System.EventHandler(this.checkBoxCards_CheckedChanged);
            // 
            // CheckBoxReplace
            // 
            this.CheckBoxReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxReplace.Checked = true;
            this.CheckBoxReplace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxReplace.Location = new System.Drawing.Point(342, 210);
            this.CheckBoxReplace.Name = "CheckBoxReplace";
            this.CheckBoxReplace.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxReplace.TabIndex = 9;
            this.CheckBoxReplace.Text = "Replace";
            this.CheckBoxReplace.UseVisualStyleBackColor = true;
            this.CheckBoxReplace.CheckedChanged += new System.EventHandler(this.checkBoxCards_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(477, 557);
            this.Controls.Add(this.ButtonReport);
            this.Controls.Add(this.ButtonRemCards);
            this.Controls.Add(this.CheckBoxReplace);
            this.Controls.Add(this.CheckBoxNoDialogues);
            this.Controls.Add(this.CheckBoxCards);
            this.Controls.Add(this.CheckBoxDebug);
            this.Controls.Add(this.CheckBoxHtml);
            this.Controls.Add(this.CheckBoxCLI);
            this.Controls.Add(this.ButtonMisc);
            this.Controls.Add(this.ButtonUpdOutline);
            this.Controls.Add(this.ButtonCheckPaths);
            this.Controls.Add(this.ButtonPython);
            this.Controls.Add(this.ButtonGenXml);
            this.Controls.Add(this.ButtonProcess);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "O2A: Select pages to process";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button ButtonProcess;
        private System.Windows.Forms.Button ButtonGenXml;
        private System.Windows.Forms.Button ButtonPython;
        private System.Windows.Forms.Button ButtonCheckPaths;
        private System.Windows.Forms.Button ButtonUpdOutline;
        private System.Windows.Forms.CheckBox CheckBoxCLI;
        private System.Windows.Forms.CheckBox CheckBoxDebug;
        private System.Windows.Forms.CheckBox CheckBoxHtml;
        private System.Windows.Forms.CheckBox CheckBoxCards;
        private System.Windows.Forms.Button ButtonMisc;
        private System.Windows.Forms.Button ButtonRemCards;
        private System.Windows.Forms.Button ButtonReport;
        private System.Windows.Forms.CheckBox CheckBoxNoDialogues;
        private System.Windows.Forms.CheckBox CheckBoxReplace;
    }
}

