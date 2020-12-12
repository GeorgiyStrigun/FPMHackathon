using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoflanHackathon
{
    class Result
    {
        [Name("Преподаватель")]
        public string TeacherName { get; private set; }
        [Name("Предмет")]
        public string Subject { get; private set; }
        [Name("Группа")]
        public string Group { get; private set; }
        [Name("Имя студента")]
        public string StudentName { get; private set; }
        [Name("Количество баллов")]
        public string Points { get; private set; }
        public Result(string teacherName, string subject, string group, string studentName, string points)
        {
            TeacherName = teacherName;
            Subject = subject;
            Group = group;
            StudentName = studentName;
            Points = points;
        }
    }
}
