using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sql_afternoon.Models
{
    public class House
    {



        public int Id { get; set; }

        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(100, double.MaxValue)]
        public double Price { get; set; }

        [Range(1855, 2022)]
        public int Year { get; set; }


    }
}