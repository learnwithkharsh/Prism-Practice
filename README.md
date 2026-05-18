# Prism Practice – Modular WPF Application using Prism

🚀 A practical WPF application built using **Prism** and **Modular Architecture** to demonstrate core Prism concepts such as:

- Regions
- Modules (IModule)
- DelegateCommand
- Event Aggregator
- Dialog Service
- Navigation
- Navigation Parameters & Callbacks
- Dynamic TabControl
- Tab Closing and Removal

This project is designed for learning Prism in a simple and practical way.

---

# 💖 Support My Work

If my WPF, C#, and Prism tutorials helped you learn something new and you'd like to support my work, you can send an Amazon Gift Card using the link below 😊

Your support helps me create more free tutorials, open-source projects, and learning content for the developer community 🚀

📧 Send Gift Card Code: [Send Code](https://wpfcsharpmetroui.blogspot.com/p/contact.html#gsc.tab=0)

Thank you for your support and encouragement ❤️

---

# 📸 Project Overview

This solution demonstrates how to create a modular WPF application using Prism and separate functionality into independent modules.

## Solution Structure

```text
PrismApp.sln
│
├── PrismApp              → Main Shell Application
├── PrismApp.Core         → Shared/Common Logic
├── SidebarModule         → Sidebar Region Module
├── ToolbarModule         → Toolbar Region Module
└── TextEditorModule      → Content/Text Editor Module
```

---

# 🏗 Architecture

This project follows **Modular MVVM Architecture** using Prism.

## Main Application

`PrismApp`

Acts as the **Shell Application** and is responsible for:

- Bootstrapping Prism
- Creating Shell Window
- Registering services
- Loading modules

Example:

```csharp
protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
{
    moduleCatalog.AddModule<ToolbarModule>();
    moduleCatalog.AddModule<SidebarModule>();
    moduleCatalog.AddModule<TextEditorModule>();
}
```

---

# 📦 Modules Used

## 1. Toolbar Module

Responsible for:

- Toolbar UI
- Command buttons
- Toolbar-related functionality

---

## 2. Sidebar Module

Responsible for:

- Navigation menu
- Sidebar content
- Region interaction

---

## 3. TextEditor Module

Responsible for:

- Main content area
- Text editor features
- Dynamic content loading

---

# ✨ Prism Features Covered

This repository demonstrates several important Prism concepts.

## Regions

Regions allow dynamic view injection into specific areas of the UI.

Examples:

- ToolbarRegion
- SidebarRegion
- ContentRegion

---

## IModule

Prism modules help split large applications into independent projects.

Benefits:

✔ Better maintainability  
✔ Reusable modules  
✔ Clean architecture

---

## DelegateCommand

Used for MVVM command binding.

Example:

```csharp
public DelegateCommand SaveCommand { get; }
```

---

## Event Aggregator

Allows communication between loosely coupled modules.

Benefits:

- Decoupled communication
- Clean event handling
- Easy module interaction

---

## Dialog Service

Used for showing dialogs in Prism applications.

Examples:

- Confirmation dialogs
- Input dialogs
- Custom popup windows

---

## Navigation

Prism navigation enables switching views using regions.

Example:

```csharp
_regionManager.RequestNavigate("ContentRegion", "EditorView");
```

---

## Navigation Parameters & Callbacks

Pass data while navigating between views.

Example:

```csharp
NavigationParameters parameters = new();
parameters.Add("Id", 1);
```

---

## Dynamic TabControl

Demonstrates:

- Dynamic tab creation
- View injection
- Runtime UI updates

---

## Tab Closing

Shows how to:

- Add close button to TabItem
- Remove tabs using commands
- Manage dynamic tabs

---

# 🛠 Technologies Used

- WPF
- C#
- Prism
- DryIoc
- MVVM
- .NET 8

---

# ▶ Getting Started

## Clone Repository

```bash
git clone https://github.com/learnwithkharsh/Prism-Practice.git
```

## Open Solution

Open:

```text
PrismApp.sln
```

in Visual Studio.

## Build & Run

1. Restore NuGet packages
2. Build solution
3. Run `PrismApp`

---

# 🎥 Prism Playlist

Learn Prism step-by-step using the playlist below:

1. Regions https://youtu.be/qLU5X0U78gI?si=b9HS1_xr-ZYy3TFQ
2. IModule https://youtu.be/v8XatfW1PTA?si=90a2Edxlm0zMMm1K
3. DelegateCommands https://youtu.be/WcGn9l_JMQU?si=EROkHDnLOVha0rSz
4. IEventAggregator https://youtu.be/s1CJSpqXNYc?si=cUgOZzZPDOPutvKd
5. Dialogs https://youtu.be/Xg-sszZTWqs?si=zMQ1JjG_A5fRl0j0
6. Navigation https://youtu.be/A05FacOhKPw?si=dIsMirpsmiQqWAzT
7. Navigation Callbacks and Parameters https://youtu.be/-nhDBp4G_uE?si=BBMwVVzJsEWk8RQ7
8. Dynamic TabControl https://youtu.be/JvJweEdjZ5g?si=XNkxFF0gfkXPKd5b
9. Add Close Button to TabItem & Removing Tabs https://youtu.be/EvQkZLSjHgA?si=19hV_G2Ap7xp66fs
10. Removing TabItems with DelegateCommand https://youtu.be/Uybz708IFQw?si=PbfM-xr2_7hzzpio
    
---


# ⭐ Support

If this repository helps you learn Prism:

⭐ Star the repository  
🍴 Fork it  
📢 Share it

Thank you for your support ❤️

# 📺 Subscribe to My YouTube Channel


If you enjoy this project and want more WPF + Prism tutorials, subscribe to the channel.

More tutorials coming soon 🚀

https://www.youtube.com/@learnwithkharsh

---
