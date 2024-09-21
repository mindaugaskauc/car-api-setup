Downloading the code:

1. Clone the project from github with the following command:
   Open a command terminal, and then clone the project from GitHub by using the command prompt:

   git clone https://github.com/car-api-setup (change if needed)

2. Go to the car-api-setup folder, and open the project in Visual Studio Code:
   cd car-api-setup
   code .

Installing packages

1. Add the NuGet package that contains the EF Core SQLite database provider and all its dependencies:
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite

2. Add the packages needed for the EF Core tools.
   dotnet add package Microsoft.EntityFrameworkCore.Design

3. Install dotnet ef tool which is used to cread migrations and scaffolding
   dotnet tool install --global dotnet-ef

Creating and running migration to create a database

1. Create a migration:
   dotnet ef migrations add InitialCreate --context CarContext

2. Apply the migration:
   dotnet ef database update --context CarContext

After applying the changes, build the application with the command
dotnet build







Testing the app:

1. Run the application with the command dotnet run

2. Add a new car

Go to Post/car and add the following code:


{
  "name": "Peugeot 408",
  "price": 12457,
  "engine": {
    "name": "Flat"
  },
  "gearbox": {
    "name": "Automatic"
  },
  "seatMaterial": {
    "name": "Leather"
  }
}

Check the result:

{
  "id": 6,
  "name": "Peugeot 408",
  "price": 12457,
  "engine": {
    "id": 5,
    "name": "Flat"
  },
  "gearbox": {
    "id": 3,
    "name": "Automatic"
  },
  "seatMaterial": {
    "id": 5,
    "name": "Leather"
  }
}

3. Update gearbox to Mechanical:

Go to Put /Car/id/updategearbox

Set car id as 6
Gearbox id as 2

Result:

  {
    "id": 6,
    "name": "Peugeot 408",
    "price": 12457,
    "engine": {
      "id": 5,
      "name": "Flat"
    },
    "gearbox": {
      "id": 2,
      "name": "Mechanical"
    },
    "seatMaterial": {
      "id": 5,
      "name": "Leather"
    }
  }

4. Delete the car Peogeot 408 from the database
   Go to Delete/Car/id and add the id 6