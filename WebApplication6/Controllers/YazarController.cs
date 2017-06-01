using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class YazarController : Controller
    {
        private static Yazar efe = new Yazar() {Id = 1, Name = "efe", Nation = "TC"};
        private static Yazar ali = new Yazar() {Id = 2, Nation = "USA", Name = "ali"};
        private static List<Yazar> yazarlar = new List<Yazar> {ali,efe};

        private static int idCreator()
        {
            if (yazarlar.Count==0)
            {
                return 1;
            }
            else
            {
                int a = yazarlar.Count;
                for (int i = 1; i < 100; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        if (yazarlar.Find(x => x.Id == i) == null) return i;
                    }
                }
                return 0;
            }

        }

        // GET: Yazar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listele()
        {
            return PartialView(yazarlar);
        }

        public ActionResult Ekle()
        {
            return PartialView();
        }

        public JsonResult Olustur(string name, string nation)
        {
            bool bas= true;
            int ID = 0;
            foreach (var m in yazarlar)
            {
                if (m.Nation==nation && m.Name==name)
                {
                    ID=m.Id;
                    bas = false;
                    break;
                }
            }
            if (bas)
            {
                Yazar writer = new Yazar() { Name = name, Id = idCreator(), Nation = nation };
                DataModel.yazarModel.Add(writer);
                yazarlar.Add(writer);
            }
            return Json(new { Basari = bas, Name = name, Nation = nation, Id = ID });
        }

        public ActionResult Goruntule(int id)
        {
            return PartialView(yazarlar.Find(x => x.Id == id));
        }

        public ActionResult Sil(int id)
        {
            yazarlar.Remove(yazarlar.Find(x => x.Id == id));
            DataModel.yazarModel.Remove(DataModel.yazarModel.Find(x => x.Id == id));
            List<Kitap> similar = DataModel.kitapModel.FindAll(x => x.YazarId == id);
            foreach (var m in similar)
            {
                DataModel.kitapModel.Remove(m);
            }
            return Json(true);
        }

        public ActionResult Degistir(int id, string name, string nation)
        {
            bool bas = true;
            int ID = 0;
            foreach (var m in yazarlar)
            {
                if (m.Nation == nation && m.Name == name)
                {
                    ID = m.Id;
                    bas = false;
                    break;
                }
            }
            if (bas)
            {
                yazarlar.Remove(yazarlar.Find(x => x.Id == id));
                DataModel.yazarModel.Remove(DataModel.yazarModel.Find(x => x.Id == id));
                Yazar writer = new Yazar() { Name = name, Id = idCreator(), Nation = nation };
                DataModel.yazarModel.Add(writer);
                yazarlar.Add(writer);
            }
            return Json(new { Basari = bas, Name = name, Nation = nation, Id = ID });
        }

        //Kitap için yazar bilgisi sağla
        public Yazar YazarBilgisiSagla(int id)
        {
            Yazar writer = yazarlar.Find(x => x.Id==id);
            return writer;
        }

    }
}