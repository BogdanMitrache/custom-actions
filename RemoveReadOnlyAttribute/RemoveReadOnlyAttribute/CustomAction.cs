using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Deployment.WindowsInstaller;

using System.Windows.Forms;

namespace RemoveReadOnlyAttribute
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult RemoveReadOnlyAttributeCA(Session session)
        {
            // display message to allow attaching the debugger
            // MessageBox.Show("Please attach a debugger to rundll32.exe.", "Attach");
 

            session.Log("Begin RemoveReadOnlyAttributeCA");

            string desktopDir = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            string filePath   = desktopDir + "\\desktop.ini"; // full path of "desktop.ini" system file 

            // Create the file if it exists.
            if (!File.Exists(filePath)) 
            {
                session.Log("File \"desktop.ini\" not found. Exit custom action with success.");
                return ActionResult.Success;
            }

            session.Log("File \"desktop.ini\" found at:" + filePath);

            System.IO.FileAttributes attributes = File.GetAttributes(filePath);

            if ((attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
            {
                // Make the file RW
                attributes = RemoveAttribute(attributes, System.IO.FileAttributes.ReadOnly);
                File.SetAttributes(filePath, attributes);
                session.Log(" Read-only attribute removed for file\"desktop.ini\".");
            }

            session.Log("Exit custom action RemoveReadOnlyAttributeCA with success.");
            return ActionResult.Success;
        }

        private static System.IO.FileAttributes RemoveAttribute(System.IO.FileAttributes attributes, System.IO.FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }      
    }
}
