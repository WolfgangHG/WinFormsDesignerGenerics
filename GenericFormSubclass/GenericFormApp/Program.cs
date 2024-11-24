using GenericFormLib;

namespace GenericFormApp
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();

      FormChild formGeneric = new FormChild();
      formGeneric.SetItem(new ChildClass { Name = "Item", IntegerVal = 5 });
      
      Application.Run(formGeneric);
    }
  }
}