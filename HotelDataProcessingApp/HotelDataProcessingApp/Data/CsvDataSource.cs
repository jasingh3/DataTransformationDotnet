using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;

namespace hotelDataProcessingApp.Data
{
   public class CsvDataSource : IDataSource, IDisposable
    {
        private CsvReader csv;
        private TextReader reader;

        public IEnumerable<Hotel> GetHotelList()
        {
            try
            {
                reader = new StreamReader("../../../hotels.csv");
                csv = new CsvReader(reader);
                csv.Configuration.Encoding = Encoding.UTF8;
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<HotelCsvMapper>();

                return csv.GetRecords<Hotel>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
    
        }

        public void Dispose()
        {
            csv?.Dispose();
            reader?.Dispose();
        }
    }
}
