using ApiPrueba.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public AddressController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        // GET: api/<RestauranteController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id,street,suit, city, zipcode, lat, long 
                            from address";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("baseprueba");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }


        //////////////////////////////////////////



        //ELIMINACION
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from address 
                        where id=@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("baseprueba");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        //ACTUALIZACIÓN


        [HttpPut]
        public JsonResult Put(Address emp)
        {
            string query = @"
                        update address set 
                        street =@street,
                        suit =@suit,
                        city =@city ,
                        zipcode =@zipcode ,
                        lat =@website ,
                        long =@companyId
                        where id =@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("baseprueba");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", emp.id);
                    myCommand.Parameters.AddWithValue("@street", emp.street);
                    myCommand.Parameters.AddWithValue("@suit", emp.suit);
                    myCommand.Parameters.AddWithValue("@city", emp.city);
                    myCommand.Parameters.AddWithValue("@zipcode", emp.zipcode);
                    myCommand.Parameters.AddWithValue("@lat", emp.lat);
                    myCommand.Parameters.AddWithValue("@long", emp.longi);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }


        //CREACIÓN

        [HttpPost]
        public JsonResult Post(Models.Address emp)
        {
            string query = @"
                        insert into address 
                        (username,email,addressId,phone,website,companyId) 
                        values
                         (@username,@email,@addressId,@phone,@website,@companyId);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("baseprueba");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {

                    myCommand.Parameters.AddWithValue("@street", emp.street);
                    myCommand.Parameters.AddWithValue("@suit", emp.suit);
                    myCommand.Parameters.AddWithValue("@city", emp.city);
                    myCommand.Parameters.AddWithValue("@zipcode", emp.zipcode);
                    myCommand.Parameters.AddWithValue("@lat", emp.lat);
                    myCommand.Parameters.AddWithValue("@long", emp.longi);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        
    }
}
