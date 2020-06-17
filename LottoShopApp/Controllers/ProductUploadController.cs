using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using E_CommerceApp.Data;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopModels.Models;
using ShopModels.ViewModel;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ProductUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        public ProductUploadController(IWebHostEnvironment env, DatabaseContext db, IMapper mapper)
        {
            _env = env;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {

                    string fileName = file.FileName;
                    string folder = "/Likhon";
                    var physicalPath = _env.WebRootPath + folder;
                    if (!Directory.Exists(physicalPath))
                    {
                        Directory.CreateDirectory(physicalPath);
                    }
                    string path = Path.Combine(physicalPath, fileName);
                    var stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    file.CopyTo(stream);
                    stream.Close();
                    stream.Dispose();
                    var webPath = folder;


                    return Ok(path);

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult PostData(ProductDto model)
        {
            var product = _mapper.Map<Shoe>(model);

            string finalImage = "";
            int pos = model.ProductImage.IndexOf("d");
            if (pos >= 0)
            {
                // String after founder  
                string afterFounder = model.ProductImage.Remove(pos);
                Console.WriteLine(afterFounder);
                // Remove everything before founder but include founder  
                string beforeFounder = model.ProductImage.Remove(0, pos);
                finalImage = beforeFounder;


            }


            if (ModelState.IsValid)
            {
                product.ProductImage = finalImage;
                _db.Shoes.Add(product);
                _db.SaveChanges();
            }


            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _db.Shoes;
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _db.Shoes.Find(id);
            return Ok(data);
        }
    
    }
}
