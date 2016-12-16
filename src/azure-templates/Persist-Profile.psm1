$profileFileName = "AzureRmProfile.json"
$ProfileFilePath = (Join-Path $env:Temp $profileFileName)

function Get-Profile {
    if((Test-Path $profileFilePath) -eq $false) {
        Write-Output "No profile saved. Please run Save-Profile to login to Azure Account"
    } else {
        $profile = Get-Content $ProfileFilePath
        Write-Output $profile
    }
}
function Save-Profile {
    # Sign In / Save Profile
    if((Test-Path $profileFilePath) -eq $false) {
        Write-Host "Logging in..." -ForegroundColor Yellow
        Login-AzureRmAccount
        Save-AzureRmProfile -Path $profileFilePath
        Write-Host "Saving profile to $profileFilePath" -ForegroundColor Green
    }
    Select-AzureRmProfile -Path $profileFilePath | Out-Null
}
function Remove-Profile {
    if((Test-Path $profileFilePath) -eq $false) {
        Write-Output "No profile saved. Please run Save-Profile to login to Azure Account"
    } else {
        Remove-Item -Path $ProfileFilePath -ErrorAction Ignore
    }
}

Export-ModuleMember -Function Get-Profile, Save-Profile, Remove-Profile
