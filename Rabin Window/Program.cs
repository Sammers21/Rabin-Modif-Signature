using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rabin_Window.BL;
using StartMenu;
using OpenkeyWindow;
using GenerateKeyWindow;
namespace Rabin_Window
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 genkeyWondow = new Form1();
            MainForm form = new MainForm();
            MessageService service = new MessageService();
            FileManager manager = new FileManager();
            MenuForm menuForm = new MenuForm();
            OpenKeyForm openKeyWindow = new OpenKeyForm();

            MainPresentor presentor = new MainPresentor(form, manager, service, menuForm, openKeyWindow,genkeyWondow);


            Application.Run(menuForm);
        }
    }
}
