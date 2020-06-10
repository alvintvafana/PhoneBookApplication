using PhoneBookApplication.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApplication.Domain.Entities
{
    public class PhoneBookAggregateRoot : BaseEntity<Guid>
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value ?? throw new ValidateException("name cannot be null");
            }
        }


        private readonly List<Entry> entries;
        public IReadOnlyCollection<Entry> Entries => entries;

        public PhoneBookAggregateRoot()
            :base(Guid.NewGuid())
        {
            entries = new List<Entry>();
        }

        public PhoneBookAggregateRoot(string name)
             : base(Guid.NewGuid())
        {
            Name = name;
            entries = new List<Entry>();
        }

        public void InsertEntry(string name, string phoneNumber)
        {
            entries.Add(new Entry(name, phoneNumber));
        }

        public void UpdateEntry(Guid id,string name, string phoneNumber)
        {
            var entry = entries.Where(a => a.Id == id).FirstOrDefault();
            entry.Name = name;
            entry.PhoneNumber = phoneNumber;
        }

        public void DeleteEntry(Guid id)
        {
            var entry = entries.Where(a => a.Id == id).FirstOrDefault();
            if(entry==null)
                throw new ValidateException("Entry does not exist");
            entries.Remove(entry);
        }

    }
}
