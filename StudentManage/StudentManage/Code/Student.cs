using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStudent.Code
{
    /// <summary>
    /// 学生模型
    /// </summary>
    public class Student
    {
        public string StudentNo { get; set; }
        public string StudentName { get; set; }
        public string Sex { get; set; }
        public string Class { get; set; }
        public string Birthday { get; set; }

    }
}