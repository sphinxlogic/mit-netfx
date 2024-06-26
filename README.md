<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!-- saved from url=(0042)http://fxdev/default/enlistBuildFxTree.htm --><HTML><HEAD>
<TITLE>MIT Dev - Enlist and Build</TITLE>
<meta content=False name=vs_showGrid>
<META http-equiv=Content-Type content="text/html; charset=windows-1252">
<META content="MSHTML 6.00.2600.0" name=GENERATOR>
<META content=FrontPage.Editor.Document name=ProgId></HEAD>
<BODY>
<TABLE width="100%" border=0>
  <TBODY>
  <TR>
    <TD width="20%"></TD>
    <TD width="50%">
      <P align=center><B><FONT 
      face="Courier New" size=4>.NET 
      Frameworks</FONT></B></P></TD>
    <TD width="30%"></TD></TR>
  <TR>
    <TD width="21%"></TD>
    <TD width="47%">
      <P align=center><FONT face=Courier size=1 
      ><A href="http://aui/">MIT Dev - 
      hard.core.mobile.team</A></FONT></P></TD>
    <TD width="32%"></TD></TR></TBODY></TABLE>
<TABLE width="100%" border=0>
  <TBODY>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2>How To:&nbsp; Enlist &amp; 
      Build the MIT branch of the Fx source tree</FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0><FONT face=Arial 
      size=2>The FX Build System provides a unified build 
      process for all of the components. The source code is located in a single 
      tree that is under Source Depot source control. The directories group 
      associated components together, and the leaf directories contain the 
      information for building the components. This document provides directions 
      for setting up and using the build system.</FONT> 
      <P><FONT face=Arial size=2>There 
      are 7 steps necessary to enable you to enlist and build the Fx source 
      tree.&nbsp; They are:</FONT></P>
      <OL>
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#MachineName" 
        >Setup your machine name</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#EnlistUsingSourceDepot" 
        >Enlist in the tree using Source Depot</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#SetEnvironmentVariables" 
        >Set appropriate environment variables</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#SetPathVariable" 
        >Set path variable</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#OpenaBuildWindow" 
        >Open a build window</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#InstallRuntime" 
        >Install the latest runtime bits</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#BuildSourceTree" 
        >Build the source tree</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#VSLKGSuites" 
        >Enlist for VSLKG suites</A></FONT> 
        <LI><FONT face=Arial size=2><A 
        href="http://fxdev/default/enlistBuildFxTree.htm#Install MDAC 2.6" 
        >Install MDAC 2.6 (required by suites)</A></FONT> 
        </LI></OL></TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A name=MachineName 
      >Machine Name</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0><FONT face=Arial 
      size=2>A recognizable email name on an enlistment 
      lets us determine who made a check-in, and helps us efficiently resolve 
      locks, conflicts, and other problems.</FONT> 
      <P><FONT face=Arial size=2 
      >Before you enlist, make sure your machine name is a 
      variation on your email name, such as JoeDev1. If it's a lab machine, 
      choose an appropriate lab name (e.g. vcbuild1).</FONT></P>
      <P><FONT face=Arial size=2>If 
      the machine name is not obviously an email name, set a comment that 
      includes an email alias so that users can run "net view \\name" and find 
      the owner of the machine. To do this, have at least one directory shared 
      out on the machine.</FONT></P>
      <P><FONT face=Arial size=2><B 
      >NT5</B>: Go to Start/Settings/Control 
      Panel/Administrative Tools/Computer Management. Then with the "Computer 
      Management (Local)" node highlighted go to Action/Properties. There is a 
      "Network Identification" tab and go there. There should be a text box to 
      put in a machine comment. Put the owner(s) of the machine in this text box 
      and press "Ok".</FONT></P>
      <P><FONT face=Arial size=2><B 
      >NT4</B>: Go to Start/Settings/Control Panel/Server. 
      Then in the description type in the owner(s) of the machine and press 
      "OK".</FONT></P>
      <BLOCKQUOTE>
        <BLOCKQUOTE>
          <P><FONT face=Arial color=#ff0000 size=2 
          >If an enlistment does not have a recognizable 
          contact, it may be deleted without notice. No questions asked. You 
          have been warned.</FONT></P></BLOCKQUOTE></BLOCKQUOTE></TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A 
      name=EnlistUsingSourceDepot>Enlist Using Source 
      Depot</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0><FONT face=Arial 
      size=2><SPAN style="COLOR: black" 
      >Run&nbsp;<A 
      href="file://\\auitest1\Tools\Utils\SourceDepot\MITSDEnlist.bat">\\auitest1\Tools\Utils\SourceDepot\MITSDEnlist.bat</A>  &nbsp;with the 
      location of where you want the FX tree on your machine.<SPAN 
      style="COLOR: black; mso-spacerun: yes">&nbsp; 
      </SPAN>Eg.</SPAN></FONT> 
      <BLOCKQUOTE>
        <P><SPAN style="COLOR: black" 
        ><FONT face=Courier size=2><B 
        >&nbsp;<A 
        href="file://\\auitest1\Tools\Utils\SourceDepot\MITSDEnlist.bat">\\auitest1\Tools\Utils\SourceDepot\MITSDEnlist.bat</A> 
        &nbsp;c:\fxdev</B></FONT></SPAN></P></BLOCKQUOTE>
      <P><FONT face=Arial size=2><SPAN 
      style="COLOR: black">This<SPAN 
      style="COLOR: black; mso-spacerun: yes">&nbsp; 
      </SPAN>will enlist into the MIT-Everett FX branch. For more information on 
      Source Depot, visit <A 
      href="http://sourcedepot">http://sourcedepot</A>&nbsp;- and the cheatsheet 
      at <A 
      href="http://cptoolzone/Tools/sourcedepot/SDCheatSheet/SDCheat_Sheet.htm">http://cptoolzone/Tools/sourcedepot/SDCheatSheet/SDCheat_Sheet.htm</A> 
      </SPAN></FONT>
      <P><FONT face=Arial size=2><SPAN 
      style="COLOR: black"></O:P></SPAN></FONT></P></TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A 
      name=SetEnvironmentVariables>Set Environment 
      Variables</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0>
      <P><FONT face=Arial size=2>The 
      build system relies on environment variables to know the location of files 
      and to control its operation. You can either copy and edit <A 
      href="file://\\auitest1\Tools\Utils\SourceDepot\sample_mitenv.bat">sample_mitenv.bat</A> 
      from&nbsp;<A 
      href="file://\\auitest1\Tools\Utils\SourceDepot\">\\auitest1\Tools\Utils\SourceDepot\</A>, or set the following environment variables in your system control 
      panel:</FONT></P>
      <P><FONT face=Arial size=2 
      ></FONT>&nbsp;</P>
      <DIV align=center>
      <CENTER>
      <TABLE width="80%" border=1>
        <TBODY>
        <TR>
          <TD width="30%" bgColor=#3399cc><FONT 
            face="Arial Black" size=1>Variable</FONT></TD>
          <TD width="70%" bgColor=#3399cc><FONT 
            face="Arial Black" size=1 
        >Description</FONT></TD></TR>
        <TR>
          <TD width="30%" bgColor=#ffffff><FONT 
            face=Arial size=1>DNAROOT=C:\FX</FONT></TD>
          <TD width="70%" bgColor=#ffffff><FONT 
            face=Arial size=1>This is where your source 
            files will be kept.</FONT> 
            <P><FONT face=Arial size=1 
            >NOTE: Environment variables _DNAROOT and 
            _DNADRIVE are deprecated. </FONT></P></TD></TR>
        <TR>
          <TD width="30%" bgColor=#a2b6d7><FONT 
            face=Arial size=1>-- BUILD TARGET --</FONT></TD>
          <TD width="70%" bgColor=#a2b6d7>
            <TABLE width="99%" border=1>
              <TBODY>
              <TR>
                <TD width="20%"><FONT face=Arial size=1 
                  >_URTTARGET</FONT></TD>
                <TD width="80%"><FONT face=Arial size=1 
                  >Root for URT builds. Normally something 
                  like "c:\complus". This will result in builds being placed in 
                  directories like&nbsp; "%_URTTARGET%\v1.x86CHK"</FONT> 
                  <P><FONT face=Arial size=1 
                  ><B>MIT Devs should 
                  set this environment variable.</B></FONT></P></TD></TR>
              <TR>
                <TD width="20%"><FONT face=Arial size=1 
                  >DNABUILT</FONT></TD>
                <TD width="80%"><FONT face=Arial size=1 
                  >Root for Visual Studio builds. Normally 
                  something like "c:\vsbuilt". This will result in builds being 
                  placed in directories like 
                  "%DNABUILT%\debug\bin\i386\complus"</FONT> 
                  <P><FONT face=Arial size=1 
                  ><B>MIT Devs should 
                  not set this environment variable. </B></FONT></P></TD></TR>
              <TR>
                <TD width="20%"><FONT face=Arial size=1 
                  >URTTARGET</FONT></TD>
                <TD width="80%"><FONT face=Arial size=1 
                  >Target for URT builds. Not normally used. 
                  This will result in builds being placed in into 
                  "%URTTARGET%"</FONT> 
                  <P><FONT face=Arial size=1 
                  ><B>The build lab 
                  should use this option. MIT Devs should not set this 
                  environment variable.</B></FONT></P></TD></TR></TBODY></TABLE></TD></TR>
        <TR>
          <TD width="30%" bgColor=#ffffff><FONT 
            face=Arial size=1 
            >SYSTEM_DIR=c:\winnt\system32</FONT></TD>
          <TD width="70%" bgColor=#ffffff><FONT 
            face=Arial size=1>The system directory of the 
            operating system</FONT></TD></TR></TBODY></TABLE></CENTER></DIV>
      <p>&nbsp;</p>
      <table align=center>
        <tr>
          <td bgColor=#3399cc>
            <P><FONT face="Arial Black" size=2>Sample Batch File to use instead 
            of setting the above variables in your System environment.<BR>Source is available at <A 
            href="file://\\auitest1\Tools\Utils\SourceDepot\sample_mitenv.bat">\\auitest1\Tools\Utils\SourceDepot\sample_mitenv.bat</A></FONT></P></td></tr>
        <tr>
          <td><pre>   
:: ---------------------
:: Source Locations
:: ---------------------


:: DNAROOT:
:: The full path for the VS projects. 

@set DNAROOT=f:\fxdev


:: ---------------------
:: Build Target
:: ---------------------


:: _URTTARGET:
:: Root for URT builds. Normally something like "c:\complus". 
:: This will result in builds being placed in directories 
:: like  "%_URTTARGET%\v1.x86CHK" 

@set _URTTARGET=f:\complus

:: DNABUIILT:
:: If you need to build VS - use DNABUILT - binaries will be placed
:: "%DNABUILT%\debug\bin\i386\complus".

:: set DNABUILT=f:\vsbuilt

:: ---------------------
:: System Directory
:: ---------------------

:: The system dir of the operating system.  
::

:: Win NT
:: set SYSTEM_DIR=c:\winnt\system32

:: Windows XP
@set SYSTEM_DIR=c:\windows\system32

:: Set path to binaries. 

:: If building URT
@set PATH=%PATH%;f:\complus\v1.x86CHK;%DNAROOT%\public\tools\common;
@set PATH=%PATH%;%DNAROOT%\public\tools\%PROCESSOR_ARCHITECTURE%;

:: If building VS
:: set PATH=%PATH%;f:\vsbuilt\debug\bin\i386\complus;%DNAROOT%\public\tools\common;
:: set PATH=%PATH%;%DNAROOT%\public\tools\%PROCESSOR_ARCHITECTURE%;
 
:: ------
:: Set debug or retail environment
:: -------

:: Debug environment
call dnaenv debug

:: Retail environment
:: dnaenv retail

:: -----
:: Add a few handy aliases<BR>:: 	- the default ones are kept in %DNAROOT%\public\tools\common\cue.pub<BR>:: -

dnaroot, bindir,
src are interesting ones defined there
:: -----

alias mitroot "pushd %DNAROOT%\src\MIT\$*"
alias mobile "pushd %DNAROOT%\src\MIT\system\web\mobile\$*"
</pre></td></tr></table>
      <P> </P>
      <P><FONT face=Arial size=2 
      ><STRONG>Windows 
      95</STRONG></FONT></P>
      <P><FONT face=Arial size=2>Set 
      the above variables in autoexec.bat. Add the following environment 
      variables are required on Windows 95. They are set automatically on 
      Windows NT. You will want to increase your environment space on Windows 95 
      by adding the following line to config.sys:</FONT></P>
      <BLOCKQUOTE>
        <P><SPAN style="COLOR: black" 
        ><FONT face=Courier size=2><B 
        >shell=c:\command.com c:\ /p 
        /e:2048</B></FONT></SPAN></P></BLOCKQUOTE>
      <DIV align=center>
      <CENTER>
      <TABLE width="75%" border=1>
        <TBODY>
        <TR>
          <TD width="56%" bgColor=#3399cc><FONT 
            face="Arial Black" size=1>Variable</FONT></TD>
          <TD width="44%" bgColor=#3399cc><FONT 
            face="Arial Black" size=1 
        >Description</FONT></TD></TR>
        <TR>
          <TD width="56%" bgColor=#ffffff><FONT 
            face=Arial size=1>USERNAME=&lt;your login 
            alias&gt;</FONT></TD>
          <TD width="44%" bgColor=#ffffff><FONT 
            face=Arial size=1>Your user name.</FONT></TD></TR>
        <TR>
          <TD width="56%" bgColor=#a2b6d7><FONT 
            face=Arial size=1 
            >PROCESSOR_ARCHITECTURE=x68</FONT></TD>
          <TD width="44%" bgColor=#a2b6d7><FONT 
            face=Arial size=1>The processor 
            architecture</FONT></TD></TR>
        <TR>
          <TD width="56%" bgColor=#ffffff><FONT 
            face=Arial size=1 
            >COMSPEC=%DNAROOT%\public\tools\%PROCESSOR_ARCHITECTURE%\win95cmd.exe</FONT></TD>
          <TD width="44%" bgColor=#ffffff><FONT 
            face=Arial size=1>NT-style command 
            processor</FONT></TD></TR></TBODY></TABLE></CENTER></DIV><BR 
      ></TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A name=SetPathVariable 
      >Set Path Variable</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0><FONT face=Arial 
      size=2>The following changes must be made to your 
      path.</FONT> <FONT face=Arial size=2><EM><U>If you are using the batch 
      file from the previous step, this is already setup for 
you</U>.</EM></FONT>
      <BLOCKQUOTE>
        <P><FONT face=Courier size=2 
        ><B>set PATH=%PATH%;<BR 
        >&lt;path to 
        framework binaries (same as _URTTARGET)&gt;;<BR 
        >%DNAROOT%\public\tools\common;<BR 
        >%DNAROOT%\public\tools\%PROCESSOR_ARCHITECTURE%;</B></FONT></P></BLOCKQUOTE>&nbsp;</TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A name=OpenaBuildWindow 
      >Open a Build Window</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0><FONT face=Arial 
      size=2>In order to do things in the DNA build system, 
      you need to have a command prompt open with the correct environment set 
      up. To do this:</FONT> 
      <OL>
        <LI><FONT face=Arial size=2 
        >Open a command prompt.</FONT> 
        <LI><FONT face=Arial size=2>If you are using the batch file from the 
        previous step, this is already setup for you - just run that.</FONT>
        <LI><FONT face=Arial size=2 
        >Else, type "dnaenv debug" or "dnaenv 
        retail".</FONT> </LI></OL>
      <P><FONT face=Arial size=2>This 
      will create an environment for making debug or retail builds. If you omit 
      the type, debug is the default. You can change from one to another by 
      running dnaenv again.</FONT></P>
      <P><FONT face=Arial size=2><BR 
      >It is important to note that any time you use the 
      build environment, you must run dnaenv. If you don't then environment 
      variables won't be set correctly and necessary directories may not exist, 
      and the build will not work. Most of the directions following this assume 
      you are running in a build window.</FONT></P>
      <P><FONT face=Arial size=2><BR 
      >Another important note is that if you delete the 
      %DNABUILT% tree, you must re-run dnaenv to create directories in this 
      tree. If you do not, midl will not work properly when building idl 
      files.</FONT></P>
      <P>&nbsp;</P></TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A name=InstallRuntime 
      >Install the Latest Runtime Bits</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0><FONT face=Arial 
      size=2>The DNA build system is designed so that you 
      do not have to do a clean build of the entire source code base. You only 
      need to build components on which you are actively working. To do this, 
      before you build, you need the headers, libs, and binaries, which are used 
      to build your component. You must do this, unless you enlist in all 
      projects and do a complete clean build. The build lab will make a clean 
      build, and produce a drop, which includes all these files. So, before you 
      build, you must copy down a drop.</FONT> <FONT face=Arial size=2 
      >To get a URT drop use �COPYURT.BAT�</FONT><BR 
      >
      <BLOCKQUOTE><FONT face=Courier size=2 
        ><B>copyurt [/v version] [/f 
        flavor] [/d dest] [/reg]</B></FONT><BR>
        <BLOCKQUOTE>
          <BLOCKQUOTE><FONT face=Arial size=2 
            >version� the URT build number that you want to 
            copy</FONT><BR><FONT face=Arial size=2 
            >flavor � checked, fastchecked, or retail build. 
            Retail is default</FONT><BR><FONT face=Arial 
            size=2>dest � location to copy URT to. This 
            defaults to the bindir for your DNA window</FONT><BR 
            ><FONT face=Arial size=2 
            >reg � Registers the copied URT bits.</FONT><BR 
            ></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE>&nbsp;</TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A name=BuildSourceTree 
      >Build the Source Tree</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0><FONT face=Arial 
      size=2>Now you are ready to build.</FONT> 
      <P><FONT face=Arial size=2 
      >Builds are done using the "build" command in a build 
      window. There are switches to control how the build is done. The directory 
      where you start build controls the scope of which files are built. All 
      directories under the starting directory are built. So, if you go to 
      %DNAROOT%, and type "build", you will rebuild everything. If you go to 
      %DNAROOT%\src\MIT, you will only build&nbsp;the Mobile Internet 
      Toolkit&nbsp;.</FONT></P>
      <P><FONT face=Arial size=2>Some 
      useful switches to build are:</FONT></P>
      <DIV align=center>
      <CENTER>
      <TABLE width="75%" border=1>
        <TBODY>
        <TR>
          <TD width="15%" bgColor=#3399cc><FONT 
            face="Arial Black" size=1>Switch</FONT></TD>
          <TD width="85%" bgColor=#3399cc><FONT 
            face="Arial Black" size=1 
        >Description</FONT></TD></TR>
        <TR>
          <TD width="15%" bgColor=#ffffff><FONT 
            face=Arial size=1>-c</FONT></TD>
          <TD width="85%" bgColor=#ffffff><FONT 
            face=Arial size=1>Clean Build: By default, only 
            targets that are out of date are built. Specifying this switch 
            causes all files to be rebuilt - like Rebuild All in Visual 
            C++.</FONT></TD></TR>
        <TR>
          <TD width="15%" bgColor=#a2b6d7><FONT 
            face=Arial size=1>-?</FONT></TD>
          <TD width="85%" bgColor=#a2b6d7><FONT 
            face=Arial size=1>Displays comprehensive list 
            of options</FONT></TD></TR></TBODY></TABLE></CENTER></DIV>&nbsp;</TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2><A name="Install MDAC 2.6" 
      >Install MDAC 2.6</A></FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0>MDAC 2.6 is required 
      for the suites to pass. 
      <P>The official ITG mdac install site: <A 
      href="http://itgweb/mdac/mdacinstallation.asp" 
      >http://itgweb/mdac/mdacinstallation.asp</A></P>
      <P>Or just install it directly from here&nbsp; <A 
      href="file://webdata/Services/Redist/mdac26/RTM/usa" 
      ><SPAN style="LINE-HEIGHT: 1mm" 
      ><FONT face=Arial 
      size=2>\\webdata\Services\Redist\mdac26\RTM\usa</FONT></SPAN></A></P>
      <P>&nbsp;</P></TD></TR>
  <TR>
    <TD width="100%" bgColor=#3399cc><FONT 
      face="Arial Black" size=2>About this 
    document</FONT></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0>
      <P><FONT face=Arial size=2>This 
      document is a modified copy of "%DNAROOT%\How To Build.html" which can be 
      viewed at:<A href="http://fxdev/default/enlistBuildFxTree.htm" 
      >http://fxdev/default/enlistBuildFxTree.htm</A> <BR 
      >Questions should be directed to: <A href="mailto:jfosler@microsoft.com" >jfosler</A></FONT></P>
      <P><FONT face=Arial size=2>This 
      document was last updated 12/12/2001.</FONT></P></TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0>&nbsp;</TD></TR>
  <TR>
    <TD width="100%" bgColor=#f0f0f0>
      <P align=center>&nbsp;<FONT face=Arial size=2>Microsoft 
      Confidential.</FONT></P></TD></TR></TBODY></TABLE></BODY></HTML>
