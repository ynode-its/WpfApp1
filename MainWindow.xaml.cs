using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinSCP;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SessionOptions opt = new SessionOptions();
            opt.Protocol = Protocol.Sftp;
            opt.GiveUpSecurityAndAcceptAnySshHostKey = true;
            opt.HostName = "XXX.XXX.XXX.XXX";
            opt.UserName = "XXXX";
            opt.Password = "XXXX";
            opt.SshHostKeyFingerprint = "ssh-rsa 2048 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            Session s = new Session();
            //opt.AddRawSettings("utf", "0");
            s.Open(opt);

            var tarnopt = new TransferOptions();
            tarnopt.TransferMode = TransferMode.Binary;
            tarnopt.PreserveTimestamp = false;
            var remote = s.ListDirectory("/home/XXXX/XXXX");

            foreach (var f in remote.Files.ToList())
            {
                System.Diagnostics.Debug.WriteLine(f.FullName);
            }

            var ret = s.GetFiles("/home/XXXX/XXXXX/日本語", "日本語.txt", false, tarnopt);

            if (false == ret.IsSuccess)
            {
                s.Dispose();
                return;
            }
            var ret1 = s.RemoveFile("/home/node/work/うTF");

            s.Dispose();
        }
    }
}
