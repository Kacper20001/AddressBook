namespace AddressBook.UI.WinForms.Views.Location
{
    partial class LocationListForm
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
            this.components = new System.ComponentModel.Container();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridLocations = new System.Windows.Forms.DataGridView();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.flowButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addLocationButton = new System.Windows.Forms.Button();
            this.editLocationButton = new System.Windows.Forms.Button();
            this.deleteLocationButton = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.clearFilterButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ContactsButton = new System.Windows.Forms.Button();
            this.FilterToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLocations)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.flowButtonsPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.dataGridLocations, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.buttonsPanel, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.filterPanel, 0, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 3;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(705, 442);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // dataGridLocations
            // 
            this.dataGridLocations.AllowUserToAddRows = false;
            this.dataGridLocations.AllowUserToDeleteRows = false;
            this.dataGridLocations.AllowUserToResizeColumns = false;
            this.dataGridLocations.AllowUserToResizeRows = false;
            this.dataGridLocations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLocations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLocations.Location = new System.Drawing.Point(3, 51);
            this.dataGridLocations.MultiSelect = false;
            this.dataGridLocations.Name = "dataGridLocations";
            this.dataGridLocations.ReadOnly = true;
            this.dataGridLocations.RowHeadersWidth = 51;
            this.dataGridLocations.RowTemplate.Height = 24;
            this.dataGridLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLocations.Size = new System.Drawing.Size(699, 328);
            this.dataGridLocations.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.flowButtonsPanel);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsPanel.Location = new System.Drawing.Point(3, 385);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(699, 54);
            this.buttonsPanel.TabIndex = 1;
            // 
            // flowButtonsPanel
            // 
            this.flowButtonsPanel.Controls.Add(this.addLocationButton);
            this.flowButtonsPanel.Controls.Add(this.editLocationButton);
            this.flowButtonsPanel.Controls.Add(this.deleteLocationButton);
            this.flowButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.flowButtonsPanel.Name = "flowButtonsPanel";
            this.flowButtonsPanel.Padding = new System.Windows.Forms.Padding(10, 10, 5, 5);
            this.flowButtonsPanel.Size = new System.Drawing.Size(876, 77);
            this.flowButtonsPanel.TabIndex = 3;
            // 
            // addLocationButton
            // 
            this.addLocationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addLocationButton.AutoSize = true;
            this.addLocationButton.Location = new System.Drawing.Point(13, 13);
            this.addLocationButton.Name = "addLocationButton";
            this.addLocationButton.Size = new System.Drawing.Size(96, 26);
            this.addLocationButton.TabIndex = 0;
            this.addLocationButton.Text = "Add Location";
            this.addLocationButton.UseVisualStyleBackColor = true;
            // 
            // editLocationButton
            // 
            this.editLocationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editLocationButton.AutoSize = true;
            this.editLocationButton.Location = new System.Drawing.Point(115, 13);
            this.editLocationButton.Name = "editLocationButton";
            this.editLocationButton.Size = new System.Drawing.Size(94, 26);
            this.editLocationButton.TabIndex = 1;
            this.editLocationButton.Text = "Edit Location";
            this.editLocationButton.UseVisualStyleBackColor = true;
            // 
            // deleteLocationButton
            // 
            this.deleteLocationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteLocationButton.AutoSize = true;
            this.deleteLocationButton.Location = new System.Drawing.Point(215, 13);
            this.deleteLocationButton.Name = "deleteLocationButton";
            this.deleteLocationButton.Size = new System.Drawing.Size(111, 26);
            this.deleteLocationButton.TabIndex = 2;
            this.deleteLocationButton.Text = "Delete Location";
            this.deleteLocationButton.UseVisualStyleBackColor = true;
            // 
            // filterPanel
            // 
            this.filterPanel.AutoSize = true;
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Controls.Add(this.filterTextBox);
            this.filterPanel.Controls.Add(this.clearFilterButton);
            this.filterPanel.Controls.Add(this.panel1);
            this.filterPanel.Controls.Add(this.ContactsButton);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPanel.Location = new System.Drawing.Point(3, 3);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(5);
            this.filterPanel.Size = new System.Drawing.Size(699, 42);
            this.filterPanel.TabIndex = 2;
            this.filterPanel.WrapContents = false;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(8, 11);
            this.filterLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(39, 16);
            this.filterLabel.TabIndex = 0;
            this.filterLabel.Text = "Filter:";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filterTextBox.Location = new System.Drawing.Point(53, 14);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(100, 22);
            this.filterTextBox.TabIndex = 1;
            this.FilterToolTip.SetToolTip(this.filterTextBox, "Type to filter locations...");
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.AutoSize = true;
            this.clearFilterButton.Location = new System.Drawing.Point(159, 8);
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(75, 26);
            this.clearFilterButton.TabIndex = 2;
            this.clearFilterButton.Text = "Clear";
            this.clearFilterButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(240, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 34);
            this.panel1.TabIndex = 5;
            // 
            // ContactsButton
            // 
            this.ContactsButton.AutoSize = true;
            this.ContactsButton.Location = new System.Drawing.Point(562, 8);
            this.ContactsButton.Name = "ContactsButton";
            this.ContactsButton.Size = new System.Drawing.Size(128, 26);
            this.ContactsButton.TabIndex = 6;
            this.ContactsButton.Text = "Contacts";
            this.ContactsButton.UseVisualStyleBackColor = true;
            this.ContactsButton.Click += new System.EventHandler(this.ContactsButton_Click);
            // 
            // LocationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 442);
            this.Controls.Add(this.mainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location Manager";
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLocations)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.flowButtonsPanel.ResumeLayout(false);
            this.flowButtonsPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.DataGridView dataGridLocations;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.FlowLayoutPanel flowButtonsPanel;
        private System.Windows.Forms.Button addLocationButton;
        private System.Windows.Forms.Button editLocationButton;
        private System.Windows.Forms.Button deleteLocationButton;
        private System.Windows.Forms.FlowLayoutPanel filterPanel;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ToolTip FilterToolTip;
        private System.Windows.Forms.Button clearFilterButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ContactsButton;
    }
}