namespace AddressBook.UI.WinForms.Views
{
    partial class EditContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.buttonFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.isActiveLabel = new System.Windows.Forms.Label();
            this.editLayoutPanel.SuspendLayout();
            this.buttonFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editLayoutPanel
            // 
            this.editLayoutPanel.ColumnCount = 2;
            this.editLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.editLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editLayoutPanel.Controls.Add(this.firstNameLabel, 0, 0);
            this.editLayoutPanel.Controls.Add(this.lastNameLabel, 0, 1);
            this.editLayoutPanel.Controls.Add(this.birthDateLabel, 0, 2);
            this.editLayoutPanel.Controls.Add(this.phoneNumberLabel, 0, 3);
            this.editLayoutPanel.Controls.Add(this.cityLabel, 0, 4);
            this.editLayoutPanel.Controls.Add(this.firstNameTextBox, 1, 0);
            this.editLayoutPanel.Controls.Add(this.lastNameTextBox, 1, 1);
            this.editLayoutPanel.Controls.Add(this.phoneNumberTextBox, 1, 3);
            this.editLayoutPanel.Controls.Add(this.birthDatePicker, 1, 2);
            this.editLayoutPanel.Controls.Add(this.cityComboBox, 1, 4);
            this.editLayoutPanel.Controls.Add(this.buttonFlowPanel, 0, 6);
            this.editLayoutPanel.Controls.Add(this.isActiveCheckBox, 1, 5);
            this.editLayoutPanel.Controls.Add(this.isActiveLabel, 0, 5);
            this.editLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.editLayoutPanel.Name = "editLayoutPanel";
            this.editLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.editLayoutPanel.RowCount = 8;
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.editLayoutPanel.Size = new System.Drawing.Size(426, 392);
            this.editLayoutPanel.TabIndex = 0;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(13, 28);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(72, 16);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name";
            this.firstNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(13, 81);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(72, 16);
            this.lastNameLabel.TabIndex = 1;
            this.lastNameLabel.Text = "Last Name";
            this.lastNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.birthDateLabel.AutoSize = true;
            this.birthDateLabel.Location = new System.Drawing.Point(13, 134);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new System.Drawing.Size(65, 16);
            this.birthDateLabel.TabIndex = 2;
            this.birthDateLabel.Text = "Birth Date";
            this.birthDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Location = new System.Drawing.Point(13, 187);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(97, 16);
            this.phoneNumberLabel.TabIndex = 3;
            this.phoneNumberLabel.Text = "Phone Number";
            this.phoneNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cityLabel
            // 
            this.cityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(13, 240);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(29, 16);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City";
            this.cityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.firstNameTextBox.Location = new System.Drawing.Point(116, 25);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(297, 22);
            this.firstNameTextBox.TabIndex = 6;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lastNameTextBox.Location = new System.Drawing.Point(116, 78);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(297, 22);
            this.lastNameTextBox.TabIndex = 7;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.phoneNumberTextBox.Location = new System.Drawing.Point(116, 184);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(297, 22);
            this.phoneNumberTextBox.TabIndex = 8;
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.birthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthDatePicker.Location = new System.Drawing.Point(116, 131);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(297, 22);
            this.birthDatePicker.TabIndex = 10;
            // 
            // cityComboBox
            // 
            this.cityComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(116, 236);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(297, 24);
            this.cityComboBox.TabIndex = 11;
            // 
            // buttonFlowPanel
            // 
            this.editLayoutPanel.SetColumnSpan(this.buttonFlowPanel, 2);
            this.buttonFlowPanel.Controls.Add(this.cancelButton);
            this.buttonFlowPanel.Controls.Add(this.saveButton);
            this.buttonFlowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonFlowPanel.Location = new System.Drawing.Point(13, 337);
            this.buttonFlowPanel.Name = "buttonFlowPanel";
            this.buttonFlowPanel.Padding = new System.Windows.Forms.Padding(10);
            this.buttonFlowPanel.Size = new System.Drawing.Size(400, 41);
            this.buttonFlowPanel.TabIndex = 12;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelButton.AutoSize = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(302, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 26);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.saveButton.AutoSize = true;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(221, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 26);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.isActiveCheckBox.Location = new System.Drawing.Point(116, 289);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isActiveCheckBox.TabIndex = 14;
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // isActiveLabel
            // 
            this.isActiveLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.isActiveLabel.AutoSize = true;
            this.isActiveLabel.Location = new System.Drawing.Point(13, 293);
            this.isActiveLabel.Name = "isActiveLabel";
            this.isActiveLabel.Size = new System.Drawing.Size(57, 16);
            this.isActiveLabel.TabIndex = 13;
            this.isActiveLabel.Text = "Is Active";
            this.isActiveLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EditContactForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(426, 392);
            this.Controls.Add(this.editLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "EditContactForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Contact";
            this.editLayoutPanel.ResumeLayout(false);
            this.editLayoutPanel.PerformLayout();
            this.buttonFlowPanel.ResumeLayout(false);
            this.buttonFlowPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel editLayoutPanel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.FlowLayoutPanel buttonFlowPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label isActiveLabel;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
    }
}