using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual User User { get; set; }
    }
}
