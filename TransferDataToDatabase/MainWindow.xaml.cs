using System.Windows.Forms;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.Configuration;
using TransferDataToDatabase.Common.Security;
using TransferDataToDatabase.Common.String;
using TransferDataToDatabase.Common.Sql;

namespace TransferDataToDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeObjects();
        }

        // ••••••••••••
        // DEFINATIONS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region Objects

        private object _lockerConnectAndLoadData;
        private DataTable _dataTableQueue;
        private OpenFileDialog _openFileDialog;
        private FolderBrowserDialog _folderBrowserDialog;

        #endregion

        #region Variables

        private int _countOfRows;
        private string _errorMessage, _publicConnectionString, _fileName, _sheetName;

        #endregion

        #region Classes

        #endregion

        // ••••••••••••
        // METHODS     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region private void InitializeObjects()
        private void InitializeObjects()
        {
            _lockerConnectAndLoadData = new object();
            _openFileDialog = new OpenFileDialog();
        }

        #endregion

        #region private void LoadDefaults()
        private void LoadDefaults()
        {
            _publicConnectionString = ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString;
            RadioButtonExcel.IsChecked = true;
        }

        #endregion

        #region private void LoadDataFromExcel()
        private void LoadDataFromExcel()
        {
            try
            {
                lock (_lockerConnectAndLoadData)
                {
                    var connectionString = "";
                    Dispatcher.Invoke(() =>
                    {
                        connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBlockPath.Text + ";Extended Properties=\"Excel 12.0;\"";
                        _fileName = TextBlockPath.Text.Substring(TextBlockPath.Text.LastIndexOf("\\") + 1, 13);
                    });
                    var excelConnection = new OleDbConnection(connectionString);
                    excelConnection.Open();

                    var dataTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dataTable == null) return;
                    var sheetName = dataTable.Rows[0]["Table_Name"].ToString();
                    //_sheetName = sheetName.Replace("'", "").Substring(0, 13);

                    _dataTableQueue = new DataTable();
                    var excelCommand = new OleDbDataAdapter(" SELECT * FROM [" + sheetName + "]", excelConnection);
                    excelCommand.Fill(_dataTableQueue);
                    _countOfRows = _dataTableQueue.Rows.Count;

                    Dispatcher.Invoke(() =>
                    {
                        TextBlockDescription.Text = "Loading Data Completed";
                        ProgressBarTransfer.Visibility = Visibility.Collapsed;
                        ButtonTransfer.IsEnabled = true;
                        ButtonConnectAndLoadData.IsEnabled = false;
                    });
                }
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region private void LoadDataFromSql()
        private void LoadDataFromSql()
        {
            lock (_lockerConnectAndLoadData)
            {
                try
                {
                    var connection = new SqlConnection(_publicConnectionString);
                    connection.Open();

                    var commandSourceCount = new SqlCommand("SELECT COUNT (*) FROM Temp", connection);
                    _countOfRows = Convert.ToInt32(commandSourceCount.ExecuteScalar());

                    _dataTableQueue = new DataTable();
                    var sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Temp " +
                                                            "ORDER BY Id",
                    connection);
                    sqlDataAdapter.Fill(_dataTableQueue);
                    Dispatcher.Invoke(() =>
                    {
                        TextBlockDescription.Text = "Loading Data Completed";
                        ProgressBarTransfer.Visibility = Visibility.Collapsed;
                        ButtonTransfer.IsEnabled = true;
                        ButtonConnectAndLoadData.IsEnabled = false;
                    });
                }
                catch (Exception exception)
                {
                    _errorMessage = exception.Message;
                    System.Windows.MessageBox.Show(_errorMessage, "Error");
                }
            }
        }
        #endregion

        #region private void TransferData()
        private void TransferData()
        {
            int insertedRows = 0, currentId = 1;
            using (var connection = new SqlConnection(_publicConnectionString))
            {
                try
                {
                    connection.Open();
                    var transactionCommand = new SqlCommand { Connection = connection };

                    var keyTrans = 1;
                    foreach (DataRow dataRow in _dataTableQueue.Rows)
                    {
                        // The Sepehr Version

                        //currentId = Convert.ToInt32(dataRow["رديف"]);
                        //Dispatcher.Invoke(() =>
                        //{
                        //    TextBlockDescription.Text = $"Transferring data ... {Environment.NewLine} {currentId} of  {_countOfRows} rows processing {Environment.NewLine} This queue contains {_dataTableQueue.Rows.Count} rows";
                        //});
                        //var transactionInfo = new object[]
                        //    {
                        //        _sheetName,
                        //        keyTrans++ + "-" + _sheetName + "-" + Math.Abs(Convert.ToInt64(dataRow["برداشت"].ToString() == "0" ? dataRow["واريز"] : dataRow["برداشت"])).ToString() + "-" + Math.Abs(Convert.ToInt64(dataRow["مانده"])).ToString(),
                        //        "ACH1",
                        //        "02",
                        //        dataRow["برداشت"].ToString() == "0" ? Math.Abs(Convert.ToInt64(dataRow["واريز"])) : Math.Abs(Convert.ToInt64(dataRow["برداشت"]) * (-1)),
                        //        Convert.ToInt64(dataRow["مانده"]),
                        //        dataRow["برداشت"].ToString() == "0" ? "C" : "D",
                        //        dataRow["کد شعبه"].ToString(),
                        //        $"{Convert.ToInt32(dataRow["شرح تراکنش"]):000}",
                        //        "Admin", //dataRow["کد کاربری"].ToString(),
                        //        $"{Convert.ToDateTime(dataRow["ساعت"]):HH:mm:ss}",
                        //        dataRow["تاريخ"].ToString(),
                        //        dataRow["فيش / حواله"].ToString().ToCorrectKeYe(),
                        //        dataRow["اطلاعات اضافي (کد سهامداري، وارد کننده###)"].ToString().ToCorrectKeYe(),
                        //        "".ToEncryptData(),
                        //        1,
                        //        DateTime.Now,
                        //        1,
                        //        DateTime.Now
                        //    };


                        // The Other Version

                        currentId = 1;
                        Dispatcher.Invoke(() =>
                        {
                            TextBlockDescription.Text = $"Transferring data ... {Environment.NewLine} {currentId} of  {_countOfRows} rows processing {Environment.NewLine} This queue contains {_dataTableQueue.Rows.Count} rows";
                        });
                        var transactionInfo = new object[]
                            {
                                $"{Convert.ToInt64(dataRow["شماره حساب"]):0000000000000}",
                                keyTrans++ + "-" + dataRow["شماره حساب"] + "-" + Convert.ToInt64(dataRow["مبلغ تراکنش"]) + "-" + "0",
                                "ACH1",
                                "02",
                                Convert.ToInt64(dataRow["مبلغ تراکنش"]),
                                "0",
                                dataRow["نوع تراکنش"],
                                dataRow["کد شعبه"].ToString(),
                                $"{Convert.ToInt32(dataRow["توصیف تراکنش"]):000}",
                                dataRow["کد کاربر"].ToString(),
                                $"{Convert.ToInt32(dataRow["زمان تراکنش"]):00:00:00}",
                                Convert.ToInt32(dataRow["تاریخ تراکنش"]).ToString("####/##/##"),
                                dataRow["اطلاعات اضافی 1"].ToString().ToCorrectKeYe(),
                                dataRow["اطلاعات اضافی 2"].ToString().ToCorrectKeYe(),
                                "".ToEncryptData(),
                                1,
                                DateTime.Now,
                                1,
                                DateTime.Now
                            };
                        if (connection.InsertSqlUnique("Transactions", transactionInfo))
                        {
                            insertedRows++;
                        }
                    }
                }
                catch (Exception exception)
                {
                    _errorMessage = exception.Message + " & CurrentId = " + currentId;
                    System.Windows.MessageBox.Show(_errorMessage, "Error");
                }

            }
            Dispatcher.Invoke(() =>
            {
                TextBlockDescription.Text = "Transfer Data Completed" + "\n" +
                                            "Count of all rows in this queue: " + _dataTableQueue.Rows.Count + " rows" + "\n" +
                                            "Count of inserted rows: " + insertedRows + " rows";
                ProgressBarTransfer.Visibility = Visibility.Collapsed;
            });
        }

        #endregion

        // ••••••••••••
        // EVENTS       ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region Window_Events

        #region MainWindow_Loaded
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDefaults();
        }
        #endregion

        #region MainWindow_Closing
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        #endregion

        #endregion

        #region RadioButton_Events

        #region RadioButtonExcel_Checked
        private void RadioButtonExcel_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockDescription.Text = "";
            ButtonConnectAndLoadData.IsEnabled = true;
            ButtonBrowse.IsEnabled = true;
            TextBlockPath.Text = "Browse Excel File";
        }

        #endregion

        #region RadioButtonSql_Checked
        private void RadioButtonSql_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockDescription.Text = "";
            ButtonConnectAndLoadData.IsEnabled = true;
            ButtonBrowse.IsEnabled = false;
            TextBlockPath.Text = "";
        }

        #endregion

        #region RadioButtonText_Checked
        private void RadioButtonText_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockDescription.Text = "";
            ButtonConnectAndLoadData.IsEnabled = true;
            ButtonBrowse.IsEnabled = true;
            TextBlockPath.Text = "Select Text Folder";
        }

        #endregion

        #endregion

        #region Button_Events

        #region ButtonBrowse_Click
        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonExcel.IsChecked == true)
            {
                _openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                _openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                _openFileDialog.Title = "Please select bank excel file to transfer.";
                _openFileDialog.ShowDialog();
                TextBlockPath.Text = _openFileDialog.FileName;
            }
            else if (RadioButtonText.IsChecked == true)
            {
                _folderBrowserDialog = new FolderBrowserDialog();
                _folderBrowserDialog.ShowDialog();
                TextBlockPath.Text = _folderBrowserDialog.SelectedPath;
            }
        }

        #endregion

        #region ButtonConnectAndLoadData_Click
        private void ButtonConnectAndLoadData_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonExcel.IsChecked == true)
            {
                if (TextBlockPath.Text == "Browse Excel File")
                {
                    TextBlockDescription.Text = "Please browse an excel file";
                    return;
                }
                var threadLoadDataFromExcel = new Thread(LoadDataFromExcel);
                threadLoadDataFromExcel.Start();
                ProgressBarTransfer.Visibility = Visibility.Visible;
                TextBlockDescription.Text = "Loading data ...";
            }
            else if (RadioButtonSql.IsChecked == true)
            {
                var threadLoadDataFromSql = new Thread(LoadDataFromSql);
                threadLoadDataFromSql.Start();
                ProgressBarTransfer.Visibility = Visibility.Visible;
                TextBlockDescription.Text = "Loading data ...";
            }
            else if (RadioButtonText.IsChecked == true)
            {

            }
        }

        #endregion

        #region ButtonTransfer_Click
        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            var threadTransferData = new Thread(TransferData);
            threadTransferData.Start();
            ProgressBarTransfer.Visibility = Visibility.Visible;
            ButtonTransfer.IsEnabled = false;
        }

        #endregion

        #endregion
    }
}
