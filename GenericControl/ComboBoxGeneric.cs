using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericControl
{
  public partial class ComboBoxGeneric<TItem> : ComboBox
    where TItem : BaseClass
  {
    public ComboBoxGeneric()
    {
      InitializeComponent();
    }

    public new TItem? SelectedItem
    {
      get
      {
        return (TItem?)base.SelectedItem;
      }
      set
      {
        base.SelectedItem = value;
      }
    }
  }
}
