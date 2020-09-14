using System;
using System.Collections.Generic;
using System.Linq;
using _02_csharp_primeros_pasos.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_csharp_primeros_pasos
{
  class Program
  {
    static void Main(string[] args)
    {
      InicializarBaseDeDatos();

      // CRUD = Create Read Update Delete
      // InsertRoles();
      PrintAllRoles();
      // InsertUser();
      // InsertMoreUsers();
      PrintUsersWithRoleName();
      // InsertPermissions();
      // InsertRolesHasPermissions();
    }

    private static void InsertRoles()
    {
      var role1 = new Role();
      role1.Name = "Administrator";
      role1.Description = "Users can do anything.";
      role1.Level = 1;

      var role2 = new Role()
      { 
        Name = "Operator",
        Description = "Users can operate mostly functions.",
        Level = 2
      };

      var role3 = new Role
      {
        Name = "Guest",
        Description = "Users only view and use some functions.",
        Level = 3
      };

      using (var db = new VespertinoDbContext())
      {
        try
        {
          db.Roles.Add(role1);
          db.Roles.Add(role2);
          db.Roles.Add(role3);

          db.SaveChanges();
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      };
    }

    private static void PrintAllRoles()
    {
      using (var db = new VespertinoDbContext())
      {
        try
        {
          var roles = db.Roles.ToList();

          foreach (var role in roles)
          {
              System.Console.WriteLine($"Id: {role.Id}, Name: {role.Name}, Description: {role.Description}, Level: {role.Level}");
          }
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      };
    }
    
    private static void InsertUser()
    {
      // role_id = 1 (Administrator)
      using (var db = new VespertinoDbContext())
      {
        try
        {
          var adminRole = db.Roles.Where(r => r.Name.Equals("Administrator")).First();

          var user = new User
          {
            Name = "bidkar",
            Password = "123",
            Firstname = "Bidkar",
            Lastname = "Aragon C.",
            Email = "bidkar.aragon@uadeo.mx",
            Gender = gender.MASCULINO,
            RoleId = adminRole.Id
          };

          db.Users.Add(user);
          db.SaveChanges();
        }
        catch (Exception ex)
        {
          System.Console.WriteLine("Error: " + ex.Message);
        }
      };
    }
    
    private static void PrintUsersWithRoleName()
    {
      using (var db = new VespertinoDbContext())
      {
        try
        {
          var users = db.Users.Include(u => u.Role).ToList();

          foreach (var user in users)
          {
              System.Console.WriteLine($"User: {user.Name}, Role: {user.Role.Name}");
          }
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      };
    }

    private static void InsertMoreUsers()
    {
      using (var db = new VespertinoDbContext())
      {
        try
        {
          var users = new List<User>
          {
            new User {
              Name = "flavio",
              Password = "321",
              Firstname = "Flavio",
              Lastname = "Morales",
              Email = "flavio.morales@uadeo.mx",
              Gender = gender.MASCULINO,
              RoleId = 2
            },
            new User {
              Name = "falcon",
              Password = "456",
              Firstname = "Ricardo",
              Lastname = "Mascareño",
              Email = "ricardo@falcon.com",
              Gender = gender.MASCULINO,
              RoleId = 3
            }
          };

          db.Users.AddRange(users);
          db.SaveChanges();
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      };
    }

    private static void InsertPermissions()
    {}

    private static void InsertRolesHasPermissions()
    {}



    private static void InicializarBaseDeDatos()
    {
      // Los DbContext son objetos de tipo Resource (open, close)
      using (var db = new VespertinoDbContext())
      {
        try
        {
          db.Database.EnsureCreated();
          System.Console.WriteLine("La base de datos ha sido inicializada o reconocida.");
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      };
    }
  }
}
