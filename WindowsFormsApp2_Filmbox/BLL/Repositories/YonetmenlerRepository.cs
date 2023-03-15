using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class YonetmenlerRepository
    {
        FilmboxEntities1 db = new FilmboxEntities1();

        public List<Yonetmenler> GetAll()
        {
            return db.Yonetmenlers.ToList();
        }

        public Yonetmenler GetbyID(int id) //1 satırlık bilgi getireceği için tipi Yonetmenler verdik.
        {
            return db.Yonetmenlers.Find(id);
        }

        public void Insert(Yonetmenler item)
        {
            db.Yonetmenlers.Add(item);
            db.SaveChanges();
        }

        public void Update(Yonetmenler item)
        {
            Yonetmenler gelen = db.Yonetmenlers.Find(item.YonetmenID);
            db.Entry(gelen).CurrentValues.SetValues(item); //Entry bizden entityden bir veri istiyor. yukarıda bulduğumuz ID'yi Yonetmenler tipinde olan değişkene(gelen) içerisine aktarıyoruz
            db.SaveChanges();
        }

        public void Delete(int item)
        {
            Yonetmenler gelen = db.Yonetmenlers.Find(item);
            db.Yonetmenlers.Remove(gelen);
            db.SaveChanges();
        }
    }
}
