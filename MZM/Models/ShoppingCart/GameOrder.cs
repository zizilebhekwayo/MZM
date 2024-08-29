using MZM.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MZM.Models
{
    public class GameOrder
    {
        [Key]
        public int cart_item_id { get; set; }
        public string cart_id { get; set; }
        public int item_id { get; set; }
        [Display(Name = "Quantity")]

        public int quantity { get; set; }
        public double price { get; set; }
        [Display(Name = "Meal Name")]
        public string ItemName { get; set; }
        [Display(Name = "Guest Email")]

        public string UserEmail { get; set; }

        [Display(Name = "Guest Name")]
        public string GuestName { get; set; }
        [Display(Name = "Guest Surname")]
        public string GuestSurname { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }


        public string AssistanceEmail { get; set; }
        public string AssistanceName { get; set; }

        [DataType(DataType.Time)]
        public string ApproveTime { get; set; }
        [DataType(DataType.Date)]
        public string ApproveDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime expDelDate { get; set; }
        public string addressValid { get; set; }
        public string BookRef { get; set; }

        [Display(Name = "Picture")]
        //[DataType(DataType.Upload)]
        public byte[] Picture { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; }
        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }
        [Display(Name = "Day Of Week")]
        public string DayOfWik { get; set; }

        public string OrderId { get; set; }

        [DataType(DataType.Time)]
        public string ShipTime { get; set; }
        public string StartShipTime { get; set; }
        [DataType(DataType.Date)]
        public string ShipDate { get; set; }
        public string StartShipDate { get; set; }
        public string receiverName { get; set; }

        public int DriverID { get; set; }
        public virtual Driver Driver { get; set; }
        public string dName { get; set; }
        public string dEmail { get; set; }
        public string dVehicle { get; set; }
        public string carPlate { get; set; }
        public string shipmentStatus { get; set; }
        public string shipmentByEmail { get; set; }
        public string shipmentByName { get; set; }
        public int shipmentExpDay { get; set; }

        public string ArrivalTime { get; set; }
        public string ArrivalDate { get; set; }

        public string receiveDate { get; set; }
        public string receiveTime { get; set; }
        public string receiverEmail { get; set; }

        public string EarlyLateParcel { get; set; }
        public string PaymentStatus { get; set; }
    }
}