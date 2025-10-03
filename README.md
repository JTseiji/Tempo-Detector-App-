# 🎶 Tempo Detector

A simple, real-time Beats Per Minute (BPM) detector built with **C# and WPF**. Users can tap a button to measure the tempo of a beat, and the app shows the BPM visually with color feedback.

## ✨ Core Features

* **Real-time BPM Detection:** Calculates BPM using the average interval of the last **4 taps**.  
* **Visual Feedback:** The BPM text changes color depending on tempo:  
    * **Blue to Green:** Slower tempos.  
    * **Green:** Medium/target tempo.  
    * **Orange to Red:** Faster tempos.  
* **Reset Button:** Clears all taps so you can start fresh.  
* **Decorative Llama Image:** A static image above the BPM for fun and style.

## 🛠️ Technology Stack

| Component | Technology | Description |
| :--- | :--- | :--- |
| **Language** | C# | Handles BPM calculation and UI logic. |
| **Framework** | WPF (.NET 8.0) | Builds the desktop interface. |
| **IDE** | Visual Studio Community | Used for coding and running the app. |

## 🚀 Getting Started

### Prerequisites

* **Visual Studio Community**  
* **.NET 8.0 Desktop Runtime**  

### Installation

1. **Clone the repository:**  
    ```bash
    git clone [https://github.com/YourUsername/Tempo-Detector.git](https://github.com/YourUsername/Tempo-Detector.git)
    ```
2. **Open the project in Visual Studio.**  
3. **Run the app:** Press F5 or Start.

### Usage

1. **Tap the button:** Click **`Tap`** in rhythm with a beat.  
2. **View BPM:** The BPM shows above the text.  
3. **Observe color:** Text color changes with speed.  
4. **Reset:** Click **`Reset`** to clear all taps.

## 💡 Color Feature (Simplified)

* BPM is limited between **60 and 180**.  
* It is scaled to a value between **0 and 1**.  
* The code blends **Blue → Green → Orange → Red** depending on the scaled value.  
* The BPM text color updates instantly with the tempo.
