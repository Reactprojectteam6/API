using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project;
using final_project.Models.Entities;
using final_project.Services;

namespace final_project.Services
{
    public class ColorService : IColorService
    {
        private DataContext _context;

     public   ColorService(DataContext dataContext)
     {
         _context=dataContext;
     }

        public List<Color> GetColors()
        {
            var list = new List<Color>();
            list = _context.Colors.ToList();
            return list;
        }
    }
}