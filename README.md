# Donor Dashboard — Mock CRM

A command-line CRM application built in C#, modeled after DonorPerfect. Built to deepen my understanding of the fundraising workflows and data management systems I work with daily as a Technical Support Specialist.

---

## What It Does

Donor Dashboard simulates the core functionality of a nonprofit CRM, allowing users to manage and analyze donor data through a simple menu-driven interface.

**Features:**
- View all donors and their giving history
- Add new donors with input validation
- Search donors by name (case-insensitive)
- View top 5 donors ranked by total giving
- View donation summary including total raised and average gift size

---

## Why I Built It

I support nonprofit clients on DonorPerfect daily — troubleshooting data issues, configuring integrations, and working with QA and engineering teams on platform bugs. I built this project to move beyond being a functional user of CRM software and start reasoning about how it works at a code level. Replicating the workflows I know well gave me a concrete foundation to build on.

---

## Tech Stack

- **Language:** C#
- **Framework:** .NET (Console Application)
- **Key Concepts:** Object-oriented programming, LINQ queries, input validation, list data structures

---

## How to Run

1. Make sure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed
2. Clone this repository
3. Navigate to the project folder in your terminal
4. Run the following command:

```bash
dotnet run
```

---

## Project Structure

```
DonorDashboard/
└── Mock CRM.cs       # Main application file containing all classes and logic
```

---

## Sample Data

The app loads four sample donors on startup so you can explore the features immediately without adding data manually.

---

## What I Learned

- Structuring a C# console app using classes and a main program loop
- Using LINQ for sorting, filtering, and aggregating data
- Handling user input safely with `TryParse` and validation loops
- Modeling real-world data workflows in code
