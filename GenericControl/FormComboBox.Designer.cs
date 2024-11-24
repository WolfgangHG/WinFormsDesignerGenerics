namespace GenericControl
{
  partial class FormComboBox
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.comboBox = new ComboBoxGeneric<ChildClass>();
      this.labelComboBox = new Label();
      this.buttonShowSelected = new Button();
      this.SuspendLayout();
      // 
      // comboBox
      // 
      this.comboBox.FormattingEnabled = true;
      this.comboBox.Location = new Point(327, 94);
      this.comboBox.Name = "comboBox";
      this.comboBox.SelectedItem = null;
      this.comboBox.Size = new Size(121, 23);
      this.comboBox.TabIndex = 0;
      // 
      // labelComboBox
      // 
      this.labelComboBox.AutoSize = true;
      this.labelComboBox.Location = new Point(215, 97);
      this.labelComboBox.Name = "labelComboBox";
      this.labelComboBox.Size = new Size(70, 15);
      this.labelComboBox.TabIndex = 1;
      this.labelComboBox.Text = "ComboBox:";
      // 
      // buttonShowSelected
      // 
      this.buttonShowSelected.Location = new Point(485, 93);
      this.buttonShowSelected.Name = "buttonShowSelected";
      this.buttonShowSelected.Size = new Size(107, 23);
      this.buttonShowSelected.TabIndex = 2;
      this.buttonShowSelected.Text = "Show selected";
      this.buttonShowSelected.UseVisualStyleBackColor = true;
      this.buttonShowSelected.Click += this.buttonShowSelected_Click;
      // 
      // FormComboBox
      // 
      this.AutoScaleDimensions = new SizeF(7F, 15F);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add(this.buttonShowSelected);
      this.Controls.Add(this.labelComboBox);
      this.Controls.Add(this.comboBox);
      this.Name = "FormComboBox";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion

    private ComboBoxGeneric<ChildClass> comboBox;
    private Label labelComboBox;
    private Button buttonShowSelected;
  }
}
