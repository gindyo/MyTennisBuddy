namespace MtB.CommonValueObjects
{
    public struct ContactInfo
    {
        public ContactInfo(string email, string cellPhoneNumber)
        {
            if (email == null && cellPhoneNumber == null)
                throw new System.Exception("At least 1 of the contact details must be provided");

            Email = email ?? "";
            CellPhoneNumber = cellPhoneNumber ?? "";
        }
        public string CellPhoneNumber { get; }
        public string Email { get; }
    }
}