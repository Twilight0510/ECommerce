
using ECommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        // Giá sản phẩm tại thời điểm mua
        public decimal UnitPrice { get; set; }
    }
}
