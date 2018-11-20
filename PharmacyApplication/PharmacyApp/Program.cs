using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Program Zarządzania Apteką".PadLeft(40));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Możliwe polecenia: Reload, Save, Remove, Raport, Exit, Clear");
            Console.ResetColor();
            string command = "";
           
            do
            {
                Console.Write("Podaj polecenie: ");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "reload":
                        Console.WriteLine("Zaraz zobaczysz wszystkie leki");
                        
                        ActiveRecord a = new Medicin();
                        a.Reload();
                        break;
                    case "save":
                        Console.WriteLine("Dodaj nowy lek");
                        ActiveRecord b = new Medicin();
                        b.Save();
                        break;
                    case "remove":
                        Console.WriteLine("Skasuj lek pod ID");
                        ActiveRecord c = new Medicin();
                        c.Reload();
                        Console.WriteLine("Poniżej podaj nr ID który chcesz skasować");
                        Console.Write("Podaj ID: ");
                        string x = Console.ReadLine();
                        do
                        {
                            if (Convert.ToInt32(x) is int)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Liczbę proszę");
                                x = Console.ReadLine();
                            }
                        } while (x!="exit");
                          c.Remove(Convert.ToInt32(x));
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "raport":
                        Medicin d = new Medicin();
                        d.Raport();
                        break;
                    case "exit":
                        return;
                }

            } while (true);
        }
    }
}
