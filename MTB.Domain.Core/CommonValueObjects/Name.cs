namespace Core.CommonValueObjects
{
    public struct Name
    {
        public readonly string First;
        public readonly string Last;

        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        public override string ToString()
        {
            return First + " " + Last;
        }
    }
}