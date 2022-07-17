# OneNote2AnkiWinFormNET

* install_dir\ is the for building installer 
* update_install_dir.bat is to update install_dir\ with:
    * Updated binary (from \bin\Release\)
    * Updated Python scripts (from root of \python_assets)
    * Updated Python env (from USER\.conda\envs\onenote2anki)
* Flow of updates:
    0. User\.conda\envs\onenote2anki\ (if modifying environment) 
    1. python_assets (if modifying scripts themselves)
    2. OneNote2AnkiWinFormNET build RELEASE (if Python script CLI/argv interface has been changed)
    3. run update_install_dirt.bat to update install_dir\
    4. re-run NSIS GUI to package install_dir\ into an installer (should be able to load previous settings from .ini file)
    5. Find installer in bin\release\ (in same folder as release exe)
