# Word Counter

#### An Epicodus exercise in xUnit testing, 06.02.17

#### **By Nick Wise***

## Description

This web application will take one word as user input and compare it to a string of words the user has also inputted. Finding all the matches of the single word in the following string.

| Word Counter behavior | input  | output  |
|---|---|---|
| Program will allow Employee to see list of stylist | nancy, josh, jenny | nancy, josh, jenny | - Need a page that displays all currently employed stylists.
| Employee can look under a specific stylist to see there details and clients |jenny | Name: "jenny" Clients: "Frank", "Bob", "Sally" | - on click route to id of selected stylist
| Owner can add a new stylist | "Sally" | "Sally" | - form that gets the id and name of the new stylist and routing within our save and find methods so they can be stored in databaseS
| Stylist can add new clients to there list of clients | add Client: "James" to Stylist: "Jenny" | Jennys Clients : "James", "Bob", "Jessica"| - one to many relation ship where the client has a stylist Id attached to their name so we can add multiple clients to a single stylist.
| Stylist can update client to there list of clients name| update Client: "James" to Client: "Jenny" | Update "James" to "Jenny"| - Update and Patch methods allow us to update user information.
| Stylist can delete  clients to there list of clients | delete Client: "James" to Stylist: "Jenny" | Jennys Clients : "Bob", "Jessica"| - one to many relation ship where the client has a stylist Id attached to their name so we can delete a client.

## Gh-pages

## Setup/Installation Requirements

https://github.com/YcleptInsan/Salon
Click the "download or clone" button and copy the link.
In your computers terminal type "git clone" & paste the copied link.
Once downloaded you can open the index.html file in the browser of your choice.
You can view the code using the text editor of your choice as well.

Next, SQLCMD: > CREATE DATABASE salon; > GO > USE salon; > GO > CREATE TABLE client (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT); > CREATE TABLE stylist (id INT IDENTITY(1,1), name VARCHAR(255)); > GO

## Known Bugs

* No known bugs


## Support and contact details

If you have any issues or have questions, ideas, concerns, or contributions please contact any of the contributors through Github.

## Technologies Used

* HTML
* JSON
* C#
* Nancy
* Razor
* xUnit
* SQL Server management 2016
* ADO.NET

### License
This software is licensed under the MIT license.

Copyright (c) 2017 **Nick Wise**
