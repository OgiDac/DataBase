using Projekat.DAO;
using Projekat.DAO.Implementacija;
using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Service
{
    public class StazaService
    {
        private static readonly IStazaDao staze = new StazaDaoImpl();

        public int Count()
        {
            return staze.Count();
        }

        public void Delete(Staza entity)
        {
            staze.Delete(entity);
        }

        public void DeleteAll()
        {
            staze.DeleteAll();
        }

        public void DeleteById(int id)
        {
            staze.DeleteById(id);
        }

        public bool ExistsById(int id)
        {
            return staze.ExistsById(id);
        }

        public IEnumerable<Staza> FindAll()
        {
            return staze.FindAll();
        }

        public Staza FindById(int id)
        {
            return staze.FindById(id);
        }
        public void Save(Staza entity)
        {
            staze.Save(entity);
        }

        public void SaveAll(IEnumerable<Staza> entities)
        {
            staze.SaveAll(entities);
        }
    }
}
