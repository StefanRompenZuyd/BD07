namespace BD07.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MedContainer
    {
        public int Id { get; set; }
        public ICollection<User> UserID { get; set; }
        public ICollection<Medicine> MedicineID { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<double> Status { get; set; }
    }
}
