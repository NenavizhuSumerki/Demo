using Demo.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class Context
    {
        public static KolotejContext DbContext = new KolotejContext();

        public static List<Service> ListUslugi = DbContext.Services.ToList();




    }
}
