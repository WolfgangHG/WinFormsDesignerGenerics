namespace GenericControl
{
  public partial class FormComboBox : Form
  {
    public FormComboBox()
    {
      InitializeComponent();

      this.comboBox.Items.Add(new ChildClass() { Name = "Item 1", IntegerVal = 5 });
      this.comboBox.Items.Add(new ChildClass() { Name = "Item 2", IntegerVal = 15 });
      this.comboBox.Items.Add(new ChildClass() { Name = "Item 3", IntegerVal = 6 });
    }

    private void buttonShowSelected_Click(object sender, EventArgs e)
    {
      MessageBox.Show(this, "Selected Item: " + this.comboBox.SelectedItem);
    }
  }
}
