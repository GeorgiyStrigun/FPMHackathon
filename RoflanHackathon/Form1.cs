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

namespace RoflanHackathon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    Teacher.ReadTeachersFromFile(Program.teachers, file);
                }
                catch (IOException)
                {
                }                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                bool successful = false;
                string file = openFileDialog1.FileName;
                try
                {
                    successful = Student.ReadStudentsFromFile(Program.groups, file);
                }
                catch (IOException)
                {
                }
                if (successful)
                {
                    listBox1.Items.Add(file);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Program.resultCollection.results.Clear();
            Program.resultCollection.Randomize(Program.teachers, Program.groups);
            foreach(var res in Program.resultCollection.results)
            {
                var row = new string[] { res.TeacherName, res.Subject, res.Group, res.StudentName, res.Points };
                var lvl = new ListViewItem(row);
                listView1.Items.Add(lvl);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    Program.resultCollection.WriteToFile(file);
                }
                catch (IOException)
                {
                }
                MessageBox.Show("Файл сохранён", "Файл сохранён");
            }
        }
    }
}
