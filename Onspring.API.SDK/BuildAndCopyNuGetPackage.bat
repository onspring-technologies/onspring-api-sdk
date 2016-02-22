@ECHO OFF
SET ROOTPATH=%~dp0

del *.nupkg

if not exist "%ROOTPATH%bin\Release\" (
	echo ******************************************************************
	echo Please build the project in Release mode
	echo ******************************************************************
	pause
	goto :eof
)

nuget.exe pack Onspring.API.SDK.csproj -IncludeReferencedProjects -Symbols -Prop Configuration=Release

ren *.symbols.nupkg *.symbols
For %%# in ("%ROOTPATH%*.nupkg") Do (
	SET FILENAME=%%~nx#
)
del %FILENAME%
ren *.symbols %FILENAME%

pause
