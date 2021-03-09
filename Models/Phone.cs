using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Num { get; set; }
      
        public int ContactId { get; set; }      // внешний ключ
        public Contact Contact { get; set; }
        public int Phone_typeId { get; set; }      // внешний ключ
        public Phonetype phone_Type { get; set; }

    }
}
