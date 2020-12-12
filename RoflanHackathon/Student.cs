using CsvHelper;
using CsvHelper.Configuration.Attributes;
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
    class Student
    {
        [Index(0)]
        public string Group { get; set; }
        [Index(1)]
        public string Name { get; set; }
        [Index(2)]
        public int Number { get; set; }
        public static bool ReadStudentsFromFile(List<List<Student>> students, string filePath)
        {
            List<Student> studentList = new List<Student>();
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Student>();
                    studentList.Clear();
                    foreach (var r in records)
                    {
                        Student s = new Student();
                        s.Group = r.Group;
                        s.Name = r.Name;
                        s.Number = r.Number;
                        studentList.Add(s);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Невозможно открыть файл", "Ошибка");
                return false;
            }
            students.Add(studentList);
            return true;
        }
    }
}
