namespace phonebook_core.Entities
{
    public class PhoneBookEntry
    {
        /// <summary>
        /// Unique ID for the Book Item
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Person first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Person last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Phone number of the format DDD-DDD-DDDD
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
