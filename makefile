all : bin\WebBrowser.exe

bin\AxSHDocVw.dll : $(SYSTEMROOT)\system32\SHDocVw.dll
  cd bin
  aximp %%SYSTEMROOT%\System32\SHDocVw.dll
  cd ..

bin\MSHTML.dll : $(SYSTEMROOT)\system32\MSHTML.tlb
  cd bin
  tlbimp MSHTML.tlb
  cd ..

res\ND.WebBrowser.WebBrowserForm.resources : res\Browser.resX
  resgen res\Browser.resx res\ND.WebBrowser.WebBrowserForm.resources

bin\WebBrowser.exe : bin\AxSHDocVw.dll bin\MSHTML.dll res\ND.WebBrowser.WebBrowserForm.resources WebBrowser.cs Open.cs About.cs ImportExport.cs AssemblyInfo.cs
  csc /target:winexe /debug+ /warn:4 /resource:res\ND.WebBrowser.WebBrowserForm.resources /r:bin\SHDocVW.dll /r:bin\AxSHDocVW.dll /r:bin\MSHTML.DLL /win32icon:res\Sphere.ico /out:bin\WebBrowser.exe WebBrowser.cs Open.cs About.cs ImportExport.cs AssemblyInfo.cs
  
clean:
  del /s *.exe *.pdb *.dll *.resources
