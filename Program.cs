using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Tovar[] tovars = new Tovar[n];
            for (int i=0;i<n;i++)
            
            {

                Console.WriteLine("Введите информацию о товаре");
                Console.WriteLine("Введите код товара");
                int kod = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());
                tovars[i] = new Tovar() { Kod = kod, Name = name, Price = price };


            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true

            };
            string jsonString = JsonSerializer.Serialize(tovars,options);

            using (StreamWriter sw = new StreamWriter("../../Products.json"))
            {
                sw.WriteLine (jsonString);
            }
        }
    }
}
