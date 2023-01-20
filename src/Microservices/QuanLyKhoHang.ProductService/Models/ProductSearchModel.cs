namespace QuanLyKhoHang.ProductService.Models
{
    public class ProductSearchModel
    {
        public string? Filter { get; set; }

        public int? CategoryId { get; set; }

        public bool? Active { get; set; }
    }
}
