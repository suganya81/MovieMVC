using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MovieMVC.Models;

namespace MovieMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MovieMVCUser class
public class MovieMVCUser : IdentityUser
{
    public List<Post>Posts { get; set; }

}

