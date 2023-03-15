using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class OyuncularRepository : IRepository<Oyuncular>
    {
        FilmboxEntities1 db = DbTool.DbInstance; // sınıf içerisinde tanımlanmış instance
        public List<Oyuncular> GetAll()
        {
            return db.Oyunculars.ToList();
        }

        public Oyuncular GetByID(int id)
        {
            return db.Oyunculars.Find(id);
        }

        public void Insert(Oyuncular item)
        {
            db.Oyunculars.Add(item);
            db.SaveChanges();
        }

        public void Update(Oyuncular item)
        {
            Oyuncular gelen = db.Oyunculars.Find(item.OyuncuID);
            db.Entry(gelen).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Oyuncular gelen = db.Oyunculars.Find(id);
            db.Oyunculars.Remove(gelen);
            db.SaveChanges();
        }
    }
}
