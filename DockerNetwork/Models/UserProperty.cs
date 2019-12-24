﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DockerNetwork.Models
{
    public class UserProperty
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
