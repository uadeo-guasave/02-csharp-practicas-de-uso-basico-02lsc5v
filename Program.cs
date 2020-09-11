using System;
using _02_csharp_primeros_pasos.Models;

namespace _02_csharp_primeros_pasos
{
  class Program
  {
    static void Main(string[] args)
    {
      InicializarBaseDeDatos();
    }

    private static void InicializarBaseDeDatos()
    {
      // Los DbContext son objetos de tipo Resource (open, close)
      using (var db = new VespertinoDbContext())
      {
        try
        {
          db.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      };
    }
  }
}
