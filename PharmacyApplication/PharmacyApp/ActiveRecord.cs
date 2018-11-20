using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public abstract class ActiveRecord
    {
        public int ID { get; }
        protected SqlConnection _connection { get; set; }
        public abstract void Save();
        public abstract void Reload();
        public abstract void Remove(int x);
        
        protected void Open()
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                
                    connection.ConnectionString = "Integrated Security=SSPI;" +
                                                  "Data Source=.\\SQLEXPRESS01;" +
                                                  "Initial Catalog=PharmacyDB;";
                _connection = connection;
                _connection.Open();
                var connectState = connection.State; //zmeinna pomocnicza
                var nameOfDB = connection.Database; //zmienna pomocnicza
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void Close()
        {
            _connection.Close();
        }
    }
}
