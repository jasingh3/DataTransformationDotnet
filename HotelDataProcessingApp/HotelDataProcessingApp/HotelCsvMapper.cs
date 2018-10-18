
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace hotelDataProcessingApp
{
  public class HotelCsvMapper: ClassMap<Hotel>
    {
            public HotelCsvMapper()
            {
                Map(x => x.Name).Name("name").Index(0);
                Map(x => x.Address).Name("address").Index(1);
                Map(x => x.Stars).Name("stars").Index(2);
                Map(x => x.Contact).Name("contact").Index(3);
                Map(x => x.Phone).Name("phone").Index(4);
                Map(x => x.Uri).Name("uri").Index(5);
            }
       
    }
}
