Techinox WebBrowser 1.0.462.33592

Created by Nikhil Dabas (nd@nikhildabas.com)

WebBrowser is a small program which hosts the Microsoft WebBrowser control and
uses most capabilities provided by it to implement a web browser. Only
capabilities provided by thr .NET framework have been used to implement the
features. No DLL functions or other such non-COM functionality has been used,
even though it could have helped in implementing a few features, like
enumerating favourites and history. A case in point is the organise
favourites feature, which does not work properly COM-style. I have included
the (commented out) code for this feature, if in a future release of
Internet Explorer it works. It is very much possible to make all functions
work, but they involve PInvoke, which did not work very well when I tried
and regularly crashed my application. I suppose it is just a bug in Beta 1
of the .NET Framework and should be corrected later.

See http://www.codeproject.com/useritems/webbrowser.asp for more.

Building the project
The file Build.bat builds the app itself. Before that, you must run ImpLibs.bat
to create the neccessary imported libraries.

This is not a final or complete implementation and could be considered a
beta relese. A lot of work needs to be done. Here is a short list:
1.  'Full Screen' and 'View Source' in the application menus.
2.  Enumeration of the user's Favorites and History.
3.  'Send' submenu of 'File' menu.
4.  Mail button on toolbar.
5.  Edit works to only to a limited extent.
6.  Tools Menu.
7.  Back and Forward drop-downs.
8.  Some pages, especially those with frames, do not load properly.
9.  There is no handling for new windows.
10. Status bar icons (secure, offline, zone) are not displayed.

Software Requirements:
1. The .NET Framework SDK.
2. Microsoft Internet Explorer.

Hardware Requirements:
Any hardware platform capable of running the above mentioned software.

Any help would be appreciated. Send all mail to:
 wb@techinox.com.