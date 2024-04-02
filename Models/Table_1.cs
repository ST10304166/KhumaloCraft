using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Web2.Models
{
    public class Table_1 : Controller
    {
        public static string con_string = "Server=tcp:stevenb.database.windows.net,1433;Initial Catalog=stevenb;Persist Security Info=False;User ID=Steven;Password=Eastarmy97;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int insert_User(Table_1 n)
        {
            string sql = "INSERT INTO userTable(userName,userSurname,Email)VALUES (@Name,@Surname,@Email)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@Name", n.Name));
            cmd.Parameters.Add(new SqlParameter("@Surname",n.Surname));
            cmd.Parameters.Add(new SqlParameter("@Email", n.Email));
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;


        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
