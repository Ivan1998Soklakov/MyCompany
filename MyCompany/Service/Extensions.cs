using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Service
{
    public static class Extensions 
    {
        static public string CutController(this string str)
        {
            return str.Replace("Controller","");
        }
    }
}
