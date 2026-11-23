
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Họ tên người dùng
        public string FullName { get; set; } = string.Empty;

        // Địa chỉ giao hàng mặc định
        public string? Address { get; set; }
    }
}
