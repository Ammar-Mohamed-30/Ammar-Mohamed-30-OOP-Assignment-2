namespace LibraryInheritance;

public class PremiumMember : Member
{
    public int ReadingPoints => ReadingPointsValue;

    public PremiumMember(
        string personId,
        string fullName,
        string phone,
        decimal discountPercentage)
        : base(
            personId,
            fullName,
            phone,
            10,
            discountPercentage,
            5)
    {
    }
}