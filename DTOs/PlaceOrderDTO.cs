using ECommerceFrontend.DTOs;

namespace ECommerceFrontend.DTOs
{
    public class PlaceOrderDTO
    {
        public int UserId { get; set; }

        public List<ItemDTO> Items { get; set; }

    }
}
