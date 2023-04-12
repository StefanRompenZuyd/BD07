namespace BD07.Models
{
    using System;
    using System.Collections.Generic;

    public class Persciption
    {
        public int Id { get; set; }
        public ICollection<Medicine> MedicineID { get; set; }
        public string Info { get; set; }
        public Nullable<int> Dosage { get; set; }
        public DateTime Schedule { get; set; }
        public bool IsCompleted { get; set; }
    }
}
