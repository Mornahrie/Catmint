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
    public class MainViewModel
    {
        public IEnumerable<Description> Descriptions { get; set; }
        public IEnumerable<Cat> Cats { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
