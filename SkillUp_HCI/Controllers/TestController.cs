using SkillUp_HCI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillUp_HCI.Controllers
{
    public class TestController : ApiController
    {
        private SkillUpEntities db = new SkillUpEntities();

        public IHttpActionResult GetTestovi(int kategorijaId)
        {
            List<TestVM> testovi = new List<TestVM>();

            List<Test> list = db.Test.Where(x => x.KategorijaID == kategorijaId).ToList();
            foreach(Test x in list)
            {
                TestVM test = new TestVM();
                test.Pitanja = new List<PitanjeVM>();
                test.BrojPitanja = x.BrojPitanja;
                test.KategorijaID = x.KategorijaID;
                test.Naziv = x.Naziv;
                test.TestID = x.TestID;

                List<Pitanje> pitanje = db.Pitanje.Where(z => z.TestID == test.TestID).ToList();
                foreach (Pitanje p in pitanje)
                {
                    PitanjeVM pvm = new PitanjeVM();
                    pvm.Odgovori = new List<OdgovorVM>();
                    pvm.Bod = p.Bod;
                    pvm.PitanjeID = p.PitanjeID;
                    pvm.PitanjeTekst = p.PitanjeTekst;
                    pvm.TestID = p.TestID;

                    List<Odgovori> odgovor= db.Odgovori.Where(y => y.PitanjeID == p.PitanjeID).ToList();
                    foreach(Odgovori o in odgovor)
                    {
                        OdgovorVM odg = new OdgovorVM();
                        odg.OdgovorID = o.OdgovorID;
                        odg.Odgovor = o.Odgovor;
                        odg.PitanjeID = o.PitanjeID;
                        odg.Tacan = o.Tacan;

                        pvm.Odgovori.Add(odg);
                    }

                    test.Pitanja.Add(pvm);
                }

                testovi.Add(test);
            }

            return Ok(testovi);
        }

        public IHttpActionResult GetTest(int testId)
        {
            TestVM test = new TestVM();
            Test t = db.Test.Where(x => x.TestID == testId).SingleOrDefault();

                test.BrojPitanja = t.BrojPitanja;
                test.KategorijaID = t.KategorijaID;
                test.Naziv = t.Naziv;
                test.TestID = t.TestID;

                foreach (Pitanje p in db.Pitanje.Where(z => z.TestID == test.TestID).ToList())
                {
                    PitanjeVM pvm = new PitanjeVM();
                    pvm.Bod = p.Bod;
                    pvm.PitanjeID = p.PitanjeID;
                    pvm.PitanjeTekst = p.PitanjeTekst;
                    pvm.TestID = p.TestID;

                    //pvm.Odgovori = db.Odgovori.Where(y => y.PitanjeID == pvm.PitanjeID).ToList();

                    test.Pitanja.Add(pvm);
                }

            return Ok(test);
        }

       
    }
}
