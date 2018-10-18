using System;
using System.Collections.Generic;
using System.Text;

namespace hotelDataProcessingApp.Validation
{
 public   class HotelNameValidator: IValidator
    {
        public Hotel Validate(Hotel instance)
        {
            if (instance.Name != null)
            {
                instance.Name = Encoding.ASCII.GetString(
                    Encoding.Convert(
                        Encoding.UTF8,
                        Encoding.GetEncoding(
                            Encoding.ASCII.EncodingName,
                            new EncoderReplacementFallback(string.Empty),
                            new DecoderExceptionFallback()
                        ),
                        Encoding.UTF8.GetBytes(instance.Name)
                    )
                );
            }

            return instance;
        }
    }
}
