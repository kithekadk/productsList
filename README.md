Install ef core tools needed for database migrations using `dotnet tool install --global dotnet-ef`

## Launching the API
On terminal run `cd product-Crud-Dotnet/product-Crud-Dotnet`

Run database migrations using `dotnet ef database update`

Launch the API using `dotnet run --launch-profile http`

Run xunit tests with `dotnet test product-Crud-Xunit`

## Running the Client

Open new terminal

Navigate to the client folder with `cd Ecommerce-Client`

Install dependencies using `npm install`

Launch the client using `ng serve -o`

## Running the Unit Tests

Open new terminal and close the server

navigate to the directory using `cd product-Crud-Dotnet/product-Crud-Xunit`

Run xunit tests with `dotnet test`
