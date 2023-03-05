# Phone Book Web App

## Pre-requisites

The following needs to be installed before running the app locally:
- `SQL Server 2019 / 2022` [Download Link](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
- `Node.js` [Download Link](https://nodejs.org/en/download/)
 - Recommended to install the latest LTS version
- `.NET 6.0 SDK` [Download Link](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks) 

## Database Setup

Following the recommended best practice to apply Entity Framework migrations (i.e. Via migration scripts and not by applying migrations during app runtime),
some setup SQL scripts need to be run prior to starting the app:

Using either Visual Studio or SSMS or a similar tool that enables running SQL scripts against MS-SQL Server:
- In `phonebook-infrastructure/Scripts/` run the `CreateDatabase_Windows.sql` script
- In `phonebook-infrastructure/Scripts/Migrations` run the `0001_initial_migration.sql` script to apply the EF migrations

## Running the App

<p>
<details>
<summary style='cursor: pointer'><b>From Visual Studio</b></summary>

Select the `phonebook-spa` project startup and run in debug mode. This will automatically run `npm install` and `ng serve` to serve the Angular front end.

</details>
</p>

<p>
<details>
<summary style='cursor: pointer'><b>From the command line</b></summary>

Ensure you have an environment variable called `ASPNETCORE_ENVIRONMENT` with a value of Development. On Windows (in non-PowerShell prompts), run SET `ASPNETCORE_ENVIRONMENT=Development.` On Linux or macOS, run export `ASPNETCORE_ENVIRONMENT=Development`.

</details>
</p>

See [MSDN - Using Angular Project Template](https://learn.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-7.0&tabs=netcore-cli) 
Navigate to `https://localhost:7118` if running from the command line (Visual Studio will automatically load the site)
- It will take a while for the initial ng setup and proxy SPA to function during first run

## Notes about the project

Overall, the time spent on this project was in the area of 6-7 hours, realistically (4-6 hours if you don't include wrestling with the SPA template quirks)

Certain design decisions were taken to allow further expansion of the application to include additional feature domains etc.
- The Angular code was developed with lazy loaded feature modules in mind. The phonebook module is lazy loaded as the default route currently, which will be beneficial as the app grows (home page / dashboard / additional module creation etc)
- Separation of concerns was adhered to as much as was possible within time constraints 
  - HTTP service is isolated from the components in the Angular code
  - Hexagonal architecture was implemented to enable further isolation of the database access code (EF core / Phonebook repository implementation) from the 'core' code. Although not really useful in this simple CRUD app, as business logic becomes more complex,
 it has room to expand in the `phonebook-core` project, while still being encapsulated from both the API Presentation layer and the underlying infrastructure layer. Of course, currently the simplicity of the application doesn't require this strict separation at the moment, but the point is that architecting for this early allows for much more efficient pivot to a more complex app.
- Specification pattern was employed to avoid some of the riskier implications of a 'generic' repository further down the line. Strongly typed Specification classes prevents uncontrolled growth of LINQ to EF queries propagating through the application layers, and encourages code reuse when reading larger data sets.
  - Again, this example is overkill for a simple CRUD application, but given further expansion, helps with keeping the code clean, and specifications centralised.
- Other design patterns were not necessary for such a simple application

### Lessons Learnt

My biggest regret was using the Microsoft Angular SPA template to start this project. It caused far more headaches than it was worth, and has changed significantly since I last used it!

### Road Map of additional functionality (that I intended to implement...)

Given that the core functionality took longer than expected to implement, I had set out to do the following within this app, but never got round to it:
- Better User Inputs for the phone number entry (clear, autoformated number entry)
- UI that is more consistent with the initial specifications
- More comprehensive unit testing (after the initial project setup and first unit test, I realised this would take too long)
- Resiliancy built in to the database requests using the `Polly` library, to handle retries, backoff etc.
- Proper error handling and useful information for the user:
  - Whilst there are validation attributes on the request models, which enable automatic `Bad Request` return messages being propagated to the Angular code, there is no handling of these errors in the front end.
  - Custom build error handlers to display validation messages in the form of a Toaster message, would have been a lot better. Console logs had to suffice...
- Dockerized application
  - For ease of setup and tear-down, and minimising pre-requisites for other developers to use
- Improved validation
  - Using a library like `FluentValidations` would enable a consistent approach to validating models and providing more useful error feedback for the front end
- API documentation
  - Use of Swagger / Sqashbuckle to document and test the API endpoints
