using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project;
using final_project.Models.Entities;
using final_project.Services;
using Microsoft.AspNetCore.Authorization;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private IColorService _service;

        public ColorController(IColorService servcie)
      {
          _service=servcie;
      }
        [HttpGet]
        public ActionResult<IEnumerable<Color>> GetColors()
        {
            return _service.GetColors();
        }
    }
}