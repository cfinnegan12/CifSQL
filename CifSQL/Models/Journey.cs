using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CifSQL.Models
{
    public class Journey
    {

        public int Id { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }
        public bool BankHolidays { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public ICollection<Stop> Stops { get; set; }

    }
}
