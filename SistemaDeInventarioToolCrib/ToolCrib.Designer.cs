namespace SistemaDeInventarioToolCrib
{
    partial class ToolCrib
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolCrib));
            pnTitle = new Panel();
            lbTitle = new Label();
            pictBxLogo = new PictureBox();
            tblPnlMain = new TableLayoutPanel();
            tblPnlControl = new TableLayoutPanel();
            lbEntrance = new Label();
            txtBxEntrance = new TextBox();
            btnExit = new Button();
            btnNew = new Button();
            btnDelete = new Button();
            dtGdVwEntrance = new DataGridView();
            tblPnlNavigation = new TableLayoutPanel();
            btnNext = new Button();
            btnBack = new Button();
            lbPage = new Label();
            tblPnlReset = new TableLayoutPanel();
            btnReset = new Button();
            pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictBxLogo).BeginInit();
            tblPnlMain.SuspendLayout();
            tblPnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGdVwEntrance).BeginInit();
            tblPnlNavigation.SuspendLayout();
            tblPnlReset.SuspendLayout();
            SuspendLayout();
            // 
            // pnTitle
            // 
            pnTitle.BackColor = Color.FromArgb(94, 167, 189);
            pnTitle.Controls.Add(lbTitle);
            pnTitle.Controls.Add(pictBxLogo);
            pnTitle.Dock = DockStyle.Top;
            pnTitle.Location = new Point(0, 0);
            pnTitle.Name = "pnTitle";
            pnTitle.Size = new Size(911, 73);
            pnTitle.TabIndex = 0;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.None;
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Arial", 25F);
            lbTitle.ForeColor = SystemColors.ControlLightLight;
            lbTitle.Location = new Point(278, 20);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(424, 39);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "TOOL CRIB - ENTRADAS ";
            // 
            // pictBxLogo
            // 
            pictBxLogo.Image = (Image)resources.GetObject("pictBxLogo.Image");
            pictBxLogo.Location = new Point(3, 3);
            pictBxLogo.Name = "pictBxLogo";
            pictBxLogo.Size = new Size(116, 68);
            pictBxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictBxLogo.TabIndex = 0;
            pictBxLogo.TabStop = false;
            // 
            // tblPnlMain
            // 
            tblPnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblPnlMain.ColumnCount = 1;
            tblPnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPnlMain.Controls.Add(tblPnlControl, 0, 0);
            tblPnlMain.Controls.Add(dtGdVwEntrance, 0, 1);
            tblPnlMain.Controls.Add(tblPnlNavigation, 0, 2);
            tblPnlMain.Location = new Point(12, 79);
            tblPnlMain.Name = "tblPnlMain";
            tblPnlMain.RowCount = 3;
            tblPnlMain.RowStyles.Add(new RowStyle());
            tblPnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPnlMain.RowStyles.Add(new RowStyle());
            tblPnlMain.Size = new Size(887, 272);
            tblPnlMain.TabIndex = 1;
            // 
            // tblPnlControl
            // 
            tblPnlControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblPnlControl.ColumnCount = 5;
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.Controls.Add(lbEntrance, 0, 0);
            tblPnlControl.Controls.Add(txtBxEntrance, 1, 0);
            tblPnlControl.Controls.Add(btnExit, 2, 0);
            tblPnlControl.Controls.Add(btnNew, 3, 0);
            tblPnlControl.Controls.Add(btnDelete, 4, 0);
            tblPnlControl.Location = new Point(3, 3);
            tblPnlControl.Name = "tblPnlControl";
            tblPnlControl.RowCount = 1;
            tblPnlControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPnlControl.Size = new Size(881, 34);
            tblPnlControl.TabIndex = 0;
            // 
            // lbEntrance
            // 
            lbEntrance.Anchor = AnchorStyles.Left;
            lbEntrance.AutoSize = true;
            lbEntrance.Font = new Font("Arial", 12F);
            lbEntrance.Location = new Point(3, 8);
            lbEntrance.Name = "lbEntrance";
            lbEntrance.Size = new Size(88, 18);
            lbEntrance.TabIndex = 0;
            lbEntrance.Text = "ENTRADA:";
            // 
            // txtBxEntrance
            // 
            txtBxEntrance.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBxEntrance.Font = new Font("Arial", 12F);
            txtBxEntrance.Location = new Point(97, 4);
            txtBxEntrance.Name = "txtBxEntrance";
            txtBxEntrance.Size = new Size(500, 26);
            txtBxEntrance.TabIndex = 1;
            txtBxEntrance.KeyPress += txtBxEntrance_KeyPress;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Left;
            btnExit.BackColor = Color.LightSteelBlue;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial", 12F);
            btnExit.Location = new Point(603, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(85, 26);
            btnExit.TabIndex = 2;
            btnExit.Text = "SALIDA";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Left;
            btnNew.BackColor = Color.LightSteelBlue;
            btnNew.Cursor = Cursors.Hand;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Arial", 12F);
            btnNew.Location = new Point(694, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 27);
            btnNew.TabIndex = 3;
            btnNew.Text = "NUEVO";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Left;
            btnDelete.BackColor = Color.LightSteelBlue;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial", 12F);
            btnDelete.Location = new Point(775, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 25);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "ELIMINAR";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dtGdVwEntrance
            // 
            dtGdVwEntrance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtGdVwEntrance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGdVwEntrance.Location = new Point(3, 43);
            dtGdVwEntrance.Name = "dtGdVwEntrance";
            dtGdVwEntrance.Size = new Size(881, 183);
            dtGdVwEntrance.TabIndex = 1;
            dtGdVwEntrance.CellEndEdit += dtGdVwEntrance_CellEndEdit;
            // 
            // tblPnlNavigation
            // 
            tblPnlNavigation.Anchor = AnchorStyles.Left;
            tblPnlNavigation.ColumnCount = 4;
            tblPnlNavigation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPnlNavigation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPnlNavigation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            tblPnlNavigation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 620F));
            tblPnlNavigation.Controls.Add(btnNext, 1, 0);
            tblPnlNavigation.Controls.Add(btnBack, 0, 0);
            tblPnlNavigation.Controls.Add(lbPage, 2, 0);
            tblPnlNavigation.Controls.Add(tblPnlReset, 3, 0);
            tblPnlNavigation.Location = new Point(3, 232);
            tblPnlNavigation.Name = "tblPnlNavigation";
            tblPnlNavigation.RowCount = 1;
            tblPnlNavigation.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPnlNavigation.Size = new Size(881, 37);
            tblPnlNavigation.TabIndex = 2;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Left;
            btnNext.BackColor = Color.LightSteelBlue;
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Arial", 10F);
            btnNext.Location = new Point(90, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(81, 26);
            btnNext.TabIndex = 1;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Left;
            btnBack.BackColor = Color.LightSteelBlue;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Arial", 10F);
            btnBack.Location = new Point(3, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(81, 26);
            btnBack.TabIndex = 0;
            btnBack.Text = "<<";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lbPage
            // 
            lbPage.Anchor = AnchorStyles.Left;
            lbPage.AutoSize = true;
            lbPage.Font = new Font("Arial", 10F);
            lbPage.Location = new Point(177, 10);
            lbPage.Name = "lbPage";
            lbPage.Size = new Size(51, 16);
            lbPage.TabIndex = 2;
            lbPage.Text = "Pagina";
            // 
            // tblPnlReset
            // 
            tblPnlReset.Anchor = AnchorStyles.Right;
            tblPnlReset.ColumnCount = 2;
            tblPnlReset.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPnlReset.ColumnStyles.Add(new ColumnStyle());
            tblPnlReset.Controls.Add(btnReset, 1, 0);
            tblPnlReset.Location = new Point(263, 3);
            tblPnlReset.Name = "tblPnlReset";
            tblPnlReset.RowCount = 1;
            tblPnlReset.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPnlReset.Size = new Size(615, 31);
            tblPnlReset.TabIndex = 3;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Right;
            btnReset.BackColor = Color.LightSteelBlue;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Arial", 10F);
            btnReset.Location = new Point(510, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(102, 25);
            btnReset.TabIndex = 2;
            btnReset.Text = "REINICIAR";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // ToolCrib
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(911, 363);
            Controls.Add(tblPnlMain);
            Controls.Add(pnTitle);
            Name = "ToolCrib";
            Text = "ToolCrib";
            Load += ToolCrib_Load;
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictBxLogo).EndInit();
            tblPnlMain.ResumeLayout(false);
            tblPnlControl.ResumeLayout(false);
            tblPnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGdVwEntrance).EndInit();
            tblPnlNavigation.ResumeLayout(false);
            tblPnlNavigation.PerformLayout();
            tblPnlReset.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTitle;
        private PictureBox pictBxLogo;
        private Label lbTitle;
        private TableLayoutPanel tblPnlMain;
        private TableLayoutPanel tblPnlControl;
        private Label lbEntrance;
        private TextBox txtBxEntrance;
        private Button btnExit;
        private Button btnNew;
        private Button btnDelete;
        private DataGridView dtGdVwEntrance;
        private TableLayoutPanel tblPnlNavigation;
        private Button btnBack;
        private Button btnNext;
        private Label lbPage;
        private TableLayoutPanel tblPnlReset;
        private Button btnReset;
    }
}
