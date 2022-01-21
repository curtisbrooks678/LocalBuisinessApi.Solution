# _Local Buisiness API_

#### _Practice assignment to get experience creating an API to hold local restaurant and shop data._

#### By _**Curtis Brooks**_

## Technologies Used

* _C#_
* _.NET 5_
* _ASP.NET Core MVC_
* _MySQL and MySQL Workbench_
* _Git_


## Setup/Installation Requirements

### Application Setup
* _Install .NET 5.0 [here](https://dotnet.microsoft.com/download/dotnet/5.0)_

* _Clone repository from GitHub to desired location using_
  > git clone https://github.com/curtisbrooks678/LocalBuisinessApi.Solution
* _In the terminal navigate to and open solution directory_
  > cd LocalBuisinessApi.Solution
* _Navigate to project directory_
  > cd LocalBuisinessApi
* _Create a file in project directory called appsettings.json_
  > touch appsettings.json
* _Add the following code to your .json file_
```
{
"ConnectionStrings": {
"DefaultConnection": "Server=localhost;Port=3306;database=curtis_brooks;uid=root;pwd=[YOUR PASSWORD];"
}
}
```
* _Make sure that [YOUR PASSWORD] matches the database password of your local MySql server._

### Database Setup

* _Download MySQL and MySQL Workbench to set up a local database_

* _Once installed, open MyMql Workbench and open a local server_

* _Go to the top level of the project directory, LocalBuisinessApi, then enter the command below to initialize the database on your MySQL Workbench._
  >dotnet ef database update

### To Run Application

* _Navigate to LocalBuisinessApi project directory in terminal_
  > cd LocalBuisinessApi

* _To download obj and bin files needed for the program to run, while still in LocalBuisinessApi folder type into the terminal:_
  >dotnet restore

* _To run the program, while still in project directory LocalBuisinessApi type into the terminal:_
  >dotnet run
#### Note: The server will not open automatically. The user will need to click on the live share link in terminal, or enter 'localhost:5000' URL into browser.
* _To interact with the program, use [Postman](https://www.postman.com/downloads/) and follow API Documentation below._

## API Documentation
Explore the API endpoints in Postman.

### Using Swagger Documentation 
To explore the Local Buisiness API with Swashbuckle, launch the project using `dotnet run` with the Terminal or Powershell, and input the following URL into your browser: `http://localhost:5000/swagger`

### Endpoints
Base URL: `https://localhost:5000`

#### HTTP Request Structure
```
GET /api/{component}
POST /api/{component}
GET /api/{component}/{id}
PUT /api/{component}/{id}
DELETE /api/{component}/{id}
```

#### Example Query
```
https://localhost:5000/api/restaurants/1
```

#### Sample JSON Response
```
{
    "shopId": 1,
    "name": "You can glue it!",
    "address": "123 Fake St, Seattle, WA",
    "specialty": "Crafts",
    "rating": 5
}
```

..........................................................................................

### Restaurants
Access information on local restaurants. _Please note: since this is a test api, there are only 3 restaurants(id 1-3)_

#### HTTP Request
```
GET /api/restaurants
POST /api/restaurants
GET /api/restaurants/{id}
PUT /api/restaurants/{id}
DELETE /api/restaurants/{id}
```

#### Path Parameters
| Parameter | Type | Required | Description |
| :---: | :---: | :---: | --- |
| name | string | true | Return any restaurants with a specific name. |
| address | string | true | Return any restaurants with a specific address. |
| cuisine | string | true | Return any restaurants with a specific cuisine. |
| rating | int | true | Return any restaurants with a specific rating (1-5). |

#### Example Query
```
https://localhost:5000/api/restaurants/?cuisine=pizza
```

#### Sample JSON Response
```
{
    "restaurantId": 1,
    "name": "Andy's Pizzeria",
    "address": "123 Fake Ave, Portland, OR",
    "cuisine": "Pizza",
    "rating": 3
}
```

..........................................................................................

### Shops
Access information on local shops. _Please note: since this is a test api, there are only 3 shops(id 1-3)_

#### HTTP Request
```
GET /api/shops
POST /api/shops
GET /api/shops/{id}
PUT /api/shops/{id}
DELETE /api/shops/{id}
```

#### Path Parameters
| Parameter | Type | Required | Description |
| :---: | :---: | :---: | --- |
| name | string | true | Return any shops with a specific name. |
| address | string | true | Return any shops with a specific address. |
| specialty | string | true | Return any shops with a specific specialty. |
| rating | int | true | Return any shops with a specific rating (1-5). |

#### Example Query
```
https://localhost:5000/api/shops/?specialty=crafts
```

#### Sample JSON Response
```
{
    "shopId": 1,
    "name": "You can glue it!",
    "address": "123 Fake St, Seattle, WA",
    "specialty": "Crafts",
    "rating": 5
}
```

## Known Bugs

* _No Known Bugs_

## License

_[MIT](https://choosealicense.com/licenses/mit/) Copyright (c) 2022 Curtis Brooks_





