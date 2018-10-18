using System;
using System.Collections.Generic;
using System.Text;

namespace hotelDataProcessingApp.Validation
{
  public  interface IValidator
    {
        Hotel Validate(Hotel instance);
    }
}
