﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFormSubclassResx
{
  public class ChildClass : BaseClass
  {
    public int IntegerVal { get; set; }

    public override string ToString()
    {

      return base.ToString() + ", Value = " + this.IntegerVal;
    }

  }
}