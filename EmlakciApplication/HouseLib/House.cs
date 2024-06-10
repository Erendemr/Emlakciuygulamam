using System;

namespace HouseLib
{
    public class House
    {
        public int Area { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNo { get; set; }
        public string District { get; set; }

        public override string ToString()
        {
            return $"Area of the house:{Area}\n How many rooms:{RoomNumber}\nFloor number:{FloorNo}\nDistrict:{District}";
        }
    }
    public class RentalHouse : House
    {
        public double Rent { get; set; }
        public int Deposit { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nRent:{Rent}\nDeposit:{Deposit}";
        }
    }
    public class SaleHouse : House
    {
        public long Price { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nPrice:{Price}";
        }
    }
}
