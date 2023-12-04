using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement;
public class UserUpdateDTO
{
    public string Name {get;set;}
    public string Email { get; set; }
    public RoleType Role {get;set;}
    public UserUpdateDTO (string name, string email, RoleType role)
    {
        Name = name;
        Email = email;
        Role = role;
    }
}
