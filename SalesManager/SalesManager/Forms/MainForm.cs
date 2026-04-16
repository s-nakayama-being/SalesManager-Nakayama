using SalesManager.Data;
using SalesManager.Models;
using SalesManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManager {
    public partial class MainForm : Form {
        #region フィールド・初期化

        private static readonly string C_InputFolderName = "Input";
        public MainForm() {
            InitializeComponent();
        }

        #endregion

        #region UI操作

        private async Task LoadData(string vFolderPath) {
            if (!Directory.Exists(vFolderPath)) {
                throw new DirectoryNotFoundException($"入力フォルダが見つかりません。\n以下の場所に「{C_InputFolderName}」フォルダを作成し、csvファイルを配置してください。\n{vFolderPath}");
            }

            await DataManager.LoadAll(vFolderPath);
        }

        private List<AggregatedSalesModel> GenerateAggregatedData() {
            var wAggregator = new SalesAggregator();
            return wAggregator.Aggregate(DataManager.Sales, DataManager.Products, DataManager.Inventories);
        }


        #endregion

        #region イベントハンドラ

        private async void FBtnRefresh_Click(object sender, EventArgs e) {
            try {
                FBtnExport.Enabled = false;
                FLblStatus.Text = "データ読み込み中...";

                var wInputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, C_InputFolderName);

                await LoadData(wInputFolderPath);
                if (this.IsDisposed || this.Disposing) return;
                FLblStatus.Text = "データ集計中...";

                var wResultList = GenerateAggregatedData();

                var wBindingList = new BindingList<AggregatedSalesModel>(wResultList);

                FLblInputFolderPath.Text = wInputFolderPath;
                FLblTargetFileName.Text = DataManager.ReadSalesFileName;
                FLblSelectedPeriod.Text = DataManager.ReadSalesTargetPeriod;


                FDgvAggregatedSales.DataSource = wBindingList;


                FLblStatus.Text = "集計完了";
            } catch (Exception ex) {
                MessageBox.Show(this, $"データの読み込みまたは集計に失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FLblStatus.Text = "エラー発生";
            }

            FBtnExport.Enabled = true;
        }
        private void FBtnExport_Click(object sender, EventArgs e) {
            try {
                if (!(FDgvAggregatedSales.DataSource is BindingList<AggregatedSalesModel> wBindingList) || wBindingList.Count == 0) {
                    MessageBox.Show(this, "エクスポートするデータがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var wOutputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
                if (!Directory.Exists(wOutputFolderPath)) Directory.CreateDirectory(wOutputFolderPath);

                var wResultList = new List<AggregatedSalesModel>(wBindingList);
                var wPeriodStirng = string.IsNullOrEmpty(DataManager.ReadSalesTargetPeriod) ? "UnknownPeriod" : DataManager.ReadSalesTargetPeriod.Replace("/", "-");

                DataExporter.Export(wResultList, wPeriodStirng, wOutputFolderPath);

                MessageBox.Show(this, $"出力が完了しました。\n出力先：{wOutputFolderPath}", "エクスポート完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(this, $"データのエクスポートに失敗しました：{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
