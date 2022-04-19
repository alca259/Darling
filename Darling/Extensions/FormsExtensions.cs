namespace Darling.Extensions;

internal static class FormsExtensions
{
    public static void PrependTextWithNewLine(this TextBox textBox, string? text)
    {
        if (string.IsNullOrEmpty(text)) return;
        textBox.Text = text + Environment.NewLine + textBox.Text;
    }
}
