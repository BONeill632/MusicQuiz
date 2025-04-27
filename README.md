# 🎵 MusicQuiz

A web application built with ASP.NET Core MVC (.NET 9) and MySQL.

---

## 🛠 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (`global.json` targets `9.0.200`)
- [Node.js](https://nodejs.org/) (for frontend dependencies)
- [MySQL](https://dev.mysql.com/downloads/) server installed and running

---

## 📥 Setup Instructions

### 1. Clone the Repository
Download or clone the project files:

```bash
git clone https://github.com/your-username/your-repo-name.git
```

### 2. Open in Visual Studio
- Open the `.sln` file in Visual Studio 2022 (or newer).

### 3. Restore NuGet Packages
- Visual Studio should restore packages automatically.
- If not, right-click the solution in Solution Explorer → **Restore NuGet Packages**.

### 4. Install Frontend Dependencies
Navigate to the folder where your `package.json` is (for example `ClientApp/`), then run:

```bash
npm install
```

### 5. Configure Database Connection
Make sure your MySQL server is running.

Check or update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=MusicQuiz;user=root;password=yourpassword;"
}
```

> ⚠️ Replace `yourpassword` with your actual MySQL password.

### 6. Set Up the Database
Open the **Package Manager Console** in Visual Studio:

- Set the default project to the one containing your `DbContext`.
- Run the following command to apply migrations and create the database:

```powershell
Update-Database
```

### 7. Run the Application
- Press `F5` or click **Start Debugging** in Visual Studio.
- The application should build and launch automatically.

---

## ℹ️ Additional Notes

- If frontend issues occur, make sure `npm install` completed without errors.
- Ensure MySQL port `3306` is open and accessible.
- If migrations are missing, you can re-create them using:

```bash
dotnet ef migrations add InitialCreate
```
and then run:

```bash
Update-Database
```

- **Security Tip:** Don't upload sensitive credentials (like database passwords) to public repositories!

---

## 🚀 You're ready to play MusicQuiz!

---

## 🏷️ Badges (Optional)

You can add these badges at the top for a professional look:

```markdown
![.NET 9.0](https://img.shields.io/badge/.NET-9.0-blueviolet)
![MySQL](https://img.shields.io/badge/Database-MySQL-blue)
![License](https://img.shields.io/badge/License-MIT-green)
```
