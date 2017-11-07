namespace MtB.CommonValueObjects
{
    public struct ContactInfo
    {
        public ContactInfo(string email, string cellPhoneNumber)
        {
            Email = email;
            CellPhoneNumber = cellPhoneNumber;
        }

        public string CellPhoneNumber { get; }
        public string Email { get; }
    }
}