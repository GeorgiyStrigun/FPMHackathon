using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoflanHackathon
{
    class ResultCollection
    {
        public List<Result> results = new List<Result>();

        public List<Result> Randomize(List<Teacher> teachers, List<List<Student>> groups)
        {
            Dictionary<Teacher, Student> dict = new Dictionary<Teacher, Student>();
            List<int> res = new List<int>();
            Random rand = new Random();
            foreach (var students in groups)
            {
                for (int i = 0; i < teachers.Count; i++)
                {
                    if (teachers[i].Group == students[0].Group)
                    {
                        for (int j = 0; j < teachers[i].ParseToPrize().SetsCount; j++)
                        {
                            int temp = rand.Next(1, students.Count);
                            bool alredyContains = false;
                            foreach (var sd in results)
                            {
                                if (sd.StudentName == students[temp].Name && sd.Subject == teachers[i].Subject) alredyContains = true;
                            }
                            if (!res.Contains(temp) && !alredyContains)
                            {
                                res.Add(temp);
                            }
                            else
                            {
                                j--;
                            }
                        }
                        foreach (var k in res)
                        {
                            results.Add(new Result(teachers[i].Name, teachers[i].Subject, teachers[i].Group, students[k].Name, teachers[i].ParseToPrize().Points));
                        }
                        res.Clear();
                    }
                }
            }
            return results;
        }
        public bool WriteToFile(string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(results);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
