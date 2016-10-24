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
        private int x=0, int y=0;
        public MainWindow()
        {
            InitializeComponent();
            InputGenerator.SendMove(0, 0);
            InitHooks();
        }
        private void InitHooks()
        {
            KListener = new KeyboardListener();
            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);
            //KListener.KeyUp += new RawKeyEventHandler(KListener_KeyUp);

        }
        void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                InputGenerator.SendMove(0, 0);
            }));
        }
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputGenerator.SendMove(0, 0);
        }
    }
}
