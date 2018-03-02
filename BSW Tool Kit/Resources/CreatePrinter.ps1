param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)


#Below is credited to John Coleman, and Eric Rood.
Function CreatePrinter {
param ($PrinterCaption, $PrinterPortName, $DriverName, $ComputerName)
$wmi = ([wmiclass]”\\$ComputerName\Root\cimv2:Win32_Printer”)
$Printer = $wmi.CreateInstance()
$Printer.Caption = $PrinterCaption
$Printer.DriverName = $DriverName
$Printer.PortName = $PrinterPortName
$Printer.DeviceID = $PrinterCaption
$Printer.put()
}


foreach ($computer in $ComputerList) {
CreatePrinter -PrinterPortName $PrinterPortName -DriverName `
$DriverName -PrinterCaption $PrinterCaption -ComputerName $computer
}