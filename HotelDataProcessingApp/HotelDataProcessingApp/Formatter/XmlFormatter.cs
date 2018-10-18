using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace hotelDataProcessingApp.Formatters
{
  public  class XmlFormatter: IDataFormatter
    {
        private readonly string currentPath = Directory.GetCurrentDirectory();
        
        public void PersistResult(IEnumerable<Hotel> dataList)
        {
            var sortedDataLst = dataList.OrderBy(d => d.Stars);
            using (XmlWriter writer = XmlWriter.Create("../../../hotels.xml"))
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Hotels");

                foreach (var hotel in dataList)
                {
                    writer.WriteStartElement("Hotel");

                    writer.WriteElementString("Name", hotel.Name);
                    writer.WriteElementString("Address", hotel.Address);
                    writer.WriteElementString("Stars", hotel.Stars.ToString());
                    writer.WriteElementString("Contact", hotel.Contact);
                    writer.WriteElementString("Phone", hotel.Phone);
                    writer.WriteElementString("Uri", hotel.Uri);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
