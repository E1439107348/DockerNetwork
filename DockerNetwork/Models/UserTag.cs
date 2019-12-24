using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DockerNetwork.Models
{
    public class UserTag
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Tag { get; set; }
        /// <summary>
        /// 创建时间1
        /// </summary>
        public  DateTime CreatedTime { get; set; }
    }
}
