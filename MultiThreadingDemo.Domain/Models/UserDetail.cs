using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo.Domain.Models
{
    [Table("UserDetails")]
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DateGenerated { get; set; }
        public bool IsBridged { get; set; }
    }
}