
---

# BazziteTools - Command Builder

Ein typsicherer **Fluent Command Builder** für .NET 10, der die Erstellung und Ausführung von Shell-Befehlen vereinfacht. Entwickelt mit Fokus auf Performance, Erweiterbarkeit und robuste Validierung.

## 🚀 Features

* **Fluent Interface**: Intuitive Verkettung von Parametern durch das *Curiously Recurring Template Pattern* (CRTP).
* **Typsicherheit**: Keine manuellen String-Präfixe; Nutzung von Enums für `-`, `--` oder `/`.
* **Smart Validation**: Automatische Prüfung von Parametern (z.B. Pflichtfelder) vor dem Build-Prozess.
* **Async Execution**: Integrierter `CommandExecutor` für asynchrone Prozesssteuerung.
* **Rich Results**: Detailliertes `CommandResult` inklusive Exit-Code, StandardOutput und StandardError.
* **Sudo Support**: Einfaches Umschalten auf Administratorrechte.

## 🛠 Installation

Das Projekt setzt das neueste **.NET 10 SDK** voraus.

```bash
dotnet add package BazziteTools

```

## 📖 Anwendung

### Einen Befehl bauen

Nutze die statische Hilfsklasse `P`, um schnell Parameter zu erzeugen:

```csharp
using BazziteTools.command.builder.@base;
using BazziteTools.command.builder.@base.@static;

var command = new Command("ls")
    .Add(P.ShortFlag("l"))
    .Add(P.LongOption("sort").WithValue("size"))
    .Add(P.Argument("/home/user/downloads"));

// Build liefert: ls -l --sort size /home/user/downloads
string raw = command.Build();

```

### Befehl ausführen

Der `CommandExecutor` übernimmt das Handling des Prozesses:

```csharp
using BazziteTools.command.executor;

CommandResult result = await CommandExecutor.ExecuteAsync(command);

if (result.Success) 
{
    Console.WriteLine(result.Output);
} 
else 
{
    Console.Error.WriteLine($"Fehler ({result.ExitCode}): {result.Error}");
}

```

## 🏗 Architektur

### Smart Validation

Jeder Parameter implementiert eine `Validate()` Methode. Der `Command.Build()` Prozess sammelt alle Fehler und verhindert die Ausführung ungültiger Befehle:

* **Flags/Options**: Validieren, dass ein Key gesetzt ist, wenn ein Präfix vorhanden ist.
* **Argumente**: Stellen sicher, dass ein Wert vorhanden ist, verbieten aber Präfixe.

### Vererbung & Erweiterbarkeit

Durch die generische Basisklasse `KeyParameter<T>` kannst du eigene Parameter-Typen erstellen, die nahtlos im Fluent-Interface funktionieren:

```csharp
public class MySpecialParam : KeyParameter<MySpecialParam> 
{
    public MySpecialParam() { Prefix = Prefixes.DoubleDash; }
}

```

## 💻 Tech Stack

* **Sprache**: C# 14 (.NET 10)
* **IDE**: JetBrains Rider
* **Plattform**: Optimiert für Bazzite (Fedora-basiert) mit KDE Plasma

## 📄 Lizenz

Dieses Projekt ist unter der MIT-Lizenz lizenziert - siehe die [LICENSE](https://www.google.com/search?q=LICENSE) Datei für Details.

---
