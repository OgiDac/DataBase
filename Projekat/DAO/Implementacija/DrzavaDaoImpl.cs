using Projekat.ConnectionPool;
using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DAO.Implementacija
{
    public class DrzavaDaoImpl : IDrzavaDao
    {
        public IEnumerable<Drzava> FindAll()
        {
            string query = "select * from drzava";
            List<Drzava> drzave = new List<Drzava>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    command.Prepare();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Drzava drzava = new Drzava
                            {
                                Idd = reader.GetInt32(0),
                                NazivD = reader.GetString(1)
                            };
                            drzave.Add(drzava);
                        }
                    }
                }
            }
            return drzave;
        }
    }
}
