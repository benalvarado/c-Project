param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)

#Below is credited to John Coleman, and Eric Rood.
Function CreatePrinterPort {
param ($PrinterIP, $PrinterPort, $PrinterPortName, $ComputerName)
$wmi = [wmiclass]”\\$ComputerName\root\cimv2:win32_tcpipPrinterPort”
$wmi.psbase.scope.options.enablePrivileges = $true
$Port = $wmi.createInstance()
$Port.name = $PrinterPortName
$Port.hostAddress = $PrinterIP
$Port.portNumber = $PrinterPort
$Port.SNMPEnabled = $false
$Port.Protocol = 1
$Port.put()
}

foreach ($computer in $ComputerList) {
CreatePrinterPort -PrinterIP $PrinterIP -PrinterPort $PrinterPort `
-PrinterPortName $PrinterPortName -ComputerName $computer
}