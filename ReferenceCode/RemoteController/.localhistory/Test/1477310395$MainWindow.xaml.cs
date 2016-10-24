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
using Utils.InputGenerator;
using Utils.Keyboard;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KeyboardListener KListener;

        public MainWindow()
        {
            InitializeComponent();
            InputGenerator.SendMove(0, 0);
            InitHooks();
        }
        private void InitHooks()
        {
            KListener = new KeyboardListener();
            MListener = new MouseListener();
            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);
            KListener.KeyUp += new RawKeyEventHandler(KListener_KeyUp);
            MListener.LeftDown += new RawMouseEventHandler(MListener_LeftDown);
            MListener.LeftUp += new RawMouseEventHandler(MListener_LeftUp);
            MListener.RightDown += new RawMouseEventHandler(MListener_RightDown);
            MListener.RightUp += new RawMouseEventHandler(MListener_RightUp);
            MListener.MouseMove += new RawMouseEventHandler(MListener_MouseMove);
            MListener.MouseWheel += new RawMouseEventHandler(MListener_MouseWheel);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputGenerator.SendMove(0, 0);
        }
    }
}
