using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UserManagement;
public class User
{

    public  string? Id{get; set;}
    public string? Name {get; set;}
    public RoleType Role {get;set;}
    public string? Email {get;set;}

    public User(){}
    public User(string name, string email, RoleType role)
    {    
        this.Id = GenerateISBN();
        this.Name = name;
        this.Email = email;
        this.Role = role;

    }
    public User(string id, string name, string email, RoleType role)
    {
       
        this.Id = string.IsNullOrEmpty(id)? GenerateISBN():id;
        this.Name = name;
        this.Email = email;
        this.Role = role;
    }

    public string GenerateISBN()
    {
        DateTime now = DateTime.Now;
        string isbn=now.ToString("MMddHHmmssfff");
        isbn += new Random().Next(1,999);
        return isbn;
    }

    public void UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        Name = userUpdateDTO.Name;
        Email = userUpdateDTO.Email;
        Role = userUpdateDTO.Role;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Email: {Email}"; 
    }

}
