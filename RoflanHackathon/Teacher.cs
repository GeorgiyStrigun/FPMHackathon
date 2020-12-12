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
    class Teacher
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public string Subject { get; set; }
        [Index(2)]
        public string Group { get; set; }
        [Index(3)]
        public string PointsSet { get; set; }
        public Prize ParseToPrize()
        {
            int setsCount;
            string points;
            string[] parts = PointsSet.Split(' ');
            setsCount = int.Parse(parts[0]);
            if (parts[1] == "зачет" || parts[1] == "зачёт")
            {
                points = "зачёт";
            }
            else
            {
                points = parts[3];
            }
            return new Prize(setsCount, points);
        }
        public static bool ReadTeachersFromFile(List<Teacher> teachers, string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Teacher>();
                    teachers.Clear();
                    foreach (var r in records)
                    {
                        Teacher t = new Teacher();
                        t.Name = r.Name;
                        t.Subject = r.Subject;
                        t.Group = r.Group;
                        t.PointsSet = r.PointsSet;
                        teachers.Add(t);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Невозможно открыть файл", "Ошибка");
                return false;
            }
            return true;
        }
    }
}
