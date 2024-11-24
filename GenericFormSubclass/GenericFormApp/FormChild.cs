using GenericFormLib;

namespace GenericFormApp
{
  //public partial class FormChild : FormGenericWrapper
  public partial class FormChild : FormGeneric<ChildClass>
  {
    public FormChild()
    {
      InitializeComponent();
    }
  }
}
