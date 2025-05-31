# 🧠 SemanticKernel.Ollama.Chat

**A minimal C# chat interface for interacting with Ollama models using Semantic Kernel with function calling support.**

This project demonstrates a simple C# chatbot example using [`Microsoft.SemanticKernel`](https://learn.microsoft.com/en-us/semantic-kernel/overview/), integrated with [Ollama](https://ollama.com/).
The example uses `llama3-groq-tool-use:8b` by default to support tool use/function calling, but can be easily customised to use different models or configurations via `appsettings.json`.

---

## ✨ Features

- 🔌 Ollama integration via `Microsoft.SemanticKernel.Connectors.Ollama`
- 💬 Interactive terminal-based chat interface
- 🧱  Fully configurable model & endpoint via `appsettings.json`

---

## 📦 Requirements

- [.NET 8+](https://dotnet.microsoft.com/)
- [Ollama](https://ollama.com/) installed and running locally  
  (_e.g., `ollama run llama3-groq-tool-use:8b`_)

---

## 🛠️ Getting Started

1. Clone the repo
2. Configure `appsettings.json` with the following setting breakdown

| Section             | Key              | Description                                                                 |
|---------------------|------------------|-----------------------------------------------------------------------------|
| `Ollama`            | `ModelName`      | The AI model to use (e.g. `llama3:8b`, `llama2`, `mistral`, `phi3`, etc.)   |
|                     | `BaseUri`        | URL of your local Ollama server (usually `http://localhost:11434`)          |

3. Run the app (have fun 😎)
