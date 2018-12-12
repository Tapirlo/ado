using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Tennis
{
    public class DatabaseTennis
    {
        public const string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Tennis; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const  String query = "SELECT * from giocatori";
        private const String queryTuttePartite = "SELECT * from partite";
        private const String queryPartite = "SELECT * from partite where inizio=@ladata";

        private const String queryPartecipanti = "SELECT * from giocatori join iscrizione on id=giocatore where partita=@lapartita";
        private const String queryLivello = "SELECT * FROM giocatori WHERE livello>=@livello";

        private const  String findPartitaId = "SELECT SCOPE_IDENTITY()";

        private const String queryInserisciPartita = "INSERT INTO partite(tipe,inizio,fine,risultato) values (@tipo,@inizio,@fine,@risultato) " + findPartitaId;

        private void CaricaPartecipanti(Partita partita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryPartecipanti, connection);
                command.Parameters.AddWithValue("@lapartita", partita.Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                  
                    while (reader.Read())
                    {
                        partita.AggiungiPartecipante(new Giocatore((int)reader["id"], (String)reader["nome"], (String)reader["cognome"], (DateTime)reader["datanascita"], (String)reader["nickname"], (int)reader["livello"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public List<Partita> GetAllPartite()
        {
            long l = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryTuttePartite, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Partita> result = new List<Partita>();
                    while (reader.Read())
                    {
                        Partita partita = new Partita((int)reader["id"], (String)reader["tipe"], (DateTime)reader["inizio"], (DateTime)reader["fine"], (String)reader["risultato"]);
                        CaricaPartecipanti(partita);
                        result.Add(partita);
                    }
                    reader.Close();
                    l = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - l;
                    Console.WriteLine("Tempo trascorso:" + l);
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        public List<Giocatore> GetGiocatoriWithLivello(int livello)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryLivello, connection);
                command.Parameters.AddWithValue("@livello", livello);
                List<Giocatore> risultato = new List<Giocatore>();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        risultato.Add(new Giocatore((int)reader["id"], (String)reader["nome"], (String)reader["cognome"], (DateTime)reader["datanascita"], (String)reader["nickname"], (int)reader["livello"]));
                    }
                    reader.Close();
                    return risultato;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        public int? AggiungiPartita(Partita partita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryInserisciPartita, connection);
                command.Parameters.AddWithValue("@tipo", partita.Tipo);
                command.Parameters.AddWithValue("@inizio", partita.Inizio);
                command.Parameters.AddWithValue("@fine", partita.Fine);
                command.Parameters.AddWithValue("@risultato", partita.Risultato);



                try
                {
                    connection.Open();
                    decimal result = (decimal) command.ExecuteScalar() ;
                    return (int)result;

                }

                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        public List<Partita> GetPartiteInData(DateTime ladata)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryPartite, connection);
                command.Parameters.AddWithValue("@ladata", ladata.ToString());
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Partita> result = new List<Partita>();
                    while (reader.Read())
                    {
                       Partita partita=new Partita((int)reader["id"], (String)reader["tipe"],  (DateTime)reader["inizio"], (DateTime)reader["fine"],(String)reader["risultato"]);
                        CaricaPartecipanti(partita);
                        result.Add(partita);
                    }
                    reader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        public List<Giocatore> getGiocatori()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Giocatore> result = new List<Giocatore>();
                    while (reader.Read())
                    {
                        result.Add(new Giocatore((int)reader["id"], (String)reader["nome"], (String)reader["cognome"], (DateTime)reader["datanascita"],(String) reader["nickname"],(int) reader["livello"]));
                    }
                    reader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                
            }
        }



    }
}
