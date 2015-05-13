# BugTracker application

This project is part of ASP.NET 5. You can find samples, documentation and getting started instructions for ASP.NET 5 at the [Home](https://github.com/aspnet/Home) repo.
The equivalent MVC5 project is in [https://bitbucket.org/howarddierking/demo-katana-bugs]([https://bitbucket.org/howarddierking/demo-katana-bugs).

* Clone the repository

### Run the application on Helios:
* If you have Visual Studio 2015 RC
    1. Open BugTracker.sln in Visual Studio 2015 RC and run the application. 
* If you don't have Visual Studio 2015 RC
    1. Open a command prompt and execute `cd \src\BugTracker\`
    2. Execute ```dnu restore``` to restore all the necessary packages.
    3. Execute ```Helios.cmd``` to launch the app on IISExpress from command line (Application started at URL **http://localhost:5001/**).

### Run on WebListener/Kestrel:
* Open a command prompt and `cd \src\BugTracker\`
* **[WebListener]:**
	4. Run `dnx . web` (Application started at URL **http://localhost:5002/**)
* **[Kestrel]:**
	5. Run `dnx . kestrel` (Application started at URL **http://localhost:5004/**)
* **[CustomHost]:**
	6. Run `dnx . run` (This hosts the app in a console application - Application started at URL **http://localhost:5003/**)

### To run the sample on Mac/Mono:
* Follow the instructions at the [Home](https://github.com/aspnet/Home) repository to install Mono and DNVM on Mac OSX.
* Open a command prompt and cd ```\src\BugTracker\```
* Execute `dnu restore`
* Try `dnx . kestrel` to run the application

### Note:
1. Application is started on different ports on different hosts. To change the port or URL modify ```Helios.cmd``` or project.json commands section in case of self-host and customhost.
