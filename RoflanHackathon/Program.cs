using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoflanHackathon
{
    static class Program
    {
        public static List<List<Student>> groups = new List<List<Student>>();
        public static List<Teacher> teachers = new List<Teacher>();
        public static ResultCollection resultCollection = new ResultCollection();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }        
    }
}
