using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibreriaApp.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public List<Title> Titles { get; set; }
    }
}
