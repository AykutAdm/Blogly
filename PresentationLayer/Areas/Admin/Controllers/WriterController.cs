using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var value = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(value);
            return Json(value);
        }

        public IActionResult UpdateWriter(WriterClass w)
        {
            var value = writers.FirstOrDefault(x => x.Id == w.Id);
            value.Name = w.Name;
            var jsonWriter= JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name= "Aykut",
            },

             new WriterClass
            {
                Id = 2,
                Name= "Osman",
            },

              new WriterClass
            {
                Id = 3,
                Name= "Bülent",
            },

               new WriterClass
            {
                Id = 4,
                Name= "Ufuk",
            },
        };
    }
}
