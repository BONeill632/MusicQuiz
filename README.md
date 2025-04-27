A web application built with ASP.NET Core MVC (.NET 9) and MySQL.

🛠 Prerequisites
.NET 9 SDK (your global.json targets version 9.0.200)

Node.js (for frontend dependencies)

MySQL server installed and running

📥 Setup Instructions
Clone or download the project files from GitHub.

Open the solution (.sln) file in Visual Studio 2022 (or newer).

Restore NuGet packages:

Visual Studio usually does this automatically.

If not, right-click the solution and select Restore NuGet Packages.

Install frontend dependencies:

Navigate to the folder that contains your package.json (e.g., ClientApp/ or wherever it's located).

Run:

bash
Copy
Edit
npm install
Configure your database:

Ensure MySQL server is running locally.

Update the connection string in appsettings.json if necessary:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=MusicQuiz;user=root;password=yourpassword;"
}
Make sure the username and password match your local MySQL setup.

Create and initialize the database:

Open the Package Manager Console in Visual Studio.

Set the default project to the project containing your Entity Framework Core migrations (probably your main web app project).

Run:

powershell
Copy
Edit
Update-Database
This will create the MusicQuiz database and apply all migrations.

Run the application:

Press F5 or click Start Debugging in Visual Studio.

The application should build and launch automatically.

ℹ️ Notes
If you encounter frontend issues, make sure npm install completed successfully.

If you update the MySQL schema later, remember to generate new EF Core migrations and apply them.

Ensure your MySQL port (3306) is open and not blocked by a firewall if you have issues connecting.

🚀 You're all set to start playing MusicQuiz!
❗ Quick Checklist for Yourself Before Submission:
Double-check that appsettings.json does not contain your real database password if you're pushing to GitHub.

Confirm the project runs after cloning and following the README instructions.

If your migrations are missing for some reason, consider adding a quick note about how to re-create them.

