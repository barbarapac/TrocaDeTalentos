using System;
using System.ComponentModel.DataAnnotations;

namespace Utfpr.Troca.De.Talentos.Domain.Models
{
    [Obsolete]
    public class Category : BaseEntity
    {
        public int offerId { get; set; }

        [Required(ErrorMessage = "The field name is required")]
        public string Name { get; private set; }
        
        enum CategoryType
        {
            Linguas,
            Matematica,
            Humanas,
            Ciencias,
            Musica,
            Outros
        }
        public Category(string name)
        {
            Name = name;
        }
        public void Update(string name)
        {
            Name = name;
        }
    }
}