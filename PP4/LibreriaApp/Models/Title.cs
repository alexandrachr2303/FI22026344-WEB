using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibreriaApp.Models
{
    public class Title
    {
        [Key]
        public int TitleId { get; set; }

        [Required]
        public string TitleName { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<TitleTag> TitleTags { get; set; }
    }
}

