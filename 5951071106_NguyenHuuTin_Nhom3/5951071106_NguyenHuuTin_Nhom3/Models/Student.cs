using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _5951071106_NguyenHuuTin_Nhom3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public String f_name { get; set; }
        public String m_name { get; set; }
        public String l_name { get; set; }
        public String address { get; set; }
        public String birthDate { get; set; }
        public String score { get; set; }
        public String dep_id { get; set; }
    }
    public class ReadStudent : Student
    {
        public ReadStudent(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            f_name = row["f_name"].ToString();
            m_name = row["m_name"].ToString();
            l_name = row["l_name"].ToString();
            address = row["address"].ToString();
            birthDate = row["birthDate"].ToString();
            score = row["score"].ToString();
        }
        
    }
    public class CreateStudent : Student
    {

    }

}