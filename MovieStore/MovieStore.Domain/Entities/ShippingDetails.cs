using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        [Display(Name = "first address")]
        public string Line1 { get; set; }

        [Display(Name = "second adress")]
        public string Line2 { get; set; }

        [Display(Name = "third address")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}