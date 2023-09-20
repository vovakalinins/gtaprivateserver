# 🎮 GTA V Private Session Joiner 🎮

---

## 📌 Table of Contents

- [Description](#-description)
- [Features](#-features)
- [Requirements](#-requirements)
- [Setup and Usage](#-setup-and-usage)
  - [Installation](#installation)
  - [Run](#run)
- [Code Snippets](#-code-snippets)
- [Limitations](#-limitations)
- [Disclaimer](#-disclaimer)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🌟 Description

This C# program is your ticket to hassle-free private sessions in **Grand Theft Auto V**. It automates the process of suspending and resuming the game, effectively moving you into an empty server.

---

## ✨ Features

- 🎯 **Automatic Detection**: Finds if GTA V is running on your system.
- ⏸️ **Pause & Play**: Suspends the GTA V process momentarily.
- ⌛ **Wait Time**: 10-second wait time during the process suspension.
- ▶️ **Instant Resume**: Resumes the GTA V process.
- 🌐 **New Server**: Transports you into an empty server.

---

## 📋 Requirements

- .NET Framework
- GTA V installed and running

---

## 🛠️ Setup and Usage

### Installation

1️⃣ Clone the repository  
2️⃣ Open the project in your C# IDE (like Visual Studio)  
3️⃣ Build the project  

### Run

1️⃣ Start GTA V  
2️⃣ Run the compiled C# program  
3️⃣ Follow the on-screen instructions  

---

## 💻 Code Snippets

- **Import user32.dll**
    ```csharp
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    ```

- **Thread Suspension & Resumption**
    ```csharp
    public static void Suspend(this Process process)
    public static void Resume(this Process process)
    ```

---

## ⚠️ Limitations

- Assumes you have GTA V running before using the program.
- Targets the first GTA V instance it finds (doesn't handle multiple instances).

---

## ❗ Disclaimer

🛑 Suspending a game's process might violate the game's terms of service. This project is for educational purposes only. Use at your own risk. 🛑

---

## 🤝 Contributing

If you have any suggestions or fixes, feel free to open issues or PRs.

---

## 📝 License

This project falls under the MIT License. For more details, see the `LICENSE.md` file.
