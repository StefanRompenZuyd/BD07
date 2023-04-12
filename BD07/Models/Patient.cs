namespace BD07.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Adress { get; set; }
        public string MedicalInfo { get; set; }
        public Nullable<double> TreatmentStatus { get; set; }
    }
}
