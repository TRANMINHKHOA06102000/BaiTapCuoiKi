namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Display(Name = "Mã Sản Phẩm")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [Display(Name = "Đơn Giá")]
        public decimal UnitCost { get; set; }
        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô Tả")]
        public string Description { get; set; }
        [Display(Name = "Trạng Thái")]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Loại Sản Phẩm")]
        public string CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
