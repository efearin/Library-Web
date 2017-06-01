using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Kitap
    {
        public string KitapAdi { get; set; }
        public int KitapId { get; set; }
        public string KitapTuru { get; set; }
        public int YazarId { get; set; }
    }


}