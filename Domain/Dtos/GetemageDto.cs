using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class GetImageDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }   
        
    }
}
