using ODP_NET_Theatre.Utils;
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
    public class VozacDaoImpl : IVozacDao
    {
        public double ProsecnaMaksimalnaBrzina(int idv)
        {
            string query = "select avg(maksbrzina) from vozac natural join rezultat group by idv  having idv=:id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;


                    ParameterUtil.AddParameter(command, "id", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", idv);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetDouble(0);
                        }
                    }
                }
            }
            return 0;
        }

        public Tuple<double, int> ProsecnoGodisteITitule(int idd)
        {
            string query = "select avg(godrodj), sum(brojtit) from vozac where drzv=:idd";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {

                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idd", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idd", idd);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            return new Tuple<double, int>(reader.GetDouble(0), reader.GetInt32(1));
                        }
                    }
                }
            }
            return null;
        }


        public IEnumerable<Vozac> VozaciIzDrzave(int idd)
        {
            string query = "select * from vozac where drzv=:idd";
            List<Vozac> vozaci = new List<Vozac>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {

                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idd", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idd", idd);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vozac vozac= new Vozac
                            {
                                Idv=reader.GetInt32(0),
                                Imev=reader.GetString(1),
                                Prezv=reader.GetString(2),
                                GodRodj=reader.GetInt32(3),
                                BrojTit=reader.GetInt32(4),
                                Drzv=reader.GetInt32(5),
                            };
                            vozaci.Add(vozac);
                        }
                    }
                }
            }
            return vozaci;
        }
    }
}
