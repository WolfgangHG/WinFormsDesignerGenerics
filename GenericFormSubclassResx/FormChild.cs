
namespace GenericFormSubclassResx
{
  //public partial class FormChild : FormGenericWrapper
  //public partial class FormChild : FormGeneric
  public partial class FormChild : FormGeneric<ChildClass>
  {
    public FormChild()
    {
      InitializeComponent();
    }
  }
}
