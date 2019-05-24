using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace DBComparator.Controllers
{
    //[Authorize]

    [EnableCors(origins: "http://localhost:11559", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            string cs = "data source=B2ML29233; database= ReportServer; user id= hack1; password=sa;";
            SqlConnection con = new SqlConnection(cs);
            string q = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'ReportServer'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> a = new List<string>();
            while (dr.Read())
            {
                a.Add((dr["TABLE_NAME"]).ToString());
            }

            return a;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values
        public IEnumerable<string> GetDatabase(string serverName, string UserName, string Pass){

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


        public IEnumerable<string> GetTable(string serverName, string UserName, string Pass,string Database)
        {

            string cs = "data source=" + serverName + "; database="+ Database+"; user id=" + UserName + "; password=sa;";
            SqlConnection con = new SqlConnection(cs);
            string q= "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = "+ Database;
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> a = new List<string>();
            while (dr.Read())
            {
                a.Add((dr["TABLE_NAME"]).ToString());
            }

            return a;
        }

        public IEnumerable<string> GetTable(string serverName, string UserName, string Pass, string Database,string Table)
        {

            string cs = "data source=" + serverName + "; database=" + Database + "; user id=" + UserName + "; password=sa;";
            SqlConnection con = new SqlConnection(cs);
            string q = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = " + Database;
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> a = new List<string>();
            while (dr.Read())
            {
                a.Add((dr["TABLE_NAME"]).ToString());
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
