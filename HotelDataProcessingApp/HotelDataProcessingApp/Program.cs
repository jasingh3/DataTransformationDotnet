using hotelDataProcessingApp;
using hotelDataProcessingApp.Data;
using hotelDataProcessingApp.Formatters;
using hotelDataProcessingApp.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataProcessingApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            var validators = new List<IValidator>() { new HotelNameValidator(), new RatingValidator(), new UrlValidator() };
            var dataFormatters = new List<IDataFormatter>() { new JsonFormatter(), new XmlFormatter() };

            string currentPath = Directory.GetCurrentDirectory();

            List<Hotel> _hotelModel = new List<Hotel>();          

            using (IDataSource dataSource = new CsvDataSource())
            {
                foreach (var record in dataSource.GetHotelList())
                {
                    foreach (var validator in validators)
                    {
                        validator.Validate(record);
                    }

                    _hotelModel.Add(record);
                }
            }

            foreach (var formatter in dataFormatters)
            {
                formatter.PersistResult(_hotelModel);
            }

            Console.Write("Data Prscd");
        }
    }
}
