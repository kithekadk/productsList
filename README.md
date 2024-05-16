## HOW TO RUN WITH DOCKER
Ensure docker desktop is opened

Clone the project

Run `docker compose up`

- The API uses port 9100 while the client runs on port 4200
- Incase you change the api port on the compose file, update the services in the client side to enable requests
  - Then build the images again using `docker compose build product-list-api` then `docker compose build product-list-web`


### RUNNING LOCALLY WITHOUT DOCKER

Install dotnet sdk using `https://dotnet.microsoft.com/en-us/download`

Install ef core tools needed for database migrations using `dotnet tool install --global dotnet-ef`

## Launching the API
On terminal run `cd product-Crud-Dotnet/product-Crud-Dotnet`

Run database migrations using `dotnet ef database update`

Launch the API using `dotnet run --launch-profile http`

## Running the Client

Open new terminal

Navigate to the client folder with `cd Ecommerce-Client`

Install dependencies using `npm install`

Launch the client using `ng serve -o`

## Running the Unit Tests

Open new terminal and close the server

navigate to the directory using `cd product-Crud-Dotnet/product-Crud-Xunit`

Run xunit tests with `dotnet test`
