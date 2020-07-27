using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CentralDeErros.Data.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int LevelId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Level Level { get; set; }
        public Category Category { get; set; }
    }
}
