# Code to article from my blog 'Decoding the code'

## Introduction

This source code is created as an example to explain use case when Azure Function V3 is used with binding - so with old method.  
The main cause of creation those repository is Twitter thread https://twitter.com/KrzanowskiM/status/1222788340954599424

The article describing problem you can find [here](https://mrmatrix.net/2020/01/azure-functions-v3-and-disappearing-function-json-files/)

## Problem reproduction

When you press F5 in Visual Studio you should see two functions available:

* folder1: [POST] http://localhost:7071/api/route/function_A
* folder2: [POST] http://localhost:7071/api/route/function_B

When you comment out this section

```xml
<Target Name="CopyFunctionBindingFilesToOutputDirectory" AfterTargets="_GenerateFunctionsExtensionsMetadataPostBuild">
  <Copy SourceFiles="folder1\function.json" DestinationFiles="$(OutDir)folder1\function.json" />
  <Copy SourceFiles="folder2\function.json" DestinationFiles="$(OutDir)folder2\function.json" />
</Target>
```

in **csproj** file and you press F5 again than functions disappears.

## Note

We are using this approach to use single codebase with various resources attached for different routing configuration. For example ```function_A``` can use different ```assignedTable``` - cloud table than ```function_B``` .
