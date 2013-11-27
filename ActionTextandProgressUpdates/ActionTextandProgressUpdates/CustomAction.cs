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

            //set the action text
            string userMessage = "Executing custom action SampleCustomAction.";
            StatusMessage(session, userMessage);
            
            // we split the progress bar in 4 big chunks, have a quarter of it assigned to our custom action
            ResetProgressBar(session, 4);
            IncrementProgressBar(session, 1);

            // halting executing just so you can see the action text and progress bar on ProgressDlg
            System.Threading.Thread.Sleep(5000);

            session.Log("End SampleCustomAction");

            return ActionResult.Success;
        }

        /*
         * helper method used to send the actiontext message to the MSI
         * kudos to a fellow developer http://community.flexerasoftware.com/archive/index.php?t-181773.html
         */
        internal static void StatusMessage(Session session, string status)
        {
            Record record = new Record(3);
            record[1] = "callAddProgressInfo";
            record[2] = status;
            record[3] = "Incrementing tick [1] of [2]";

            session.Message(InstallMessage.ActionStart, record);
            Application.DoEvents();
        }

        /*
         * helper methods to control the progress bar
         * kudos to a fellow developer http://windows-installer-xml-wix-toolset.687559.n2.nabble.com/Update-progress-bar-from-deferred-custom-action-tt4994990.html#a4997563
         */

        public static MessageResult ResetProgressBar(Session session, int totalStatements)
        {
            var record = new Record(3);
            record[1] = 0; // "Reset" message 
            record[2] = totalStatements;  // total ticks 
            record[3] = 0; // forward motion 
            return session.Message(InstallMessage.Progress, record);
        }

        public static MessageResult IncrementProgressBar(Session session, int progressPercentage)
        {
            var record = new Record(3);
            record[1] = 2; // "ProgressReport" message 
            record[2] = progressPercentage; // ticks to increment 
            record[3] = 0; // ignore 
            return session.Message(InstallMessage.Progress, record);
        }
    }
}
