using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookStore.Models
{
    public class Product
    {
      
        [Key]
        public int Id { get; set; }
        [Required]
        //  tiêu đề của sản phẩm
        public  string Title { get; set; }

        [Required]
        // mô tả của sản phẩm
        public  string Description { get; set; }

        [Required]
        // số ISBN của sách . vạch đen đen phía sau cuốn sách
        public  string ISBN { get; set; }

        [Required]
        // tên tác giả của sách
        public  string Author { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(1,1000)]
        // giá niêm yết của sản phẩm
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        // giá cho từ 1 đến 50 sản phẩm
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        // giá cho từ 50 sản phẩm trở lên

        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        // giá cho từ 100 sản phẩm trở lên
        public double Price100 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
