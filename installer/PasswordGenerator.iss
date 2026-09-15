; Inno Setup script for Password Generator.
;
; Packages the Release build output (PasswordGenerator.exe + its .config +
; word-list.csv, all three required side by side -- see
; PasswordGenerator.csproj / README.md) into a standalone Setup.exe with a
; Start Menu shortcut and a normal Add/Remove Programs entry. Requires the
; free Inno Setup compiler (https://jrsoftware.org/isinfo.php) to build.
;
; Build the app first (MSBuild, Release configuration):
;   msbuild PasswordGenerator\PasswordGenerator.csproj /p:Configuration=Release
; Then compile this script (from the Inno Setup IDE, or via the command line):
;   ISCC.exe installer\PasswordGenerator.iss

#define MyAppName "Password Generator"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "nathancarlmitchell"
#define MyAppURL "https://github.com/nathancarlmitchell/Password-Generator"
#define MyAppExeName "PasswordGenerator.exe"
#define PublishDir "..\PasswordGenerator\bin\Release"

[Setup]
; Fixed, random GUID identifying this app across versions -- regenerating it
; would make Windows treat an upgrade as a separate, unrelated install.
AppId={{9B6A3E7D-4F2C-4A8E-9E1D-6C7B2A4F5E8C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
; Let the installer adapt to whichever the user picks in the elevation
; prompt, instead of hard-requiring admin rights just to install a small
; utility into Program Files.
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
SetupIconFile=..\PasswordGenerator\Icon\AppIcon.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
OutputDir=Output
OutputBaseFilename=PasswordGenerator-Setup

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop shortcut"; GroupDescription: "Additional shortcuts:"; Flags: unchecked

[Files]
Source: "{#PublishDir}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#PublishDir}\PasswordGenerator.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#PublishDir}\word-list.csv"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: nowait postinstall skipifsilent
