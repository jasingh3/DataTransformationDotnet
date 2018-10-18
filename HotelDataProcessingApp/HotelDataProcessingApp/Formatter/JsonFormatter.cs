using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace hotelDataProcessingApp.Formatters
{
   public  class JsonFormatter: IDataFormatter
    {
        private readonly string currentPath = Directory.GetCurrentDirectory();

        public void PersistResult(IEnumerable<Hotel> dataList)
        {
            var sortedDataLst = dataList.OrderBy(d=>d.Stars);
            string jsonData = JsonConvert.SerializeObject(sortedDataLst, Newtonsoft.Json.Formatting.None);
            System.IO.File.WriteAllText( "../../../hotel.json", jsonData);
        }
    }
}
