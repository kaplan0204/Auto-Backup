using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Uroosoft_Auto_Backup.Model;

namespace Uroosoft_Auto_Backup
{
    public partial class MainForm : Form
    {
        private readonly DatabaseContext db = new DatabaseContext();
        public MainForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            db.Database.EnsureCreated();
            dataGridView1.DataSource = db.Process.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDirectoryPath.Text;
            DialogResult drResult = folderBrowserDialog1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
            {
                txtDirectoryPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDestantionPath.Text;
            DialogResult drResult = folderBrowserDialog1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
            {
                txtDestantionPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDestantionPath.Text) && !string.IsNullOrEmpty(txtDirectoryPath.Text))
            {
                Tbl_Process dd = new Tbl_Process
                {
                    ProcessDestationPath = txtDestantionPath.Text,
                    ProcessSourcePath = txtDirectoryPath.Text,
                    ProcessStatus = 1,
                    ProcessType = Convert.ToInt16(comboBox1.SelectedIndex.ToString()),
                    ProcessRunnigStartDate = dateTimePicker1.Value
                };
                db.Process.Add(dd);
                db.SaveChanges();
                dataGridView1.DataSource = db.Process.ToList();
            }
            else
            {
                MessageBox.Show("Kayıt Yapılmadı. Dizin Kontrolleri Yapınız.");
            }
        }

        private void TabSavedProcess_Click(object sender, EventArgs e)
        {
            //var aa=db.Process
            dataGridView1.DataSource = db.Process.ToList();
        }
    }
}
