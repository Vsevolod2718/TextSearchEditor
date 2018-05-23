using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EditorTextSearchWinForm.Model;

namespace EditorTextSearchWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            FileManager manager = new FileManager();
            MessageService message = new MessageService();

            MainPresenter presenter = new MainPresenter(form, manager, message);

            Application.Run(form);
        }
    }

}
