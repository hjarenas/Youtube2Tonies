# Youtube2Tonies.WebApi
Backend that takes a url and converts it to a wav file. 

# Instructions for noobies
1. Download dotnet core 6
2. Open a command line (PS, bash, etc), go to the folder `Youtube2Tonies.WebApi`
3. Run `dotnet run`
4. Go to the URL `https://localhost:7137/index.html` and use swagger to call the VideoConverter api

# The 2Tonies part 
For now, you'll need to download the wav file and manually upload it to the right Creative Tonie. The idea is to have a UI that allows you to choose the creative Tonie and add the extra sound audio at the end of it.

## Listing Tonies
It is already possible to see the list of available tonies. Make sure that you put the username and password in the [secretes manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows#secret-manager) or in [environmental variables](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows#environment-variables) and not in plain text in the appSettings.