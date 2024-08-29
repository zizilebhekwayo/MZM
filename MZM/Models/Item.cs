using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MZM.Models
{
    public class Item
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCode { get; set; }
        [Required]
        [ForeignKey("Department")]
        [Display(Name = "Category")]
        public int Department_ID { get; set; }

        public DateTime MyDate { get; set; }

        public string CurrentDate { get; set; }
        public string CurrentTime { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime CurrentDate { get; set; }

        public string Posted { get; set; }

        public string ReadingTime { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MinLength(3)]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [MinLength(3)]

        public string Description { get; set; }
        //[Display(Name = "Qty in Stock")]
        //public int QuantityInStock { get; set; }

        //[Required]
        [Display(Name = "Picture")]
        //[DataType(DataType.Upload)]
        public byte[] Picture { get; set; }

        public string SalesEmail { get; set; }
        public string SalesName { get; set; }

        [DataType(DataType.Time)]
        public string ApproveTime { get; set; }
        [DataType(DataType.Date)]
        public string ApproveDate { get; set; }

        public DateTime Date { get; set; }

        public DateTime Post { get; set; }

        public virtual Department Department { get; set; }

    }
}