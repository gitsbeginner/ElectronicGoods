using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RequestMaster.Models
{
  
    public class RequestContext: DbContext
    {
        public RequestContext():base("DefaultConnection")
        {

        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StateRequest> States { get; set; }
    }
}