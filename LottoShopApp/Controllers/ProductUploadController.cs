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
using Repository.Contracts;
using Services.Contracts;
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
        private readonly IPostDataServices _postDataServices;
        public ProductUploadController(IWebHostEnvironment env, DatabaseContext db, IMapper mapper, IPostDataServices postDataServices)
        {
            _env = env;
            _db = db;
            _mapper = mapper;
            _postDataServices = postDataServices;
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
            var data = _postDataServices.PostData(model);


            return Ok(data);
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
