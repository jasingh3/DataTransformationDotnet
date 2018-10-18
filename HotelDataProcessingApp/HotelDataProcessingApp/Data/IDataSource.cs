using System;
using System.Collections.Generic;

namespace hotelDataProcessingApp.Data
{
   public  interface IDataSource : IDisposable
    {
        IEnumerable<Hotel> GetHotelList();
    }
}