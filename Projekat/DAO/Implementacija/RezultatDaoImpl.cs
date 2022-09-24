using ODP_NET_Theatre.Utils;
using Projekat.ConnectionPool;
using Projekat.DTO;
using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DAO.Implementacija
{
    public class RezultatDaoImpl : IRezultatDao
    {
        public int GetBrojTitulaKuci(List<Vozac> vozaci)
        {
            int brojac = 0;
            foreach (var item in vozaci)
            {
                brojac += BrojTitulaVozaca(item);
            }

            return brojac;
        }
        
        private int BrojTitulaVozaca(Vozac item)
        {
            string query = "select count(*) from rezultat natural join staza where drzs=:drz and plasman = 1 and idv = :idv";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                    ParameterUtil.AddParameter(command, "drz", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idv", item.Idv);
                    ParameterUtil.SetParameterValue(command, "drz", item.Drzv);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Rezultat> GetRezultatiVozaca(int idv)
        {
            string query = "select idr,idv,ids,sezona,plasman, bodovi, maksbrzina from rezultat natural join vozac where idv=:id";
            List<Rezultat> rezultati = new List<Rezultat>();
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
                        while (reader.Read())
                        {
                            Rezultat rezultat = new Rezultat();
                            rezultat.Idr = reader.GetString(0);
                            rezultat.Idv = reader.GetInt32(1);
                            rezultat.Ids = reader.GetInt32(2);
                            rezultat.Sezona = reader.GetInt32(3);
                            rezultat.Plasman = reader.GetInt32(4);
                            rezultat.Bodovi = reader.GetInt32(5);
                            rezultat.MaksBrzina = reader.GetDouble(6);
                            rezultati.Add(rezultat);
                        }
                    }
                }
            }
            return rezultati;
            
        }
        public void DodajRezultat(Rezultat rezultat)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();
                if (rezultat.Plasman==1)
                {
                    DodajTitulu(rezultat.Idv, connection);
                }
                Save(rezultat, connection);
                transaction.Commit();
            }
        }

        private void DodajTitulu(int idv, IDbConnection connection)
        {
            string query = "update vozac set brojtit=brojtit+1 where idv=:id";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "id", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "id", idv);
                command.ExecuteNonQuery();
            }
        }

        public void Save(Rezultat rezultat, IDbConnection connection)
        {
            string query= "insert into rezultat (idr,idv,ids,sezona,plasman,bodovi,maksbrzina) values(:idr, :idv, :ids, :sezona, :plasman, :bodovi, :maksbrzina)";
            
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idr", DbType.String);
                    ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                    ParameterUtil.AddParameter(command, "ids", DbType.Int32);
                    ParameterUtil.AddParameter(command, "sezona", DbType.Int32);
                    ParameterUtil.AddParameter(command, "plasman", DbType.Int32);
                    ParameterUtil.AddParameter(command, "bodovi", DbType.Int32);
                    ParameterUtil.AddParameter(command, "maksbrzina", DbType.Double);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idr", rezultat.Idr);
                    ParameterUtil.SetParameterValue(command, "idv", rezultat.Idv);
                    ParameterUtil.SetParameterValue(command, "ids", rezultat.Ids);
                    ParameterUtil.SetParameterValue(command, "sezona", rezultat.Sezona);
                    ParameterUtil.SetParameterValue(command, "plasman", rezultat.Plasman);
                    ParameterUtil.SetParameterValue(command, "bodovi", rezultat.Bodovi);
                    ParameterUtil.SetParameterValue(command, "maksbrzina", rezultat.MaksBrzina);
                    command.ExecuteNonQuery();

                }
            
        }

        public List<Prvoplasirani> GetPrvoplasiraniNaStazi(int ids)
        {
            string query = "select imev,prezv, sezona, bodovi from rezultat natural join vozac where ids=:ids and plasman=1 order by sezona desc";
            List<Prvoplasirani> prvoplasirani = new List<Prvoplasirani>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "ids", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "ids", ids);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Prvoplasirani p = new Prvoplasirani();
                            p.Ime= reader.GetString(0);
                            p.Prezime= reader.GetString(1);
                            p.Sezona= reader.GetInt32(2);
                            p.BrojBodova= reader.GetInt32(3);
                            prvoplasirani.Add(p);
                        }
                    }
                }
            }
            return prvoplasirani;
        }
    }
}
