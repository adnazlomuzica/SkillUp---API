using SkillUp_HCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillUp_HCI.Controllers
{
    public class KorisniciController : ApiController
    {
        private SkillUpEntities db = new SkillUpEntities();

        [HttpGet]
        public IHttpActionResult Provjera(string username, string password)
        {
            Korisnici k = db.Korisnici.SingleOrDefault(x => x.KorisnickoIme == username && x.Lozinka == password);

            return Ok(k);
        }

        public Korisnici PostKorisnik(Korisnici k)
        {

            Korisnici kor = db.Korisnici.Find(k.KorisnikID);

            if (kor != null)
            {
                kor.Ime = k.Ime;
                kor.KorisnickoIme = k.KorisnickoIme;
                kor.Lozinka = k.Lozinka;
                kor.Prezime = k.Prezime;
                db.SaveChanges();

                return kor;
            }

            else
            {
                Korisnici korisnik = db.Korisnici.Where(x => x.KorisnickoIme == k.KorisnickoIme).FirstOrDefault();

                if (korisnik == null)
                {
                    db.Korisnici.Add(k);
                    db.SaveChanges();

                }

                return korisnik;
            }

        }
    }
}
