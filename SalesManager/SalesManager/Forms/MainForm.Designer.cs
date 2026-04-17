namespace SalesManager {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip FMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem FFileToolStripMenuItem;
        private System.Windows.Forms.GroupBox FGrpProcessInfo;
        private System.Windows.Forms.Label FLblTargetFile;
        private System.Windows.Forms.Label FLblInputFolder;
        private System.Windows.Forms.Label FLblTargetPeriod;
        private System.Windows.Forms.Label FLblInputFolderPath;
        private System.Windows.Forms.Label FLblTargetFileName;
        private System.Windows.Forms.Label FLblSelectedPeriod;
        private System.Windows.Forms.Label FLblStatus;
        private System.Windows.Forms.Button FBtnRefresh;
        private System.Windows.Forms.Button FBtnExportAggregatedSales;
        private System.Windows.Forms.Panel FPnlBottom;
        private System.Windows.Forms.DataGridView FDgvAggregatedSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColTotalSalesQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColCurrentInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColRemainingInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColRestockStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColTotalSalesAmount;
        private System.Windows.Forms.ToolStripMenuItem FTsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem FTsmiExportAggregatedSales;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FMenuStripMain = new System.Windows.Forms.MenuStrip();
            this.FFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FTsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.FTsmiExportRestock = new System.Windows.Forms.ToolStripMenuItem();
            this.FTsmiExportAggregatedSales = new System.Windows.Forms.ToolStripMenuItem();
            this.FGrpProcessInfo = new System.Windows.Forms.GroupBox();
            this.FLblTargetPeriod = new System.Windows.Forms.Label();
            this.FLblTargetFile = new System.Windows.Forms.Label();
            this.FLblTargetFileName = new System.Windows.Forms.Label();
            this.FLblSelectedPeriod = new System.Windows.Forms.Label();
            this.FLblInputFolderPath = new System.Windows.Forms.Label();
            this.FLblInputFolder = new System.Windows.Forms.Label();
            this.FLblStatus = new System.Windows.Forms.Label();
            this.FBtnRefresh = new System.Windows.Forms.Button();
            this.FBtnExportAggregatedSales = new System.Windows.Forms.Button();
            this.FPnlBottom = new System.Windows.Forms.Panel();
            this.FBtnExportRestock = new System.Windows.Forms.Button();
            this.FDgvAggregatedSales = new System.Windows.Forms.DataGridView();
            this.FColProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColTotalSalesQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColCurrentInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColRemainingInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColRestockStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColTotalSalesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FMenuStripMain.SuspendLayout();
            this.FGrpProcessInfo.SuspendLayout();
            this.FPnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDgvAggregatedSales)).BeginInit();
            this.SuspendLayout();
            // 
            // FMenuStripMain
            // 
            this.FMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FFileToolStripMenuItem});
            this.FMenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.FMenuStripMain.Name = "FMenuStripMain";
            this.FMenuStripMain.Size = new System.Drawing.Size(984, 24);
            this.FMenuStripMain.TabIndex = 0;
            this.FMenuStripMain.Text = "menuStrip1";
            // 
            // FFileToolStripMenuItem
            // 
            this.FFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FTsmiRefresh,
            this.FTsmiExportRestock,
            this.FTsmiExportAggregatedSales});
            this.FFileToolStripMenuItem.Name = "FFileToolStripMenuItem";
            this.FFileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.FFileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // FTsmiRefresh
            // 
            this.FTsmiRefresh.Name = "FTsmiRefresh";
            this.FTsmiRefresh.Size = new System.Drawing.Size(177, 22);
            this.FTsmiRefresh.Text = "再読込(&L)";
            this.FTsmiRefresh.Click += new System.EventHandler(this.FTsmiRefresh_Click);
            // 
            // FTsmiExportRestock
            // 
            this.FTsmiExportRestock.Name = "FTsmiExportRestock";
            this.FTsmiExportRestock.Size = new System.Drawing.Size(177, 22);
            this.FTsmiExportRestock.Text = "発注候補出力(&R)";
            this.FTsmiExportRestock.Click += new System.EventHandler(this.FTsmiExportRestock_Click);
            // 
            // FTsmiExportAggregatedSales
            // 
            this.FTsmiExportAggregatedSales.Name = "FTsmiExportAggregatedSales";
            this.FTsmiExportAggregatedSales.Size = new System.Drawing.Size(177, 22);
            this.FTsmiExportAggregatedSales.Text = "週次報告書出力(&W)";
            this.FTsmiExportAggregatedSales.Click += new System.EventHandler(this.FTsmiExportAggregatedSales_Click);
            // 
            // FGrpProcessInfo
            // 
            this.FGrpProcessInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FGrpProcessInfo.Controls.Add(this.FLblTargetPeriod);
            this.FGrpProcessInfo.Controls.Add(this.FLblTargetFile);
            this.FGrpProcessInfo.Controls.Add(this.FLblTargetFileName);
            this.FGrpProcessInfo.Controls.Add(this.FLblSelectedPeriod);
            this.FGrpProcessInfo.Controls.Add(this.FLblInputFolderPath);
            this.FGrpProcessInfo.Controls.Add(this.FLblInputFolder);
            this.FGrpProcessInfo.Location = new System.Drawing.Point(0, 27);
            this.FGrpProcessInfo.Name = "FGrpProcessInfo";
            this.FGrpProcessInfo.Size = new System.Drawing.Size(984, 97);
            this.FGrpProcessInfo.TabIndex = 1;
            this.FGrpProcessInfo.TabStop = false;
            this.FGrpProcessInfo.Text = "処理ステータス";
            // 
            // FLblTargetPeriod
            // 
            this.FLblTargetPeriod.AutoSize = true;
            this.FLblTargetPeriod.Location = new System.Drawing.Point(12, 71);
            this.FLblTargetPeriod.Name = "FLblTargetPeriod";
            this.FLblTargetPeriod.Size = new System.Drawing.Size(59, 12);
            this.FLblTargetPeriod.TabIndex = 4;
            this.FLblTargetPeriod.Text = "対象期間：";
            // 
            // FLblTargetFile
            // 
            this.FLblTargetFile.AutoSize = true;
            this.FLblTargetFile.Location = new System.Drawing.Point(12, 46);
            this.FLblTargetFile.Name = "FLblTargetFile";
            this.FLblTargetFile.Size = new System.Drawing.Size(69, 12);
            this.FLblTargetFile.TabIndex = 2;
            this.FLblTargetFile.Text = "対象ファイル：";
            // 
            // FLblTargetFileName
            // 
            this.FLblTargetFileName.AutoEllipsis = true;
            this.FLblTargetFileName.AutoSize = true;
            this.FLblTargetFileName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FLblTargetFileName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FLblTargetFileName.Location = new System.Drawing.Point(88, 46);
            this.FLblTargetFileName.Name = "FLblTargetFileName";
            this.FLblTargetFileName.Size = new System.Drawing.Size(96, 12);
            this.FLblTargetFileName.TabIndex = 3;
            this.FLblTargetFileName.Text = "ファイルがありません";
            // 
            // FLblSelectedPeriod
            // 
            this.FLblSelectedPeriod.AutoEllipsis = true;
            this.FLblSelectedPeriod.AutoSize = true;
            this.FLblSelectedPeriod.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FLblSelectedPeriod.Location = new System.Drawing.Point(88, 71);
            this.FLblSelectedPeriod.Name = "FLblSelectedPeriod";
            this.FLblSelectedPeriod.Size = new System.Drawing.Size(11, 12);
            this.FLblSelectedPeriod.TabIndex = 5;
            this.FLblSelectedPeriod.Text = "-";
            // 
            // FLblInputFolderPath
            // 
            this.FLblInputFolderPath.AutoEllipsis = true;
            this.FLblInputFolderPath.AutoSize = true;
            this.FLblInputFolderPath.Location = new System.Drawing.Point(88, 21);
            this.FLblInputFolderPath.Name = "FLblInputFolderPath";
            this.FLblInputFolderPath.Size = new System.Drawing.Size(41, 12);
            this.FLblInputFolderPath.TabIndex = 1;
            this.FLblInputFolderPath.Text = "未設定";
            // 
            // FLblInputFolder
            // 
            this.FLblInputFolder.AutoSize = true;
            this.FLblInputFolder.Location = new System.Drawing.Point(12, 21);
            this.FLblInputFolder.Name = "FLblInputFolder";
            this.FLblInputFolder.Size = new System.Drawing.Size(70, 12);
            this.FLblInputFolder.TabIndex = 0;
            this.FLblInputFolder.Text = "入力フォルダ：";
            // 
            // FLblStatus
            // 
            this.FLblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FLblStatus.AutoEllipsis = true;
            this.FLblStatus.AutoSize = true;
            this.FLblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.FLblStatus.Location = new System.Drawing.Point(12, 19);
            this.FLblStatus.Name = "FLblStatus";
            this.FLblStatus.Size = new System.Drawing.Size(53, 12);
            this.FLblStatus.TabIndex = 0;
            this.FLblStatus.Text = "準備完了";
            // 
            // FBtnRefresh
            // 
            this.FBtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnRefresh.BackColor = System.Drawing.Color.White;
            this.FBtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FBtnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.FBtnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.FBtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FBtnRefresh.Location = new System.Drawing.Point(603, 10);
            this.FBtnRefresh.Name = "FBtnRefresh";
            this.FBtnRefresh.Size = new System.Drawing.Size(121, 30);
            this.FBtnRefresh.TabIndex = 1;
            this.FBtnRefresh.Text = "再読込 (集計更新)";
            this.FBtnRefresh.UseVisualStyleBackColor = false;
            this.FBtnRefresh.Click += new System.EventHandler(this.FBtnRefresh_Click);
            // 
            // FBtnExportAggregatedSales
            // 
            this.FBtnExportAggregatedSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnExportAggregatedSales.BackColor = System.Drawing.Color.LightCyan;
            this.FBtnExportAggregatedSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FBtnExportAggregatedSales.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.FBtnExportAggregatedSales.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FBtnExportAggregatedSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnExportAggregatedSales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FBtnExportAggregatedSales.Location = new System.Drawing.Point(857, 10);
            this.FBtnExportAggregatedSales.Name = "FBtnExportAggregatedSales";
            this.FBtnExportAggregatedSales.Size = new System.Drawing.Size(121, 30);
            this.FBtnExportAggregatedSales.TabIndex = 3;
            this.FBtnExportAggregatedSales.Text = "週次報告書出力";
            this.FBtnExportAggregatedSales.UseVisualStyleBackColor = false;
            this.FBtnExportAggregatedSales.Click += new System.EventHandler(this.FBtnExportAggregatedSales_Click);
            // 
            // FPnlBottom
            // 
            this.FPnlBottom.Controls.Add(this.FBtnExportRestock);
            this.FPnlBottom.Controls.Add(this.FBtnExportAggregatedSales);
            this.FPnlBottom.Controls.Add(this.FBtnRefresh);
            this.FPnlBottom.Controls.Add(this.FLblStatus);
            this.FPnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FPnlBottom.Location = new System.Drawing.Point(0, 511);
            this.FPnlBottom.Name = "FPnlBottom";
            this.FPnlBottom.Size = new System.Drawing.Size(984, 50);
            this.FPnlBottom.TabIndex = 3;
            // 
            // FBtnExportRestock
            // 
            this.FBtnExportRestock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnExportRestock.BackColor = System.Drawing.Color.LightCyan;
            this.FBtnExportRestock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FBtnExportRestock.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.FBtnExportRestock.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FBtnExportRestock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBtnExportRestock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FBtnExportRestock.Location = new System.Drawing.Point(730, 10);
            this.FBtnExportRestock.Name = "FBtnExportRestock";
            this.FBtnExportRestock.Size = new System.Drawing.Size(121, 30);
            this.FBtnExportRestock.TabIndex = 2;
            this.FBtnExportRestock.Text = "発注候補出力";
            this.FBtnExportRestock.UseVisualStyleBackColor = false;
            this.FBtnExportRestock.Click += new System.EventHandler(this.FBtnExportRestock_Click);
            // 
            // FDgvAggregatedSales
            // 
            this.FDgvAggregatedSales.AllowUserToAddRows = false;
            this.FDgvAggregatedSales.AllowUserToDeleteRows = false;
            this.FDgvAggregatedSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FDgvAggregatedSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FDgvAggregatedSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FColProductId,
            this.FColProductName,
            this.FColTotalSalesQuantity,
            this.FColCurrentInventory,
            this.FColRemainingInventory,
            this.FColRestockStatus,
            this.FColTotalSalesAmount});
            this.FDgvAggregatedSales.Location = new System.Drawing.Point(5, 130);
            this.FDgvAggregatedSales.Name = "FDgvAggregatedSales";
            this.FDgvAggregatedSales.ReadOnly = true;
            this.FDgvAggregatedSales.RowTemplate.Height = 21;
            this.FDgvAggregatedSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FDgvAggregatedSales.Size = new System.Drawing.Size(973, 375);
            this.FDgvAggregatedSales.TabIndex = 2;
            // 
            // FColProductId
            // 
            this.FColProductId.DataPropertyName = "ProductId";
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FColProductId.DefaultCellStyle = dataGridViewCellStyle49;
            this.FColProductId.HeaderText = "商品ID";
            this.FColProductId.Name = "FColProductId";
            this.FColProductId.ReadOnly = true;
            // 
            // FColProductName
            // 
            this.FColProductName.DataPropertyName = "ProductName";
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.FColProductName.DefaultCellStyle = dataGridViewCellStyle50;
            this.FColProductName.HeaderText = "商品名";
            this.FColProductName.Name = "FColProductName";
            this.FColProductName.ReadOnly = true;
            // 
            // FColTotalSalesQuantity
            // 
            this.FColTotalSalesQuantity.DataPropertyName = "TotalSoldQuantity";
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle51.Format = "N0";
            dataGridViewCellStyle51.NullValue = null;
            this.FColTotalSalesQuantity.DefaultCellStyle = dataGridViewCellStyle51;
            this.FColTotalSalesQuantity.HeaderText = "合計販売数";
            this.FColTotalSalesQuantity.Name = "FColTotalSalesQuantity";
            this.FColTotalSalesQuantity.ReadOnly = true;
            // 
            // FColCurrentInventory
            // 
            this.FColCurrentInventory.DataPropertyName = "CurrentInventory";
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle52.Format = "N0";
            dataGridViewCellStyle52.NullValue = null;
            this.FColCurrentInventory.DefaultCellStyle = dataGridViewCellStyle52;
            this.FColCurrentInventory.HeaderText = "現在在庫数";
            this.FColCurrentInventory.Name = "FColCurrentInventory";
            this.FColCurrentInventory.ReadOnly = true;
            // 
            // FColRemainingInventory
            // 
            this.FColRemainingInventory.DataPropertyName = "RemainingInventory";
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle53.Format = "N0";
            dataGridViewCellStyle53.NullValue = null;
            this.FColRemainingInventory.DefaultCellStyle = dataGridViewCellStyle53;
            this.FColRemainingInventory.HeaderText = "販売後在庫";
            this.FColRemainingInventory.Name = "FColRemainingInventory";
            this.FColRemainingInventory.ReadOnly = true;
            // 
            // FColRestockStatus
            // 
            this.FColRestockStatus.DataPropertyName = "RestockStatus";
            this.FColRestockStatus.HeaderText = "発注候補";
            this.FColRestockStatus.Name = "FColRestockStatus";
            this.FColRestockStatus.ReadOnly = true;
            // 
            // FColTotalSalesAmount
            // 
            this.FColTotalSalesAmount.DataPropertyName = "TotalSalesAmount";
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle54.Format = "C0";
            dataGridViewCellStyle54.NullValue = null;
            this.FColTotalSalesAmount.DefaultCellStyle = dataGridViewCellStyle54;
            this.FColTotalSalesAmount.HeaderText = "合計売上金額";
            this.FColTotalSalesAmount.Name = "FColTotalSalesAmount";
            this.FColTotalSalesAmount.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.FPnlBottom);
            this.Controls.Add(this.FDgvAggregatedSales);
            this.Controls.Add(this.FGrpProcessInfo);
            this.Controls.Add(this.FMenuStripMain);
            this.MainMenuStrip = this.FMenuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "売上管理・集計";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FMenuStripMain.ResumeLayout(false);
            this.FMenuStripMain.PerformLayout();
            this.FGrpProcessInfo.ResumeLayout(false);
            this.FGrpProcessInfo.PerformLayout();
            this.FPnlBottom.ResumeLayout(false);
            this.FPnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDgvAggregatedSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FBtnExportRestock;
        private System.Windows.Forms.ToolStripMenuItem FTsmiExportRestock;
    }
}

