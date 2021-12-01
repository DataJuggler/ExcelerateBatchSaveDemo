

#region using statements


#endregion

namespace DataFields
{

    #region class MainForm
    /// <summary>
    /// This is the designer for the main form for this app.
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl FileBrowser;
        private DataJuggler.Win.Controls.Button LoadDataButton;
        private Label StatusLabel;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
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
            #endregion
            
            #region InitializeComponent()
            /// <summary>
            ///  Required method for Designer support - do not modify
            ///  the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
                this.FileBrowser = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
                this.LoadDataButton = new DataJuggler.Win.Controls.Button();
                this.StatusLabel = new System.Windows.Forms.Label();
                this.SuspendLayout();
                //
                // FileBrowser
                //
                this.FileBrowser.BackColor = System.Drawing.Color.Transparent;
                this.FileBrowser.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
                this.FileBrowser.ButtonColor = System.Drawing.Color.LemonChiffon;
                this.FileBrowser.ButtonImage = ((System.Drawing.Image)(resources.GetObject("FileBrowser.ButtonImage")));
                this.FileBrowser.ButtonWidth = 48;
                this.FileBrowser.DarkMode = false;
                this.FileBrowser.DisabledLabelColor = System.Drawing.Color.Empty;
                this.FileBrowser.Editable = true;
                this.FileBrowser.EnabledLabelColor = System.Drawing.Color.Empty;
                this.FileBrowser.Filter = null;
                this.FileBrowser.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.FileBrowser.HideBrowseButton = false;
                this.FileBrowser.LabelBottomMargin = 0;
                this.FileBrowser.LabelColor = System.Drawing.Color.LemonChiffon;
                this.FileBrowser.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                this.FileBrowser.LabelText = "File:";
                this.FileBrowser.LabelTopMargin = 0;
                this.FileBrowser.LabelWidth = 80;
                this.FileBrowser.Location = new System.Drawing.Point(145, 53);
                this.FileBrowser.Name = "FileBrowser";
                this.FileBrowser.OnTextChangedListener = null;
                this.FileBrowser.OpenCallback = null;
                this.FileBrowser.ScrollBars = System.Windows.Forms.ScrollBars.None;
                this.FileBrowser.SelectedPath = null;
                this.FileBrowser.Size = new System.Drawing.Size(709, 32);
                this.FileBrowser.StartPath = null;
                this.FileBrowser.TabIndex = 0;
                this.FileBrowser.TextBoxBottomMargin = 0;
                this.FileBrowser.TextBoxDisabledColor = System.Drawing.Color.Empty;
                this.FileBrowser.TextBoxEditableColor = System.Drawing.Color.Empty;
                this.FileBrowser.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.FileBrowser.TextBoxTopMargin = 0;
                this.FileBrowser.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
                //
                // LoadDataButton
                //
                this.LoadDataButton.BackColor = System.Drawing.Color.Transparent;
                this.LoadDataButton.ButtonText = "Load Data";
                this.LoadDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.LoadDataButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                this.LoadDataButton.ForeColor = System.Drawing.Color.LemonChiffon;
                this.LoadDataButton.Location = new System.Drawing.Point(696, 167);
                this.LoadDataButton.Margin = new System.Windows.Forms.Padding(4);
                this.LoadDataButton.Name = "LoadDataButton";
                this.LoadDataButton.Size = new System.Drawing.Size(158, 48);
                this.LoadDataButton.TabIndex = 1;
                this.LoadDataButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
                this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
                //
                // label1
                //
                this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
                this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.StatusLabel.ForeColor = System.Drawing.Color.LemonChiffon;
                this.StatusLabel.Location = new System.Drawing.Point(0, 424);
                this.StatusLabel.Name = "label1";
                this.StatusLabel.Size = new System.Drawing.Size(1113, 26);
                this.StatusLabel.TabIndex = 2;
                this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                //
                // MainForm
                //
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackgroundImage = global::DataFields.Properties.Resources.BlackImage;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(1113, 450);
                this.Controls.Add(this.StatusLabel);
                this.Controls.Add(this.LoadDataButton);
                this.Controls.Add(this.FileBrowser);
                this.DoubleBuffered = true;
                this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.Name = "MainForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Main Form";
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
