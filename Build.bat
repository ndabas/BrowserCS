@echo off
resgen Browser.resx Techinox.WebBrowser.WebBrowserForm.resources
csc /target:winexe /debug+ /resource:Techinox.WebBrowser.WebBrowserForm.resources /r:System.dll /r:System.WinForms.dll /r:System.Drawing.dll /r:Microsoft.Win32.Interop.dll /r:SHDocVW.dll /r:AxSHDocVW.dll /r:MSHTML.DLL /win32icon:Sphere.ico /out:WebBrowser.exe WebBrowser.cs Open.cs About.cs ImportExport.cs AssemblyInfo.cs
