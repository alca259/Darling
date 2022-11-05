namespace Darling.Extensions;

internal static class FormsExtensions
{
    public static void PrependTextWithNewLine(this TextBox textBox, string text)
    {
        if (string.IsNullOrEmpty(text)) return;
        textBox.ControlInvoke(new Action(() =>
        {
            textBox.Text = text + Environment.NewLine + textBox.Text;
        }));
    }

    public static void ControlInvoke(this Control control, Action action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(action);
            return;
        }

        action();
    }
}
