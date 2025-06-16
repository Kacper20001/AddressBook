namespace AddressBook.UI.WinForms
{
    partial class ContactListForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridContacts = new System.Windows.Forms.DataGridView();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.flowButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addContactButton = new System.Windows.Forms.Button();
            this.editContactButton = new System.Windows.Forms.Button();
            this.deleteContactButton = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.clearFilterButton = new System.Windows.Forms.Button();
            this.manageLocationsButton = new System.Windows.Forms.Button();
            this.FilterToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContacts)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.flowButtonsPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.dataGridContacts, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.buttonsPanel, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.filterPanel, 0, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 3;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(882, 553);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // dataGridContacts
            // 
            this.dataGridContacts.AllowUserToAddRows = false;
            this.dataGridContacts.AllowUserToDeleteRows = false;
            this.dataGridContacts.AllowUserToResizeColumns = false;
            this.dataGridContacts.AllowUserToResizeRows = false;
            this.dataGridContacts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridContacts.Location = new System.Drawing.Point(3, 51);
            this.dataGridContacts.MultiSelect = false;
            this.dataGridContacts.Name = "dataGridContacts";
            this.dataGridContacts.ReadOnly = true;
            this.dataGridContacts.RowHeadersWidth = 51;
            this.dataGridContacts.RowTemplate.Height = 24;
            this.dataGridContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridContacts.Size = new System.Drawing.Size(876, 439);
            this.dataGridContacts.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.flowButtonsPanel);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsPanel.Location = new System.Drawing.Point(3, 496);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(876, 54);
            this.buttonsPanel.TabIndex = 1;
            // 
            // flowButtonsPanel
            // 
            this.flowButtonsPanel.Controls.Add(this.addContactButton);
            this.flowButtonsPanel.Controls.Add(this.editContactButton);
            this.flowButtonsPanel.Controls.Add(this.deleteContactButton);
            this.flowButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.flowButtonsPanel.Name = "flowButtonsPanel";
            this.flowButtonsPanel.Padding = new System.Windows.Forms.Padding(10, 10, 5, 5);
            this.flowButtonsPanel.Size = new System.Drawing.Size(876, 77);
            this.flowButtonsPanel.TabIndex = 3;
            // 
            // addContactButton
            // 
            this.addContactButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addContactButton.AutoSize = true;
            this.addContactButton.Location = new System.Drawing.Point(13, 13);
            this.addContactButton.Name = "addContactButton";
            this.addContactButton.Size = new System.Drawing.Size(90, 26);
            this.addContactButton.TabIndex = 0;
            this.addContactButton.Text = "Add Contact";
            this.addContactButton.UseVisualStyleBackColor = true;
            // 
            // editContactButton
            // 
            this.editContactButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editContactButton.AutoSize = true;
            this.editContactButton.Location = new System.Drawing.Point(109, 13);
            this.editContactButton.Name = "editContactButton";
            this.editContactButton.Size = new System.Drawing.Size(88, 26);
            this.editContactButton.TabIndex = 1;
            this.editContactButton.Text = "Edit Contact";
            this.editContactButton.UseVisualStyleBackColor = true;
            // 
            // deleteContactButton
            // 
            this.deleteContactButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteContactButton.AutoSize = true;
            this.deleteContactButton.Location = new System.Drawing.Point(203, 13);
            this.deleteContactButton.Name = "deleteContactButton";
            this.deleteContactButton.Size = new System.Drawing.Size(105, 26);
            this.deleteContactButton.TabIndex = 2;
            this.deleteContactButton.Text = "Delete Contact";
            this.deleteContactButton.UseVisualStyleBackColor = true;
            // 
            // filterPanel
            // 
            this.filterPanel.AutoSize = true;
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Controls.Add(this.filterTextBox);
            this.filterPanel.Controls.Add(this.clearFilterButton);
            this.filterPanel.Controls.Add(this.panel1);
            this.filterPanel.Controls.Add(this.manageLocationsButton);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPanel.Location = new System.Drawing.Point(3, 3);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(5);
            this.filterPanel.Size = new System.Drawing.Size(876, 42);
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
            this.FilterToolTip.SetToolTip(this.filterTextBox, "Type to filter contacts...\r\n");
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
            // manageLocationsButton
            // 
            this.manageLocationsButton.AutoSize = true;
            this.manageLocationsButton.Location = new System.Drawing.Point(732, 8);
            this.manageLocationsButton.Name = "manageLocationsButton";
            this.manageLocationsButton.Size = new System.Drawing.Size(128, 26);
            this.manageLocationsButton.TabIndex = 3;
            this.manageLocationsButton.Text = "Manage Locations";
            this.manageLocationsButton.UseVisualStyleBackColor = true;
            this.manageLocationsButton.Click += new System.EventHandler(this.manageLocationsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(240, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 34);
            this.panel1.TabIndex = 4;
            // 
            // ContactListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.mainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ContactListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Manager";
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContacts)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.flowButtonsPanel.ResumeLayout(false);
            this.flowButtonsPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.DataGridView dataGridContacts;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.FlowLayoutPanel flowButtonsPanel;
        private System.Windows.Forms.Button addContactButton;
        private System.Windows.Forms.Button editContactButton;
        private System.Windows.Forms.Button deleteContactButton;
        private System.Windows.Forms.FlowLayoutPanel filterPanel;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ToolTip FilterToolTip;
        private System.Windows.Forms.Button clearFilterButton;
        private System.Windows.Forms.Button manageLocationsButton;
        private System.Windows.Forms.Panel panel1;
    }
}

