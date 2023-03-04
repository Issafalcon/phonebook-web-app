using phonebook_core.Entities;

namespace phonebook_core.Specifications
{
    internal class PhoneBookEntryByLastNameSpecification : BaseSpecification<PhoneBookEntry>
    {
        public PhoneBookEntryByLastNameSpecification(string lastName) : base((e) => e.LastName == lastName)
        {
        }
    }
}
