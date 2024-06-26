using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_2._3
{
    public class Train
    {
        public LinkedList<Carriage> Carriages { get; private set; }
        public string Name { get; set; }
        public string RouteNumber { get; set; }

        // Конструктор класу Train
        public Train(string name, string routeNumber)
        {
            Carriages = new LinkedList<Carriage>();
            Name = name;
            RouteNumber = routeNumber;
        }

        // Метод додавання вагона до потягу
        public void AddCarriage(Carriage carriage, int? position = null)
        {
            // Якщо позиція не вказана, додаємо вагон в кінець
            if (position == null)
            {
                Carriages.AddLast(carriage);
            }
            else
            {
                // Якщо позиція вказана, знаходимо відповідний вузол і додаємо перед ним
                var node = Carriages.First;
                for (int i = 0; i < position && node != null; i++)
                {
                    node = node.Next;
                }
                if (node != null)
                {
                    Carriages.AddBefore(node, carriage);
                }
                else
                {
                    Carriages.AddLast(carriage);
                }
            }
        }

        // Метод видалення вагона з потягу
        public void RemoveCarriage(int? position = null)
        {
            // Якщо позиція не вказана, видаляємо останній вагон
            if (position == null)
            {
                Carriages.RemoveLast();
            }
            else
            {
                // Якщо позиція вказана, знаходимо відповідний вузол і видаляємо його
                var node = Carriages.First;
                for (int i = 0; i < position && node != null; i++)
                {
                    node = node.Next;
                }
                if (node != null)
                {
                    Carriages.Remove(node);
                }
            }
        }

        // Метод пошуку вагонів за критеріями
        public IEnumerable<Carriage> FindCarriagesByCriteria(Func<Carriage, bool> criteria)
        {
            // Перебираємо всі вагони і повертаємо ті, що відповідають критеріям
            foreach (var carriage in Carriages)
            {
                if (criteria(carriage))
                {
                    yield return carriage;
                }
            }
        }

        // Метод розрахунку загальної ваги потягу
        public double CalculateTotalWeight()
        {
            double totalWeight = 0;
            foreach (var carriage in Carriages)
            {
                totalWeight += carriage.Weight;
            }
            return totalWeight;
        }

        // Метод виведення інформації про всі вагони
        public void PrintAllCarriagesInfo()
        {
            foreach (var carriage in Carriages)
            {
                Console.WriteLine($"ID: {carriage.Id}, Type: {carriage.Type}, Weight: {carriage.Weight}, Length: {carriage.Length}, Number: {carriage.Number}");
            }
        }

        // Метод зміни маршруту потягу під час руху
        public void ChangeRouteWhileInMotion(string Route)
        {
            Console.WriteLine("Вкажіть маршрут");
            Route = Console.ReadLine();
            RouteNumber = Route;
            Console.WriteLine($"Маршрут потягу змінено на {Route} під час руху.");
        }

        // Метод додавання вагона до потягу під час руху
        public void AddCarriageWhileInMotion(Carriage carriage, int? position = null)
        {
            AddCarriage(carriage, position);
            Console.WriteLine("Ви впевнені, що хочете додати вагон під час руху поїзду ? (1.так 2.ні)");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("Вагон приєднано до потягу під час руху.");
            }
            else
            {
                Console.WriteLine("Вагон не було приєднано до потягу під час руху.");
            }

        }

        // Метод видалення вагона з потягу під час руху
        public void RemoveCarriageWhileInMotion(int? position = null)
        {
            RemoveCarriage(position);
            Console.WriteLine("Ви впевнені, що хочете видалити вагон під час руху поїзду ? (1.так 2.ні)");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("Вагон видалено з потягу під час руху.");
            }
            else
            {
                Console.WriteLine("Вагон не було видалено з потягу.");
            }
        }
    }
}
