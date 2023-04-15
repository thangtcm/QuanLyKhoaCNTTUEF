# QuanLyKhoaCNTTUEF
A full stack web project built using ASP.NET, EF Core.
The app can be used to browse and manage school system events

## Screenshots: 
Login:

<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231065-5a28d96f-08df-44d9-a40c-9eda77ddc581.png">

Event management page:

<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231073-f6dd087c-3c4d-478a-8783-9b1b2d9c7864.png">
<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231180-5a5a42d6-1850-48eb-8472-13a45b2c54ae.png">
<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231184-b82b8ac7-5e58-4b60-9dae-71a4738c251b.png">

Plan management page:

<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231081-4f8c9967-053a-4403-b222-4ba6e5aaee86.png">
<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231220-e475aa62-1a01-4bde-b554-0588690e260f.png">

Group management page:

![image](https://user-images.githubusercontent.com/22448178/232231295-0e197b47-e7a8-4a26-825d-3dbf11b76434.png)
<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231533-49ed8a67-8b9d-43c7-aea2-b8a5b56f5948.png">
<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231641-c55fd19b-6d63-4fd9-a69f-d994f73a4cad.png">
<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231703-da166bf8-4820-4f42-8d68-3ee6783b2271.png">

Task management page:

<img width="1920" alt="image" src="https://user-images.githubusercontent.com/22448178/232231304-3dd871f1-2c99-4abe-840c-8245a717a756.png">

![image](https://user-images.githubusercontent.com/22448178/232231327-d0e48f36-5e36-4e1c-9bca-a434a5edd9c5.png)

ToastR notifications:

<img width="324" alt="image" src="https://user-images.githubusercontent.com/22448178/232232028-878239fd-6cd6-4e57-a04e-bb02157d9323.png">

**Admin**
- Can edit and delete events.
- Can edit and delete plans.
- Can edit and delete groups.
- Can edit and delete tasks.
- Can edit and delete users.

- Can delete user accounts.

## Built With:
- ASP.NET Core 6
- Entity Framework Core 
- Microsoft SQL Server Express
- ASP.NET Identity System
- MVC Areas (Admin / User)
- Razor Pages + Partial Views
- Customized Log in and Register pages (scaffolded)
- Responsive Design (Custom CSS, Bootstrap and JS animations/transitions/DOM)
- Bootstrap 5

(Libraries)
jQuery

## Database structure (corresponds to 3rd normal form with some reservations for simplification):
<img width="1184" alt="image" src="https://user-images.githubusercontent.com/22448178/232232236-a9ee879c-d43c-4f7c-81ae-1c505b2f3f9f.png">

## Local Enviroment Setup
1. You need to have the .NET 7 SDK installed. Be sure to download the latest version for Visual Studio 2022.
2. Use the latest version of Visual Studio 2022: https://visualstudio.microsoft.com/downloads/
3. Install SQL Server 2019 (or later version), Developer or Express edition: https://www.microsoft.com/en-us/sql-server/sql-server-downloads. By default this uses localdb; adjust the connection string in appsettings.json if needed. 



