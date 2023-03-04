using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace phonebook_spa.Models
{
    public class CreatePhoneBookEntryRequest
    {
        /// <summary>
        /// Person first name
        /// </summary>
        [JsonProperty("firstName", Required = Required.Always)]
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Person last name
        /// </summary>
        [JsonProperty("lastName", Required = Required.Always)]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        /// <summary>
        /// Phone number of the format DDD-DDD-DDDD
        /// </summary>
        [JsonProperty("phoneNumber", Required = Required.Always)]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public string PhoneNumber { get; set; }
    }
}
