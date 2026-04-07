using Dapper;
using DataAccessLayer1.Repository;
using System.Data;

public class ContactRepository : IContactRepository
{
    private readonly DapperContext _context;

    public ContactRepository(DapperContext context)
    {
        _context = context;
    }

    public List<ContactInfo> GetAllContacts()
    {
        var sql = @"SELECT c.*, comp.CompanyName, d.DepartmentName
                    FROM ContactInfo c
                    INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                    LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId";

        using var con = _context.CreateConnection();
        return con.Query<ContactInfo>(sql).ToList();
    }

    public ContactInfo GetContactById(int id)
    {
        using var con = _context.CreateConnection();
        return con.QueryFirstOrDefault<ContactInfo>(
            "SELECT * FROM ContactInfo WHERE ContactId=@id", new { id });
    }

    public void AddContact(ContactInfo contact)
    {
        using var con = _context.CreateConnection();
        con.Execute(@"INSERT INTO ContactInfo
        (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
        VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)", contact);
    }

    public void UpdateContact(ContactInfo contact)
    {
        using var con = _context.CreateConnection();
        con.Execute(@"UPDATE ContactInfo SET
        FirstName=@FirstName, LastName=@LastName,
        EmailId=@EmailId, MobileNo=@MobileNo,
        Designation=@Designation,
        CompanyId=@CompanyId, DepartmentId=@DepartmentId
        WHERE ContactId=@ContactId", contact);
    }

    public void DeleteContact(int id)
    {
        using var con = _context.CreateConnection();
        con.Execute("DELETE FROM ContactInfo WHERE ContactId=@id", new { id });
    }

    public List<Company> GetCompanies()
    {
        using var con = _context.CreateConnection();
        return con.Query<Company>("SELECT * FROM Company").ToList();
    }

    public List<Department> GetDepartments()
    {
        using var con = _context.CreateConnection();
        return con.Query<Department>("SELECT * FROM Department").ToList();
    }
}