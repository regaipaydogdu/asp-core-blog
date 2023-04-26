using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        public string username { get; set; }

        public string password { get; set; }
    }
}
