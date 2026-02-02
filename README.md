# BazziteTools 🛠️

Ein leistungsstarkes C#-Framework zur Automatisierung und Verwaltung von **Bazzite OS**. 
Dieses Projekt ermöglicht es, komplexe Linux-Systembefehle (Distrobox, Flatpak, rpm-ostree) elegant in C# zu bauen, zu validieren und direkt auszuführen.

## 🚀 Features

- **Fluent Command Builder**: Befehle wie Legosteine zusammenstecken (z.B. für `distrobox`, `curl`, `flatpak`).
- **Smart Validation**: Erkennt Fehler (z.B. fehlende Parameter) vor der Ausführung und gibt Warnungen aus (z.B. bei Sudo-Nutzung).
- **Command Executor**: Führt Befehle asynchron in der Bash aus und liefert Exit-Codes sowie Output zurück.
- **Output Interpreters**: Verwandelt Text-Ausgaben der Shell in echte C#-Objekte (z.B. Distrobox-Container-Listen).
- **Hardware Aware**: Spezielle Integration für **NVIDIA GPUs** (RTX 5060 Ti Support) zum Auslesen von Temperatur und Auslastung.
- **Bazzite Optimized**: Unterstützung für `rpm-ostree` Layering und `flatpak-spawn` Host-Kommunikation.

## 📦 Architektur

Das Projekt folgt einer klaren Trennung:
1. **Builder**: Konstruktion des Shell-Strings.
2. **Executor**: Interaktion mit dem Betriebssystem.
3. **Interpreter**: Logische Auswertung der Ergebnisse.



## 🛠️ Installation

1. Klone das Repository.
2. Öffne die Solution in **JetBrains Rider**.
3. Stelle sicher, dass du das neueste **.NET 10 SDK** installiert hast.

## 💻 Code-Beispiele

### Distrobox Container auflisten & interpretieren

```csharp
var result = await CommandExecutor.ExecuteAsync(DistroBox.List());
var containers = result.ToContainerList();

foreach (var c in containers)
{
    Console.WriteLine($"[{c.Status}] {c.Name}");
}

```

### GPU Temperatur auslesen (NVIDIA)

```csharp
var gpuCheck = new NvidiaSmiBuilder().QueryTemperature();
var result = await CommandExecutor.ExecuteAsync(gpuCheck);

if (result.Success) {
    Console.WriteLine($"GPU Temp: {result.Output}°C");
}

```

### System-Ordner sicher vorbereiten (Workflow)

```csharp
var setup = FileSystemWorkflows.PrepareAdminFolder("/tmp/mytool", "andreas");
await CommandExecutor.ExecuteAsync(setup);

```

## 🐧 Systemvoraussetzungen

* **OS**: Bazzite (oder andere Fedora-basierte Atomic Desktops).
* **Desktop**: KDE Plasma (empfohlen).
* **Hardware**: NVIDIA GPU (für Hardware-Features).
* **IDE**: JetBrains Rider.

---

Erstellt von Andreas – 2026
