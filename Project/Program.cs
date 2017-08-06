namespace Droid_communication
{
    using System;
    using System.ServiceProcess;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new TS_Communication(args)
            //};
            //ServiceBase.Run(ServicesToRun);

            // ---------------------------------------


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SlackDemo());
            //Application.Run(new DemoOutlook());
            //Application.Run(new DemoLync());
            Application.Run(new Droid_Communicator());
        }
    }
}
