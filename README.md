# VSLocalAI

## Overview
VSLocalAI is a Visual Studio extension that enables AI-powered autocomplete and code suggestions using your own locally hosted AI models. It primarily supports KoboldCpp, KoboldAI, and OogaBooga.

The motivation behind VSLocalAI was to provide AI-assisted code generation without risking the exposure of sensitive code to external services. Now, you can leverage AI-powered autocompletion while maintaining complete control over your development environment.

This extension now functions independently of IntelliCode.

## Features
- Integrates with Visual Studio’s suggestion mechanism, enabling "Tab to accept" from a local AI backend.
- Automatically includes references (Classes, Interfaces, Enums, Records, Structs) in prompts to improve LLM understanding (C# only).
- Uses a built-in tokenizer and KoboldCpp tokenizers to prevent excessive prompt length from affecting context relevance.
- Hotkeys for manual generation requests and re-displaying lost suggestions.

## Examples
VSLocalAI supports both single-line and multi-line suggestions.

## What Does "VSLocalAI" Mean?
VSLocalAI stands for **VS Local Artificial Intelligence**.

## Installation
Download and install the VSLocalAI Visual Studio extension. Ensure you have an accessible KoboldCpp instance running.

## Running a Local AI Model
This is a brief guide to setting up KoboldCpp and DeepSeek Coder.

### Prerequisites
- The extension has been tested with **KoboldCpp v1.54**.
- Recommended model: **DeepSeek Coder GGUF**, particularly `deepseek-coder-6.7b-instruct.Q8_0.gguf` (requires 12GB VRAM at 8-bit quantization).
- Ensure the selected model supports code insertion with tokens `<|fim_begin|>`, `<|fim_hole|>`, and `<|fim_end|>`.
- Launch KoboldCpp, load your model, and set the context size (4096 is recommended).

## Usage
Start Visual Studio and begin coding. VSLocalAI will provide suggestions in a similar fashion to IntelliCode.

### Hotkeys
- **[Alt+A]**: Generate a code suggestion.
- **[Alt+Z]**: Generate a single-line suggestion.
- **[Alt+S]**: Re-display the last suggestion.

## Known Issues
- IntelliCode may occasionally override VSLocalAI’s suggestions. However, VSLocalAI can now function without IntelliCode enabled.

### v1.6.2
- Fixed a bug that was overriding the context length.
- Resolved a pipeline-breaking issue.

### v1.6.2 - R
- Released source code.
