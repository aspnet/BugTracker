# BugTracker application

This project is part of ASP.NET vNext. You can find samples, documentation and getting started instructions for ASP.NET vNext at the [Home](https://github.com/aspnet/home) repo.

### Run the application on Helios:
* Execute ```build.cmd``` to restore all the necessary packages, and run tests.
**NOTE: Tests require Visual Studio 2014 LocalDB on the machine to run. 
* Open BugTracker.sln in Visual Studio 2014 and run the individual applications on ```Helios```.

### Run on WebListener/Kestrel:
* Open a command prompt and cd ```\src\BugTracker\```
* **[Helios]:**
	4. ```Helios.cmd``` to launch the app on IISExpress from command line (Application started at URL **http://localhost:5001/**).
* **[WebListener]:**
	5. Run ```k WebListener``` (Application started at URL **http://localhost:5002/**)
* **[Kestrel]:**
	5. Run ```k Kestrel``` (Application started at URL **http://localhost:5004/**)
* **[CustomHost]:**
	6. Run ```k run``` (This hosts the app in a console application - Application started at URL **http://localhost:5003/**)

### To run the sample on Mac/Mono:
* Follow [Home](https://github.com/aspnet/home) instructions to install mono, kvm on Mac
* Open a command prompt and cd ```\src\BugTracker\```
* Execute ``kpm restore```
* Try `k Kestrel` to run the application

### Note:
1. Application is started on different ports on different hosts. To change the port or URL modify ```Helios.cmd``` or project.json commands section in case of self-host and customhost.
