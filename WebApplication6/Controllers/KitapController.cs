using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class KitapController : Controller
    {
        private static int idCreator()
        {
            if (DataModel.kitapModel.Count == 0)
            {
                return 1;
            }
            else
            {
                int a = DataModel.kitapModel.Count;
                for (int i = 1; i < 100; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        if (DataModel.kitapModel.Find(x => x.KitapId == i) == null) return i;
                    }
                }
                return 0;
            }
        }

        // GET: Kitap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KitapListele()
        {
            return PartialView(DataModel.kitapModel);
        }

        public ActionResult YazarBilgisiBlogu(int yazarid)
        {
            var writer = new KitapController().YazarBilgisi(yazarid);
            return PartialView(writer);
        }

        public Yazar YazarBilgisi(int yazarid)
        {
            Yazar writer = new YazarController().YazarBilgisiSagla(yazarid);
            return writer;
        }

        public ActionResult KitapGoruntule (int bookId)
        {
            Kitap book = DataModel.kitapModel.Find(x => x.KitapId == bookId);
            return PartialView(book);
        }

        public ActionResult KitapEkle()
        {
            return PartialView();
        }

        public ActionResult KitapSil(int id)
        {
            DataModel.kitapModel.Remove(DataModel.kitapModel.Find(x => x.KitapId == id));
            return Json(true);
        }

        public ActionResult KitapOlustur(string name, string type, int writer)
        {
            bool bas = true;
            int ID = 0;
            string Type = "";
            foreach (var m in DataModel.kitapModel)
            {
                if (m.KitapAdi==name && m.YazarId==writer)
                {
                    bas = false;
                    ID = m.KitapId;
                    break;
                }
            }
            if (bas)
            {
                DataModel.kitapModel.Add(new Kitap() { KitapId = idCreator(), KitapAdi = name, KitapTuru = type, YazarId = writer });
            }
            return Json(new {Basari = bas, Id=ID});
        }

        public ActionResult KitapGuncelle(string name, string type, int writer, int id)
        {
            bool bas=true;
            int ID = 0;
            foreach (var m in DataModel.kitapModel)
            {
                if (m.KitapAdi==name && m.KitapTuru==type && m.YazarId==writer)
                {
                    bas = false;
                    ID = m.KitapId;
                    break;
                }
            }
            if (bas)
            {
                var ch = DataModel.kitapModel.Find(x => x.KitapId == id);
                ch.KitapAdi = name;
                ch.KitapTuru = type;
                ch.YazarId = writer;
            }
            return Json(new {Basari=bas,Id=ID});
        }
    }
}