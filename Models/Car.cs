using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sql_afternoon.Models
{
    public class Car
    {



        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(100, double.MaxValue)]
        public double Price { get; set; }

        [Range(1900, 2022)]
        public int Year { get; set; }


    }
}