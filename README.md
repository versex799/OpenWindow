# Open Window Project

This project is a learning platform for building exploitation modules in .Net. Being new to the infosec world can be daunting. In order to learn more about the plethora of exploits that exist, I needed a foundation on which I could build. This is my attempt at building that foundation.

The goal of this project is to enable people to quickly develop self-contained modules that can be dynamically plugged into the application and run, without having to develop a full application for a small exploit. Simply develop a plugin, import it and run it. The benefit of this approach is that it greatly extends the usefulness of the application. These modules can then be shared with others who wish to use them. 

## Getting Started

To get started, you will need to download or clone the repo. When you open the solution, there are three projects. The main application is OpenWindow. There is an OpenWindowLib project that contains various classes that are shared between modules and the main application. The ExampleModule project is the template for creating a new module. The example module can be used as a basis on which to create your own module.

### Prerequisites

- Knowledge of C# / WPF
- Visual Studio 
