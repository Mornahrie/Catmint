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
    public class ReservViewModel
    {
        public IEnumerable<Tables> Tables { get; set; }
        public IEnumerable<Booked> Booked { get; set; }
    }

}
