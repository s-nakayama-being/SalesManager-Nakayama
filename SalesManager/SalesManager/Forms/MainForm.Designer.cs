namespace SalesManager {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.FMenuStripMain = new System.Windows.Forms.MenuStrip();
            this.FFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FGrpProcessInfo = new System.Windows.Forms.GroupBox();
            this.FBtnSelectFolder = new System.Windows.Forms.Button();
            this.FLblTargetPeriod = new System.Windows.Forms.Label();
            this.FLblTargetFile = new System.Windows.Forms.Label();
            this.FLblTargetFileName = new System.Windows.Forms.Label();
            this.lblSelectedPeriod = new System.Windows.Forms.Label();
            this.FLblInputFolderPath = new System.Windows.Forms.Label();
            this.FLblInputFolder = new System.Windows.Forms.Label();
            this.FDgvAggregatedSales = new System.Windows.Forms.DataGridView();
            this.FColProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColTotalSalesQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColCurrentInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColRemainingInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColIsRestockNeeded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColTotalSalesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FPnlBottom = new System.Windows.Forms.Panel();
            this.FBtnExport = new System.Windows.Forms.Button();
            this.FBtnRefresh = new System.Windows.Forms.Button();
            this.FLblStatus = new System.Windows.Forms.Label();
            this.FMenuStripMain.SuspendLayout();
            this.FGrpProcessInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDgvAggregatedSales)).BeginInit();
            this.FPnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // FMenuStripMain
            // 
            this.FMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FFileToolStripMenuItem,
            this.FEditToolStripMenuItem});
            this.FMenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.FMenuStripMain.Name = "FMenuStripMain";
            this.FMenuStripMain.Size = new System.Drawing.Size(984, 24);
            this.FMenuStripMain.TabIndex = 0;
            this.FMenuStripMain.Text = "menuStrip1";
            // 
            // FFileToolStripMenuItem
            // 
            this.FFileToolStripMenuItem.Name = "FFileToolStripMenuItem";
            this.FFileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.FFileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // FEditToolStripMenuItem
            // 
            this.FEditToolStripMenuItem.Name = "FEditToolStripMenuItem";
            this.FEditToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.FEditToolStripMenuItem.Text = "編集(&E)";
            // 
            // FGrpProcessInfo
            // 
            this.FGrpProcessInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FGrpProcessInfo.Controls.Add(this.FBtnSelectFolder);
            this.FGrpProcessInfo.Controls.Add(this.FLblTargetPeriod);
            this.FGrpProcessInfo.Controls.Add(this.FLblTargetFile);
            this.FGrpProcessInfo.Controls.Add(this.FLblTargetFileName);
            this.FGrpProcessInfo.Controls.Add(this.lblSelectedPeriod);
            this.FGrpProcessInfo.Controls.Add(this.FLblInputFolderPath);
            this.FGrpProcessInfo.Controls.Add(this.FLblInputFolder);
            this.FGrpProcessInfo.Location = new System.Drawing.Point(0, 27);
            this.FGrpProcessInfo.Name = "FGrpProcessInfo";
            this.FGrpProcessInfo.Size = new System.Drawing.Size(984, 97);
            this.FGrpProcessInfo.TabIndex = 1;
            this.FGrpProcessInfo.TabStop = false;
            this.FGrpProcessInfo.Text = "処理ステータス";
            // 
            // FBtnSelectFolder
            // 
            this.FBtnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnSelectFolder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FBtnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FBtnSelectFolder.Location = new System.Drawing.Point(868, 18);
            this.FBtnSelectFolder.Name = "FBtnSelectFolder";
            this.FBtnSelectFolder.Size = new System.Drawing.Size(110, 30);
            this.FBtnSelectFolder.TabIndex = 2;
            this.FBtnSelectFolder.Text = "フォルダ設定";
            this.FBtnSelectFolder.UseVisualStyleBackColor = false;
            // 
            // FLblTargetPeriod
            // 
            this.FLblTargetPeriod.AutoSize = true;
            this.FLblTargetPeriod.Location = new System.Drawing.Point(12, 71);
            this.FLblTargetPeriod.Name = "FLblTargetPeriod";
            this.FLblTargetPeriod.Size = new System.Drawing.Size(59, 12);
            this.FLblTargetPeriod.TabIndex = 0;
            this.FLblTargetPeriod.Text = "対象期間：";
            // 
            // FLblTargetFile
            // 
            this.FLblTargetFile.AutoSize = true;
            this.FLblTargetFile.Location = new System.Drawing.Point(12, 46);
            this.FLblTargetFile.Name = "FLblTargetFile";
            this.FLblTargetFile.Size = new System.Drawing.Size(69, 12);
            this.FLblTargetFile.TabIndex = 0;
            this.FLblTargetFile.Text = "対象ファイル：";
            // 
            // FLblTargetFileName
            // 
            this.FLblTargetFileName.AutoEllipsis = true;
            this.FLblTargetFileName.AutoSize = true;
            this.FLblTargetFileName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FLblTargetFileName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FLblTargetFileName.Location = new System.Drawing.Point(88, 46);
            this.FLblTargetFileName.Name = "FLblTargetFileName";
            this.FLblTargetFileName.Size = new System.Drawing.Size(106, 12);
            this.FLblTargetFileName.TabIndex = 0;
            this.FLblTargetFileName.Text = "ファイルがありません";
            // 
            // lblSelectedPeriod
            // 
            this.lblSelectedPeriod.AutoEllipsis = true;
            this.lblSelectedPeriod.AutoSize = true;
            this.lblSelectedPeriod.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSelectedPeriod.Location = new System.Drawing.Point(88, 71);
            this.lblSelectedPeriod.Name = "lblSelectedPeriod";
            this.lblSelectedPeriod.Size = new System.Drawing.Size(12, 12);
            this.lblSelectedPeriod.TabIndex = 0;
            this.lblSelectedPeriod.Text = "-";
            // 
            // FLblInputFolderPath
            // 
            this.FLblInputFolderPath.AutoEllipsis = true;
            this.FLblInputFolderPath.AutoSize = true;
            this.FLblInputFolderPath.Location = new System.Drawing.Point(88, 21);
            this.FLblInputFolderPath.Name = "FLblInputFolderPath";
            this.FLblInputFolderPath.Size = new System.Drawing.Size(41, 12);
            this.FLblInputFolderPath.TabIndex = 0;
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
            this.FColIsRestockNeeded,
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
            this.FColProductId.HeaderText = "商品ID";
            this.FColProductId.Name = "FColProductId";
            this.FColProductId.ReadOnly = true;
            // 
            // FColProductName
            // 
            this.FColProductName.DataPropertyName = "ProductName";
            this.FColProductName.HeaderText = "商品名";
            this.FColProductName.Name = "FColProductName";
            this.FColProductName.ReadOnly = true;
            // 
            // FColTotalSalesQuantity
            // 
            this.FColTotalSalesQuantity.DataPropertyName = "TotalSalesQuantity";
            this.FColTotalSalesQuantity.HeaderText = "合計販売数";
            this.FColTotalSalesQuantity.Name = "FColTotalSalesQuantity";
            this.FColTotalSalesQuantity.ReadOnly = true;
            // 
            // FColCurrentInventory
            // 
            this.FColCurrentInventory.DataPropertyName = "CurrentInventory";
            this.FColCurrentInventory.HeaderText = "現在在庫数";
            this.FColCurrentInventory.Name = "FColCurrentInventory";
            this.FColCurrentInventory.ReadOnly = true;
            // 
            // FColRemainingInventory
            // 
            this.FColRemainingInventory.DataPropertyName = "RemainingInventory";
            this.FColRemainingInventory.HeaderText = "販売後在庫";
            this.FColRemainingInventory.Name = "FColRemainingInventory";
            this.FColRemainingInventory.ReadOnly = true;
            // 
            // FColIsRestockNeeded
            // 
            this.FColIsRestockNeeded.DataPropertyName = "IsRestockNeeded";
            this.FColIsRestockNeeded.HeaderText = "発注候補";
            this.FColIsRestockNeeded.Name = "FColIsRestockNeeded";
            this.FColIsRestockNeeded.ReadOnly = true;
            // 
            // FColTotalSalesAmount
            // 
            this.FColTotalSalesAmount.DataPropertyName = "TotalSalesAmount";
            this.FColTotalSalesAmount.HeaderText = "合計売上金額";
            this.FColTotalSalesAmount.Name = "FColTotalSalesAmount";
            this.FColTotalSalesAmount.ReadOnly = true;
            // 
            // FPnlBottom
            // 
            this.FPnlBottom.Controls.Add(this.FBtnExport);
            this.FPnlBottom.Controls.Add(this.FBtnRefresh);
            this.FPnlBottom.Controls.Add(this.FLblStatus);
            this.FPnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FPnlBottom.Location = new System.Drawing.Point(0, 511);
            this.FPnlBottom.Name = "FPnlBottom";
            this.FPnlBottom.Size = new System.Drawing.Size(984, 50);
            this.FPnlBottom.TabIndex = 3;
            // 
            // FBtnExport
            // 
            this.FBtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnExport.BackColor = System.Drawing.SystemColors.Highlight;
            this.FBtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FBtnExport.ForeColor = System.Drawing.Color.Transparent;
            this.FBtnExport.Location = new System.Drawing.Point(868, 10);
            this.FBtnExport.Name = "FBtnExport";
            this.FBtnExport.Size = new System.Drawing.Size(110, 30);
            this.FBtnExport.TabIndex = 2;
            this.FBtnExport.Text = "週次報告書出力";
            this.FBtnExport.UseVisualStyleBackColor = false;
            // 
            // FBtnRefresh
            // 
            this.FBtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnRefresh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FBtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FBtnRefresh.Location = new System.Drawing.Point(752, 10);
            this.FBtnRefresh.Name = "FBtnRefresh";
            this.FBtnRefresh.Size = new System.Drawing.Size(110, 30);
            this.FBtnRefresh.TabIndex = 2;
            this.FBtnRefresh.Text = "再読込 (集計更新)";
            this.FBtnRefresh.UseVisualStyleBackColor = false;
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
            this.FMenuStripMain.ResumeLayout(false);
            this.FMenuStripMain.PerformLayout();
            this.FGrpProcessInfo.ResumeLayout(false);
            this.FGrpProcessInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDgvAggregatedSales)).EndInit();
            this.FPnlBottom.ResumeLayout(false);
            this.FPnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem FFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FEditToolStripMenuItem;
        private System.Windows.Forms.GroupBox FGrpProcessInfo;
        private System.Windows.Forms.Label FLblTargetFile;
        private System.Windows.Forms.Label FLblInputFolder;
        private System.Windows.Forms.Label FLblTargetPeriod;
        private System.Windows.Forms.Label FLblInputFolderPath;
        private System.Windows.Forms.Label FLblTargetFileName;
        private System.Windows.Forms.Label lblSelectedPeriod;
        private System.Windows.Forms.Button FBtnSelectFolder;
        private System.Windows.Forms.DataGridView FDgvAggregatedSales;
        private System.Windows.Forms.Panel FPnlBottom;
        private System.Windows.Forms.Label FLblStatus;
        private System.Windows.Forms.Button FBtnExport;
        private System.Windows.Forms.Button FBtnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColTotalSalesQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColCurrentInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColRemainingInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColIsRestockNeeded;
        private System.Windows.Forms.DataGridViewTextBoxColumn FColTotalSalesAmount;
    }
}

