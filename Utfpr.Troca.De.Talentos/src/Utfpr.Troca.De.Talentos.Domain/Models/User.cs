using System;
using System.ComponentModel.DataAnnotations;

namespace Utfpr.Troca.De.Talentos.Domain.Models
{
    [Obsolete]
    public class User : BaseEntity
    {
        [Required]
        public int RA { get; private set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; private set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; private set; }

        [Required]
        public string Password { get; private set; }
 
        public bool isAdmin { get; private set; }

        public string photo { get; private set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        
        
        
        // public void Update(string name, string email, string password)
        // {
        //     ValidaUsuario(name, email, password);
        // }
        // private void ValidaUsuario()
        // {
        //     if (string.IsNullOrEmpty(Name))
        //         throw new Exception("Nome não pode ser vazio");
        //
        //     if (string.IsNullOrEmpty(Email))
        //         throw new Exception("Email não pode ser vazio");
        //
        //     if (string.IsNullOrEmpty(Password))
        //         throw new Exception("Senha não pode ser vazio");
        // }
    }
}
