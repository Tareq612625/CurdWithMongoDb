using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using MongoDB.Bson.Serialization.Attributes;

namespace CurdWithMongoDb.Models
{
    [BsonIgnoreExtraElements]
    public class ItemMaster:Common
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Item id")]
        public int ItemId { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? ItemName { get; set; }


        [Display(Name = "Description")]
        [StringLength(maximumLength: 250, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? ItemDescription { get; set; }


        [Display(Name = "Catagory")]
        [Required(ErrorMessage = "{0} is Required")]
        public int CatagoryId { get; set; }
       


        [Display(Name = "Unit")]
        [Required(ErrorMessage = "{0} is Required")]
        public int UnitId { get; set; }
        

        [Display(Name = "Group")]
        public int GroupId { get; set; }
      

        [Display(Name = "Keyword")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? ItemKeyword { get; set; }


        [Display(Name = "Rate")]
        [Required(ErrorMessage = "{0} is Required")]
        public decimal ItemRate { get; set; }

        [Display(Name = "Image")]
        public string? ItemImage { get; set; }
    }
}
