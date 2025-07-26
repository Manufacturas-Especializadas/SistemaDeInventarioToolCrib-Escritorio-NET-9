namespace SistemaDeInventarioToolCrib
{
    partial class ToolCrib_Salidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolCrib_Salidas));
            pnTitle = new Panel();
            lbTitle = new Label();
            pictBxLogo = new PictureBox();
            tblPnlMain = new TableLayoutPanel();
            dtGdVwExit = new DataGridView();
            tblPnlNavigation = new TableLayoutPanel();
            btnNext = new Button();
            btnBack = new Button();
            lbPage = new Label();
            tblPnlReset = new TableLayoutPanel();
            btnReset = new Button();
            tblPnlControl = new TableLayoutPanel();
            lbExit = new Label();
            btnEntrance = new Button();
            btnNew = new Button();
            btnDelete = new Button();
            txtBxExit = new TextBox();
            pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictBxLogo).BeginInit();
            tblPnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGdVwExit).BeginInit();
            tblPnlNavigation.SuspendLayout();
            tblPnlReset.SuspendLayout();
            tblPnlControl.SuspendLayout();
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
            pnTitle.TabIndex = 1;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.None;
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Arial", 25F);
            lbTitle.ForeColor = SystemColors.ControlLightLight;
            lbTitle.Location = new Point(271, 19);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(372, 39);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "TOOL CRIB - SALIDAS";
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
            tblPnlMain.Controls.Add(dtGdVwExit, 0, 1);
            tblPnlMain.Controls.Add(tblPnlNavigation, 0, 2);
            tblPnlMain.Controls.Add(tblPnlControl, 0, 0);
            tblPnlMain.Location = new Point(12, 79);
            tblPnlMain.Name = "tblPnlMain";
            tblPnlMain.RowCount = 3;
            tblPnlMain.RowStyles.Add(new RowStyle());
            tblPnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPnlMain.RowStyles.Add(new RowStyle());
            tblPnlMain.Size = new Size(887, 272);
            tblPnlMain.TabIndex = 2;
            // 
            // dtGdVwExit
            // 
            dtGdVwExit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtGdVwExit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGdVwExit.Location = new Point(3, 43);
            dtGdVwExit.Name = "dtGdVwExit";
            dtGdVwExit.Size = new Size(881, 183);
            dtGdVwExit.TabIndex = 1;
            dtGdVwExit.CellEndEdit += dtGdVwExit_CellEndEdit;
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
            // tblPnlControl
            // 
            tblPnlControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblPnlControl.ColumnCount = 5;
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.ColumnStyles.Add(new ColumnStyle());
            tblPnlControl.Controls.Add(lbExit, 0, 0);
            tblPnlControl.Controls.Add(btnEntrance, 2, 0);
            tblPnlControl.Controls.Add(btnNew, 3, 0);
            tblPnlControl.Controls.Add(btnDelete, 4, 0);
            tblPnlControl.Controls.Add(txtBxExit, 1, 0);
            tblPnlControl.Location = new Point(3, 3);
            tblPnlControl.Name = "tblPnlControl";
            tblPnlControl.RowCount = 1;
            tblPnlControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPnlControl.Size = new Size(881, 34);
            tblPnlControl.TabIndex = 0;
            // 
            // lbExit
            // 
            lbExit.Anchor = AnchorStyles.Left;
            lbExit.AutoSize = true;
            lbExit.Font = new Font("Arial", 12F);
            lbExit.Location = new Point(3, 8);
            lbExit.Name = "lbExit";
            lbExit.Size = new Size(69, 18);
            lbExit.TabIndex = 0;
            lbExit.Text = "SALIDA:";
            // 
            // btnEntrance
            // 
            btnEntrance.Anchor = AnchorStyles.Left;
            btnEntrance.BackColor = Color.LightSteelBlue;
            btnEntrance.Cursor = Cursors.Hand;
            btnEntrance.FlatStyle = FlatStyle.Flat;
            btnEntrance.Font = new Font("Arial", 12F);
            btnEntrance.Location = new Point(581, 3);
            btnEntrance.Name = "btnEntrance";
            btnEntrance.Size = new Size(107, 28);
            btnEntrance.TabIndex = 2;
            btnEntrance.Text = "ENTRADAS";
            btnEntrance.UseVisualStyleBackColor = false;
            btnEntrance.Click += btnEntrance_Click;
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
            // txtBxExit
            // 
            txtBxExit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBxExit.Font = new Font("Arial", 12F);
            txtBxExit.Location = new Point(78, 4);
            txtBxExit.Name = "txtBxExit";
            txtBxExit.Size = new Size(497, 26);
            txtBxExit.TabIndex = 1;
            txtBxExit.KeyPress += txtBxExit_KeyPress;
            // 
            // ToolCrib_Salidas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(911, 363);
            Controls.Add(tblPnlMain);
            Controls.Add(pnTitle);
            Name = "ToolCrib_Salidas";
            Text = "ToolCrib_Salidas";
            Load += ToolCrib_Salidas_Load;
            pnTitle.ResumeLayout(false);
            pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictBxLogo).EndInit();
            tblPnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtGdVwExit).EndInit();
            tblPnlNavigation.ResumeLayout(false);
            tblPnlNavigation.PerformLayout();
            tblPnlReset.ResumeLayout(false);
            tblPnlControl.ResumeLayout(false);
            tblPnlControl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTitle;
        private Label lbTitle;
        private PictureBox pictBxLogo;
        private TableLayoutPanel tblPnlMain;
        private DataGridView dtGdVwExit;
        private TableLayoutPanel tblPnlNavigation;
        private Button btnNext;
        private Button btnBack;
        private Label lbPage;
        private TableLayoutPanel tblPnlReset;
        private Button btnReset;
        private TableLayoutPanel tblPnlControl;
        private Label lbExit;
        private Button btnEntrance;
        private Button btnNew;
        private Button btnDelete;
        private TextBox txtBxExit;
    }
}