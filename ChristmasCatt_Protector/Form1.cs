using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using random_Project_IdeA.Protactions;
using System.Diagnostics;

namespace random_Project_IdeA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        internal static string filepath;

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "日本書紀العالمحالعجلة林氏家族การดำน้ำดูปะการังसंस्कृतम्संस्कृतावाक्abcdeiu78ajd76的是有为也而要你可生家发如成起经abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void JunkSpam(ModuleDefMD module)
        {
            int number = System.Convert.ToInt32(Number_Of_Junk.Text);
            for (int i = 0; i < number; i++)
            {
                var junkatrb = new TypeDefUser("https://github.com/ChristmasCatt" + RandomString(20), "https://github.com/ChristmasCatt" + RandomString(20), module.CorLibTypes.Object.TypeDefOrRef);
                module.Types.Add(junkatrb);
            }
        }
        private void Protect_Click(object sender, EventArgs e)
        {
            filepath = txtOpenFile.Text;
            if (String.IsNullOrEmpty(filepath) || String.IsNullOrWhiteSpace(filepath))
            {
                MessageBox.Show("Enter valid path!", "Error!");
            }
            else
            {
                if (File.Exists(filepath))
                {


                    try
                    {
                        AssemblyDef assembly = AssemblyDef.Load(txtOpenFile.Text);
                        ModuleContext modCtx = ModuleDefMD.CreateModuleContext();
                        ModuleDefMD module = ModuleDefMD.Load(txtOpenFile.Text, modCtx);
                        string outputFile = Path.Combine(Path.GetDirectoryName(filepath), txtFileName.Text + ".exe");

                        if (CheckBox_String_Encryption.Checked)
                        {
                            Strings.Execute(module);
                        }
                        if (Int_Encoding.Checked)
                        {
                            Confusion.Execute(module);
                        }
                        if (Rename_CheckBox.Checked)
                        {
                            NameProtect.Execute(assembly, module);
                        }
                        if (Junk_CheckBox.Checked)
                        {
                            JunkSpam(module);
                        }

                        module.Write(outputFile);

                        MessageBox.Show("Protected.\nFile located at: " + outputFile, "Protected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Protection failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("File doesn't exist!", "Error!");
                }
            }
        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "Executables | *.*";
            openfiledialog.ShowDialog();
            txtOpenFile.Text = openfiledialog.FileName;
            filepath = txtOpenFile.Text;
            if (File.Exists(filepath))
            {
                if (Path.GetExtension(filepath) == ".dll")
                {
                    MessageBox.Show("DLL Loaded", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(filepath) == ".exe")
                {
                    MessageBox.Show("EXE Loaded", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CheckBox_String_Encryption_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Int_Encoding_Click(object sender, EventArgs e)
        {

        }

        private void Rename_CheckBox_Click(object sender, EventArgs e)
        {

        }

        private void Junk_CheckBox_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ChristmasCatt");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Process.Start("https://keyauth.cc/");
        }
    }
}
