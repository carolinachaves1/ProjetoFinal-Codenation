﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<Error> Errors { get; set; }
    }
}
