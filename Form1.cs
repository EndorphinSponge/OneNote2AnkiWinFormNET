﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using Microsoft.Office.Interop.OneNote;

namespace OneNote2AnkiWinFormNET
{
    public partial class Form1 : Form
    {
        // Make global OneNote instance
        Microsoft.Office.Interop.OneNote.Application ONENOTE_APP = new Microsoft.Office.Interop.OneNote.Application();
        public static string USER = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile); // Needs to be static for other variables to use it
        public static string ROOT_SLN = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; // Gets parent directory of bin\debug\ folder
        public static string ROOT_EXE = System.Windows.Forms.Application.StartupPath; // Gets directory that contains exe

        public string XML_DEV = $@"{ROOT_SLN}\python_assets\export.xml";
        public string PYTHON_DEV = $@"{USER}\.conda\envs\onenote2anki\python.exe";
        public string SCRIPT_DEV = $@"{ROOT_SLN}\python_assets\main.py";

        public string XML_LIVE = $@"{ROOT_EXE}\python_assets\export.xml";
        public string PYTHON_LIVE = $@"{ROOT_EXE}\pyenv\python.exe";
        public string SCRIPT_LIVE = $@"{ROOT_EXE}\python_assets\main.py";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // Load XML hierarchy
            string hierarchy_str = "";
            ONENOTE_APP.GetHierarchy(null,
                Microsoft.Office.Interop.OneNote.HierarchyScope.hsPages, out hierarchy_str);
            XmlDocument hierarchy_xml_doc = new XmlDocument();
            hierarchy_xml_doc.LoadXml(hierarchy_str);


            // Add the root node's children to the TreeView.
            treeView1.Nodes.Clear();
            addTreeViewChildNodes(treeView1.Nodes, hierarchy_xml_doc.DocumentElement);
        }

        // =============== Custom functions ==========================
        // Add the children of this XML node to this child nodes collection.
        private void addTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
                if (child_node.Attributes["ID"] != null && child_node.Attributes["name"] != null) 
                {
                    TreeNode new_node = parent_nodes.Add(child_node.Attributes["ID"].Value, child_node.Attributes["name"].Value);
                    // Recursively make this node's descendants.
                    addTreeViewChildNodes(new_node.Nodes, child_node);

                    // If this is a leaf node, make sure it's visible.
                    //if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
                }

            }
        }

        private void findCheckedNodes(List<TreeNode> checked_nodes, TreeNodeCollection nodes)
        {
            // Modifies checked_nodes object that is passed in as argument
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.Checked) checked_nodes.Add(node);

                // Check the node's descendants.
                findCheckedNodes(checked_nodes, node.Nodes);
            }
        }

        public void runPython()
        {
            // Boilerplate code for switching between dev and live mode
            string python_path; // Declare variables but don't assign any values yet 
            string script_path;
            string xml_path;
            if (checkBoxDebug.Checked)
            { 
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV;
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE;
                xml_path = XML_LIVE;
            }

            var psi = new ProcessStartInfo
            {
                FileName = python_path,
                Arguments = $"\"{script_path}\"", // File name should not be enclosed in brackets since it is taken literally in the file name
                UseShellExecute = false, // For some reason, this needs to be true in order for Python script to work, maybe b/c Python program relies on Shell
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            };
            var process = new Process
            {
                StartInfo = psi,
                EnableRaisingEvents = true
            };

            process.Start();
            process.WaitForExit();

            if (checkBoxCLI.Checked)
            {
                // Redirect output for debugging:
                // https://www.mathworks.com/matlabcentral/answers/586706-how-to-redirect-standard-input-and-standard-output-using-net-system-diagnostics-process
                var stdin = process.StandardInput.ToString();
                MessageBox.Show(stdin);
                var stdout = process.StandardOutput.ReadToEnd();
                MessageBox.Show(stdout);
                var stder = process.StandardError.ReadToEnd();
                MessageBox.Show(stder);
            }
            MessageBox.Show("Python process finished");
        }

        public void genXml(bool runpy)
        {
            // Boilerplate code for switching between dev and live mode
            string python_path; // Declare variables but don't assign any values yet 
            string script_path;
            string xml_path;
            if (checkBoxDebug.Checked)
            {
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV;
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE;
                xml_path = XML_LIVE;
            }
            // Tree parsing
            List<TreeNode> selected_nodes = new List<TreeNode>();
            findCheckedNodes(selected_nodes, treeView1.Nodes);
            foreach (TreeNode node in selected_nodes)
            {
                MessageBox.Show($"Found {node.Text}, {node.Name}");
                string page_xml_str = ""; // Reset the string variable, unsure if necessary 
                ONENOTE_APP.GetPageContent($"{node.Name}", out page_xml_str, PageInfo.piBinaryData); //    piBinary to include binary type data
                XmlDocument page_xml_doc = new XmlDocument();
                page_xml_doc.LoadXml(page_xml_str);
                page_xml_doc.Save(xml_path);
                if (runpy)
                {
                    runPython();
                }
            }

            //XmlNodeList xn_list = hierarchy_xml_doc.SelectNodes($"//*[@name='{}']");

        }

        private void checkFilePaths()
        {
            // Boilerplate code for switching between dev and live mode
            string python_path; // Declare variables but don't assign any values yet 
            string script_path;
            string xml_path;
            if (checkBoxDebug.Checked)
            {
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV;
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE;
                xml_path = XML_LIVE;
            }

            if (File.Exists(python_path))
            {
                MessageBox.Show("Required Python interpreter exists");
            }
            else
            {
                MessageBox.Show("Required Python interpreter not found");
            }
            if (File.Exists(script_path))
            {
                MessageBox.Show("Required Python script exists");
            }
            else
            {
                MessageBox.Show("Required Python script not found");
            }
            if (File.Exists(xml_path))
            {
                MessageBox.Show("XML already exists at xml_path");
            }
            else
            {
                MessageBox.Show("xml_path has no file");
            }
        }


        // =============== Auto-generated functions ==========================

        private void processPage(object sender, EventArgs e)
        {
            genXml(runpy: true);
        }

        private void genXmlOnly(object sender, EventArgs e)
        {
            genXml(runpy: false);
        }

        private void runPythonOnly(object sender, EventArgs e)
        {
            runPython();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkFilePaths();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ROOT_SLN);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}