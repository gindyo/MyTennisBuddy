namespace MtB.SmsComponents
{
    public struct Sms
    {
        public string Text { get; }

        public Sms(string text)
        {
            Text = text;
        }

        public override int GetHashCode()
        {
            return (Text != null ? Text.GetHashCode() : 0);
        }
    }
}