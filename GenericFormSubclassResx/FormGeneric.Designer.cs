namespace GenericFormSubclassResx
{
  partial class FormGeneric<TClass>
  //partial class FormGeneric
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric<TClass>));
      //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneric));
      this.textBoxItem = new TextBox();
      this.labelItem = new Label();
      this.pictureBox = new PictureBox();
      ((System.ComponentModel.ISupportInitialize)this.pictureBox).BeginInit();
      this.SuspendLayout();
      // 
      // textBoxItem
      // 
      this.textBoxItem.Location = new Point(255, 93);
      this.textBoxItem.Name = "textBoxItem";
      this.textBoxItem.ReadOnly = true;
      this.textBoxItem.Size = new Size(354, 23);
      this.textBoxItem.TabIndex = 3;
      // 
      // labelItem
      // 
      this.labelItem.AutoSize = true;
      this.labelItem.Location = new Point(172, 96);
      this.labelItem.Name = "labelItem";
      this.labelItem.Size = new Size(77, 15);
      this.labelItem.TabIndex = 2;
      this.labelItem.Text = "Current item:";
      // 
      // pictureBox
      // 
      this.pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
      this.pictureBox.Location = new Point(192, 288);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new Size(164, 65);
      this.pictureBox.TabIndex = 4;
      this.pictureBox.TabStop = false;
      // 
      // FormGeneric
      // 
      this.AutoScaleDimensions = new SizeF(7F, 15F);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.textBoxItem);
      this.Controls.Add(this.labelItem);
      this.Name = "FormGeneric";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)this.pictureBox).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion

    protected TextBox textBoxItem;
    protected Label labelItem;
    protected PictureBox pictureBox;
  }
}
