using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сапёр3.Controllers
{
    static class MainController
    {
        public static void InitApp(Form1 current, Settings setingsForm)
        {
            AppInterfaceController.Init(current, setingsForm);
            GameLogicController.Init();
            SetingsFormController.Init(setingsForm);
        }

        public static void ReastartApp()
        {
            //DEBUG CODE
            //Console.Clear();
            Console.WriteLine("RESTART" + "\n");
            //

            AppInterfaceController.ClearMap();
            GameLogicController.Reastart();
        }

        public static void NewSetings(Form1 current)
        {
            //DEBUG CODE
            //Console.Clear();
            Console.WriteLine("RESTART NEW SETINGS" + "\n");
            //

            AppInterfaceController.NewSetings();
            GameLogicController.NewSettings();
        }
    }
}
