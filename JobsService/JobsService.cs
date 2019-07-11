using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace JobsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JobsService" in both code and config file together.
    public class Converter
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
    public class JobsService : IJobsService
    {
        Jobs jobs = new Jobs();
        String constr = "server=CTSC01166866301;initial catalog=Sample1;User Id=cttdev;Password=cttdev";
        //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlDataAdapter sda;
        DataTable dt;
        public List<Jobs> OpeningJobsByRole(string role)
        {
            List<Jobs> jobs = new List<Jobs>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("select * from jobs where role="+role, con);
                con.Open();
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                jobs = (from DataRow dr in dt.Rows
                               select new Jobs()
                               {
                                   Id = Convert.ToInt32(dr["jobId"]),
                                   Role = dr["role"].ToString(),
                                   Job = dr["job"].ToString()
                                   
                               }).ToList();
                return jobs;
            }
        }

        public List<Jobs> OpeningJobs()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                
                List<Jobs> jobs = new List<Jobs>();
                SqlCommand cmd = new SqlCommand("select * from jobs", con);
                con.Open();
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                con.Close();
            jobs = (from DataRow dr in dt.Rows
                    select new Jobs()
                    {
                        Id = Convert.ToInt32(dr["jobId"]),
                        Role = dr["role"].ToString(),
                        Job = dr["job"].ToString()

                    }).ToList();
            return jobs;
            }
        }

    }
    
}
