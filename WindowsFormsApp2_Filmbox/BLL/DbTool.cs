using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DbTool
    {
        private static FilmboxEntities1 _dbInstance;
        public static FilmboxEntities1 DbInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new FilmboxEntities1();
                }
                return _dbInstance;
            }
        }
    }
}
