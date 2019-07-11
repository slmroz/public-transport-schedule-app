The application consists of five projects, four of them included in the Visual Studio solution being the server side part.
Those are:
- WebApi - containing WebAPI controllers available from the client side via ajax calls.
- BusinessLogic - all the neccessary services and calculation logic
- Data - the modela and mocked repositories (as suggested in the homework description, no database is involved here for the sake of simplicity)
- Tests - sample unit tests included here. 

The WebApi project needs to get started in order for the server side to be available for the web client.

web-client folder contains an ReactJS application playing the client side role.
In order to be ran successfully, it needs to be properly configured first.

web-client\src\config.js stores the app configuration settings:
- serverUrl - including port, if other than 80. Cors is enabled on the server side (WebApiConfig Register method) so there's a possibility to get cross-domain access via ajax.
- autoupdateInterval - in seconds, used for the autoupdate functionality and defines how often the schedule WebAPI is called. It could be as low as 60 (as we basically expect the minutes to change in such interval) or some smaller values for more accurate refreshes. To reduce the API calls and keep user experience on a high level we could think of some further improvements like a client side logic checking when it's time to call the server (as soon as the closest bus of any route arrives). To be further defined could be also minute rounding - used Math.Ceiling in this case.

Running the client app is quite straightforward:
- go to the web-client folder
- type "npm start"