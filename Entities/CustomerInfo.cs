namespace customer_registration.Entities;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("CustomerInfo")]
public class CustomerInfo
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public bool MeritalStatus { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public int ZipCode { get; set; }

    public string Address { get; set; } = string.Empty;
}

