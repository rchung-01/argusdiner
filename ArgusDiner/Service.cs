using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Enumeration;
using System.Text;

namespace ArgusDiner
{
    public class Service
    {
        public OrderModel PlacedOrder { get; set; }


        public double Add(OrderModel orderedItems)
        {
            //deserialize json
            PlacedOrder = SaveOrder(orderedItems);

            return CalculateTotalCost(PlacedOrder);
        }
        

        private OrderModel SaveOrder(OrderModel order)
        {
            // saves no of items to existing order  
            return order;
        }

        private double CalculateTotalCost(OrderModel order)
        {
            return CalculateServiceChargeOnFood(order) + (order.NoOfDrinks * 2.00);
        }

        private static double CalculateServiceChargeOnFood(OrderModel order)
        {
            return (order.NoOfStarters * 4.00) + (order.NoOfMains * 7.00) * 1.20;
            //round to 2 decimal places
        }
        

    }
}
