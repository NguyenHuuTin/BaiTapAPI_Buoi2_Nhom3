using _5951071106_NguyenHuuTin_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _5951071106_NguyenHuuTin_Nhom3.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*" , methods: "*")]
    public class StudentController : ApiController
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F5QFG7D\SQLEXPRESS;Initial Catalog=Nawab;User ID=sa;password=0369");
        private SqlDataAdapter adapter;
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
         // con = new SqlConnection(@"Data Source=DESKTOP-F5QFG7D\SQLEXPRESS;Initial Catalog=Nawab;User ID=sa;password=0369");
            DataTable dt = new DataTable();
            var query = "select * from Student";
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow studentRecord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecord));
                }
            }
            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
           // con = new SqlConnection(@"Data Source=DESKTOP-F5QFG7D\SQLEXPRESS;Initial Catalog=Nawab;User ID=sa;password=0369");
            DataTable dt = new DataTable();
            var query = "select * from Student where Id=" + id;
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentRecord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecord));
                }
            }
            return students;
        }

        // POST api/<controller>
        public String Post([FromBody] CreateStudent value)
        {
           // con = new SqlConnection(@"Data Source=DESKTOP-F5QFG7D\SQLEXPRESS;Initial Catalog=Nawab;User ID=sa;password=0369");
            var query = "insert into Student(f_name,m_name,l_name,address,birthDate,score) values(@f_name, @m_name, @l_name, @address, @birthDate, @score)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@f_name",value.f_name);
            cmd.Parameters.AddWithValue("@m_name",value.m_name);
            cmd.Parameters.AddWithValue("@l_name", value.l_name);
            cmd.Parameters.AddWithValue("@address", value.address);
            cmd.Parameters.AddWithValue("@birthDate", value.birthDate);
            cmd.Parameters.AddWithValue("@score", value.score);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }

        // PUT api/<controller>/5
        public String Put(int id, [FromBody] CreateStudent value)
        {
            //con = new SqlConnection(@"Data Source=DESKTOP-F5QFG7D\SQLEXPRESS;Initial Catalog=Nawab;User ID=sa;password=0369");
            var query = "update Student set f_name = @f_name, m_name = @m_name , l_name = @l_name , address = @address , birthDate = @birthDate , score = @score where Id= " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@f_name", value.f_name);
            cmd.Parameters.AddWithValue("@m_name", value.m_name);
            cmd.Parameters.AddWithValue("@l_name", value.l_name);
            cmd.Parameters.AddWithValue("@address", value.address);
            cmd.Parameters.AddWithValue("@birthDate", value.birthDate);
            cmd.Parameters.AddWithValue("@score", value.score);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }

        // DELETE api/<controller>/5
        public String Delete(int id)
        {
            //con = new SqlConnection(@"Data Source=DESKTOP-F5QFG7D\SQLEXPRESS;Initial Catalog=Nawab;User ID=sa;password=0369");
            var query = "delete from Student  where Id= " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }
    }
}