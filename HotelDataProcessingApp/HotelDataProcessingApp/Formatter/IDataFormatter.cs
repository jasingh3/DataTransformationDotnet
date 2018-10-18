using System;
using System.Collections.Generic;
using System.Text;

namespace hotelDataProcessingApp.Formatters
{
     interface IDataFormatter
    {
        void PersistResult(IEnumerable<Hotel> dataList);
    }
}
