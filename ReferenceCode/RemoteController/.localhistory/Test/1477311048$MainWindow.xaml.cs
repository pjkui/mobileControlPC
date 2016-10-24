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
using Utils.Mouse;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KeyboardListener KListener;
        private MouseListener MListener;

        private int x=0;
        private int y=0;
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
            MListener.MouseMove += new RawMouseEventHandler(MListener_MouseMove);
            //KListener.KeyUp += new RawKeyEventHandler(KListener_KeyUp);

        }
        void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                x+=2;
                y+=2;
                if (x > 1024)
                {
                    x = 0;
                }
                if(y>1024) y=0;
                InputGenerator.SendMove(x*100, y*100);
            }));
        }

        void MListener_MouseMove(object sender, RawMouseEventArgs args)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                string tbMouseCapture = "MOVE " + args.x + " - " + args.y;
                Console.WriteLine(tbMouseCapture);
            }));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputGenerator.SendMove(0, 0);
        }
    }
}
