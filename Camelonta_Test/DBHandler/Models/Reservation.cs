using System;
using System.Collections.Generic;
using System.Text;

namespace DBHandler
{
    public class Reservation
    {
        private const int _baseDayFee = 200; //Could also be set in config file

        public string ReservationGuid { get; set; }
        public LivingType Type { get; set; }   
        public string PersonalNumber { get; set; }
        public double Cost { get { return CalculateCost(); } }   
        public DateTime DateMade { get; set; }
        public DateTime EndDate { get; set; }

        private double CalculateCost()
        {
            double NumberofDays = (DateMade - EndDate).TotalDays;

            switch(Type)
            {
                case LivingType.Apartment:
                    return _baseDayFee * NumberofDays;
                case LivingType.Bungalow:
                    return _baseDayFee * NumberofDays * 1.5;
                case LivingType.Villa:
                    return _baseDayFee * NumberofDays * 2.5;
            }

            //Log here
            throw new Exception("Unable to calculate cost");
        }
    }

    public enum LivingType
    {
        Apartment,
        Bungalow,
        Villa
    }
}
