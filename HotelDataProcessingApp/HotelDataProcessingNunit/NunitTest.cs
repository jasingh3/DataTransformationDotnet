using System;
using System.Collections.Generic;
using System.Text;
using hotelDataProcessingApp;
using hotelDataProcessingApp.Data;
using hotelDataProcessingApp.Validation;
using Moq;
using NUnit.Framework;

namespace hotelDataProcessingNunit
{
    [TestFixture]
    public class NunitTest
    {
        private Mock<IDataSource> _mockDataSource;
        private HotelNameValidator _hotelNameValidator;
        private RatingValidator _ratingValidator;
        private UrlValidator _urlValidator;
        private List<Hotel> _hotels;

        [SetUp]
        public void SetParamters()
        {

            _mockDataSource = new Mock<IDataSource>();
            _mockDataSource.Setup(x => x.GetHotelList()).Returns(DataIntialization.GetHotels());

            _hotels = new List<Hotel>();
            foreach (var hotel in _mockDataSource.Object.GetHotelList())
            {
                _hotels.Add(hotel);
            }

        }

        [Test]
        public void ValidateNameTest()
        {        
            byte[] bytes = Encoding.Default.GetBytes(_hotels[0].Name);
             var  name2= Encoding.UTF8.GetString(bytes);

            _hotelNameValidator = new HotelNameValidator();
            var hotel1 = _hotelNameValidator.Validate(_hotels[0]);
            

            Assert.AreEqual(hotel1.Name,name2);
           
            Assert.AreEqual(_hotelNameValidator.Validate(_hotels[1]).Name,"");

        }

        [Test]
        public void ValidateRatingTest()
        {
            _ratingValidator=new RatingValidator();

           Assert.AreEqual(_ratingValidator.Validate(_hotels[0]).Stars,"4");
           Assert.AreEqual(_ratingValidator.Validate(_hotels[1]).Stars,"Invalid Rating");
            Assert.AreEqual(_ratingValidator.Validate(_hotels[2]).Stars, "Invalid Rating");
        }



        [Test]
        public void ValidateUrlTest()
        {
            _urlValidator = new UrlValidator();

           Assert.AreEqual(_urlValidator.Validate(_hotels[0]).Uri, _hotels[0].Uri);
           Assert.AreEqual(_urlValidator.Validate(_hotels[2]).Uri,null);
        }
    }
}
