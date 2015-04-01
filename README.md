# BugTracker application

This project is part of ASP.NET vNext. You can find samples, documentation and getting started instructions for ASP.NET vNext at the [Home](https://github.com/aspnet/home) repo.
The equivalent MVC5 project is in [https://bitbucket.org/howarddierking/demo-katana-bugs]([https://bitbucket.org/howarddierking/demo-katana-bugs).

### Run the application on Helios:
* If you have Visual Studio 2015
    1. Open BugTracker.sln in Visual Studio 2015 and run the application. 
* If you don't have Visual Studio 2015 (Using IIS Express)
    1. Get the latest beta4 dnx. (You can follow the instruction at [Home](https://github.com/aspnet/Home/tree/release))
    2. Open a command prompt and cd `\src\BugTracker\`
    3. Execute `dnu restore` to restore all the necessary packages.
    4. Execute `dnu publish` to build a deployment. The default output path is `.\bin\output`
    5. Execute `'C:\Program Files (x86)\IIS Express\iisexpress.exe' /path:<project folder>\bin\output\wwwroot /port:5000` to start IIS Express. (Assuming your IIS Express is installed under C:\Program Files (x86))

### Run on WebListener/Kestrel:
* Open a command prompt and cd `\src\BugTracker\`
* **[WebListener]:**
	4. Run `dnx . WebListener` (Application started at URL **http://localhost:5002/**)
* **[Kestrel]:**
	5. Run `dnx . Kestrel` (Application started at URL **http://localhost:5004/**)
* **[CustomHost]:**
	6. Run `dnx . run` (This hosts the app in a console application - Application started at URL **http://localhost:5003/**)

### To run the sample on Mac/Mono:
* Follow [Home](https://github.com/aspnet/home) instructions to install mono, kvm on Mac
* Open a command prompt and cd `\src\BugTracker\`
* Execute `dnu restore`
* Try `dnx . Kestrel` to run the application

### Note:
* Application is started on different ports on different hosts. To change the port or URL modify project.json's commands section in case of self-host and customhost.