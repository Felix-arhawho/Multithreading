using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo.Domain.Models
{
    [Table("UserComments")]
    public class UserComment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CollectiveInformationJson { get; set; }
        public string DateGenerated { get; set; }
    }
}
