using System;
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
        Microsoft.Office.Interop.OneNote.Application onApplication = new Microsoft.Office.Interop.OneNote.Application();
        public string XML_PATH = @"C:\Users\steve\OneDrive - ualberta.ca\Coding\OneNote2AnkiWinFormNET\python_assets\export.xml";
        public string PYTHON = @"C:\Users\steve\.conda\envs\onenote2anki\python.exe";
        public string SCRIPT = $@"C:\Users\steve\OneDrive - ualberta.ca\Coding\OneNote2AnkiWinFormNET\python_assets\main.py"; // -u Parameter to redirect stream


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // Load XML hierarchy
            string hierarchy_str = "";
            onApplication.GetHierarchy(null,
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
            var psi = new ProcessStartInfo
            {
                FileName = PYTHON,
                Arguments = $"\"{SCRIPT}\"", // File name should not be enclosed in brackets since it is taken literally in the file name
                UseShellExecute = false, // For some reason, this needs to be true in order for Python script to work, maybe b/c Python program relies on Shell
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            };
            var process = new Process
            {
                //MessageBox.Show("Run Script here");
                // New process & configuration
                StartInfo = psi,
                EnableRaisingEvents = true
            };

            process.Start();
            //process.BeginErrorReadLine(); // Asynchronous methods
            //process.BeginOutputReadLine();
            process.WaitForExit();

            string args = textBox1.Text;
            if (args.IndexOf("debug") >= 0) // Searchs for debug argument
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
            // Tree parsing
            List<TreeNode> selected_nodes = new List<TreeNode>();
            findCheckedNodes(selected_nodes, treeView1.Nodes);
            foreach (TreeNode node in selected_nodes)
            {
                MessageBox.Show($"Found {node.Text}, {node.Name}");
                string page_xml_str = ""; // Reset the string variable, unsure if necessary 
                onApplication.GetPageContent($"{node.Name}", out page_xml_str, PageInfo.piBinaryData); //    piBinary to include binary type data
                XmlDocument page_xml_doc = new XmlDocument();
                page_xml_doc.LoadXml(page_xml_str);
                page_xml_doc.Save(XML_PATH);
                if (runpy)
                {
                    runPython();
                }
            }

            //XmlNodeList xn_list = hierarchy_xml_doc.SelectNodes($"//*[@name='{}']");

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


    }
}
