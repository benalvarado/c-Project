param([string[]] $Computer, [string[]] $Printer)

$a = Get-WmiObject -ComputerName $Computer -query "SELECT * FROM win32_printer WHERE name ='$Printer'"
$a.delete()
