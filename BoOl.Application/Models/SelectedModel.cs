namespace BoOl.Application.Models
{
    public class SelectedModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public SelectedModel(int value, string text)
        {
            Value = value;
            Text = text;
        }
    }
}
