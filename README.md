Install ef core tools needed for database migrations using `dotnet tool install --global dotnet-ef`

## Launching the API
On terminal run `cd product-Crud-Dotnet/product-Crud-Dotnet`

Run database migrations using `dotnet ef database update`

Launch the API using `dotnet run --launch-profile http`

Run xunit tests with `dotnet test product-Crud-Xunit`

## Running the Client

Navigate to the client flder with `cd Ecommerce-Client`

Install dependencies using `npm install`

Launch the client using `ng serve -o`
