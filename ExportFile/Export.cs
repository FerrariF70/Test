using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Test.ViewModels;

namespace Test.ExportFile
{
    public class Export : IExport
    {
        /// <summary>
        /// Экспорт в формат CSV
        /// </summary>
        public async Task CSV(IList listOfCar)
        {
            FileStream fs = CreateFile("car.csv");
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"Id,NameModel,DateOfIssue,Price,");

            foreach (CarModel car in listOfCar)
            {
                await sw.WriteLineAsync($"{car.Id},{car.NameModel},{car.DateOfIssue},{car.Price}$");
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Экспорт в формат TXT
        /// </summary>
        public async Task Txt(IList listOfCar)
        {
            FileStream fs = CreateFile("car.txt");
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"Id Name Model Date Of Issue Price");

            foreach (CarModel car in listOfCar)
            {
                await sw.WriteLineAsync($"{car.Id} {car.NameModel} {car.DateOfIssue} {car.Price}$");
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Создания файла для экспорта
        /// </summary>
        private FileStream CreateFile(string file)
        {
            return File.Create(Path.Combine(Environment.CurrentDirectory, file));
        }
    }
}
