namespace GenericFormApp
{
  partial class FormChild
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
      this.checkBox1 = new CheckBox();
      this.SuspendLayout();
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(172, 201);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(166, 19);
      this.checkBox1.TabIndex = 4;
      this.checkBox1.Text = "Checkbox from child form";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // FormChild
      // 
      this.AutoScaleDimensions = new SizeF(7F, 15F);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Controls.Add(this.checkBox1);
      this.Name = "FormChild";
      this.Controls.SetChildIndex(this.labelItem, 0);
      this.Controls.SetChildIndex(this.textBoxItem, 0);
      this.Controls.SetChildIndex(this.checkBox1, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion

    private CheckBox checkBox1;
  }
}
