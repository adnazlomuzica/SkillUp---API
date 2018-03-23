using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillUp_HCI.Models
{
    public class PitanjeVM
    {
        public int PitanjeID { get; set; }
        public int TestID { get; set; }
        public string PitanjeTekst { get; set; }
        public double Bod { get; set; }
        public List<OdgovorVM> Odgovori { get; set; }
    }

    public class PitanjaOdgovorVM
    {
        public PitanjeVM pitanje { get; set; }
        public List<OdgovorVM> odgovoriList { get; set; }
    }
}