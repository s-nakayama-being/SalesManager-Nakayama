using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManager.Data;
using SalesManager.Models;
using SalesManager.Services;

namespace SalesManager {
    public partial class MainForm : Form {
        #region フィールド・初期化

        private static readonly string C_InputFolderName = "Input";
        private static readonly string C_OutputFolderName = "Output";
        private static readonly string C_ReportSalesName = "週次報告書";
        private static readonly string C_ReportRestockName = "発注候補リスト";

        public MainForm() {
            InitializeComponent();

            typeof(DataManager).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(FDgvAggregatedSales, true, null);
        }

        #endregion

        #region UI操作

        private async Task RefreshData() {
            try {
                FPnlBottom.Enabled = false;
                FBtnExportAggregatedSales.Enabled = false;
                FLblStatus.Text = "データ読み込み中...";

                var wInputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, C_InputFolderName);

                var (wSalesFileName, wDisplayPeriod, wSystemPeriod) = await LoadData(wInputFolderPath);
                if (this.IsDisposed || this.Disposing) return;

                FLblStatus.Text = "データ集計中...";

                FDgvAggregatedSales.DataSource = await Task.Run(() => GenerateAggregatedData());

                FLblStatus.Text = "集計完了";
                FBtnExportAggregatedSales.Enabled = true;

                FLblInputFolderPath.Text = wInputFolderPath;
                FLblTargetFileName.Text = wSalesFileName;
                FLblSelectedPeriod.Text = wDisplayPeriod;
                FLblSelectedPeriod.Tag = wSystemPeriod;
            } catch (Exception ex) {
                MessageBox.Show(this, $"データの読み込みまたは集計に失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FLblStatus.Text = "エラー発生";
            } finally {
                if (!this.IsDisposed && !this.Disposing) {
                    FPnlBottom.Enabled = true;
                    FBtnRefresh.Focus();
                }
            }
        }

        private async Task<(string FFileName, string FDisplayPeriod, string FSystemPeriod)> LoadData(string vFolderPath) {
            if (!Directory.Exists(vFolderPath)) {
                throw new DirectoryNotFoundException($"入力フォルダが見つかりません。\n以下の場所に「{C_InputFolderName}」フォルダを作成し、csvファイルを配置してください。\n{vFolderPath}");
            }
            return await DataManager.LoadAll(vFolderPath);
        }

        private List<AggregatedSalesModel> GenerateAggregatedData() {
            var wAggregator = new SalesAggregator();
            return wAggregator.Aggregate(DataManager.Sales, DataManager.Products, DataManager.Inventories);
        }

        private void ExportData(string vDisplayName, Action<List<AggregatedSalesModel>, string, string> vExportAction) {
            try {
                if (!(FDgvAggregatedSales.DataSource is List<AggregatedSalesModel> wResultList) || !wResultList.Any()) {
                    MessageBox.Show(this, "エクスポートするデータがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var wOutputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, C_OutputFolderName);
                var wPeriodString = FLblSelectedPeriod.Tag as string ?? "UnknownPeriod";

                vExportAction(wResultList, wPeriodString, wOutputFolderPath);

                MessageBox.Show(this, $"{vDisplayName}の出力が完了しました。\n出力先：{wOutputFolderPath}", "エクスポート完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(this, $"データのエクスポートに失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region イベントハンドラ

        private async void MainForm_Load(object sender, EventArgs e) => await RefreshData();
        private async void FBtnRefresh_Click(object sender, EventArgs e) => await RefreshData();
        private void FBtnExportAggregatedSales_Click(object sender, EventArgs e) => ExportData(C_ReportSalesName, DataExporter.ExportAggregatedSales);
        private async void FTsmiRefresh_Click(object sender, EventArgs e) => await RefreshData();
        private void FTsmiExportAggregatedSales_Click(object sender, EventArgs e) => ExportData(C_ReportSalesName, DataExporter.ExportAggregatedSales);
        private void FBtnExportRestock_Click(object sender, EventArgs e) => ExportData(C_ReportRestockName, DataExporter.ExportRestockList);
        private void FTsmiExportRestock_Click(object sender, EventArgs e) => ExportData(C_ReportRestockName, DataExporter.ExportRestockList);

        #endregion
    }
}
