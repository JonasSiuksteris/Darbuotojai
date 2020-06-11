namespace Darbuotojai.Models
{
    public class ErrorViewModel
    {
        public string Error { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(Error);
    }
}
