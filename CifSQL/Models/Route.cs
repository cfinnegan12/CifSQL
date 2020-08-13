using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ATCOcif;

namespace CifSQL.Models
{
    public class Route
    {
        public int Id { get; set; }
        
        [MaxLength(4)]
        public string RouteNumber { get; set; }

        public Direction Direction { get; set; }

        [MaxLength(68)]
        public string Description { get; set; }
    }
}
