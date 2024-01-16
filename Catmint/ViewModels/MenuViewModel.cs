using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catmint.Data;
using Catmint.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Catmint.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
