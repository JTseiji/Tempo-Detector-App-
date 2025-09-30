# 🎶 Tempo Detector

A simple, real-time Beats Per Minute (BPM) detector application built with **C# and Windows Presentation Foundation (WPF)**, designed as a learning project for fundamental programming and GUI concepts. Users can tap a button to determine the tempo of a song or beat.

## ✨ Core Features

* **Real-time BPM Detection:** Calculates the Beats Per Minute based on the average time interval between the last four button taps.
* **Rolling Average:** Uses a rolling average of the last **4 taps** for a stable and responsive tempo reading.
* **Visual Feedback (Color-Coded Tempo):** The displayed BPM text changes color to provide instant visual feedback on the speed:
    * **Cool Colors (Blue/Green):** Slower tempos (below 60 BPM).
    * **Warm Colors (Red/Orange):** Faster tempos (above 120 BPM).
    * **Green:** Target tempo (around 60-75 BPM).
* **Reset Functionality:** A dedicated button clears all tap history, allowing the user to start a new tempo detection sequence.

## 🛠️ Technology Stack

| Component | Technology | Description |
| :--- | :--- | :--- |
| **Language** | C\# | The core logic for calculation and UI interaction. |
| **Framework** | WPF (`.NET 8.0`) | Used for creating the Windows desktop user interface. |
| **Development** | Visual Studio Community | The IDE used to build and run the project. |

## 🚀 Getting Started

### Prerequisites

* **Visual Studio Community (or higher):** Required to open, build, and run the project.
* **.NET 8.0 Desktop Runtime:** Required to execute the application.

### Installation and Setup

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/YourUsername/Tempo-Detector.git](https://github.com/YourUsername/Tempo-Detector.git)
    ```
2.  **Open in Visual Studio:**
    * Navigate to the cloned directory.
    * Open the solution file (`Tempo Detector.sln`) in Visual Studio.
3.  **Run the Application:**
    * Set the configuration to `Debug` or `Release`.
    * Press the **Start** button (or F5) to compile and run the application.

### Usage

1.  **Tap to Start:** Click the **`tAp`** button repeatedly in time with a desired beat.
2.  **View BPM:** The calculated BPM will appear next to the llama image.
3.  **Observe Color:** Watch the BPM text color change from **blue** (slow) to **red** (fast), letting you know the relative speed instantly.
4.  **Reset:** Click the **`Reset`** button to clear the tap history and start a new measurement.

## 💡 How the Color Feature Works (Simplified)

The C\# code uses a simple formula to map the detected BPM to a color value:

1.  The BPM is **clamped** (limited) to a range between **60 BPM (min)** and **120 BPM (max)**.
2.  This clamped value is **normalized** (scaled) to a number between 0.0 and 1.0.
    * 0.0 represents the coolest color (slowest tempo).
    * 1.0 represents the warmest color (fastest tempo).
3.  A custom function then blends **Blue** (0.0), **Green** (0.5), and **Red** (1.0) to create a smooth, intuitive color gradient that changes instantly with the tempo.
