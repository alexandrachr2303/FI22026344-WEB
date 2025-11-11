using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibreriaApp.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        public string TagName { get; set; }

        public List<TitleTag> TitleTags { get; set; }
    }
}
