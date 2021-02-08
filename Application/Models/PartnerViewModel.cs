using System;
using System.Collections.Generic;

namespace Application.Models
{
  public class PartnerViewModel
  {
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Name { get; set; }
    public string RegistryCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string About { get; set; }
    public byte[] Image { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PartnerAddressViewModel> PartnerAddress { get; set; }
    public virtual ICollection<EmployeeViewModel> Employees { get; set; }
  }
}
