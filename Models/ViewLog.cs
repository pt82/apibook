using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class ViewLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string login { get; set; }
        public string FullDesc { get; set; }
        public DateTime Date { get; set; }
    }
}
