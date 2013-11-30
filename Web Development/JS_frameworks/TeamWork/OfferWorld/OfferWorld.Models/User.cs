using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferWorld.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MinLength(5), MaxLength(15)]
        public string Username { get; set; }

        [Required]
        public string AuthCode { get; set; }

        [Required]
        public string Email { get; set; }

        public string SessionKey { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        [Required]
        public bool Admin { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public User()
        {
            this.Items = new HashSet<Item>();
            this.Comments = new HashSet<Comment>();
            this.Offers = new HashSet<Offer>();
        }
    }
}
