using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6.Models;

namespace WebApplication6.Models
{
    public static class DataModel
    {
        private static Kitap cinali = new Kitap() { KitapAdi = "cinali", KitapTuru = "Criminal", KitapId = 1, YazarId = 1 };
        private static Kitap okkes = new Kitap() { KitapAdi = "okkes", KitapTuru = "Horror", KitapId = 2, YazarId = 2 };
        private static Yazar efe = new Yazar() { Id = 1, Name = "efe", Nation = "TC" };
        private static Yazar ali = new Yazar() { Id = 2, Nation = "USA", Name = "ali" };
        public static List<Yazar> yazarModel = new List<Yazar>() {efe,ali};
        public static List<Kitap> kitapModel = new List<Kitap>() {cinali,okkes};
    }
}