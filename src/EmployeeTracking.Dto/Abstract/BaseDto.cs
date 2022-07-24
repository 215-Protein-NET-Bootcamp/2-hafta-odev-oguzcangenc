﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrancking.Dto.Abstract
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }


        [MaxLength(500)]
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        public bool Available { get; set; }
    }
}
