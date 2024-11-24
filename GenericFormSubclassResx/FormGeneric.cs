namespace GenericFormSubclassResx
{
  public partial class FormGeneric<TClass> : Form
    where TClass : BaseClass
    //public partial class FormGeneric : Form 
  {
    public FormGeneric()
    {
      InitializeComponent();
    }



    //public void SetItem<TClass>(TClass item) where TClass : BaseClass
    public void SetItem(TClass item)
    {
      this.textBoxItem.Text = item.ToString();
    }
  }
}
