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
            AddTreeViewChildNodes(treeView1.Nodes, hierarchy_xml_doc.DocumentElement);
        }


        // Add the children of this XML node 
        // to this child nodes collection.
        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
                if (child_node.Attributes["ID"] != null && child_node.Attributes["name"] != null) 
                {
                    TreeNode new_node = parent_nodes.Add(child_node.Attributes["ID"].Value, child_node.Attributes["name"].Value);
                    // Recursively make this node's descendants.
                    AddTreeViewChildNodes(new_node.Nodes, child_node);

                    // If this is a leaf node, make sure it's visible.
                    //if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load required files            
            string page_path = @"C:\Users\steve\OneDrive - ualberta.ca\Coding\OneNote2AnkiWinFormNET\python_assets\export.xml"; // Placeholder for page XML export, Python scripts refer to the same directory

            // Tree parsing
            List<TreeNode> selected_nodes = new List<TreeNode>();
            FindCheckedNodes(selected_nodes, treeView1.Nodes);
            foreach (TreeNode node in selected_nodes)
            {
                MessageBox.Show($"Found {node.Text}, {node.Name}");
                String page_xml_str = ""; // Reset the string variable, unsure if necessary 
                onApplication.GetPageContent($"{node.Name}", out page_xml_str, PageInfo.piBinaryData);
                XmlDocument page_xml_doc = new XmlDocument();
                page_xml_doc.LoadXml(page_xml_str);
                page_xml_doc.Save(page_path); 
                runPython();
            }
            
            //XmlNodeList xn_list = hierarchy_xml_doc.SelectNodes($"//*[@name='{}']");
            //MessageBox.Show("Executing main Python process");
            

        }

        private void FindCheckedNodes(List<TreeNode> checked_nodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.Checked) checked_nodes.Add(node);

                // Check the node's descendants.
                FindCheckedNodes(checked_nodes, node.Nodes);
            }
        }

        public void runPython()
        {
            //MessageBox.Show("Run Script here");
            // New process
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\steve\.conda\envs\venv2\python.exe";

            // Script and arguments 
            string version = textBox1.Text;
            var script = $@"C:\Users\steve\OneDrive - ualberta.ca\Coding\OneNote2AnkiWinFormNET\main.py";
            var file_name = "Export.xml";

            psi.Arguments = $"\"{script}\" {file_name}"; // File name should not be enclosed in brackets since it is taken literally in the file name

            // Process configuration & Running
            psi.UseShellExecute = false; // For some reason, this needs to be true in order for Python script to work, maybe b/c Python program relies on Shell
            using (var process = Process.Start(psi))
            {
                process.WaitForExit();
                MessageBox.Show("Python process finished");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Load required files            
            string page_path = @"C:\Users\steve\OneDrive - ualberta.ca\Coding\OneNote2AnkiWinFormNET\python_assets\export.xml"; // Placeholder for page XML export, Python scripts refer to the same directory

            // Tree parsing
            List<TreeNode> selected_nodes = new List<TreeNode>();
            FindCheckedNodes(selected_nodes, treeView1.Nodes);
            foreach (TreeNode node in selected_nodes)
            {
                MessageBox.Show($"Found {node.Text}, {node.Name}");
                String page_xml_str = ""; // Reset the string variable, unsure if necessary 
                onApplication.GetPageContent($"{node.Name}", out page_xml_str, PageInfo.piBinaryData);
                XmlDocument page_xml_doc = new XmlDocument();
                page_xml_doc.LoadXml(page_xml_str);
                page_xml_doc.Save(page_path);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            runPython();
        }
    }
}
