using elektronikus_naplo;
using elektronikus_naplo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static elektronikus_naplo.ElektronikusNaploDtos;

namespace elektronikus_naplo
{
    [Route("tanulok")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Connect connect = new();
        private readonly List<ElektronikusNaploDtos> tanulok = new();


        [HttpGet]
        public ActionResult<IEnumerable<ElektronikusNaploDtos>> Get()
        {

            try
            {
                connect.connection.Open();

                string sql = "SELECT * FROM tanulok";

                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var tanulolista = new TanuloDto(
                        reader.GetGuid("Azon"),
                        reader.GetInt32("Jegy"),
                        reader.GetString("Leiras"),
                        reader.GetDateTime("Letrehozas")
                        );

                    //tanulok.Add(tanulolista); //CS1503 hiba
                }
                connect.connection.Close();

                return StatusCode(200, tanulok);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")]
        public ActionResult<ElektronikusNaploDtos> Get(Guid id)
        {

            try
            {
                connect.connection.Open();

                string sql = "SELECT * FROM tanulok WHERE Id=@Azon";

                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);

                cmd.Parameters.AddWithValue("Id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var result = new TanuloDto(
                        reader.GetGuid("Id"),
                        reader.GetInt32("Jegy"),
                        reader.GetString("Leiras"),
                        reader.GetDateTime("Letrehozas")
                        );

                    connect.connection.Close();
                    return StatusCode(200, result);
                }
                else
                {
                    Exception e = new();
                    connect.connection.Close();
                    return StatusCode(404, e.Message);
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        //JegyHozzaad
        [HttpPost]
        public ActionResult<TanuloOsztaly> Post(JegyHozzaad hozzaadJegy)
        {
            //DateTime dateTime = DateTime.Now;
            //string Time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

            var tanulo = new TanuloOsztaly
            {
                Azon = Guid.NewGuid(),
                Jegy = hozzaadJegy.Jegy,
                Leiras = hozzaadJegy.Leiras,
                Letrehozas = DateTimeOffset.Now
            };

            try
            {
                connect.connection.Open();

                string sql = $"INSERT INTO `tanulok`(`Azon`, `Jegy`, `Leiras`, `Letrehozas`) VALUES (@Azon, @Jegy,@Leiras,@Letrehozas)";


                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);

                cmd.Parameters.AddWithValue("Azon", tanulo.Azon);
                cmd.Parameters.AddWithValue("Jegy", tanulo.Jegy);
                cmd.Parameters.AddWithValue("Leiras", tanulo.Leiras);
                cmd.Parameters.AddWithValue("Letrehozas", tanulo.Letrehozas);

                cmd.ExecuteNonQuery();

                connect.connection.Close();

                return StatusCode(201, tanulo);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}