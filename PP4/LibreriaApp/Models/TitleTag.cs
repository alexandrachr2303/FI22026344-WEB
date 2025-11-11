using System.ComponentModel.DataAnnotations;

namespace LibreriaApp.Models
{
    public class TitleTag
    {
        [Key]
        public int TitleTagId { get; set; }

        public int TitleId { get; set; }
        public Title Title { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
