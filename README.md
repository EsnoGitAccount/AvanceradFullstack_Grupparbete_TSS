# AvanceradFullstack_Grupparbete_TSS

## Description:
This repo is fullstack project made by a group of students for a group assignment. The project aims to create a daily challenge game heavily inspired by the swedish gameshow "På Spåret".

This repo contains both the frontend and the backend applications.

## Prerequisites
.NET SDK: 10.x
Node.js: 24.x
npm: Bundled with Node.js 24.x
Database: SQL Server / Azure SQL
Your own Azure account with a Blob Storage up and running

## Setup:
The repo contains almost everything that is needed to run it locally after setting it up. The one thing that is needed that you also need is an Azure account with a Blob Storage up and running. Other than that you should just need to clone/fork it and setup the environment variables.

## Clone and navigate
git clone https://github.com/EsnoGitAccount/AvanceradFullstack_Grupparbete_TSS

cd AvanceradFullstack_Grupparbete_TSS

### Frontend-Setup:
The frontend should be run from the frontend folder ("./frontend").
The url to the backend is set in "./frontend/.env.development". This should match the localhost port the backend is using by default, but if you need to change it this is where.
Run "npm install" in the frontend folder to setup dependencies.
To start the frontend application run the command "npm run dev" in the frontend folder.

### Backend-Setup:
The backend should be run from the backend folder ("./backend").
Before starting the backend you need to set up your userSecrets and your database.

Here is a guide to the important userSecrets to configure:

  Database:
  
  | Configuration key | Description | Required |
  |---|---|---|
  | `ConnectionStrings:DefaultConnection` | Connection string for the application's database. | Yes |
  
  Azure Blob Storage:
  
  | Configuration key | Description | Required |
  |---|---|---|
  | `BlobAzureStorage:ConnectionString` | Connection string used to access Azure Blob Storage. | Yes |
  | `BlobAzureStorage:ContainerName` | Name of the Azure Blob Storage container. Default: `cityimages`. | Yes |
  
  JWT Authentication:
  
  | Configuration key | Description | Default value |
  |---|---|---|
  | `Jwt:Issuer` | Issuer identifier for generated JWT tokens. | `WhereAreWeBackend` |
  | `Jwt:Audience` | Audience identifier for generated JWT tokens. | `WhereAreWeFrontend` |
  | `Jwt:SigningKey` | Secret key used to sign and validate JWT tokens. | Must be configured |
  | `Jwt:AccessTokenMinutes` | Lifetime of an access token in minutes. | `30` |
  | `Jwt:RefreshTokenDays` | Lifetime of a refresh token in days. | `7` |
  
  Seed Users:
  
  The application uses predefined seed users to populate the database with initial accounts. These users are added to the users table in the database the first time you run the application if they do not already exist.
  
  | Configuration key | Description |
  |---|---|
  | `SeedUsers:User1:Username` | Username for the first seed user. |
  | `SeedUsers:User1:Email` | Email address for the first seed user. |
  | `SeedUsers:User1:Password` | Password for the first seed user. |
  | `SeedUsers:User2:Username` | Username for the second seed user. |
  | `SeedUsers:User2:Email` | Email address for the second seed user. |
  | `SeedUsers:User2:Password` | Password for the second seed user. |
  | `SeedUsers:Admin:Username` | Username for the administrator account. |
  | `SeedUsers:Admin:Email` | Email address for the administrator account. |
  | `SeedUsers:Admin:Password` | Password for the administrator account. |
  
  Seed user credentials should be configured securely. Do not use production credentials or real user passwords as seed values.
  
  Configure seed user passwords using User Secrets as well, if they are not already provided through another secure configuration source.
  
  Developers must obtain the necessary credentials and configuration values separately before running the application.

The secrets you need to configure yourself are the jwt signingkey (a suggestion would be a 64 character random string), and the BlobAzureStorage:ConnectionString which should be to a Blob Storage you control and a ContainerName that matches a container in your own Blob Storage.

If you want to configure which pictures are tied to the cities you need to manually edit the seeded data in "./backend/data/DataBaseSeed.cs". The cityPicture property is the name of a file inside your Blob Storage configured in secrets.

After secrets are configured you can create the database and run the backend application.

To create the database you can run the command "dotnet ef database update" in the backend folder ("./backend").
To then run the application run the command "dotnet run" in the backend folder ("./backend").

### Azurite Setup (Integration Tests)

Some integration tests may require Azurite, a local emulator for Azure Blob Storage. Azurite allows developers to test Blob Storage functionality without connecting to a real Azure Storage account.

**Install Azurite**

Azurite can be installed globally using npm:

```bash
npm install -g azurite
```

**Start Azurite**

Run the following command in a separate terminal:

```bash
azurite
```

By default, the Blob service runs on `http://127.0.0.1:10000`.

**Configure the connection string**

If the integration tests use the default Azurite connection, configure the following value in the test environment:

```text
BlobAzureStorage:ConnectionString = UseDevelopmentStorage=true
```

The container name should match the container expected by the tests.

**Run the tests**

From the backend folder, run:

```bash
dotnet test
```

Keep Azurite running while executing integration tests that depend on Blob Storage.
