namespace MtB.CommonValueObjects
{
    public struct Name
    {
        private readonly string _first;
        private readonly string _last;

        public Name(string first, string last)
        {
            _first = first;
            _last = last;
        }

        public override string ToString()
        {
            return _first + " " + _last;
        }
    }
}