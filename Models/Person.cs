using System;
using System.Collections.Generic;

namespace ApiLoginFormunica.Models
{
    public partial class Person
    {
        public Person()
        {
            ContactInformations = new HashSet<ContactInformation>();
            Users = new HashSet<User>();
        }

        public int IdPerson { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int WorkerCode { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<ContactInformation> ContactInformations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
