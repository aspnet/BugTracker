REM Selfhost does not need this bin folder
REM rmdir /S /Q bin

REM Figure out path to K.cmd

FOR /F %%j IN ('dir /b /o:-d ..\..\packages\ProjectK*') do (SET K_CMD_PATH=..\..\packages\%%j\tools\k.cmd)
echo Found k.cmd at %K_CMD_PATH%. Starting the self host application
%K_CMD_PATH% web