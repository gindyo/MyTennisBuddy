namespace MtB.Communication.Components.ForSendingEmail
{
    public struct Email
    {
        public string Text { get; }
        public string To { get;}
        public string From { get; }
        public string Subject { get; }

        public Email( string text, string to = "", string from="", string subject="")
        {
            Text = text;
            To = to;
            From = from;
            Subject = subject;
        }

        public override bool Equals(object obj)
        {
            if(obj is Email)
                return Equals(((Email)obj));
            return false;
        }

        public bool Equals(Email other)
        {
            return string.Equals(Text, other.Text) && string.Equals(To, other.To) && string.Equals(From, other.From) && string.Equals(Subject, other.Subject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Text != null ? Text.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (To != null ? To.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (From != null ? From.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Subject != null ? Subject.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}