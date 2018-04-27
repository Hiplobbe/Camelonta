using System;
using DBHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Webb.Tests
{
    [TestClass]
    public class DbHandlerTests
    {
        [TestMethod]
        public void GetReservation()
        {
           Assert.IsNotNull(DbHandler.getReservation("26b1aa2a-027d-4a30-a164-15c9e508a48b"));
        }

        [TestMethod]
        public void CostCalculation()
        {
            Reservation reserv = new Reservation
            {
                ReservationGuid = Guid.NewGuid().ToString(),
                Type = LivingType.Apartment,
                PersonalNumber = "553322-2121",
                DateMade = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7)
            };

            Assert.IsFalse(reserv.Cost <= 0);
        }

        [TestMethod]
        public void MakeReservation()
        {   
            Reservation reserv = new Reservation
            {
                ReservationGuid = Guid.NewGuid().ToString(),
                Type = LivingType.Apartment,
                PersonalNumber = "553322-2121",
                DateMade = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7)
            };

            //Normally there would also be a "remove" method in the DbHandler that would have to run after this, as to not flood server with test data
            DbHandler.insertReservation(reserv); 
        }
    }
}
