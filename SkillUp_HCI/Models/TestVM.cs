using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillUp_HCI.Models
{
    public class TestVM
    {
        public int TestID { get; set; }
        public string Naziv { get; set; }
        public int KategorijaID { get; set; }
        public int BrojPitanja { get; set; }
        public List<PitanjeVM> Pitanja { get; set; }
    }
}