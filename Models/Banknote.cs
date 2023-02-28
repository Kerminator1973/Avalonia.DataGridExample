namespace Avalonia.DataGridExample.Models
{
    public class Banknote
    {
        public int Id { get; set; }
        public string Currency { get; set; } = null!;
        public string Denomination { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
