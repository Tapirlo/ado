using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Giocatore
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public String Nickname { get; set; }
        public int Livello { get; set; }

        public ICollection<Iscrizione> Iscrizioni { get; set; }

        public Giocatore(int id,String nome,String cognome, DateTime datanascita,String nickname,int livello)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            DataNascita = datanascita;
            Nickname = nickname;
            Livello = livello;
        }
        public Giocatore()
        {

        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Id: ");
            builder.Append(Id);
            builder.Append(" Nome: ");
            builder.Append(Nome);
            builder.Append(" Cognome: ");
            builder.Append(Cognome);
            builder.Append(" Data nascita: ");
            builder.Append(DataNascita);
            builder.Append(" Nickname: ");
            builder.Append(Nickname);
            builder.Append(" Livello: ");
            builder.Append(Livello);
            return builder.ToString();
        }


    }
}
