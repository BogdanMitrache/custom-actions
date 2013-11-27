using System.Collections.Generic;
using System.Windows.Forms;

   
namespace ActionTextandProgressUpdates
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Principal;
    using System.Text;
    using Microsoft.Deployment.WindowsInstaller;

    public class CustomActions
    {
        [CustomAction]
        public static ActionResult SampleCustomAction(Session session)
        {
            session.Log("Begin SampleCustomAction");

            //set the actiontext
            string userMessage = "Executing custom action SampleCustomAction.";
            StatusMessage(session, userMessage);

            // halting executing just so you can see the actiontext on ProgressDlg
            System.Threading.Thread.Sleep(5000);

            session.Log("End SampleCustomAction");

            return ActionResult.Success;
        }

        // helper method used to send the actiontext message to the MSI
        internal static void StatusMessage(Session session, string status)
        {
            Record record = new Record(3);
            record[1] = "callAddProgressInfo";
            record[2] = status;
            record[3] = "Incrementing tick [1] of [2]";

            session.Message(InstallMessage.ActionStart, record);
            Application.DoEvents();
        }
    }
}
