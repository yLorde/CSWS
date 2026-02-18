# 📚 CSWS --- Controlled Study Windows Shield

**CSWS** is a C# application designed to help you stay focused during
study sessions or important tasks by automatically blocking distracting
applications defined in a custom list.

If a blocked application is opened, the system can close the program or
lock Windows, preventing procrastination.

------------------------------------------------------------------------

## ✨ Features

✅ Detects the application currently in focus on Windows\
✅ Checks whether it is on the block list\
✅ Automatically blocks access\
✅ Can lock the Windows workstation\
✅ Fully configurable application list\
✅ Lightweight and simple application

------------------------------------------------------------------------

## 🎯 Purpose

CSWS was created to help students and professionals maintain
productivity by preventing access to distracting applications during
focus periods.

Examples of use:

-   Block games during study\
-   Block social media during work\
-   Create deep focus sessions\
-   Control computer usage

------------------------------------------------------------------------

## 🧱 Project Structure

    CSWS/
    ├── Program.cs
    ├── blockedList.txt
    ├── CSWS.csproj
    ├── CSWS.sln
    └── README.md

### Important files

  File                Description
  ------------------- ------------------------------
  `Program.cs`        Main application logic
  `blockedList.txt`   List of blocked applications
  `.csproj`           Project configuration
  `.sln`              Visual Studio solution

------------------------------------------------------------------------

## ⚙️ How to use

### 1️⃣ Clone the repository

``` bash
git clone https://github.com/yLorde/CSWS.git
cd CSWS
```

------------------------------------------------------------------------

### 2️⃣ Configure blocked applications

Open the file:

    blockedList.txt

Add executable names separated by commas.

Example:

    chrome.exe, discord.exe, steam.exe

------------------------------------------------------------------------

### 3️⃣ Build the project

``` bash
dotnet build
```

------------------------------------------------------------------------

### 4️⃣ Run

``` bash
dotnet run
```

The program will continuously monitor the currently focused application.

------------------------------------------------------------------------

## 🔒 How it works internally

The system:

1.  Detects the currently focused window\
2.  Retrieves the active application name\
3.  Compares it with the blocked list\
4.  If blocked:
    -   locks Windows or terminates the process

------------------------------------------------------------------------

## 🧩 Requirements

-   Windows\
-   .NET SDK\
-   Permission to lock workstation

------------------------------------------------------------------------

## 🛠️ Possible future improvements

-   [ ] Graphical interface (GUI)\
-   [ ] Whitelist mode\
-   [ ] Focus timer\
-   [ ] Usage statistics\
-   [ ] Blocking profiles\
-   [ ] Pomodoro mode integration\
-   [ ] Windows service

------------------------------------------------------------------------

## 📄 License

This project is licensed under the MIT License.

------------------------------------------------------------------------

## 👨‍💻 Author

Developed by **yLorde**
