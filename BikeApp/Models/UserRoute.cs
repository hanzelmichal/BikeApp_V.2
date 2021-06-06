using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeApp.Models
{

    public class UserRoute
    {
            /*[Key]*/
            public int RouteId { get; set; }
            public string Link { get; set; }
            public string UserId { get; set; }
            public string City { get; set; }
            public string RouteName { get; set; }
        
    }
}
