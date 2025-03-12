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
Singleline\
![](https://github.com/cntseesharp/L.AI/blob/main/images/generation_example_1.jpg?raw=true)

Multiline\
![](https://github.com/cntseesharp/L.AI/blob/main/images/generation_example_2.jpg?raw=true)

## What Does "VSLocalAI" Mean?
VSLocalAI stands for **VS Local Artificial Intelligence**.

## Installation
Download and install the VSLocalAI Visual Studio extension. Ensure you have an accessible KoboldCpp instance running.

## Running a Local AI Model
This is a brief guide to setting up KoboldCpp and DeepSeek Coder.

### Prerequisites
My instance ran on RTX 3090 in CUDA mode, I highly advise renting compute time, if your machine struggles with LLM Inference at an acceptable rate, since suggestion generation time is gonna hurt your experience.

1. Download and setup [KoboldCpp](https://github.com/LostRuins/koboldcpp). Extension tested on version 1.54;
2. Download any GGUF quantized coding model that was trained in instruct mode from [HuggingFace](https://huggingface.co/).\
I recommend: [DeepSeek Coder GGUF](https://huggingface.co/deepseek-ai/deepseek-coder-6.7b-instruct), it shows a decent result, but requires at least 12 GB of VRAM in 8-bit quantization mode with 4096 context length. You're looking for [deepseek-coder-6.7b-instruct.Q8_0.gguf](https://huggingface.co/TheBloke/deepseek-coder-6.7B-instruct-GGUF/resolve/main/deepseek-coder-6.7b-instruct.Q8_0.gguf?download=true) (7.2 GB of disk space);\
If you opt-out for a different model - please, check if it was trained for code insertion. DeepSeek Coder has 3 special tokens for that: <｜fim▁begin｜>, <｜fim▁hole｜> and <｜fim▁end｜>;
3. Launch KoboldCpp and select your model, don't forget to set the correct Context Size, 4096 should be enough;\
![](https://github.com/cntseesharp/L.AI/blob/main/images/kobold_example.jpg?raw=true)

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
