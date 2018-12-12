using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Partita
    {
        public int Id { get; set; }
        public String Tipo { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public String Risultato { get; set; }

        public ICollection<Iscrizione> Iscrizioni { get; set; }
        private List<Giocatore> partecipanti;


        public void AggiungiPartecipante(Giocatore g)
        {
            partecipanti.Add(g);
        }

        public Partita(int id,String tipo,DateTime inizio,DateTime fine,String risultato)
        {
            Id = id;
            Tipo = tipo;
            Inizio = inizio;
            Fine = fine;
            Risultato = risultato;
            partecipanti = new List<Giocatore>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Id: ");
            builder.Append(Id);
            builder.Append(" Tipo: ");
            builder.Append(Tipo);
            builder.Append(" Inizio: ");
            builder.Append(Inizio);
            builder.Append(" Fine: ");
            builder.Append(Fine);
            builder.Append(" Risultato: ");
            builder.Append(Risultato);

            builder.Append(Environment.NewLine);
            builder.Append(" Partecipanti: ");
            builder.Append(Environment.NewLine);

            for (int i=0;i<partecipanti.Count;i++)
            {
                builder.Append(partecipanti[i]);
                builder.Append(Environment.NewLine);

            }

            return builder.ToString();

        }
    }
}
