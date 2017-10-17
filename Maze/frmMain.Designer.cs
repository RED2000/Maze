namespace MazeGen
{
    partial class frmMain
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
      this.pnlCon = new System.Windows.Forms.Panel();
      this.picVisual = new System.Windows.Forms.PictureBox();
      this.cmsSave = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnGenerate = new System.Windows.Forms.Button();
      this.btnUp = new System.Windows.Forms.Button();
      this.btnLeft = new System.Windows.Forms.Button();
      this.btnRight = new System.Windows.Forms.Button();
      this.btnDown = new System.Windows.Forms.Button();
      this.btnSolve = new System.Windows.Forms.Button();
      this.txtWidth = new System.Windows.Forms.TextBox();
      this.txtHeight = new System.Windows.Forms.TextBox();
      this.lblWin = new System.Windows.Forms.Label();
      this.pnlCon.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picVisual)).BeginInit();
      this.cmsSave.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlCon
      // 
      this.pnlCon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlCon.AutoScroll = true;
      this.pnlCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlCon.Controls.Add(this.picVisual);
      this.pnlCon.Location = new System.Drawing.Point(191, 18);
      this.pnlCon.Name = "pnlCon";
      this.pnlCon.Size = new System.Drawing.Size(325, 171);
      this.pnlCon.TabIndex = 2;
      // 
      // picVisual
      // 
      this.picVisual.ContextMenuStrip = this.cmsSave;
      this.picVisual.Location = new System.Drawing.Point(3, 3);
      this.picVisual.Name = "picVisual";
      this.picVisual.Size = new System.Drawing.Size(246, 142);
      this.picVisual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.picVisual.TabIndex = 1;
      this.picVisual.TabStop = false;
      // 
      // cmsSave
      // 
      this.cmsSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
      this.cmsSave.Name = "cmsSave";
      this.cmsSave.Size = new System.Drawing.Size(68, 26);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(27, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(44, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "Width : ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(27, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Height : ";
      // 
      // btnGenerate
      // 
      this.btnGenerate.Location = new System.Drawing.Point(30, 84);
      this.btnGenerate.Name = "btnGenerate";
      this.btnGenerate.Size = new System.Drawing.Size(155, 39);
      this.btnGenerate.TabIndex = 12;
      this.btnGenerate.Text = "Generate";
      this.btnGenerate.UseVisualStyleBackColor = true;
      this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
      // 
      // btnUp
      // 
      this.btnUp.Location = new System.Drawing.Point(598, 47);
      this.btnUp.Name = "btnUp";
      this.btnUp.Size = new System.Drawing.Size(22, 21);
      this.btnUp.TabIndex = 21;
      this.btnUp.Text = "W";
      this.btnUp.UseVisualStyleBackColor = true;
      this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
      // 
      // btnLeft
      // 
      this.btnLeft.Location = new System.Drawing.Point(561, 74);
      this.btnLeft.Name = "btnLeft";
      this.btnLeft.Size = new System.Drawing.Size(22, 21);
      this.btnLeft.TabIndex = 22;
      this.btnLeft.Text = "A";
      this.btnLeft.UseVisualStyleBackColor = true;
      this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
      // 
      // btnRight
      // 
      this.btnRight.Location = new System.Drawing.Point(638, 74);
      this.btnRight.Name = "btnRight";
      this.btnRight.Size = new System.Drawing.Size(22, 21);
      this.btnRight.TabIndex = 23;
      this.btnRight.Text = "D";
      this.btnRight.UseVisualStyleBackColor = true;
      this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
      // 
      // btnDown
      // 
      this.btnDown.Location = new System.Drawing.Point(598, 102);
      this.btnDown.Name = "btnDown";
      this.btnDown.Size = new System.Drawing.Size(22, 21);
      this.btnDown.TabIndex = 24;
      this.btnDown.Text = "S";
      this.btnDown.UseVisualStyleBackColor = true;
      this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
      // 
      // btnSolve
      // 
      this.btnSolve.Location = new System.Drawing.Point(581, 145);
      this.btnSolve.Name = "btnSolve";
      this.btnSolve.Size = new System.Drawing.Size(51, 19);
      this.btnSolve.TabIndex = 25;
      this.btnSolve.Text = "Solve";
      this.btnSolve.UseVisualStyleBackColor = true;
      this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
      // 
      // txtWidth
      // 
      this.txtWidth.Location = new System.Drawing.Point(77, 15);
      this.txtWidth.Name = "txtWidth";
      this.txtWidth.Size = new System.Drawing.Size(26, 20);
      this.txtWidth.TabIndex = 26;
      // 
      // txtHeight
      // 
      this.txtHeight.Location = new System.Drawing.Point(77, 44);
      this.txtHeight.Name = "txtHeight";
      this.txtHeight.Size = new System.Drawing.Size(26, 20);
      this.txtHeight.TabIndex = 27;
      // 
      // lblWin
      // 
      this.lblWin.AutoSize = true;
      this.lblWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblWin.ForeColor = System.Drawing.Color.OrangeRed;
      this.lblWin.Location = new System.Drawing.Point(53, 145);
      this.lblWin.Name = "lblWin";
      this.lblWin.Size = new System.Drawing.Size(91, 37);
      this.lblWin.TabIndex = 28;
      this.lblWin.Text = "Win!!";
      this.lblWin.Visible = false;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(710, 244);
      this.Controls.Add(this.lblWin);
      this.Controls.Add(this.txtHeight);
      this.Controls.Add(this.txtWidth);
      this.Controls.Add(this.btnSolve);
      this.Controls.Add(this.btnDown);
      this.Controls.Add(this.btnRight);
      this.Controls.Add(this.btnLeft);
      this.Controls.Add(this.btnUp);
      this.Controls.Add(this.btnGenerate);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pnlCon);
      this.Name = "frmMain";
      this.Text = "Maze ";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.pnlCon.ResumeLayout(false);
      this.pnlCon.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picVisual)).EndInit();
      this.cmsSave.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCon;
        private System.Windows.Forms.PictureBox picVisual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ContextMenuStrip cmsSave;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.Button btnUp;
    private System.Windows.Forms.Button btnLeft;
    private System.Windows.Forms.Button btnRight;
    private System.Windows.Forms.Button btnDown;
    private System.Windows.Forms.Button btnSolve;
    private System.Windows.Forms.TextBox txtWidth;
    private System.Windows.Forms.TextBox txtHeight;
    private System.Windows.Forms.Label lblWin;
  }
}

