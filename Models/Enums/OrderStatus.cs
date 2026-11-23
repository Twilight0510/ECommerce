namespace ECommerce.Models.Enums
{
    public enum OrderStatus
    {
        Pending = 0,   // Chờ xử lý
        Shipping = 1,  // Đang giao
        Completed = 2, // Hoàn thành
        Cancelled = 3  // Đã hủy
    }
}
