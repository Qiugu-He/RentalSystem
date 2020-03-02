# Rental System
A rental system allows store mamanger to manage/modify information about all items in store that to be rented, and also manage information about thier clients and their rental records.

# How it works?
The System is based on **ASP.NET MVC 5**. The goal is to provide  functionalities for system administrator to manage the database, and for online customers to rental the items that are intrested to them. 

The system using authorization and authentication to distinguish between admin and customer by using login function. The system administrator can get/add/delete/update the itmes in store, and they also can get/add/delete/update all the information about its registered customer. This is done by implementing **RESTful API** via http request, which will do the correspoding query **SQL** operations to the related table in database (Microsoft SQL server).

The customer can register and login (or via social media), however, they can only view and edit their profile, and view the items that are avaliable in store.

# System Structure
As program is based on .net MVC, so the main components is **Model <--> Controller <--> View**

For example, customer to view all the Items avaliable in store. The ItemController will fetch all the itmes (Model) from DB by using **Entity Framework**. It is a tool to access database, a object relational mapper, which maps data in relational DB into objects of application. Then after fetch the data from DB, it render the corresponding HTML views to user.


# RESTful API built/testing:
The API built that get the **raw JSON data** from DB is for testing purpose. You can using tools such as Postman to make a request call.

To be noted here, the data that API received or returned is using **Domain Transfer model** for transfer data between client and server, as this orginal domain model contains implementation detailes, and it can be changed frequently, this change can potentially break the existing client that depend on this Obj. The transfer is done by using 'Automapper'.


# Performance:
- Each realtions in DB is set with a primary key, an indexes is added on the column of the table that are accessed frequently (e.g. Items table, user table), so SQL query are executed faster.
- Disabled Session

# App demo:
- **Resigter & login**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/login.png" alt="alt text" width="60%" height="60%">
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/register.png" alt="alt text" width="60%" height="60%">

- **Itmes avaliable in store**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/Items.png" alt="alt text" width="60%" height="60%">

- **Member/User list**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/User.png" alt="alt text" width="60%" height="60%">


- **User Rental form**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/Rental1.png" alt="alt text" width="60%" height="60%">

- **Rental recored**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/Rental2.png" alt="alt text" width="60%" height="60%">

- **Database tables**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/DB1.png" alt="alt text" width="60%" height="60%">

- **Database user and Items records**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/DB2.png" alt="alt text" width="60%" height="60%">
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/DB3.png" alt="alt text" width="60%" height="60%">

- **Database rental records**
<img src="https://github.com/Qiugu-He/RentalSystem/blob/master/DB4.png" alt="alt text" width="60%" height="60%">



