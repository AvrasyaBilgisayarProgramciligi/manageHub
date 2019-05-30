namespace manageHub
{
    partial class AddItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bClosee = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bAddItem = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(90)))), ((int)(((byte)(102)))));
            this.mainPanel.Controls.Add(this.bClosee);
            this.mainPanel.Controls.Add(this.bClose);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(364, 28);
            this.mainPanel.TabIndex = 16;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            // 
            // bClosee
            // 
            this.bClosee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClosee.FlatAppearance.BorderSize = 0;
            this.bClosee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.bClosee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bClosee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClosee.Image = ((System.Drawing.Image)(resources.GetObject("bClosee.Image")));
            this.bClosee.Location = new System.Drawing.Point(322, 0);
            this.bClosee.Name = "bClosee";
            this.bClosee.Size = new System.Drawing.Size(42, 28);
            this.bClosee.TabIndex = 0;
            this.bClosee.TabStop = false;
            this.bClosee.UseVisualStyleBackColor = true;
            this.bClosee.Click += new System.EventHandler(this.BClosee_Click);
            // 
            // bClose
            // 
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Image = ((System.Drawing.Image)(resources.GetObject("bClose.Image")));
            this.bClose.Location = new System.Drawing.Point(398, 0);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(42, 28);
            this.bClose.TabIndex = 1;
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.label2.Location = new System.Drawing.Point(54, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Item Name";
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.White;
            this.itemName.Font = new System.Drawing.Font("Arial", 15.75F);
            this.itemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.itemName.Location = new System.Drawing.Point(57, 111);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(174, 32);
            this.itemName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(120, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Add Item";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.panel1.Location = new System.Drawing.Point(1, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 4);
            this.panel1.TabIndex = 17;
            // 
            // bAddItem
            // 
            this.bAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.bAddItem.FlatAppearance.BorderSize = 0;
            this.bAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddItem.Font = new System.Drawing.Font("Arial", 12F);
            this.bAddItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bAddItem.Location = new System.Drawing.Point(253, 111);
            this.bAddItem.Name = "bAddItem";
            this.bAddItem.Size = new System.Drawing.Size(88, 32);
            this.bAddItem.TabIndex = 2;
            this.bAddItem.Text = "Add";
            this.bAddItem.UseVisualStyleBackColor = false;
            this.bAddItem.Click += new System.EventHandler(this.BAddItem_Click);
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 168);
            this.Controls.Add(this.bAddItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddItemForm_FormClosed);
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button bClosee;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bAddItem;
    }
}