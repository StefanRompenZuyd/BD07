namespace BD07.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MedEvent
    {
        public int Id { get; set; }
        public ICollection<User> UserID { get; set; }
        public ICollection<MedContainer> MedContainerID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
