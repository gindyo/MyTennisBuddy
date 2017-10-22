namespace MtB.EmailComponents
{
    public struct Email
    {
        public string Text { get; }

        public Email(string text)
        {
            Text = text;
        }

        public override int GetHashCode()
        {
            return (Text != null ? Text.GetHashCode() : 0);
        }
    }
}