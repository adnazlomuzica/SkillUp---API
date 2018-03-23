using SkillUp_HCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillUp_HCI.Controllers
{
    public class KategorijaController : ApiController
    {
        private SkillUpEntities db = new SkillUpEntities();

        public IHttpActionResult GetKategorije()
        {
            return Ok(db.su_SelectAllCategories().ToList());
        }

        public IHttpActionResult GetBrojTestova(int kategorijaId)
        {
            int broj = db.Test.Where(x => x.KategorijaID == kategorijaId).Count();

            return Ok(broj);
        }
    }
}
