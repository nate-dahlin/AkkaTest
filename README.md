#Simple NetCore Akka Application with self hosted web API and NetCore Angular self hosted web UI

##Build
1. Open project in Visual Studio 2017 and build all the dlls
1. In command prompt navigate to the UI folder and issue `npm install`
1. In command prompt navigate to the UI folder and issue `ng build`

##Usage
1. The solution consits of 2 projects. A UI with some simple buttons that uses Typescript/Javascript to make http get requests to the API application which then calls the Akka system.
1. To run them open a command prompt and type `dotnet AkkaTest.dll` and `dotnet UI.dll`
	- another option is running it from within Visual Studio
1. Then navigate to a http://localhost:12346/index.html
1. "UI Health Check" button will make an http call to http://localhost:12346/api/healthcheck and dispaly it
	-this does nothing with Akka
1. "API Health Check" button will make an http call to http://localhost:12345/api/healthcheck and dispaly it
	-this does nothing with Akka but does call the other web server
1. "API Health Check with Akka" button will make an http call to http://localhost:12345/api/healthcheck/<someMessage> and dispaly it
	-this does call Akka on the other web server
1. After filling in a message and pressing "FooBar" will make a http call to http://localhost:12345/api/foobar/<someMessage> and display it
	-this calls Akka and creates a new actor which adds a bit to the message (Foo) and then passes the message onto another actor who adds a bit (Bar) and then sends the message to MVC
1. After filling in a message and pressing "FooBar Delayed" will make a http call to http://localhost:12345/api/foobar/delay/<someMessage> and display it
	-this is the same as the above only there are 2 second wait before it passes the message along
1. "Get FooBar Children" button will make an http call to http://localhost:12345/api/foobar/children and displays all the actors created by FooCoordinator
	-FooCoordinator creates a new actor to process a message. When asked FooCordinator will return all the active children it has

##To put load against the system just call the API directly