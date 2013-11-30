using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LizardmanCinemas.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int IsLike { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
