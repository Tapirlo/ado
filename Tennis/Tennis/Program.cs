using System;
using System.Collections.Generic;

namespace Tennis
{
    class Program
    {

        private static DatabaseTennis database;

        private static RepositoryTennis repository;

        private static void InserisciPartita()
        {
            Console.WriteLine("Inserisci il tipo di partita");
            String tipo = Console.ReadLine();

            DateTime datainizio;
            while (true)
            {
                try
                {
                    Console.WriteLine("Inserisci la data di inizio della partita");
                    datainizio = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            DateTime datafine;

            while (true)
            {
                try
                {
                    Console.WriteLine("Inserisci la data di fine della partita");
                    datafine = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            Console.WriteLine("Inserisci il risultato della partita");
            String risultato = Console.ReadLine();

            Partita partita = new Partita(0, tipo, datainizio, datafine, risultato);
            int? id = database.AggiungiPartita(partita);
            if (id!=null)
            {
                Console.WriteLine("Partita inserita con id: "+id);
            }
            else
            {
                Console.WriteLine("Errore!");
            }

        }

        private static void InserisciPartitaEF()
        {
            Console.WriteLine("Inserisci il tipo di partita");
            String tipo = Console.ReadLine();

            DateTime datainizio;
            while (true)
            {
                try
                {
                    Console.WriteLine("Inserisci la data di inizio della partita");
                    datainizio = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            DateTime datafine;

            while (true)
            {
                try
                {
                    Console.WriteLine("Inserisci la data di fine della partita");
                    datafine = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            Console.WriteLine("Inserisci il risultato della partita");
            String risultato = Console.ReadLine();

            Partita partita = new Partita(0, tipo, datainizio, datafine, risultato);
            repository.InserisciPartita(partita);
            Console.WriteLine("Partita inserita ");
          
        }


        private static void GiocatoriConLivello()
        {
            int livello;
            while (true)
            {
                try
                {
                    Console.WriteLine("Inserisci il livello");
                    livello = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            List<Giocatore> giocatori = database.GetGiocatoriWithLivello(livello);
            for(int i=0;i<giocatori.Count;i++)
            {
                Console.WriteLine(giocatori[i]);
            }
        }

        private static void VisualizzaPartiteIndata()
        {
            DateTime ladata;
            while (true)
            {
                try
                {
                    Console.WriteLine("Inserisci una data");
                    ladata = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            List<Partita> partite = database.GetPartiteInData(ladata);
            for(int i =0;i<partite.Count;i++)
            {
                Console.WriteLine(partite[i]);
            }

        }

        static void CicloPrincipaleEF()
        {
            while (true)
            {
                int n;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Inserisci 1 per stampare tutte le partite, inserisci 2 per tutte le partite in una data,inserisci 3 per inserire una partita, inserisci  inserisci 0 per uscire");
                        n = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                switch (n)
                {
                    case 0:
                        return;
                   
                    case 1:
                        PrintaTuttePartiteEF();
                        break;
                    case 2:
                        VisualizzaPartiteIndataEF();
                        break;
                    case 3:
                        InserisciPartitaEF();
                        break;
                }


            }


        }
        static void CicloPrincipale()
        {
            while(true)
            {
                int n;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Inserisci 1 per stampare tutte le partite, inserisci 2 per tutte le partite in una data,inserisci 3 per inserire una partita, inserisci 4 per cercare giocatori con livello, inserisci  inserisci 0 per uscire");
                        n = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                    switch(n)
                    {
                        case 0:
                            return;
                        case 1:
                            PrintaTuttePartite();
                            break;
                        case 2:
                            VisualizzaPartiteIndata();
                            break;
                        case 3:
                            InserisciPartita();
                            break;
                        case 4:
                            GiocatoriConLivello();
                            break;

                   
                }

                
            }
           


           

        }

        private static void VisualizzaPartiteIndataEF()
        {
            DateTime ladata;
            while (true)
            {
                
                try
                {
                    Console.WriteLine("Inserisci una data");
                    ladata = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            List<Partita> partite = repository.GetPartiteInData(ladata);
            for (int i = 0; i < partite.Count; i++)
            {
                Console.WriteLine(partite[i]);
            }
        }

        private static void PrintaTuttePartiteEF()
        {
            List<Partita> tutte = repository.GetAllPartite();
            for(int i=0;i<tutte.Count;i++)
            {
                Console.WriteLine(tutte[i]);
            }
        }

        private static void PrintaTuttePartite()
        {
            List<Partita> tutte = database.GetAllPartite();
            for (int i = 0; i < tutte.Count; i++)
            {
                Console.WriteLine(tutte[i]);
            }
        }
        static void Main(string[] args)
        {
           
            database = new DatabaseTennis();
            repository = new RepositoryTennis();
            int n=2;
            while ((n!=1)&&(n!=0))
            {
                try
                {
                    Console.WriteLine("Inserisci 1 per lavorare con ado, inserisci 0 per lavorare con ef");
                    n = Int32.Parse(Console.ReadLine());
                   
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if(n==1)
            {
                CicloPrincipale();

            }
            else
            {
                CicloPrincipaleEF();
            }
        }
    }
}
