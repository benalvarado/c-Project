param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)

#Below is credited to John Coleman, and Eric Rood.
Function InstallPrinterDriver {
Param ($DriverName, $DriverPath, $DriverInf, $ComputerName)
$wmi = [wmiclass]”\\$ComputerName\Root\cimv2:Win32_PrinterDriver”
$wmi.psbase.scope.options.enablePrivileges = $true
$wmi.psbase.Scope.Options.Impersonation = `
[System.Management.ImpersonationLevel]::Impersonate
$Driver = $wmi.CreateInstance()
$Driver.Name = $DriverName
$Driver.DriverPath = $DriverPath
$Driver.InfName = $DriverInf
$wmi.AddPrinterDriver($Driver)
$wmi.put()
}


foreach ($computer in $ComputerList) {
InstallPrinterDriver -DriverName $DriverName -DriverPath `
$DriverPath -DriverInf $DriverInf -ComputerName $computer
}