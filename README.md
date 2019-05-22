# Car Fleet Manager

Hello, dear reader! I am sure you are a fan of cars. Even if not, it will be a very good example to work with cars and databases. Well, let's look at the application.


## Get started
The application is called **"Car Fleet Manager"**. It is was developed in C# programming language and created on the old and good WPF technology. On the server side, T-SQL queries are used. So let's see a short demo how to app works.

![demo](https://lh3.googleusercontent.com/vyBs8p26-FSC6lkOCQDjVCCa07a1RC60VUl5QsBy6m3ys_041jsGdkBpVbDvwINIrSA-VD7tg8f356dFdoCAAlWmvEqHlsBua-fTUaRoJ5wcsT7fFH8k4XwIC7jlLlv44U9TJjBKvdOGvFGe9KtRgGgYFfu4_WOpo6YZu2O91_YcXNcAKMPX3w6NJfvRkI4A8knS8mJA7heKJFSGcfeQANr1RojD4CFyb8rydSJWWokYljEyAkIwSmBpM_MeiKLmm0EECNWio9MH8c2mFuOQDiK5Ok1Ca8DalZpsq6uhfCDaIB5RGnsmsW5CE9wFp6tFs1FBNwZqchqtmOj8jez3ZtvJa5XPx3Bk-1Y6d7FD04kCrdxuTalTFAF1rPvTF1OBzbTH2CwCSBVOfumzz1dGifkzVSL0iGz7fiGUfaFyCoNms2g7YVYLP2D6xpGCfnUwA0Z6k0Tm7hAWYrPS_cjDkghUYoTQQRD86eIDAHuxjdZRJtmDsGgkKH2aftJsYDN-sAc9Pl7Y2W-N2gGlcwVMAqs3cLu7s3LKzG8iyY0Wnvw1G_iCc0sI0gWYNgeH1pleR1pDd1zXkSdH0p_G7cBKDpeHDIO7_2brE-KPc6rbCk4Gja1r_ZKtxATpsffYbbO7QW9OJfs0IRWpeZuuf1P-1Qj_VdZzjTg=w500-h378-no)



## Connect to database
The first, create a WPF project (.Net Framework). The next step you need to create a database (the *"Server Explorer"* window). Right-click on the *"Create New SQL Server Database..."* item.

To connect to the database, you need to use the [SqlConnection Class](https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection?view=netframework-4.8). The variable *connectionStringDB* you need to declare in the constructor. And also, you need to add the *using System.Configuration* reference. An example code for connecting to a database is shown below.

```csharp
 using System.Configuration;

 public partial class MainWindow : Window
 {
        readonly SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            // connection string to database
            string connectionStringDB = ConfigurationManager.ConnectionStrings["Car_Fleet_Manager.Properties.Settings.SunlistDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionStringDB);
        }
 }
```

In the Visual Studio you can visually see this path, that is written to the *connectionStringDB* variable.

![ConnectionString](https://lh3.googleusercontent.com/1629qw7ZhnE7Vc14DdCr2ElkPocjI-yiM3r6gUH4VMikoW1aSuNsfBPfXr-8G58pMbA40syL-d79v6jI71htEE3hKME0Bwd3imo9GaVvCDhkq0fgtWWxrnE9PanRc88f6JMYhoc37V-nl6IYNA47naautZjcfdH6CsrFuZca3S-zpNsSjzBv90N-EPFGtxhqt6OjA4sQCg912k188iX8w25aCgs6hzpI1fyBqO7250XAIKb3KmyhVtSTTpahfjXR9M7_0Na7qbroMrlGSouIT0FFY1aPL4lxEsWJcArWeU4syWL_XhQZ_WXWX3DrBnJ8YGEOnzS9wGVc0OXEhEkjj9NCcl-BNoKeJHcDokRd6vmjx0kPkyAIEweoHsxUnBccYUgzx28VYcwLwJhX7oIRqQNrwMw31KwdhjECr3P-fdh8k0RVsODLEi-UNjSYe6XUNQYXyyOhrJrPYUplmrEufXy5hhj0U34dltBcQ5tkyEdmTEIzAVzSDdaLWlxt0AsrFgi2HJbGIVPY8WuGxfirjmoVnxb18n9falUygczSj2lKGhT596EBkEJnum0khunjAZKZr_rMMU0VdIPRoICmvKywkxtCnr7wJ_t0utJBnLLaEtL-VP7drjuRfYWsilmmzadec_TgBuOUD2nz7BbHAeR1u1TXkt4=w353-h275-no)


## User interface of the app

**The application has 3 lists**

List #1 contains the names of all сar fleets. List #2 contains all available machines that are in the selected car fleet. That is, lists #1 and #2 are linked together. And the last list #3 shows all new cars are available in 2019 that are in the registry.
   
**Several working buttons for working with lists**

There are opportunities to add, update, and delete objects in lists. All buttons have hints when hovering over them.
   
**Powerful input field**

   Also, the application has an input field for editing object names in all 3 lists. With the "Update"  button, you can set a written value.
  
Application has three windows. The Main Window looks like this. 

![MainWindow](https://lh3.googleusercontent.com/b_seff9EXmrz4KjxHH3fJg1utT4j-zdYyaK6zNhjzLKYQCur_0OSRb3cUn07Ul1qhcA69SRBlkQarup4pqfFuQ4snUNqG1n-V7lOkEkfg3vKvbezLRX78TbV39tWleM-vRfzRDU3rYK0oUAmUhC_f0XdUyP2394I6bZnBfYXojdWCesf8o1CguosyicPIv3QO9ttSYEpNkwOiuMBvoJBVDdYX5qnAG1kJKZGqz9-ZfgrwCGvmx9L8sm15iqbXtuN7WadP6pSG3jOW819nxl4VUVg4IMP6Pwd7S0W2EVQDeDS0WcQpXTTMnFUPg5HqWg4OU4zcI3SxHW010M4FBuTSMUjlLfakOJfccIizscoYTXNqcRkEpg_W7KAEpmZ6KD4hD4p7cQqsVaHfTMYqQ2FaHvlT8EOLKPBiRFdIGOEDtiB4j3KlNexQEuyGfjuonX3EhU1foIjjgnOvKudYRrIHZWxLnWEDNYrnfmETLiL3zhLWD8nhgTRDTyWMgTv517jgf1mq-Yh9cmWjDCSBYEcbzDisk1LbdOVAkZFK-olRvejyFfYjHsQ3bonjz4H8kb2s82asm4PQSsBChkFsZLI8r_hgvv9JFQ1PSreuyudpwe836xWPg5tC8NU_u7sFQVUnI1md0NvcWuEgJctAlTn4-8Y7NiqsXM=w884-h666-no)

## Database diagram
The diagram shows all the relationships between the 3 tables. 

The CarFleet table contains information about the location of the fleets. The Car table contains data about the car brand (together with the model). And the latest CarRegister table shows all available machines that are currently in the registry. 

T-SQL queries are shown below.

![Diagram](https://lh3.googleusercontent.com/ZZCGJiEj_QPE-2IwvQrv3F1FmAW3JgsRF9heVOrgrPMciPuHz-zR8kHZ-tnbRQIrL3eqVGNNq4DHQ7J6UAw3BQksPek8a88N2yxBmzNjsOUAMUUe4dAzPw4lWOoA1anLMiiYDsNcWaHQelDMXMBR8p2Mjyju1xesUSe5sPgmRzAUHZ50-3ChRLfj_-0CwSQvab_SFSBoWmhO-ZVrZ_6yPSWBJT1Iylv868aDZpJDk7WBizz7hKdI07OrN2iHfWDAb9f2u_jNY8sZOnvfxtbzenLpJrj5g8RmMTiwdu4M6FwbAzU45Ra9w4zPbkXunQ4qoPrcjlE4duQJbHN77vcMcycLZvv68BZhDIwLQZWPHrH2DyBzq-Ky8PPvbYDAa5hm2LOjCUWHPMJXdAItrOot06jNphgGEti_vr7PHnI05KaFdfUeJ2M5_yPdX-M4D7B3w2h7N3gqwr6SAiHQcGABM9dOT6VK9Manq0LU3Jwg1Ae9aFDHSdqGMcRMhYzxPunCCCr6S8omuRO7tiY-5a1tyPZ4ny0wIwUg3C1voyonmZDOribO1BWSreWwKrAaSAw0gazd2bMNoZ9N-euRlA1-rl30bBp2EoKPDWVtAKXEfN41-89LMyAWggL9bVxYO37_xJcY-vhzFjtojyv-AmCXf-DPGawhssY=w745-h436-no)


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

- [Microsoft Visual Studio Enterprise 2019 Preview](https://visualstudio.microsoft.com/) is an integrated development environment (IDE) from Microsoft. It is used to develop computer programs, as well as websites, web apps, web services and mobile apps.
- [Blend for Visual Studio Enterprise 2019 Preview](https://visualstudio.microsoft.com/) is a user interface design tool developed and sold by Microsoft for creating graphical interfaces for web and desktop applications that blend the features of these two types of applications.
- [Microsoft SQL Server 2017 Delevoper Edition](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads) is a relational database management system developed by Microsoft. SQL Server includes the same features as SQL Server Enterprise Edition, but is limited by the license to be only used as a development and test system, and not as production server. Starting early 2016, Microsoft made this edition free of charge to the public.
- [Microsoft SQL Server Management Studio 17.9.1 (SSMS)](https://docs.microsoft.com/ru-ru/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) is a software application first launched with Microsoft SQL Server 2005 that is used for configuring, managing, and administering all components within Microsoft SQL Server.

## License

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

Car Fleet Manager used the GNU v3 GPL. Look the [LICENSE.txt](https://github.com/JuniorPoligraphist/CarFleetManager/blob/master/LICENSE/LICENSE.txt) file for more details

## Version
Available build version of the application:

- `[assembly: AssemblyVersion("1.0.0.1")]`
- `[assembly: AssemblyFileVersion("1.0.0.1")]`


## Special thanks

And at the end, I want to thank Denis Panjuta for a great C# course: 
[Complete C# Masterclass](https://www.udemy.com/course/complete-csharp-masterclass/ "Complete C# Masterclass")

Thank you, Denis! :sunglasses::blush::smiley:
