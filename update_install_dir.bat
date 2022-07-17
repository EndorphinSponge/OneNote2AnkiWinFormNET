robocopy C:\Users\steve\.conda\envs\onenote2anki install_dir\pyenv /s /e
:: robocopy seems to check for differences between files first before copying
robocopy python_assets install_dir\python_assets *.py /s
:: Only copy python files, recursively, ignore empty directories (no /e)
copy bin\Release\OneNote2AnkiWinFormNET.exe install_dir /y
:: Overwrite if there is a file (/y)
