using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Iscrizione
    {
        public int Giocatore { get; set; }
        public int Partita { get; set; }

        public Giocatore GiocatoreNavigation { get; set; }

        public Partita PartitaNavigation { get; set; }

        public Iscrizione()
        {

        }

        public Iscrizione(int p,int g)
        {
            Giocatore = g;
            Partita = p;
        }
    }
}
