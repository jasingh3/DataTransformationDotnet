using System;
using System.Collections.Generic;
using System.Text;
using hotelDataProcessingApp;

namespace hotelDataProcessingNunit
{
   public static class DataIntialization
    {

        public  static  List<Hotel>  GetHotels()
        {
            var hotels = new List<Hotel>
            {
                new Hotel() {Name = "xys",Address = null, Contact = null, Phone ="12345", Stars = "4",Uri="http://www.chicagoparthenonhostel.com/"},
             new Hotel() {Name="", Address = "123,abc,789", Contact = "ytr", Phone = "+1312787654", Stars = "-9", Uri="https://www.netflix.jklm"},
                new Hotel() {Name="12345", Address = "123,abc,789", Contact = "ytr", Phone = "", Stars = "17", Uri=null}
            };

            return hotels;
        }
    }
}
