using System.Threading.Tasks;

namespace DialogTest
{
    public interface IDialog
    {
        Task<DialogResult> Show(string title, string message, string accepte, string cancel, bool isPassword = false);
    }
    public class DialogResult
    {
        public string PressedButtonTitle { get; set; }
        public string Text { get; set; }
    }
}
