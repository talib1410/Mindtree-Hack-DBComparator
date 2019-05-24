using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace DBComparator.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values
        public IEnumerable<string> Get(string serverName, string UserName, string Pass){

            string cs = "data source="+ serverName+"; database= master; user id="+ UserName+"; password=sa;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT name FROM master.dbo.sysdatabases WHERE name NOT IN('master', 'tempdb', 'model', 'msdb'); ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> a = new List<string>();
            while (dr.Read())
            {
                a.Add((dr["name"]).ToString());
            }
            
            return a;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
