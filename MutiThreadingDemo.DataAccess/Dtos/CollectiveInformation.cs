using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutiThreadingDemo.DataAccess.Dtos
{
    public class CollectiveInformation
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public bool HasGeneratedUserDetail { get; set; }
        public string DateUserDetailWasGenerated { get; set; }
        public string DateBridged { get; set; }
    }
}