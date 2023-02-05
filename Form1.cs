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
using System.Runtime.InteropServices; // Imports Marshal interop class

namespace OneNote2AnkiWinFormNET
{
    public partial class Form1 : Form
    {
        // Make global OneNote instance
        Microsoft.Office.Interop.OneNote.Application ONENOTE_APP = new Microsoft.Office.Interop.OneNote.Application();
        public static string USER = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile); // Needs to be static for other variables to use it
        public static string ROOT_SLN = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; // Gets parent directory of bin\debug\ folder
        public static string ROOT_EXE = System.Windows.Forms.Application.StartupPath; // Gets directory that contains exe

        public string XML_DEV = $@"{ROOT_SLN}\python_assets\data\page_xml.xml";
        public string XMLOUTLINE_DEV = $@"{ROOT_SLN}\python_assets\data\outline_xml.xml";
        public string PYTHON_DEV = $@"{USER}\.conda\envs\onenote2anki\python.exe";
        public string SCRIPT_DEV = $@"{ROOT_SLN}\python_assets\";

        // Note that CMD processes start with same directory as exe, hence don't need ROOT_EXE in these variables
        public string XML_LIVE = $@"python_assets\data\page_xml.xml";
        public string XMLOUTLINE_LIVE = $@"python_assets\data\outline_xml.xml";
        public string PYTHON_LIVE = $@"pyenv\python.exe";
        public string SCRIPT_LIVE = $@"python_assets\";


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
                    TreeNode new_node = parent_nodes.Add(child_node.Attributes["ID"].Value, child_node.Attributes["name"].Value); // Uses the ID as node "name" and the node's name (e.g., title) as the text
                    
                    addTreeViewChildNodes(new_node.Nodes, child_node); // Recursively make this node's descendants.

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
            if (CheckBoxDebug.Checked)
            { 
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV + "main.py";
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE + "main.py";
                xml_path = XML_LIVE;
            }

            string arguments = "";
            if (CheckBoxHtml.Checked)
            {
                arguments = arguments + "html ";
            }
            if (CheckBoxCards.Checked)
            {
                arguments = arguments + "add ";
            }
            bool redirect = CheckBoxCLI.Checked;

            var psi = new ProcessStartInfo
            {
                FileName = python_path,
                Arguments = $"\"{script_path}\" {arguments}", // File name should not be enclosed in brackets since it is taken literally in the file name
                UseShellExecute = false, // Can set to true to mimic local CMD behaviour - https://stackoverflow.com/questions/5255086/when-do-we-need-to-set-processstartinfo-useshellexecute-to-true
                RedirectStandardInput = redirect,
                RedirectStandardOutput = redirect,
                RedirectStandardError = redirect,
                CreateNoWindow = false
            };
            var process = new Process
            {
                StartInfo = psi,
                EnableRaisingEvents = true
            };

            process.Start();
            process.WaitForExit();

            if (CheckBoxCLI.Checked)
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

            if (!CheckBoxNoDialogues.Checked)
            {
                MessageBox.Show("Python process finished");
            }
        }

        public void genXml(bool runpy)
        {
            // Boilerplate code for switching between dev and live mode
            string python_path; // Declare variables but don't assign any values yet 
            string script_path;
            string xml_path;
            if (CheckBoxDebug.Checked)
            {
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV + "main.py";
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE + "main.py";
                xml_path = XML_LIVE;
            }

            // Tree parsing
            var ns_manager = new XmlNamespaceManager(new NameTable()); // Allows namespace search later
            ns_manager.AddNamespace("one", "http://schemas.microsoft.com/office/onenote/2013/onenote");

            List<TreeNode> selected_nodes = new List<TreeNode>();
            findCheckedNodes(selected_nodes, treeView1.Nodes);

            foreach (TreeNode node in selected_nodes)
            {
                string page_title = node.Text; // Page/section name is stored in node.Text while ID is stored as node.Name
                string page_id = node.Name;

                if (!CheckBoxNoDialogues.Checked)
                {
                    MessageBox.Show($"Found {page_title}, ID: {page_id}");
                }


                string page_xml_str = ""; // Reset the string variable, unsure if necessary 

                ONENOTE_APP.GetPageContent($"{node.Name}", out page_xml_str, PageInfo.piBinaryData); // piBinary to include binary type data
                XmlDocument page_xml_doc = new XmlDocument();
                page_xml_doc.LoadXml(page_xml_str);


                XmlElement root_node = page_xml_doc.DocumentElement;
                // XmlNodeList nodes_filtered = root_node.SelectNodes("//*[@objectID]", ns_manager); // Modify every node that has an object ID - too slow
                XmlNodeList nodes_filtered = root_node.SelectNodes("//one:Outline/one:OEChildren/one:OE", ns_manager); // ns_manager allows namespace 


                foreach (XmlNode oenode in nodes_filtered)
                {
                    string node_id = oenode.Attributes["objectID"].Value;
                    string object_link = "";
                    ONENOTE_APP.GetHyperlinkToObject(bstrHierarchyID: page_id,
                        bstrPageContentObjectID: node_id,
                        out object_link); // Note that bstrHierarchyID needs to be a page if you're passing in an ObjectID

                    XmlAttribute attr = page_xml_doc.CreateAttribute("objectLink"); //Create a new attribute
                    attr.Value = object_link;

                    oenode.Attributes.SetNamedItem(attr); //Add the attribute to the node 

                }

                page_xml_doc.Save(xml_path);

                if (runpy)
                {
                    runPython();
                }

            }

        }

        private void checkFilePaths()
        {
            // Boilerplate code for switching between dev and live mode
            string python_path; // Declare variables but don't assign any values yet 
            string script_path;
            string xml_path;
            if (CheckBoxDebug.Checked)
            {
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV + "main.py";
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE + "main.py";
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

        private void updateOutline()
        {
            // Boilerplate code for switching between dev and live mode
            string xmloutline_path;
            if (CheckBoxDebug.Checked)
            {
                xmloutline_path = XMLOUTLINE_DEV;
            }
            else
            {
                xmloutline_path = XMLOUTLINE_LIVE;
            }
            string hierarchy_str = "";
            ONENOTE_APP.GetHierarchy(null,
                Microsoft.Office.Interop.OneNote.HierarchyScope.hsPages, out hierarchy_str);
            XmlDocument hierarchy_xml_doc = new XmlDocument();
            hierarchy_xml_doc.LoadXml(hierarchy_str);
            hierarchy_xml_doc.Save(xmloutline_path);
            MessageBox.Show("Updated Outline XML");
        }
        // =============== Auto-generated functions ==========================

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            genXml(runpy: true);
        }

        private void ButtonGenXml_Click(object sender, EventArgs e)
        {
            genXml(runpy: false);
        }

        private void ButtonPython_Click(object sender, EventArgs e)
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

        private void ButtonCheckPaths_Click(object sender, EventArgs e)
        {
            checkFilePaths();
        }

        private void buttonUpdateOutline(object sender, EventArgs e)
        {
            updateOutline();
        }

        private void ButtonMisc_Click(object sender, EventArgs e)
        {
            


        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxCards_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            string python_path; // Declare variables but don't assign any values yet 
            string script_path;
            string xml_path;
            if (CheckBoxDebug.Checked)
            {
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV + "anki_api.py";
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE + "anki_api.py";
                xml_path = XML_LIVE;
            }

            string arguments = "report";

            var psi = new ProcessStartInfo
            {
                FileName = python_path,
                Arguments = $"\"{script_path}\" {arguments}", // File name should not be enclosed in brackets since it is taken literally in the file name
                UseShellExecute = false, // Can set to true to mimic local CMD behaviour - https://stackoverflow.com/questions/5255086/when-do-we-need-to-set-processstartinfo-useshellexecute-to-true
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

            var stdout = process.StandardOutput.ReadToEnd();
            MessageBox.Show(stdout);
            var stder = process.StandardError.ReadToEnd();
            MessageBox.Show(stder);
        }

        private void ButtonRemCards_Click(object sender, EventArgs e)
        {
            string python_path; // Declare variables but don't assign any values yet 
            string script_path;
            string xml_path;
            if (CheckBoxDebug.Checked)
            {
                python_path = PYTHON_DEV;
                script_path = SCRIPT_DEV + "anki_api.py";
                xml_path = XML_DEV;
            }
            else
            {
                python_path = PYTHON_LIVE;
                script_path = SCRIPT_LIVE + "anki_api.py";
                xml_path = XML_LIVE;
            }

            DialogResult dialog_result = MessageBox.Show("Removing all auto-generated cards", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialog_result == DialogResult.Yes)
            {
                string arguments = "remove";

                var psi = new ProcessStartInfo
                {
                    FileName = python_path,
                    Arguments = $"\"{script_path}\" {arguments}", // File name should not be enclosed in brackets since it is taken literally in the file name
                    UseShellExecute = false, // Can set to true to mimic local CMD behaviour - https://stackoverflow.com/questions/5255086/when-do-we-need-to-set-processstartinfo-useshellexecute-to-true
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

                var stdout = process.StandardOutput.ReadToEnd();
                MessageBox.Show(stdout);
                var stder = process.StandardError.ReadToEnd();
                MessageBox.Show(stder);
            }
            else if (dialog_result == DialogResult.No)
            {
                
            }
        }

        
    }
}
