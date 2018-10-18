using System;
using System.Collections.Generic;
using System.Text;

namespace hotelDataProcessingApp.Validation
{
 public  class RatingValidator: IValidator
    {
        public Hotel Validate(Hotel instance)
        {
            if (Int32.Parse(instance.Stars) < 0 || Int32.Parse(instance.Stars) > 5 || instance.Stars == null)
            {
                instance.Stars = "Invalid Rating";
            }

            return instance;
        }
    }
}
