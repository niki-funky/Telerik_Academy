using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferWorld.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }

        public virtual Item Item { get; set; }
    }
}
