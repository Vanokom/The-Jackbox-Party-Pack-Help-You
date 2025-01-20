using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using IWshRuntimeLibrary;


namespace The_JackBox_Party_Pack_Help_You
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите любую версию The Jackbox Party Pack";
                openFileDialog.Filter = "Выберите любую версию (*.exe)|*.exe";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = openFileDialog.FileName;
                    string shortcutName = Path.GetFileNameWithoutExtension(targetPath) + ".lnk";
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string shortcutPath = Path.Combine(desktopPath, shortcutName);

                    CreateShortcut(shortcutPath, targetPath);
                    MessageBox.Show("Ярлык c обходом Jackbox успешно создан на рабочем столе!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CreateShortcut(string shortcutPath, string targetPath)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            shortcut.Arguments = "-jbg.config serverUrl=jb-ecast.klucva.ru";
            shortcut.Save();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Открытие сайта GitHub в браузере
                string url = "https://dl.whatif.one/";
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при открытии сайта: " + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
