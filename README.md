# ConferencePlanner
Solving the Conference Planner problem

Solution created by – Lalasa Ala
Solution Name – ConferencePlanner.sln
Coding editor used – Visual Studio 2015
Program executables – executables can be run directly by double clicking on them.
1.	Bin\release\ConferencePlannerConsole.exe
2.	Bin\release\ConferencePlannerWPF.exe

The solution has four project items
1.	ConferencePlannerConsole – Console application
2.	ConferencePlannerWPF – WPF application
3.	ConferencePlannerLibrary – Class library used by Console application and wpf application.
4.	ConferencePlannerLibrary.UnitTests – Unitests for the common library.

ConferencePlannerConsole 
This application takes a file as an argument. If an argument is not provided, it uses the default Input/input.txt file. Input/input.txt has the test input provided in the assignment

ConferencePlannerWPF
When this application is launched, two choices are presented 
1.	File input - provide file path. Paste the test input provided in the assignment to the file.
2.	Text input - Type or paste the test input provided in the assignment into the text box.
Click on “Create Schedule” button after selection one of the choices and providing the input.

ConferencePlannerLibrary
The common library is used by both the console and wpf app to create the schedule.

ConferencePlannerLibrary.UnitTests
Unit test project with unit tests for ConferencePlannerLibrary.

Miscellaneous items - ConferencePlannerClassDiagram.cd – class diagram
