robocopy C:\Users\steve\.conda\envs\onenote2anki install_dir\pyenv /s /e
:: robocopy seems to check for differences between files first before copying


robocopy python_assets install_dir\python_assets /s /XD .git .vscode __pycache__ archive /XF *.pyproj *.gitignore
:: Only copy python files, recursively, ignore empty directories (no /e)
:: /XF and /XD to exclude files and directorys respectively https://superuser.com/questions/482112/using-robocopy-and-excluding-multiple-directories
:: /L argument can be used to give a summary of the operation before actually carrying out operation


copy bin\Release\OneNote2AnkiWinFormNET.exe install_dir /y
:: Overwrite if there is a file (/y)

