﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MZM.Models
{
    public class Cart_Item
    {
        [Key]
        public string cart_item_id { get; set; }
        [ForeignKey("Cart")]
        public string cart_id { get; set; }
        [ForeignKey("Item")]
        public int item_id { get; set; }
        public int quantity { get; set; }
        [DataType(DataType.Currency)]
        public double price { get; set; }

        public virtual Item Item { get; set; }


        public virtual Cart Cart { get; set; }

        public string UserEmail { get; set; }

        public int? OrderId { get; set; }
    }
}