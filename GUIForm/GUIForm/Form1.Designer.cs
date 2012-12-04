namespace GUIForm
{
    partial class Form1
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
            this.SeedActorLabel = new System.Windows.Forms.Label();
            this.GetSeedActor = new System.Windows.Forms.Button();
            this.SeparatedActorLabel = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.SeparatedActor1 = new System.Windows.Forms.ComboBox();
            this.SeedActor1 = new System.Windows.Forms.ComboBox();
            this.Initialize = new System.Windows.Forms.Button();
            this.actorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SeedActorLabel
            // 
            this.SeedActorLabel.AutoSize = true;
            this.SeedActorLabel.Location = new System.Drawing.Point(13, 18);
            this.SeedActorLabel.Name = "SeedActorLabel";
            this.SeedActorLabel.Size = new System.Drawing.Size(63, 13);
            this.SeedActorLabel.TabIndex = 1;
            this.SeedActorLabel.Text = "Seed Actor:";
            // 
            // GetSeedActor
            // 
            this.GetSeedActor.Location = new System.Drawing.Point(740, 13);
            this.GetSeedActor.Name = "GetSeedActor";
            this.GetSeedActor.Size = new System.Drawing.Size(75, 23);
            this.GetSeedActor.TabIndex = 2;
            this.GetSeedActor.Text = "Seed";
            this.GetSeedActor.UseVisualStyleBackColor = true;
            this.GetSeedActor.Click += new System.EventHandler(this.GetSeedActor_Click);
            // 
            // SeparatedActorLabel
            // 
            this.SeparatedActorLabel.AutoSize = true;
            this.SeparatedActorLabel.Location = new System.Drawing.Point(380, 18);
            this.SeparatedActorLabel.Name = "SeparatedActorLabel";
            this.SeparatedActorLabel.Size = new System.Drawing.Size(87, 13);
            this.SeparatedActorLabel.TabIndex = 4;
            this.SeparatedActorLabel.Text = "Separated Actor:";
            // 
            // OutputBox
            // 
            this.OutputBox.AcceptsReturn = true;
            this.OutputBox.AcceptsTab = true;
            this.OutputBox.Location = new System.Drawing.Point(16, 83);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputBox.Size = new System.Drawing.Size(291, 511);
            this.OutputBox.TabIndex = 5;
            // 
            // SeparatedActor1
            // 
            this.SeparatedActor1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SeparatedActor1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SeparatedActor1.FormattingEnabled = true;
            this.SeparatedActor1.Location = new System.Drawing.Point(485, 15);
            this.SeparatedActor1.Name = "SeparatedActor1";
            this.SeparatedActor1.Size = new System.Drawing.Size(216, 21);
            this.SeparatedActor1.TabIndex = 6;
            // 
            // SeedActor1
            // 
            this.SeedActor1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SeedActor1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SeedActor1.FormattingEnabled = true;
            this.SeedActor1.Location = new System.Drawing.Point(82, 15);
            this.SeedActor1.Name = "SeedActor1";
            this.SeedActor1.Size = new System.Drawing.Size(216, 21);
            this.SeedActor1.TabIndex = 7;
            // 
            // Initialize
            // 
            this.Initialize.Location = new System.Drawing.Point(28, 54);
            this.Initialize.Name = "Initialize";
            this.Initialize.Size = new System.Drawing.Size(75, 23);
            this.Initialize.TabIndex = 8;
            this.Initialize.Text = "Initialize";
            this.Initialize.UseVisualStyleBackColor = true;
            this.Initialize.Click += new System.EventHandler(this.Initialize_Click);
            // 
            // actorBindingSource
            // 
            this.actorBindingSource.DataSource = typeof(GUIForm.Actor);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 606);
            this.Controls.Add(this.Initialize);
            this.Controls.Add(this.SeedActor1);
            this.Controls.Add(this.SeparatedActor1);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.SeparatedActorLabel);
            this.Controls.Add(this.GetSeedActor);
            this.Controls.Add(this.SeedActorLabel);
            this.Name = "Form1";
            this.Text = "Baconator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SeedActorLabel;
        private System.Windows.Forms.Button GetSeedActor;
        private System.Windows.Forms.Label SeparatedActorLabel;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.ComboBox SeparatedActor1;
        private System.Windows.Forms.ComboBox SeedActor1;
        private System.Windows.Forms.Button Initialize;
        private System.Windows.Forms.BindingSource actorBindingSource;
    }
}

