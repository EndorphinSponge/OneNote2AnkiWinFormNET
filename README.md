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
    3. run update_install_dir.bat to update install_dir\
    4. re-run NSIS GUI (in Portable Programs) to package install_dir\ into an installer, found in bin\Release\ ("Load from previous" option in NSIS takes previously generated .ini to pre-populate all fields)


* For Python-only quickfixes, only need to complete STEPS 3-4 to update installer with new .py files
* For Fixes involving WinForm, need STEP 2 to update exe file 
