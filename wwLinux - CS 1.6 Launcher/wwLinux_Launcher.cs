using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wwLinux_Launcher
{
    public partial class wwLinux_Launcher : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public string AppCurrentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
        public string AppOfficialSite = "www.wwlinux.uz";

        internal static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new wwLinux_Launcher());
            }
        }

        public wwLinux_Launcher()
        {
            InitializeComponent();
            FontsInstall();
            PreIndex();
            AutoHZ("hz");
            SetAppVersion();
        }

        void RunProgram(string programExe, string programArgument)
        {
            try
            {
                if (File.Exists(programExe))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = programExe;
                    process.StartInfo.Arguments = programArgument;
                    process.Start();
                }
                else
                {
                    MessageBox.Show("Файл не найдена: " + programExe);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }
        void PreIndex()
        {
            CheckResolution.SelectedIndex = 0;
            CheckHz.SelectedIndex = 0;
        }

        void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void wwlinuxLogo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        static void ReplaceTextInConfigFiles()
        {
            try
            {
                string directoryPath = @"cstrike";
                string oldText = "fps_max \"101\"";

                string[] files = Directory.GetFiles(directoryPath, "*.cfg");

                foreach (string file in files)
                {
                    if (new FileInfo(file).IsReadOnly == false)
                    {
                        string content = File.ReadAllText(file);

                        if (content.Contains(oldText))
                        {
                            content = content.Replace(oldText, string.Empty);
                            File.WriteAllText(file, content);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }

        static void UnReplaceTextInConfigFiles()
        {
            try
            { 
                string directoryPath = @"cstrike";
                string oldText = "fps_max \"101\"";
                string newText = "fps_max \"101\"";

                string[] files = Directory.GetFiles(directoryPath, "*.cfg");

            
                foreach (string file in files)
                {
                    if (new FileInfo(file).IsReadOnly == false)
                    {
                        string content = File.ReadAllText(file);

                        if (!content.Contains(oldText))
                        {
                            content += "\n" + newText;
                            File.WriteAllText(file, content);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }

        string AutoHZ(string video)
        {
            string vendor = "Unknown";
            string refreshRate = "60";

            try
            {
                // Get vendor
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "wmic";
                    process.StartInfo.Arguments = "PATH WIN32_VIDEOCONTROLLER GET Name /VALUE";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    foreach (var line in output.Split('\n'))
                    {
                        if (line.StartsWith("Name="))
                        {
                            vendor = line.Split('=')[1].Trim();
                            break;
                        }
                    }
                }

                // Get Max RefreshRate
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "wmic";
                    process.StartInfo.Arguments = "PATH WIN32_VIDEOCONTROLLER GET MaxRefreshRate /VALUE";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    foreach (var line in output.Split('\n'))
                    {
                        if (line.StartsWith("MaxRefreshRate="))
                        {
                            refreshRate = line.Split('=')[1].Trim();
                            break;
                        }
                    }
                }

                /* "56", "59", "60", "75", "100", "120", "144", "165", "180",
                "200", "240", "280", "300", "360", "380", "400", "480", "500",
                "580", "600" */

                switch (refreshRate)
                {
                    case "56":
                    case "59":
                    case "60":
                    case "61":
                    case "64":
                        refreshRate = "60";
                        CheckHz.SelectedIndex = 0;
                        break;
                    case "74":
                    case "75":
                    case "76":
                        refreshRate = "75";
                        CheckHz.SelectedIndex = 1;
                        break;
                    case "99":
                    case "100":
                    case "101":
                        refreshRate = "100";
                        CheckHz.SelectedIndex = 2;
                        break;
                    case "119":
                    case "120":
                    case "121":
                        refreshRate = "120";
                        CheckHz.SelectedIndex = 3;
                        break;
                    case "143":
                    case "144":
                    case "145":
                        refreshRate = "144";
                        CheckHz.SelectedIndex = 4;
                        break;
                    case "164":
                    case "165":
                    case "166":
                        refreshRate = "165";
                        CheckHz.SelectedIndex = 5;
                        break;
                    case "179":
                    case "180":
                    case "181":
                        refreshRate = "180";
                        CheckHz.SelectedIndex = 6;
                        break;
                    case "199":
                    case "200":
                    case "201":
                        refreshRate = "200";
                        CheckHz.SelectedIndex = 7;
                        break;
                    case "239":
                    case "240":
                    case "241":
                        refreshRate = "240";
                        CheckHz.SelectedIndex = 8;
                        break;
                    case "279":
                    case "280":
                    case "281":
                        refreshRate = "280";
                        CheckHz.SelectedIndex = 9;
                        break;
                    case "299":
                    case "300":
                    case "301":
                        refreshRate = "300";
                        CheckHz.SelectedIndex = 10;
                        break;
                    case "359":
                    case "360":
                    case "361":
                        refreshRate = "360";
                        CheckHz.SelectedIndex = 11;
                        break;
                    case "379":
                    case "380":
                    case "381":
                        refreshRate = "380";
                        CheckHz.SelectedIndex = 12;
                        break;
                    case "399":
                    case "400":
                    case "401":
                        refreshRate = "400";
                        CheckHz.SelectedIndex = 13;
                        break;
                    case "479":
                    case "480":
                    case "481":
                        refreshRate = "480";
                        CheckHz.SelectedIndex = 14;
                        break;
                    case "499":
                    case "500":
                    case "501":
                        refreshRate = "500";
                        CheckHz.SelectedIndex = 15;
                        break;
                    case "579":
                    case "580":
                    case "581":
                        refreshRate = "580";
                        CheckHz.SelectedIndex = 16;
                        break;
                    case "599":
                    case "600":
                    case "601":
                        refreshRate = "600";
                        CheckHz.SelectedIndex = 17;
                        break;
                    default:
                        refreshRate = refreshRate;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.ToString()}");
            }

            return video == "hz" ? refreshRate : vendor;

        }

        string SelectedResolution(string selectItem)
        {
            string resolution = "";
            string hz = "";

            for (int i = 0; i < CheckResolution.SelectedItem.ToString().Length; i++)
            {
                if (CheckResolution.SelectedItem.ToString()[i] == 'x')
                {
                    break;
                }
                resolution += CheckResolution.SelectedItem.ToString()[i];
            }
            for (int i = 0; i < CheckHz.SelectedItem.ToString().Length - 1; i++)
            {
                if ((CheckHz.SelectedItem.ToString()[i] == 'H' && CheckHz.SelectedItem.ToString()[i + 1] == 'Z') ||
                    CheckHz.SelectedItem.ToString()[i] == 'h' && CheckHz.SelectedItem.ToString()[i + 1] == 'z')
                {
                    break;
                }
                hz += CheckHz.SelectedItem.ToString()[i];
            }

            string selectedResolution = resolution;
            string selectedHz = hz;

            if (selectItem == "resolution")
            {
                return selectedResolution;
            }
            else
            {
                return selectedHz;
            }
        }
        void NvidiaInstall()
        {
            try
            {
                string windowsAppsDirectory = @"C:\Program Files\WindowsApps";
                string nvidiaControlPanelDirectory = FindNvidiaControlPanelDirectory(windowsAppsDirectory);

                if (!string.IsNullOrEmpty(nvidiaControlPanelDirectory))
                {
                    string destinationDirectory = @"C:\Program Files\NVIDIA Corporation\Control Panel Client";
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    CopyFiles(nvidiaControlPanelDirectory, destinationDirectory);
                }

                string FindNvidiaControlPanelDirectory(string directory)
                {
                    foreach (string subDir in Directory.GetDirectories(directory, "*NVIDIAControlPanel*", SearchOption.AllDirectories))
                    {
                        return subDir;
                    }
                    return null;
                }

                void CopyFiles(string sourceDirectory, string destinationDirectory)
                {
                    foreach (string file in Directory.GetFiles(sourceDirectory))
                    {
                        string fileName = Path.GetFileName(file);
                        string destFile = Path.Combine(destinationDirectory, fileName);
                        File.Copy(file, destFile, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }

        void FontsInstall()
        {
            AppVersionLabel.FontJetBrains();
            CheckResolution.FontJetBrains();
            CheckHz.FontJetBrains();
            CheckNoforcemaccel.FontJetBrains();
            CheckNoforcemparms.FontJetBrains();
            CheckNoforcemspd.FontJetBrains();
            CheckNofbo.FontJetBrains();
            CheckFPS.FontJetBrains();
            CheckRawInput.FontJetBrains();
            ParamLaunch.FontJetBrains();
            ButtonPlay.FontMichroma();
        }

        void CsEnglish()
        {
            RegistryKey steamKey = null;

            steamKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Valve\Steam");

            steamKey.SetValue("Language", "english", RegistryValueKind.String);
        }

        void RunRawInput()
        {
            if (CheckRawInput.Checked)
            {
                string programExe = @"rawinput.exe";
                string programArgument = "hl.exe";
                string currentPath = AppDomain.CurrentDomain.BaseDirectory;

                using (MemoryStream fileOutExe = new MemoryStream(Properties.Resources.rawinputexe))
                using (GZipStream gzexe = new GZipStream(fileOutExe, CompressionMode.Decompress))
                using (MemoryStream decompressedExe = new MemoryStream())
                {
                    gzexe.CopyTo(decompressedExe);
                    RunProgramGZip(decompressedExe.ToArray(), programExe);
                }

                using (MemoryStream fileOutDll = new MemoryStream(Properties.Resources.rawinputdll))
                using (GZipStream gzdll = new GZipStream(fileOutDll, CompressionMode.Decompress))
                using (MemoryStream decompressedDll = new MemoryStream())
                {
                    gzdll.CopyTo(decompressedDll);
                    File.WriteAllBytes(Path.Combine(currentPath, "rinput.dll"), decompressedDll.ToArray());
                }

                async void RunProgramGZip(byte[] exeBytes, string exeName)
                {
                    string exePath = Path.Combine(currentPath, exeName);
                    File.WriteAllBytes(exePath, exeBytes);
                    await Task.Delay(90000);
                    RunProgram(exePath, programArgument);
                }
            }
        }

        void ButtonPlay_Click(object sender, EventArgs e)
        {
            string programExe = "hl.exe";
            string paramLaunch = "-steam -game cstrike -32bpp -gl -high -nojoy -nomsaa -noaafonts -nomaster -nocrashdialog" + " " + ParamLaunch.Text + " " + $"-w {SelectedResolution("resolution")}" + " " + $"-freq {SelectedResolution("hz")}" + " -full";

            if (CheckNoforcemaccel.Checked)
                paramLaunch += " -noforcemaccel";
            if (CheckNoforcemparms.Checked)
                paramLaunch += " -noforcemparms";
            if (CheckNoforcemspd.Checked)
                paramLaunch += " -noforcemspd";
            if (CheckNofbo.Checked)
                paramLaunch += " -nofbo";
            if (CheckFPS.Checked)
            {
                int newHz = int.Parse(SelectedResolution("hz")) + 1;
                paramLaunch += $" -dev +fps_max {newHz} +cl_showfps 1";
                ReplaceTextInConfigFiles();
            }
            else
            {
                UnReplaceTextInConfigFiles();
            }

            if (CheckRawInput.Checked)
            {
                paramLaunch += " -rawinput";
            }

            RunProgram(programExe, paramLaunch);
            RunRawInput();
            CsEnglish();
        }

        void NvidiaSettings_Click(object sender, EventArgs e)
        {
            NvidiaInstall();

            string programExe = @"C:\Program Files\NVIDIA Corporation\Control Panel Client\nvcplui.exe";
            string programArgument = "";

            string programDir = @"C:\Program Files\NVIDIA Corporation\Control Panel Client";
            string programDir2 = @"C:\nvidia";
            string programDir3 = @"C:\Program Files\DARKSHELL\main\tools";
            string programDir4 = @"C:\Program Files (x86)\Runpad Pro Shell\darkshell\tools";


            if (Directory.Exists(programDir))
            {
                programExe = @"C:\Program Files\NVIDIA Corporation\Control Panel Client\nvcplui.exe";
                programArgument = "";
            }
            else if (Directory.Exists(programDir2))
            {
                programExe = @"C:\nvidia\showpanel.exe";
                programArgument = "";
            }
            else if (Directory.Exists(programDir3))
            {
                programExe = @"C:\Program Files\DARKSHELL\main\tools\dr_nvidia_control_panel.exe";
                programArgument = "";
            }
            else
            {
                programExe = @"C:\Program Files (x86)\Runpad Pro Shell\darkshell\tools\dr_nvidia_control_panel.exe";
                programArgument = "";
            }

            RunProgram(programExe, programArgument);
        }

        void MouseSettings_Click(object sender, EventArgs e)
        {
            string programExe = @"C:\Program Files\DARKSHELL\dr_mouse.exe";
            string programArgument = "";

            string programDir = @"C:\Program Files\DARKSHELL";
            string programDir2 = @"C:\wwLinux\Programs\DARKSHELL Mouse Control";
            string programDir3 = @"C:\DarkMod\Programs\DarkMouse";
            string programDir4 = @"C:\DarkOS\Programs\DarkMouse";
            string programDir5 = @"C:\Program Files (x86)\Runpad Pro Shell";
            string programDir6 = @"C:\Program Files (x86)\Runpad Shell 3D";

            if (Directory.Exists(programDir))
            {
                programExe = @"C:\Program Files\DARKSHELL\dr_mouse.exe";
                programArgument = "";
            }
            else if (Directory.Exists(programDir2))
            {
                programExe = @"C:\wwLinux\Programs\DARKSHELL Mouse Control\dr_mouse.exe";
                programArgument = "";
            }
            else if (Directory.Exists(programDir3))
            {
                programExe = @"C:\DarkMod\Programs\DarkMouse\darkmouse.exe";
            }
            else if (Directory.Exists(programDir4))
            {
                programExe = @"C:\DarkOS\Programs\DarkMouse\darkmouse.exe";
            }
            else if (Directory.Exists(programDir5))
            {
                programExe = @"C:\Program Files (x86)\Runpad Pro Shell\darkshell\tools\dr_mouse.exe";
            }
            else if (Directory.Exists(programDir6))
            {
                programExe = @"C:\Program Files (x86)\Runpad Shell 3D\bodymouse.exe";
            }
            else
            {
                programExe = @"C:\Windows\System32\control.exe";
                programArgument = "mouse";
            }

            RunProgram(programExe, programArgument);
        }

        void SetAppVersion()
        {
            AppVersionLabel.Text = $"v{AppCurrentVersion}";
        }

        private void wwlinuxLogo_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(AppOfficialSite);
        }

        void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void ButtonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

    }
}
