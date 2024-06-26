using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_2._3
{
    public class FreightCarriage : Carriage
    {
        public double MaxLoadCapacity { get; set; }
        public CargoType CargoType { get; set; }

        public FreightCarriage(string id, string type, double weight, double length, int number, double maxLoadCapacity, CargoType cargoType)
            : base(id, type, weight, length, number)
        {
            MaxLoadCapacity = maxLoadCapacity;
            CargoType = cargoType;
        }

        
        public void LoadUnloadCargo(double amount)
        {
            if (amount > 0)
            {
                if (amount <= MaxLoadCapacity)
                {                   
                    Console.WriteLine($"Вагон {Id} завантажено на {amount} одиниць {CargoType}.");
                }
                else
                {    
                    Console.WriteLine($"Вагон {Id} не може бути завантажений на {amount} одиниць {CargoType}. Перевищено максимальну вантажопідйомність ({MaxLoadCapacity}).");
                }
            }
            else if (amount < 0)
            {
                Console.WriteLine($"З вагона {Id} розвантажено {-amount} одиниць {CargoType}.");
            }
            else
            {
                Console.WriteLine("Необхідно вказати ненульову кількість вантажу.");
            }
        }
    }

    public enum CargoType
    {
        Grain,
        Coal,
        Wood,
        Metal,
        Oil
    }
}


