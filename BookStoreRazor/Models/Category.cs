using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStoreRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "trường tên danh mục là bắt buộc")]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Thứ tự hiển thị phải nằm trong khoảng từ 1 đến 100")]
        public int DisplayOrder { get; set; }
    }
}
