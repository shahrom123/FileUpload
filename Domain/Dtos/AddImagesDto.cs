using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
   
    public class AddImagesDto 
    {
        public int Id { get; set; }
        public int TodoId { get; set; }  
        public IFormFile File { get; set;  }    
    }

}
