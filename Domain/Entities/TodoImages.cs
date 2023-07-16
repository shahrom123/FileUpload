using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TodoImage
    {
        public int Id { get; set; } 
        public string FileName { get; set; } 
        public int TodoId { get; set; } 
        public Todo Todo { get; set; }

        public TodoImage( string fileName, int todoId)
        {

            FileName = fileName;
            TodoId = todoId;
      
        }
    }
}



