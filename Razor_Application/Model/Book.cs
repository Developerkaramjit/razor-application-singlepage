using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Application.Model
{
    public class Book
    {
       public int Id { get; set; }
        [Required]
       public String Name { get; set; }
        [Required]
       public String Author { get; set; }
        [Required]
       public int ISBN { get; set; }
    }
}
