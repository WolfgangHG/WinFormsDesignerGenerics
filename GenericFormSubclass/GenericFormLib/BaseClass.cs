using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFormLib
{
  public class BaseClass
  {
    public string Name { get; set; } = "";


    public override string ToString()
    {

      return this.Name;
    }
  }
}
