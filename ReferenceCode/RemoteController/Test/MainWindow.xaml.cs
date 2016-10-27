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
        private Task always_move_task = null;
        private bool running_flag = false;

        private int x = 0;
        private int y = 0;
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
            if (args.Key == Key.A)
            {
                if (running_flag == false)
                {
                    running_flag = true;

                    always_move_task = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("task start!...");

                        while (running_flag)
                        {
                            System.Threading.Thread.Sleep(1000);
                            this.Dispatcher.Invoke((Action)(() =>
                            {
                                Random rd = new Random();
                                x += 2;
                                y += 2;
                                x = rd.Next(54433);
                                y = rd.Next(9800);
                                InputGenerator.SendMove(x, y);
                            }));
                        }
                        Console.WriteLine("task stop!...");
                    });
                    //always_move_task.Start();
                }
                else
                {
                    running_flag = false;
                }
            }
            this.Dispatcher.Invoke((Action)(() =>
            {
                x += 2;
                y += 2;
                if (x > 1024)
                {
                    x = 0;
                }
                if (y > 1024) y = 0;
                InputGenerator.SendMove(x * 100, y * 100);
            }));
        }

        void MListener_MouseMove(object sender, RawMouseEventArgs args)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                string tbMouseCapture = "MOVE " + args.x + " - " + args.y + "\n";
                Console.WriteLine(tbMouseCapture);
            }));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputGenerator.SendMove(0, 0);
        }
    }
}
