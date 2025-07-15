# RavenDB CRUD App (.NET)

This is a simple .NET MVC application demonstrating how to perform basic Create, Read, Update, and Delete (CRUD) operations using RavenDB — a fully transactional NoSQL document database.

---

## 🚀 Features

- Document-based storage using RavenDB
- Seed data for People and Departments
- Auto-creation of collections upon storing documents
- MVC-based UI for listing, adding, and editing records
- Lazy-loaded singleton DocumentStore for efficient access

---

## 🛠️ Prerequisites

Before running the project, make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [RavenDB Community Edition](https://ravendb.net/download)

---

## 📦 How to Set Up RavenDB

1. Download and extract RavenDB from the link above.
2. Navigate to the extracted folder.
3. Run the RavenDB server:
   - On Windows: `Start.cmd`
   - On Linux/macOS: `./run.sh`
4. Once it's running, go to [http://localhost:8080](http://localhost:8080)
5. Create a new database named: `RTest1`

---

## ▶️ How to Run the App

1. Clone this repository:
   ```bash
   git clone https://github.com/Rujwol/RavenDBDotnetCRUD.git
````

2. Open the solution in Visual Studio or your preferred IDE.
3. Make sure `RavenDbStore.cs` points to:

   ```csharp
   Urls = new[] { "http://127.0.0.1:8080/" };
   Database = "RTest1";
   ```
4. Build and run the project.
5. Navigate to `/People` in the browser to see the list of seeded people.

---

## 📁 Project Structure

```
RavenDBDotnetCRUD/
│
├── Models/
│   ├── Person.cs
│   └── Department.cs
│
├── RavenDbStore.cs     # Lazy singleton for IDocumentStore
├── SeedData.cs         # Seeds Person and Department data
├── Controllers/
│   └── PeopleController.cs
│
└── Views/
    └── People/
        └── Index.cshtml, Edit.cshtml, etc.
```

---

## 🧠 Notes

* RavenDB collections are created automatically when documents are first inserted.
* You can add new fields to models at any time; existing documents will remain valid (schema-free).
* Embedded vs referenced documents are supported (denormalization is common).

---

