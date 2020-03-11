using System;
using System.Collections.Generic;
using System.Linq;

namespace Musterdaten
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Customer[] customers = Service.GetCustomers();
            Order[] orders = Service.GetOrders();
            Product[] products = Service.GetProducts();

            //1.Geben Sie alle OrderIds auf der Console aus.
            orders.ToList().ForEach(x => Console.WriteLine(x.OrderID));
            Console.WriteLine(".........Aufgabe 2...........");
            //2.Geben Sie alle Customers auf der Console aus, deren Name mit H anfängt.
            List<Customer> result = customers.Where(x => x.Name.StartsWith("H")).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine(".........Aufgabe 3...........");
            //3.Geben Sie alle order Ids auf der Console aus, deren Menge > 3 ist und deren Shipped Status false ist.

            List<Order> order = orders.Where(x => x.OrderID >= 3 && x.Shipped==false).ToList();
            foreach (var item in order)
            {
                Console.WriteLine(item.OrderID);
            }
            Console.WriteLine(".........Aufgabe 4...........");

            //4.Sortieren Sie alle Bestellungen über Ihre Menge und geben Sie die  Id und die Menge aus.
            order.OrderByDescending(x => x.Quantity).ToList().ForEach(x => Console.WriteLine(x.OrderID + "     " + x.Quantity));


            Console.WriteLine(".........Aufgabe 5...........");

            //5.Gruppieren Sie alle Kunden nach Ihrem Wohnsitz und geben Sie das Ergebnis aus.
          //  customers.GroupBy(x => x.City).ToList().ForEach(x => Console.WriteLine());
            var kunde = customers.GroupBy(x => x.City).ToList();
            foreach (var item in kunde)
            {
                Console.WriteLine(" the City is : "+item.Key);
                foreach (var items in item)
                {
                    Console.WriteLine(items.Name);
                }
            }

            Console.WriteLine(".........Aufgabe 6...........");
            //6.Geben Sie alle Wohnorte der Kunden aus (keine doppelten Ausgaben!).
        
            var c = customers.Select(x => x.City).Distinct();
            foreach (var item in c)
            {
            Console.WriteLine(item);

            }



            Console.WriteLine(".........Aufgabe 7...........");
            //7.Wieviele Bestellungen hat jeweils ein Kunde aufgegeben?


            customers.ToList().ForEach(x => Console.WriteLine("Name: " + x.Name + " orders: " + x.Orders.Count()));

            Console.WriteLine(".........Aufgabe 8...........");
            //8.Geben Sie den maximalen Preis eines Produktes aus!
               
            double maxPrice = 0;
            products.ToList().ForEach(x =>
            {
                if (x.Price > maxPrice)
                    maxPrice = x.Price;
            });
            Console.WriteLine(maxPrice);

         


            Console.WriteLine(".........Aufgabe 9...........");
            //9.Geben Sie die ersten 3 Produktnamen aus!
            var productsList = products.ToList().Take(3).ToList();
            productsList.ForEach(x => Console.WriteLine(x.ProductName));


            Console.WriteLine(".........Aufgabe 10...........");
            //10.Prüfen sie ob alle Produkte mehr als 3 (Euro) kosten!
            Console.WriteLine(products.ToList().All(x => x.Price > 3));


            Console.WriteLine(".........Aufgabe 11...........");
            //11.Prüfen sie ob es ein Produkt gibt, welches mehr als 10 (Euro) kosten!
            Console.WriteLine(products.ToList().Any(x => x.Price > 10));


            Console.WriteLine(".........Aufgabe 12...........");
            //12.Geben Sie das letzte Produkt aus, welches mehr als 25 (Euro) kostet! Wenn es kein Produkt gibt, geben sie aus: "Kein Produkt kostet mehr als 25 Euro"
            Console.WriteLine(products.ToList().LastOrDefault(x => x.Price > 25));



            Console.WriteLine(".........Aufgabe 13...........");
            //13.Erzeugen Sie eine LISTE<string> mit allen Kundennamen.
            List<string> custemersNames = new List<string>();
            customers.ToList().ForEach(x => custemersNames.Add(x.Name));
            custemersNames.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(".........Aufgabe 14...........");
            // //14.Erzeugen Sie ein Array mit allen OrdersIds vom ersten Kunden.
            var firstCustomer = customers.ToList().FirstOrDefault();
            int[] firstCustomerIds = firstCustomer.Orders.Select(x => x.OrderID).ToArray();
            firstCustomerIds.ToList().ForEach(x => Console.WriteLine(x));


            Console.WriteLine(".........Aufgabe 115...........");
            //15. In den Musterdaten liegen insgesamt 16 Bestellungen vor. Es soll nun für jede Bestellung die Bestellnummer des Artikels,
            //die Bestellmenge und der Einzelpreis des Artikels ausgegeben werden.
            orders.ToList().ForEach(x => Console.WriteLine(
                "BestellNUmmer :" + x.OrderID + "  BestellMenge : " + x.Quantity + "  Preis : " +
                products.ToList().FirstOrDefault(y => y.ProductID == x.ProductID).Price.ToString()));

            Console.ReadKey();
    }
	}
}
