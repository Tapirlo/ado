using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tennis
{
    public class RepositoryTennis : IDisposable
    {
        private Contesto contesto;

        public RepositoryTennis()
        {
            contesto = Contesto.SqlServerContext();
        }

        public void Dispose()
        {
            contesto.Dispose();
        }

        public List<Partita> GetPartiteInData(DateTime ladata)
        {
            return contesto.Partite.Where(x => x.Inizio == ladata).ToList();
        }

        public List<Partita> GetAllPartite()
        {
            long l=DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var risultato= contesto.Partite.ToList();
            l = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - l;
            Console.WriteLine("Tempo trascorso: " + l);
            return risultato;

        }

        public void InserisciPartita(Partita p)
        {
            contesto.Partite.Add(p);
            contesto.SaveChanges();
        }
    }
}
