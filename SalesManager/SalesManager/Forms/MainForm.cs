using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManager.Data;
using SalesManager.Models;
using SalesManager.Services;

namespace SalesManager {
    public partial class MainForm : Form {
        #region フィールド・初期化

        private static readonly string C_InputFolderName = "Input";
        public MainForm() {
            InitializeComponent();
        }

        #endregion

        #region UI操作

        private async Task RefreshData() {
            try {
                FBtnRefresh.Enabled = false;
                FBtnExport.Enabled = false;
                FLblStatus.Text = "データ読み込み中...";

                var wInputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, C_InputFolderName);

                var (wSalesFileName, wTargetPeriod) = await LoadData(wInputFolderPath);
                if (this.IsDisposed || this.Disposing) return;

                FLblStatus.Text = "データ集計中...";

                FDgvAggregatedSales.DataSource = await Task.Run(() => GenerateAggregatedData());

                FLblStatus.Text = "集計完了";
                FBtnExport.Enabled = true;

                FLblInputFolderPath.Text = wInputFolderPath;
                FLblTargetFileName.Text = wSalesFileName;
                FLblSelectedPeriod.Text = wTargetPeriod;
            } catch (Exception ex) {
                MessageBox.Show(this, $"データの読み込みまたは集計に失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FLblStatus.Text = "エラー発生";
            } finally {
                FBtnRefresh.Enabled = true;
            }
        }

        private async Task<(string FFileName, string FPeriod)> LoadData(string vFolderPath) {
            if (!Directory.Exists(vFolderPath)) {
                throw new DirectoryNotFoundException($"入力フォルダが見つかりません。\n以下の場所に「{C_InputFolderName}」フォルダを作成し、csvファイルを配置してください。\n{vFolderPath}");
            }
            return await DataManager.LoadAll(vFolderPath);
        }

        private List<AggregatedSalesModel> GenerateAggregatedData() {
            var wAggregator = new SalesAggregator();
            return wAggregator.Aggregate(DataManager.Sales, DataManager.Products, DataManager.Inventories);
        }

        private void ExportData() {
            try {
                if (!(FDgvAggregatedSales.DataSource is List<AggregatedSalesModel> wResultList) || !wResultList.Any()) {
                    MessageBox.Show(this, "エクスポートするデータがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var wOutputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
                if (!Directory.Exists(wOutputFolderPath)) Directory.CreateDirectory(wOutputFolderPath);

                var wPeriodString = string.IsNullOrEmpty(FLblSelectedPeriod.Text) ? "UnknownPeriod" : FLblSelectedPeriod.Text;

                DataExporter.Export(wResultList, wPeriodString, wOutputFolderPath);

                MessageBox.Show(this, $"出力が完了しました。\n出力先：{wOutputFolderPath}", "エクスポート完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(this, $"データのエクスポートに失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region イベントハンドラ

        private async void MainForm_Load(object sender, EventArgs e) => await RefreshData();
        private async void FBtnRefresh_Click(object sender, EventArgs e) => await RefreshData();
        private void FBtnExport_Click(object sender, EventArgs e) => ExportData();
        private async void FTsmiLoad_Click(object sender, EventArgs e) => await RefreshData();
        private void FTsmiExport_Click(object sender, EventArgs e) => ExportData();

        #endregion
    }
}
