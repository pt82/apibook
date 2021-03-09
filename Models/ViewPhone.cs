using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class ViewPhone
    {
        public int Id { get; set; }
        public string Num { get; set; }
        public int ContactId { get; set; }
        public int Phone_typeId { get; set; }
        public string Type { get; set; }
     
    }
}
