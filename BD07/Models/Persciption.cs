namespace BD07.Models
{
    public class Persciption
    {
        public int Id { get; set; }
        public ICollection<Medicine> ID { get; set; }
        public string Info { get; set; }
        public string Dosage { get; set; }
        public DateTime Schedule { get; set; }
        public bool IsCompleted { get; set; }
    }
}
