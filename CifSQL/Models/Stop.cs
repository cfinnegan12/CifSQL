using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CifSQL.Models
{
    public class Stop
    {

        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location{ get; set; }

        [Column(TypeName ="time(0)")]
        public TimeSpan Time { get; set; }
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
    }
}
