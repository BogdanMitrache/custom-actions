custom-actions
==============

### RemoveReadOnlyAttribute ###


"Warning 1910" may appear when you uninstall your MSI package on Vista or newer OS-es. This happens because somehow the file "desktop.ini" from the Public Desktop folder got set to Read-Only, which should not happen. 
This VS 2010 solution generates a DLL called "RemoveReadOnlyAttribute.CA.dll" that can be used as a custom action to remove this flag, if found to be set. 

To build the project you also need Wix Toolset 3.5 or higher installed, follow the steps from here for more details: 
http://www.advancedinstaller.com/user-guide/qa-c-sharp-ca.html


### ... ###
