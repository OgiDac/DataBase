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
    public class StazaDaoImpl : IStazaDao
    {
        public int Count()
        {
            string query = "select count(*) from staza";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void Delete(Staza entity)
        {
            string query = "delete from staza where ids=:id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", entity.Ids);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAll()
        {
            string query = "delete from staza";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteById(int id)
        {
            string query = "delete from staza where ids=:id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            string query = "select * from staza where ids=:id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);
                    return command.ExecuteScalar() != null;
                }
            }
        }

        public IEnumerable<Staza> FindAll()
        {
            string query = "select ids, nazivs, brojkrug, duzkrug, drzs from staza";
            List<Staza> staze = new List<Staza>();
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
                            Staza staza = new Staza
                            {
                                Ids = reader.GetInt32(0),
                                Nazivs = reader.GetString(1),
                                BrojKrug = reader.GetInt32(2),
                                DuzKrug = reader.GetDouble(3),
                                Drzs = reader.GetInt32(4)
                            };
                            staze.Add(staza);
                        }
                    }
                }
            }
            return staze;
        }
        public Staza FindById(int id)
        {
            string query = "select * from staza where ids=:id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Staza s = new Staza(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDouble(3), reader.GetInt32(4));
                            return s;
                        }
                    }
                }
            }
            return null;
        }

        public void Save(Staza entity)
        {
            string query;
            if (ExistsById(entity.Ids))
                query = "update staza set nazivs=:naziv ,brojkrug =:bk, duzkrug= :dk, drzs=:drzava where ids=:id";
            else
                query = "insert into staza (nazivs,brojkrug, duzkrug, drzs, ids) VALUES(:naziv, :bk, :dk, :drzava, :id)";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "naziv", DbType.String);
                    ParameterUtil.AddParameter(command, "bk", DbType.Int32);
                    ParameterUtil.AddParameter(command, "dk", DbType.Double);
                    ParameterUtil.AddParameter(command, "drzava", DbType.Int32);
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "naziv", entity.Nazivs);
                    ParameterUtil.SetParameterValue(command, "bk", entity.BrojKrug);
                    ParameterUtil.SetParameterValue(command, "dk", entity.DuzKrug);
                    ParameterUtil.SetParameterValue(command, "drzava", entity.Drzs);
                    ParameterUtil.SetParameterValue(command, "id", entity.Ids);
                    command.ExecuteNonQuery();

                }
            }
        }

        public void SaveAll(IEnumerable<Staza> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();
                foreach (Staza s in entities)
                {
                    Save(connection, s);
                }
                transaction.Commit();
            }
        }
        public void Save(IDbConnection connection, Staza entity)
        {
            string query;
            if (ExistsById(entity.Ids))
                query = "update staza set nazivs=:naziv ,brojkrug =:bk, duzkrug= :dk, drzs=:drzava where ids=:id";
            else
                query = "insert into staza (nazivs,brojkrug, duzkrug, drzs, ids) VALUES(:naziv, :bk, :dk, :drzava, :id)";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "naziv", DbType.String);
                ParameterUtil.AddParameter(command, "bk", DbType.Int32);
                ParameterUtil.AddParameter(command, "dk", DbType.Double);
                ParameterUtil.AddParameter(command, "drzava", DbType.Int32);
                ParameterUtil.AddParameter(command, "id", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "naziv", entity.Nazivs);
                ParameterUtil.SetParameterValue(command, "bk", entity.BrojKrug);
                ParameterUtil.SetParameterValue(command, "dk", entity.DuzKrug);
                ParameterUtil.SetParameterValue(command, "drzava", entity.Drzs);
                ParameterUtil.SetParameterValue(command, "id", entity.Ids);
                command.ExecuteNonQuery();

            }
        }
        public IEnumerable<Staza> GetStazePoDrzavi(string nazivd)
        {
            string query = "select ids, nazivs, brojkrug, duzkrug, drzs from staza inner join drzava on staza.drzs=drzava.idd where nazivd=:naziv";
            List<Staza> staze = new List<Staza>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "naziv", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "naziv", nazivd);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Staza staza = new Staza
                            {
                                Ids = reader.GetInt32(0),
                                Nazivs = reader.GetString(1),
                                BrojKrug = reader.GetInt32(2),
                                DuzKrug = reader.GetDouble(3),
                                Drzs = reader.GetInt32(4)
                            };
                            staze.Add(staza);
                        }
                    }
                }
            }
            return staze;
        }

        public double GetProsecnaMaksBrzina(int ids)
        {
            string query = "select avg(maksbrzina) from staza natural join rezultat where ids=:ids";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "ids", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "ids", ids);
                    return Convert.ToDouble(command.ExecuteScalar());
                }
            }
        }
    }
}
