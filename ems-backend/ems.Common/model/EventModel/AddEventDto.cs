using Microsoft.AspNetCore.Http;

namespace ems.Common.model.Event
{
    public class AddEventDto
    {
        public string Name { get; set; }
        public string? SubTitle { get; set; }
        public int SupplierId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int InventoryId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public string? Description { get; set; }
        public List<IFormFile>? EventFiles { get; set; }
    }
}
