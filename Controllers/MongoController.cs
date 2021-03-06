using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mvc.Services;
namespace mvc.Controllers
{
    public class MongoController : Controller
    {
        public static IConfigurationRoot Configuration { get; set; }
        public async Task<JsonResult> getAllTeam()
        {
            var mongoDbService = new MongoDbService("test", "Team", "mongodb://admin:secure@localhost:2277");
            var allTeam = await mongoDbService.GetAllTeam();
            return Json(allTeam);
        }
        public async Task<JsonResult> getAllOffice()
        {
            var mongoDbService = new MongoDbService("test", "Office", "mongodb://admin:secure@localhost:2277");
            var allOffice = await mongoDbService.GetAllOffice();
            return Json(allOffice);
        }
    }
}
