BugTracker application
=========

This project is part of ASP.NET vNext. You can find samples, documentation and getting started instructions for ASP.NET vNext at the [Home](https://github.com/aspnet/home) repo.


###Getting Started

The first thing we need to do is setup the tools required to build and run an application.

* To setup `kvm` on your machine find getting started instructions at the [Home](https://github.com/aspnet/home) repo.
* Clone MusicStore repository, if you have not already.

### Run the application:
1. Open a command prompt and cd ```\src\<AppFolder>\```
2. Run ```kpm restore``` to restore all the necessary packages and generate project files
   Note: ```kpm restore``` currently works only on Desktop flavor. If you intend to use Core CLR, you should get Desktop flavor, execute ```kpm restore``` and then switch to Core CLR
3. **[Helios]:**
	4. ```Helios.cmd``` to launch the app on IISExpress (Application started at URL **http://localhost:5001/**).
4. **[SelfHost]:**
	5. Run ```k web``` (Application started at URL **http://localhost:5002/**)
5. **[CustomHost]:**
	6. Run ```k run``` (This hosts the app in a console application - Application started at URL **http://localhost:5003/**)

### Switching between Desktop CLR and CoreCLR:
By default the app runs on desktop CLR. To switch to run the app on CoreCLR follow the steps below
* On the command line, execute ```kvm install [BuildNumber] -svrc50```
* This command will install core clr flavor of this KRE build.
* If you want to run on IIS/IISExpress against core clr, open k.ini and update KRE_FLAVOR to CORECLR and follow steps for running the application from 'Run the application' section
* If you want to run on SelfHost against core clr, follow steps for running the application from 'Run the application' section

### Adding a new package:
1. Edit the project.json to include the package you want to install.
2. Do a ```kpm restore``` - This will restore the package in the project.

### Note:
1. Application is started on different ports on different hosts. To change the port or URL modify ```Helios.cmd``` or project.json commands section in case of self-host and customhost.