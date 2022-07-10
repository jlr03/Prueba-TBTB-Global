using ApiRestauranteJuventic.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public WorkerController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        // GET: api/<RestauranteController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id,username,email, addressId, phone, website, companyId 
                            from worker";

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
                        delete from worker 
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
        public JsonResult Put(Worker emp)
        {
            string query = @"
                        update worker set 
                        username =@username,
                        email =@email,
                        addressId =@addressId ,
                        phone =@phone ,
                        website =@website ,
                        companyId =@companyId
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
                    myCommand.Parameters.AddWithValue("@username", emp.username);
                    myCommand.Parameters.AddWithValue("@email", emp.email);
                    myCommand.Parameters.AddWithValue("@addressId", emp.addressId);
                    myCommand.Parameters.AddWithValue("@phone", emp.phone);
                    myCommand.Parameters.AddWithValue("@website", emp.website);
                    myCommand.Parameters.AddWithValue("@companyId", emp.companyId);


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
        public JsonResult Post(Models.Worker emp)
        {
            string query = @"
                        insert into worker 
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
                    
                    myCommand.Parameters.AddWithValue("@username", emp.username);
                    myCommand.Parameters.AddWithValue("@email", emp.email);
                    myCommand.Parameters.AddWithValue("@addressId", emp.addressId);
                    myCommand.Parameters.AddWithValue("@phone", emp.phone);
                    myCommand.Parameters.AddWithValue("@website", emp.website);
                    myCommand.Parameters.AddWithValue("@companyId", emp.companyId);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        /*
        [HttpPut]
        public JsonResult Put(Plato plato)
        {
            string query = @"
                        update plato set 
                        nombre=@nombre,
                        precio=@precio,
                        descripcion=@descripcion,
                        descripcion_larga=@descripcion_larga,
                        img=@img,
                        img2=@img2
                        where id =@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("basejuventic");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", plato.id);
                    myCommand.Parameters.AddWithValue("@nombre", plato.nombre);
                    myCommand.Parameters.AddWithValue("@precio", plato.precio);
                    myCommand.Parameters.AddWithValue("@descripcion", plato.descripcion);
                    myCommand.Parameters.AddWithValue("@descripcion_larga", plato.descripcion_larga);
                    myCommand.Parameters.AddWithValue("@img", plato.img);
                    myCommand.Parameters.AddWithValue("@img2", plato.img2);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }
        */
    }
}
