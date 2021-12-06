using System;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods = new List<IBakedFood>();
        private List<IDrink> drinks = new List<IDrink>();
        private List<ITable> tables = new List<ITable>();
        private decimal total = 0;

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = default;

            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            else if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }
            
            bakedFoods.Add(food);
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = default;

            if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }
            else if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }

            drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = default;

            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = tables.FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);

            if (freeTable is null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            freeTable.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var targetTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var targetFood = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (targetTable is null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (targetFood is null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            targetTable.OrderFood(targetFood);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var targetTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var targetDrink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (targetTable is null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (targetDrink is null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            targetTable.OrderDrink(targetDrink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var targetTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = targetTable.GetBill() + targetTable.Price;
            total += bill;
            targetTable.Clear();

            return $"Table: {tableNumber}{Environment.NewLine}" +
                   $"Bill: {bill}";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(table => !table.IsReserved).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, total);
        }
    }
}