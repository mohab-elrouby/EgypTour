# EgypTour

EgypTour is a .NET WebAPI that provides users with a way to explore trip destinations to visit in Egypt, read and write reviews about differnet places and restaurants, chat with locals as tour guides, schedule trips, and add posts. It uses SQL Server for storage and is designed to be easily scalable and customizable.

## Features

- Explore destinations to visit in Egypt
- Read & write reviews about different places and services
- Chat with local Egyptian tour guides
- Schedule trips
- Add posts

## Technologies Used

- .NET 6.0 
- SQL Server 2019

## Getting Started

### Prerequisites

- .NET6 SDK - includes the .NET runtime and command line tools ([link to download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)).
- SQL Server ([link to microsoft downloads page](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)).

### Installation

1. Clone the repository
<code>git clone https://github.com/mohab-elrouby/EgypTour.git</code>

2. Navigate to the project directory
3. Build the project
<pre>dotnet build</pre>
4. Update the appsettings.json file with your SQL Server connection string
<pre>  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=EgyTour;Integrated Security=true;Encrypt=False"
  }</pre>
5. apply the migrations to create the database 
<pre>dotnet ef database update</pre>
6. Run the project
<pre>dotnet run</pre>


## API Reference

Please refer to the API documentation for information on how to use the EgypTour API.

## Contributing

Contributions are always welcome! If you'd like to contribute to the project, make a fork to the repo, add your code and make a pull request to the contribution branch.

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.


