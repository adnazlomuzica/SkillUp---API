using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillUp_HCI.Models
{
    public class OdgovorVM
    {
        public int OdgovorID { get; set; }
        public string Odgovor { get; set; }
        public bool Tacan { get; set; }
        public int PitanjeID { get; set; }
    }
}