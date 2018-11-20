using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    class Medicin:ActiveRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public decimal Price { get; set; }
        public long Amount { get; set; }
        public string WithPrescription { get; set; }


        public override void Reload()
        {
            Open();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Lista Leków".PadLeft(40));
            Console.ForegroundColor = ConsoleColor.Magenta;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * From Medicine";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;

            //List<ActiveRecord> result = new List<ActiveRecord>();
            print("ID", "Nazwa", "Firma", "Cena", "Ilość", "Recepta");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    new Medicin();
                    ID = Convert.ToInt32(reader.GetValue(0));
                    Name = reader.GetValue(1).ToString();
                    Manufacture = reader.GetValue(2).ToString();
                    Price = Convert.ToDecimal(reader.GetValue(3));
                    Amount = Convert.ToInt32(reader.GetValue(4));
                    WithPrescription = reader.GetValue(5).ToString();
                    print(ID.ToString(), Name, Manufacture, Price.ToString(), Amount.ToString(), WithPrescription);
                }
            }
            
            Console.ResetColor();
            Close();
        }

        protected void print (string id, string name, string manufacture, string price, string amount, string withPrescription)
        {
            Console.Write("|");
            Console.Write(id.PadLeft(10));
            Console.Write("|");
            Console.Write(name.PadLeft(10));
            Console.Write("|");
            Console.Write(manufacture.PadLeft(10));
            Console.Write("|");
            Console.Write(price.PadLeft(10));
            Console.Write("|");
            Console.Write(amount.PadLeft(10));
            Console.Write("|");
            Console.Write(withPrescription.PadLeft(15));
            Console.WriteLine("|");
            Console.WriteLine("".PadLeft(72, '-'));
        }

        public override void Save()
        {
            Open();
            Console.ForegroundColor = ConsoleColor.Magenta;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Medicine (Name, Manufacture, Price, Amount, WithPrescription) VALUES (@Name, @Manufacture, @Price, @Amount, @WithPrescription)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;

            Console.Write("Nazwa: ");
            Name = Console.ReadLine();
            SqlParameter sqlParameterName = new SqlParameter()
            {
                ParameterName = "@Name",
                Value = Name,
                DbType = DbType.String
            };
            cmd.Parameters.Add(sqlParameterName);

            Console.Write("Producent: ");
            Manufacture = Console.ReadLine();
            SqlParameter sqlParameterManufactures = new SqlParameter()
            {
                ParameterName = "@Manufacture",
                Value = Manufacture,
                DbType = DbType.String
            };
            cmd.Parameters.Add(sqlParameterManufactures);

            Console.Write("Cena: ");
            Price = Convert.ToDecimal(Console.ReadLine());
            SqlParameter sqlParameterPrice = new SqlParameter()
            {
                ParameterName = "@Price",
                Value = Price,
                DbType = DbType.Decimal
            };
            cmd.Parameters.Add(sqlParameterPrice);

            Console.Write("Liczba: ");
            Amount = Convert.ToInt64(Console.ReadLine());
            SqlParameter sqlParameterAmount = new SqlParameter()
            {
                ParameterName = "@Amount",
                Value = Amount,
                DbType = DbType.Int64
            };
            cmd.Parameters.Add(sqlParameterAmount);

            Console.Write("WithPrescription: ");
            WithPrescription = Console.ReadLine();
            SqlParameter sqlParameterWithPrescription = new SqlParameter()
            {
                ParameterName = "@WithPrescription",
                Value = WithPrescription,
                DbType = DbType.String
            };
            cmd.Parameters.Add(sqlParameterWithPrescription);
            cmd.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dodałeś nowy rekord");
            Console.ResetColor();
            Close();
        }
        
        public override void Remove(int id)
        {
            Open();
            
            Console.ForegroundColor = ConsoleColor.Red;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete FROM  Medicine WHERE ID = @id";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;

            SqlParameter sqlParameterCity = new SqlParameter();
            sqlParameterCity.ParameterName = "@id";
            sqlParameterCity.Value = id;
            sqlParameterCity.DbType = DbType.String;
            cmd.Parameters.Add(sqlParameterCity);
            Console.Write("Jesteś tego pewny?[T/N]: ");
            string c = Console.ReadLine();
            if (c.ToLower()=="t")
            {
              cmd.ExecuteNonQuery();
            }
            Console.ResetColor();
            Close();
        }

        public void Raport()
        {
            Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * From View_MedicinInMonth";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string content = $"{reader.GetValue(0)}, {reader.GetValue(1)}";
                    File.AppendAllText("Raport.txt", content+Environment.NewLine);
                }
            }
            
            Console.ResetColor();
            Close();
        }

    }
}
