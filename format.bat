REM A script to run Astyle for the sources

SET STYLE=--style=allman --indent=spaces=4 --indent-namespaces --lineend=windows --min-conditional-indent=0
SET OPTIONS=--pad-header --unpad-paren --suffix=none

astyle %STYLE% %OPTIONS% -r neo/cm/*.cpp
astyle %STYLE% %OPTIONS% -r neo/cm/*.h
astyle %STYLE% %OPTIONS% -r neo/curl/*.cpp
astyle %STYLE% %OPTIONS% -r neo/curl/*.h
astyle %STYLE% %OPTIONS% -r neo/d3xp/*.cpp
astyle %STYLE% %OPTIONS% -r neo/d3xp/*.h
astyle %STYLE% %OPTIONS% -r neo/framework/*.cpp
astyle %STYLE% %OPTIONS% -r neo/framework/*.h
astyle %STYLE% %OPTIONS% -r neo/game/*.cpp
astyle %STYLE% %OPTIONS% -r neo/game/*.h
astyle %STYLE% %OPTIONS% -r neo/openal/*.cpp
astyle %STYLE% %OPTIONS% -r neo/openal/*.h
astyle %STYLE% %OPTIONS% -r neo/renderer/*.cpp
astyle %STYLE% %OPTIONS% -r neo/renderer/*.h
astyle %STYLE% %OPTIONS% -r neo/sound/*.cpp
astyle %STYLE% %OPTIONS% -r neo/sound/*.h
astyle %STYLE% %OPTIONS% -r neo/idlib/*.cpp
astyle %STYLE% %OPTIONS% -r neo/idlib/*.h
astyle %STYLE% %OPTIONS% -r neo/sys/*.cpp
astyle %STYLE% %OPTIONS% -r neo/sys/*.h
astyle %STYLE% %OPTIONS% -r neo/tools/*.cpp
astyle %STYLE% %OPTIONS% -r neo/tools/*.h
astyle %STYLE% %OPTIONS% -r neo/typeinfo/*.cpp
astyle %STYLE% %OPTIONS% -r neo/typeinfo/*.h
astyle %STYLE% %OPTIONS% -r neo/ui/*.cpp
astyle %STYLE% %OPTIONS% -r neo/ui/*.h
