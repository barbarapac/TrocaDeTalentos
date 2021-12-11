using System;
using System.ComponentModel.DataAnnotations;

namespace Utfpr.Troca.De.Talentos.Domain.Models
{
    [Obsolete]
    public class Offer
    {
        public int userId { get; set; }

        [StringLength(30, ErrorMessage = "title cannot be longer than 30 characters.")]
        public string title { get; set; }

        public string description { get; set; }

        public DateTime CreatedAt { get; private set; }
    
        public Offer() {
            CreatedAt = DateTime.Now;
        }
        public Offer(int userId, string title, string description)
        {
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.CreatedAt = DateTime.Now;
        }

        public void Update(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}