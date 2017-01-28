namespace DroneVideoReceiver
{
    partial class VideoReceiverForm
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
            this.panelVideo = new System.Windows.Forms.Panel();
            this.richTextBoxParams = new System.Windows.Forms.RichTextBox();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelVideo
            // 
            this.panelVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVideo.AutoSize = true;
            this.panelVideo.BackColor = System.Drawing.SystemColors.MenuText;
            this.panelVideo.Location = new System.Drawing.Point(189, 10);
            this.panelVideo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(607, 404);
            this.panelVideo.TabIndex = 0;
            // 
            // richTextBoxParams
            // 
            this.richTextBoxParams.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBoxParams.Enabled = false;
            this.richTextBoxParams.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxParams.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxParams.Name = "richTextBoxParams";
            this.richTextBoxParams.ReadOnly = true;
            this.richTextBoxParams.Size = new System.Drawing.Size(175, 456);
            this.richTextBoxParams.TabIndex = 1;
            this.richTextBoxParams.Text = "";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStartStop.Location = new System.Drawing.Point(424, 419);
            this.buttonStartStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(138, 46);
            this.buttonStartStop.TabIndex = 2;
            this.buttonStartStop.Text = "Start Video Receiver";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // VideoReceiverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(804, 474);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.richTextBoxParams);
            this.Controls.Add(this.panelVideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VideoReceiverForm";
            this.Text = "SIDUS Video Receiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.RichTextBox richTextBoxParams;
        private System.Windows.Forms.Button buttonStartStop;
    }
}

