#By BigTeddy 05 September 2011 
 
#This script uses the .NET FileSystemWatcher class to monitor file events in folder(s). 
#The advantage of this method over using WMI eventing is that this can monitor sub-folders. 
#The -Action parameter can contain any valid Powershell commands.  I have just included two for example. 
#The script can be set to a wildcard filter, and IncludeSubdirectories can be changed to $true. 
#You need not subscribe to all three types of event.  All three are shown for example. 
# Version 1.1 
 
$folder = 'C:\Users\dginev\Documents\Visual Studio 2017\Projects\MtB\'
$filter = '*Test?.dll'  # You can enter a wildcard filter here. 
 
# In the following line, you can change 'IncludeSubdirectories to $true if required.                           
$fsw = New-Object IO.FileSystemWatcher $folder, $filter -Property @{IncludeSubdirectories = $true;NotifyFilter = [IO.NotifyFilters]'FileName, LastWrite'} 
 
# Here, all three events are registerd.  You need only subscribe to events that you need: 
 
Register-ObjectEvent $fsw Created -SourceIdentifier FileCreated -Action { 
    $name = $Event.SourceEventArgs.Name
    $changeType = $Event.SourceEventArgs.ChangeType 
    $timeStamp = $Event.TimeGenerated 
    Write-Host "The file '$name' was $changeType at $timeStamp" -fore green 
    Out-File -FilePath c:\scripts\filechange\outlog.txt -Append -InputObject "The file '$name' was $changeType at $timeStamp"
} 
 
Register-ObjectEvent $fsw Deleted -SourceIdentifier FileDeleted -Action { 
    $name = $Event.SourceEventArgs.Name 
    $changeType = $Event.SourceEventArgs.ChangeType 
    $timeStamp = $Event.TimeGenerated 
    Write-Host "The file '$name' was $changeType at $timeStamp" -fore red 
    Out-File -FilePath c:\scripts\filechange\outlog.txt -Append -InputObject "The file '$name' was $changeType at $timeStamp"

} 
 
Register-ObjectEvent $fsw Changed -SourceIdentifier FileChanged -Action { 
    $name = $Event.SourceEventArgs.Name 
    if($name -notlike "*obj*" -and $name -notlike "*Temp*")
    {
        Start-Process -NoNewWindow -FilePath "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" -ArgumentList $name,"/framework:FrameworkCore10" 
    }
} 
 
# To stop the monitoring, run the following commands: 
# Unregister-Event FileDeleted 
# Unregister-Event FileCreated 
# Unregister-Event FileChanged
