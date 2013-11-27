custom-actions
==============

This repo will include only Windows Installer custom actions. 

==============

### RemoveReadOnlyAttribute ###


"Warning 1910" may appear when you uninstall your MSI package on Vista or newer OS-es. This happens because somehow the file "desktop.ini" from the Public Desktop folder got set to Read-Only, which should not happen. 
This VS 2010 solution generates a DLL called "RemoveReadOnlyAttribute.CA.dll" that can be used as a custom action to remove this flag, if found to be set. 

To build the project you also need Wix Toolset 3.5 or higher installed, follow the steps from here for more details: 
http://www.advancedinstaller.com/user-guide/qa-c-sharp-ca.html


### ActionTextandProgressUpdates ###

This is a sample custom action that shows how to update the action text and progressbar.
It contains a sample.aip file, the calls the custom action, which you can build even with a trial version of Advanced Installer.

The DLL "ActionTextandProgressUpdates.CA.dll" is a standard MSI custom actions DLL, so you can use it in any
installer package, be it built with Advanced Installer, Wix, etc...


Detailed explanations about how to schedule the custom actions and a C++ option to update the action text and progressbar can be found on the following link:
http://msdn.microsoft.com/en-us/library/aa367525(VS.85).aspx