# dotnet-deploy

This repo contains the source code for cross-platform dotnet tool dotnet-deploy. It contains the implementation of the tool and the documentation.

# Purpose of the tools

The dotnet-deploy tool aims to provide an opiniated deployment tool for your .net core applications.

The first target is to support Azure Functions projects.

# Basic usage

```
Usage: deploy [options] [command]

Options:
  -?|-h|--help  Show help information

Commands:
  aws           
  azure         
  gcp
```
```
Usage: deploy aws [options]

Options:
  -?|-h|--help  Show help information
```
```
Usage: deploy azure [options]

Options:
  -?|-h|--help          Show help information
  -f|--functionAppName  FunctionAppName used to deploy Azure Functions       
```
```
Usage: gcp [options]

Options:
  -?|-h|--help  Show help information
```

# Building from source

dotnet-deploy is developed using Visual Studio Code using Remote Development Extension for WSL. To build the project, you can use the *build* task. To  build, package and deploy the tool locally, you can use the *all* task.

# Questions and comments

For all feedback, use the Issues on this repository.


