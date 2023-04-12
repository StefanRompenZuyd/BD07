namespace BD07.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Portion { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Retailer { get; set; }
    }
}
