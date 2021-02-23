# Open Window Project

This project is a learning platform for building exploitation modules in .Net. Being new to the infosec world can be daunting. In order to learn more about the plethora of exploits that exist, I needed a foundation on which I could build. This is my attempt at building that foundation.

The goal of this project is to enable people to quickly develop self-contained modules that can be dynamically plugged into the application and run, without having to develop a full application for a small exploit. Simply develop a plugin, import it and run it. The benefit of this approach is that it greatly extends the usefulness of the application. These modules can then be shared with others who wish to use them. 

## Getting Started

To get started, you will need to download or clone the repo. When you open the solution, there are three projects. The main application is OpenWindow. There is an OpenWindowLib project that contains various classes that are shared between modules and the main application. The ExampleModule project is the template for creating a new module. The example module can be used as a basis on which to create your own module.

This is still a work in progress. While I am slowly working on some relatively easy modules, there may be functionality that is desired that is not in place. If you happen to write a module that needs additional information from the main application, be sure to let me know so that I can add it. 

### Prerequisites

- Knowledge of C# / WPF
- Visual Studio 

## Works in Porgress

- Building out the API to be used for creating functionality within modules

## Future Development

- Add the concept of sessions that can link modules
- Add the ability to ingest and execute Python scripts
- Add the ability to download and install modules
