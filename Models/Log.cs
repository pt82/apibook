using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User { get; set; }
        public string FullDesc { get; set; }
        public DateTime Date { get; set; }
    }
}
