using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace webcrudlogin.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string username, string senha)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=database-base.cfj1bpto3ea6.us-east-1.rds.amazonaws.com; database= db_magalu; uid=biacrisg; password=Marialuiza4");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM  db_magalu.`db_magalu.usuarios` WHERE username = '{username}' AND password = '{senha}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

           
                if (await reader.ReadAsync())
                {
                    return Json(new { MSG = "Bem vindo ao magalu "});
                }

            

            return Json(new { MSG = " Erro ao logar" });

        }
    }
}
