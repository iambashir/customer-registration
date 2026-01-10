namespace customer_registration.DTOs;

public class CustomerInfoDto
{
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public bool MeritalStatus { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public int ZipCode { get; set; }
    public string Address { get; set; } = string.Empty;
}

