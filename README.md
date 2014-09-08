Bamboo-Excel-Addin
==================

1. Features
2. Known Issues
3. Wish list


1. FEATURES
=============================

Import - List of Files
-----------------------------
Lists all the files within the selected folder and sub folders recursively.
Includes all available file attributes.


Import - List of Directories
-----------------------------
Lists all the within the selected folder and sub folders recursively.
Includes all a available folder attributes.

If the "Report latest file access date within folder" is selected the latest "last accessed" date of files within each folder will also be reported.  Selecting this option
will have some impact on the performance.

On encountering access/permission errors it will be reported against each folder.
On encountering folder paths that are too long it will be reported against each folder.


Replace text in files
-----------------------------
Replaces all 'find string' with 'replace string' within all files within the selected folders and sub folders.  The result of the operation is listed in an Excel sheet.

Options
	> Case sensitive - The search mechanism will be case sensitive.
	> Check for matches only - This will spoof the replace operation.  
	  If checked, the  fills will be searched for the existence  of the 'find string', but will not be  modified.  An operation report will be generated in an Excel sheet.


Unprotect Workbook
-----------------------------
If the current workbook has been protected, this will unprotect it and provide the password used to protect it.  The process will also unprotect the worksheets within the current workbook.

This will not provide the password for file level protection (i.e. password required to Open or Modify an Excel sheet).


2. Known Issues
===============================================
1. Number of files and folders are limited to the number of rows on a single worksheet.
2. Another issue test