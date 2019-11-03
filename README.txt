This program is built as a dotnet tool so it can be invoked to create a C# buildate constants class for use in any program

To build and install:

dotnet build -r win-x64 -c Release
dotnet pack -c Release --nologo
dotnet tool install --global --add-source ./nupkg MakeBuildDate

See: https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create
And https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-pack
And https://stackoverflow.com/questions/1600962/displaying-the-build-date

Use: 
	MakeBuildDate .\path\to\my\builddatefile.cs
