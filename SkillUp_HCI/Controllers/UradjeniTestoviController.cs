using SkillUp_HCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillUp_HCI.Controllers
{
    public class UradjeniTestoviController : ApiController
    {

        private SkillUpEntities db = new SkillUpEntities();

        public IHttpActionResult GetUradjeniTestovi(int korisnikId)
        {
            List<UradjeniTestoviVM> ut = new List<UradjeniTestoviVM>();

            List<UradjeniTestovi> lista = db.UradjeniTestovi.Where(x => x.KorisnikID == korisnikId).ToList();
            foreach (UradjeniTestovi u in lista)
            {
                UradjeniTestoviVM uradjeniTestovi = new UradjeniTestoviVM();
                uradjeniTestovi.KorisnikID = u.KorisnikID;
                uradjeniTestovi.Rezultat = u.Rezultat;
                uradjeniTestovi.Test = u.Test.Naziv;
                uradjeniTestovi.UradjeniTest = u.UradjeniTest;

                ut.Add(uradjeniTestovi);
            }

            return Ok(ut);
        }

        public IHttpActionResult PostUradjeniTest(UradjeniTestoviVM uradjeniTestovi)
        {
            UradjeniTestovi ut = new UradjeniTestovi();

            ut.KorisnikID = uradjeniTestovi.KorisnikID;
            ut.Rezultat = uradjeniTestovi.Rezultat;
            ut.TestID = uradjeniTestovi.TestID;

            db.UradjeniTestovi.Add(ut);

            db.SaveChanges();

            return Ok(ut);
        }
    }
}
