param([string[]] $Computer, [string[]] $Printer, [string[]] $driverName, [string[]] $infPath)
#Copy-Item -Path \\itsm\data\WestCampus\EricsTOOLBAG\HPUniversalPrintDriver\pcl6x3262120636 -Destination \\sw1409-14536\c$\install\Printer;

Invoke-Command -ComputerName $Computer {cscript C:\Windows\System32\Printing_Admin_Scripts\en-US\prndrvr.vbs -a -m "$driverName" -i "$infPath"}

#Copy-Item -Path C:\Users\dbeiner\Desktop\BSW?Tool?Kit?Newest\BSW?Tool?Kit\bin\Debug\HPUniversalPrintDriver\pcl6x32 -Destination \\sw1409-14536\c$\install\Printer;