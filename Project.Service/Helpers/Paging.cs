using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Helpers
{
    public class Paging
    {
        public int PerPage { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int Total { get; set; }
    }
}
