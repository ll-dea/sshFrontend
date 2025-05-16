using Microsoft.AspNetCore.Identity;
using NLog.Web.LayoutRenderers;
using System;
using SSH_FrontEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models
{
    public class Users 
    {
        [Key]
        public string Id { get; set; }

        
        public string password { get; set; }


        public string UserName { get; set; }
     

        public string Email { get; set; }
        public int role { get; set; }
       

        

      

     

   

    }
}
