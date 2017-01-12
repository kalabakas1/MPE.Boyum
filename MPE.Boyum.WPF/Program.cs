using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace MPE.Boyum.WPF
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            var container = Setup.Container;
            container.Register<MainWindow>();
            container.Verify();

            RunApplication(container);
        }

        //http://simpleinjector.readthedocs.io/en/latest/wpfintegration.html
        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
