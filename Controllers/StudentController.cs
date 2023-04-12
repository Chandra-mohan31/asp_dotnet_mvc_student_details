using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication2MVC.Models;

namespace WebApplication2MVC.Controllers
{
    public class StudentController : Controller
    {
        public static List<StudentModel> list_of_students;
        public IActionResult Index()
        {
            
            try
            {
                list_of_students = new List<StudentModel>();
                string connString = "Data Source=F48DPF2;Initial Catalog=PracticeDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from StudentDetails";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StudentModel sm = new StudentModel();

                    sm.studentId = (int)reader["id"];
                    sm.studentName = (string)reader["name"];
                    list_of_students.Add(sm);
                }
                reader.Close();
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewData["list_of_students"] = list_of_students;
            return View();
        }
        public IActionResult Student()
        {
            return View();
        }
    }
}
