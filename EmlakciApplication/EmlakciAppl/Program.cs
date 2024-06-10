using HouseLib;
namespace EmlakciAppl
{
    internal class Program
    {
        static List<House> allHouses = new List<House>();
        static List<RentalHouse> rentallists = new List<RentalHouse>();
        static List<SaleHouse> salelists = new List<SaleHouse>();
        static void Main(string[] args)
        {
            Boolean loop = true;
            do
            {
                
                Console.WriteLine("Do you want Rental or Sale House?");
                Console.WriteLine("-------");
                Console.WriteLine("1.Rental house");
                Console.WriteLine("2.Sale house");
                int pick = int.Parse(Console.ReadLine());
                if (pick == 1)
                {
                    RentalMenu();
                }
                else if(pick == 2)
                {
                    SaleMenu();
                }                
                else
                {
                    Console.WriteLine("Please just 1 or 2");
                }
                Console.WriteLine("Done or Keep?");
                string secpick = Console.ReadLine().ToLower().Trim();
                if (secpick == "done")
                {
                    Console.WriteLine("Successfuly Saved.");
                    loop = false;
                }

            } while (loop);
        }
        static void RentalMenu()
        {
            Console.WriteLine("1.Add new Rental house");
            Console.WriteLine("2.Show registered houses");
            Console.WriteLine("-------");
            int pick = int.Parse(Console.ReadLine());
            if (pick == 1) 
            {
                AddRental();
            }
            else if (pick == 2)
            {
                ShowRegist(@"C:\Users\Erol Can\Desktop\RH.txt");
            }
        }
        static void SaleMenu()
        {
            Console.WriteLine("1.Add new Sale house");
            Console.WriteLine("2.Show registered houses");
            int pick = int.Parse(Console.ReadLine());
            if (pick == 1)
            {
                AddSale();
            }
            else if (pick == 2)
            {
                ShowRegist(@"C:\Users\Erol Can\Desktop\SH.txt");
            }
        }
        static void AddRental()
        {
            RentalHouse rentalHouse = HFeatures<RentalHouse>();
            rentallists.Add(rentalHouse);
            allHouses.Add(rentalHouse);
            Save(rentallists,"RH.txt");
        }
        static void AddSale()
        {
            SaleHouse saleHouse = HFeatures<SaleHouse>();
            salelists.Add(saleHouse);
            allHouses.Add(saleHouse);
            Save(salelists,"SH.txt");
        }

        static T HFeatures<T>() where T : House ,new()
        {
            T house = new T();
            Console.Write("Area of the house:");
            house.Area = int.Parse(Console.ReadLine());
            Console.Write("How many rooms:");
            house.RoomNumber = int.Parse(Console.ReadLine());
            Console.Write("Floor number:");
            house.FloorNo = int.Parse(Console.ReadLine());
            Console.Write("District:");
            house.District = Console.ReadLine();

            if (house is RentalHouse)
            {
                Console.Write("Rent:");
                (house as RentalHouse).Rent = double.Parse(Console.ReadLine());
                Console.Write("Deposit:");
                (house as RentalHouse).Deposit = int.Parse(Console.ReadLine());
            }
            else if (house is SaleHouse)
            {
                Console.Write("Price:");
                (house as SaleHouse).Price = long.Parse(Console.ReadLine());
            }
            return house;
        }

        static void ShowRegist(string filename)
        {
            if(File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach(string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("There is no registered house.");
            }
        }

        static void Save<T>(List<T> lists,string filename) where T: House
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath = Path.Combine(path, filename);
            StreamWriter file = new StreamWriter(filepath,true);
            foreach (var list in  lists)
            {
                file.WriteLine(list.ToString());
                file.WriteLine();
            }
            file.Close();
        }

            

    }
}
