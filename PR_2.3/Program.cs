using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Train train = new Train("Hogwarts-Express", "9¾");

            
            DiningCarriage diningCarriage = new DiningCarriage("D1", "Dining", 55, 25, 1, 10, true, 5, 100);
            FreightCarriage freightCarriage = new FreightCarriage("F2", "Freight", 60, 30, 2, 50, CargoType.Coal);
            PassengerCarriage passengerCarriage = new PassengerCarriage("P3", "Passenger", 50, 28, 3, 50, "Standard");
            SleepingCarriage sleepingCarriage = new SleepingCarriage("S4", "Sleeping", 65, 32, 4, 10, true, true);

            train.AddCarriage(diningCarriage);
            train.AddCarriage(freightCarriage);
            train.AddCarriage(passengerCarriage);
            train.AddCarriage(sleepingCarriage);

            Console.WriteLine("Hogwarts-Express готується до виїзду зі станції Кінгс-Крос \nВагони потягу:");
            
            train.PrintAllCarriagesInfo();

            Console.WriteLine("Їжа готова та подається студентам");
            Console.WriteLine("Введіть оцінку якості їжі у вагоні D1 (від 1 до 5):");
            int diningCarriageRating = int.Parse(Console.ReadLine());
            diningCarriage.EvaluateFood(diningCarriageRating);

            diningCarriage.CheckFoodStocks();

            
            Console.WriteLine("Введіть кількість пасажирів, яких ви хочете розмістити у вагоні P3:");
            int passengersCount = int.Parse(Console.ReadLine());
            passengerCarriage.AreThereFreeSeats(passengersCount);

           
            Console.WriteLine("Введіть кількість вугілля, яку потрібно завантажити у вагон F2:");
            double grainAmount = double.Parse(Console.ReadLine());
            freightCarriage.LoadUnloadCargo(grainAmount);
            Console.WriteLine("Hogwarts-Express вирушає зі станції Кінгс-Крос.");


            
            Console.WriteLine("Hogwarts-Express прибув до ст. Гогсмід");
            Console.WriteLine("Введіть кількість пасажирів, яких ви хочете висадити з вагона P3:");
            int disembarkCount = int.Parse(Console.ReadLine());
            passengerCarriage.DisembarkPassengers(disembarkCount);

           
            sleepingCarriage.CheckSleepingPeople();

           
            sleepingCarriage.CheckShowers();

            
            sleepingCarriage.CheckDoorsInCompartments();

            
            train.ChangeRouteWhileInMotion("456-Б");

            
            SleepingCarriage newSleepingCarriage = new SleepingCarriage("S5", "Sleeping", 70, 35, 5, 12, true, true);
            train.AddCarriageWhileInMotion(newSleepingCarriage, 2);

            
            train.RemoveCarriageWhileInMotion(1);

            
            IEnumerable<Carriage> passengerCarriages = train.FindCarriagesByCriteria(carriage => carriage.Type == "Passenger");
            Console.WriteLine("Вагони-пасажири:");
            foreach (var carriage in passengerCarriages)
            {
                Console.WriteLine(carriage.Id);
            }

            
            double totalWeight = train.CalculateTotalWeight();
            Console.WriteLine($"Загальна вага потягу: {totalWeight} тонн");
        }
    }
    
}
