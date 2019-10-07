# Car Fleet Manager

Hello, dear reader! I'm sure you are a fan of cars. Even if not, it will be a cool example to work with vehicles and databases for you. Well, let's look at the application.


## Get started
The application is called **"Car Fleet Manager."** It's was developed in C# programming language using the old but still good WPF (Windows Presentation Foundation) technology. On the server side, T-SQL queries are used. So let's see a short demo on how to app works. Of course, I have a link on youtube, click on image below.


[![demo](http://img.youtube.com/vi/e23ARn997sQ/0.jpg)](http://www.youtube.com/watch?v=e23ARn997sQ "Click me and go to youtube for watch demo")


## Connect to database
The first, create a WPF project (.Net Framework). The next step you need to create a database (the *"Server Explorer"* window). Right-click on the *"Create New SQL Server Database..."* item.

For connect to the database, you need to use the [SqlConnection Class](https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection?view=netframework-4.8). The variable *connectionStringDB* you need to declare in the constructor. And also, you need to add the *using System.Configuration* reference. Example code for connecting to a database is shown below.

```csharp
 using System.Configuration;

 public partial class MainWindow : Window
 {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            // connection string to database
            string connectionStringDB = ConfigurationManager.ConnectionStrings["Car_Fleet_Manager.Properties.Settings.SunlistDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionStringDB);
        }
 }
```

In the Visual Studio, you can visually see this path, that is written to the *connectionStringDB* variable.

![ConnectionString](https://github.com/SunlistOG/CarFleetManager/blob/master/ConnString.png)


## The user interface of the app

**The application has three lists**

List #1 contains the names of all сar fleets. List #2 includes all available machines that are in the selected car fleet. That is, lists #1 and #2 are linked together. And the last list #3 shows all new cars are available in 2019 that are in the registry.
   
**Several working buttons for working with lists**

There are opportunities to add, update, and delete objects in lists. All buttons have hints when hovering over them.
   
**Powerful input field**

Also, the application has an input field for editing object names in all three lists. With the "Update"  button, you can set a written value.
  
Application has three windows. The Main Window looks like this. 

![MainWindow](https://github.com/SunlistOG/CarFleetManager/blob/master/Main%20Window.jpg)


## Database diagram
The diagram shows all the relationships between the three tables.

The CarFleet table contains information about the location of the fleets. 
The Car table includes data about the car brand (together with the model). 
And the latest CarRegister table shows all available machines that are currently in the registry. 

T-SQL queries are shown below.


![Diagram](https://github.com/SunlistOG/CarFleetManager/blob/master/Diagram.png)


**T-SQL query for CarFleet table**

```sql
CREATE TABLE [dbo].[CarFleet] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Location] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

**T-SQL query for Car table**

```sql
CREATE TABLE [dbo].[Car] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Brand] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

**T-SQL query for CarRegister table**

```sql
CREATE TABLE [dbo].[CarRegister] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [CarFleetId] INT NOT NULL,
    [CarId]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CarFK] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Car] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [CarFleetFK] FOREIGN KEY ([CarFleetId]) REFERENCES [dbo].[CarFleet] ([Id]) ON DELETE CASCADE
);
```

## Built With
The application is built with tools such as:

- [Microsoft Visual Studio Enterprise 2019 Preview](https://visualstudio.microsoft.com/) is an integrated development environment (IDE) from Microsoft. It is used to develop computer programs, as well as websites, web apps, web services, and mobile apps.
- [Blend for Visual Studio Enterprise 2019 Preview](https://visualstudio.microsoft.com/) is a user interface design tool developed and sold by Microsoft for creating graphical interfaces for web and desktop applications that blend the features of these two types of applications.
- [Microsoft SQL Server 2017 Developer Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) is a relational database management system developed by Microsoft. SQL Server includes the same features as SQL Server Enterprise Edition but is limited by the license to be only used as a development and test system, and not a production server. Starting early 2016, Microsoft made this edition free of charge to the public.
- [Microsoft SQL Server Management Studio 17.9.1 (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) is a software application first launched with Microsoft SQL Server 2005 that is used for configuring, managing, and administering all components within Microsoft SQL Server.

**Note!** Don't be afraid, when you see a Visual Studio preview version. I'm used the preview version for testing. And **you can also use the free Community version of Visual Studio and Blend too.**


## License

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

Car Fleet Manager used the GNU v3 GPL. Look the [LICENSE.txt](https://github.com/SunlistOG/CarFleetManager/blob/master/LICENSE/LICENSE.txt) file for more details

## Version
The available build version of the application:

- `[assembly: AssemblyVersion("1.0.0.1")]`
- `[assembly: AssemblyFileVersion("1.0.0.1")]`


## Special thanks

In the end, I want to thank Denis Panjuta for a great C# course: 
[Complete C# Masterclass](https://www.udemy.com/course/complete-csharp-masterclass/ "Complete C# Masterclass")

Thank you, Denis! :sunglasses::blush::smiley:
