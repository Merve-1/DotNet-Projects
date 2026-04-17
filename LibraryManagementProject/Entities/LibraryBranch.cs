namespace LibraryManagementProject;

public class LibraryBranch
{
    public string Id { get; private set; } = null;
    public string Name { get; private set; } = null;
    public string Address { get; private set; } = null;
    public string Phone  { get; private set; } = null;
    public string OpeningHours { get; private set; } = null;
    public Librarian Manager { get; private set; } = null;

    private readonly List<BookCopy> _copies = [];
    private readonly List<Member> _members = [];
    
}