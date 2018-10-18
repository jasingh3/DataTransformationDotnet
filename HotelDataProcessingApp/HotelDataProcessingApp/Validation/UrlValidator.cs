using System;
using System.Collections.Generic;
using System.Text;

namespace hotelDataProcessingApp.Validation
{
  public  class UrlValidator: IValidator
    {
        public Hotel Validate(Hotel instance)
        {
            if (instance.Uri == null)
            {
                return instance;
            }

            if (Uri.IsWellFormedUriString(instance.Uri, UriKind.RelativeOrAbsolute))
            {
                instance.Uri = "Not a valid Uri";
            }

            return instance;
        }
    }
}
