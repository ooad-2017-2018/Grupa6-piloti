﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerodrom.Model
{
    
    public class Osoba
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private string telefon;
        private string Email;


        public Osoba() { }
        public Osoba(string ime, string prezime, DateTime datumRodjenja, string telefon, string email)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            
            this.telefon = telefon;
            Email = email;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email1 { get => Email; set => Email = value; }
    }
}
