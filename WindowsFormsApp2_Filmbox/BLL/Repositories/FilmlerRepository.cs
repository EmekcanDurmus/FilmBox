using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class FilmlerRepository : IRepository<Filmler>
    {
        FilmboxEntities1 db = new FilmboxEntities1();
        public List<Filmler> GetAll()
        {
            return db.Filmlers.ToList();
        }

        public Filmler GetByID(int id)
        {
            return db.Filmlers.Find(id);
        }

        public void Insert(Filmler item)
        {
            db.Filmlers.Add(item);
            db.SaveChanges();
        }

        public void Update(Filmler item)
        {
            Filmler gelen = db.Filmlers.Find(item.FilmID);
            db.Entry(gelen).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Filmler gelen = db.Filmlers.Find(id);
            db.Filmlers.Remove(gelen);
            db.SaveChanges();
        }
    }
}
