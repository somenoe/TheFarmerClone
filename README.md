# The Farmer Clone

A clone of the legendary farming Flash game "The Farmer" by w_w.

Built with C# and the [KNI framework](https://github.com/kniEngine/kni).

## Development Status

🚧 **In Development** - This project is currently under active development.

## Getting Started

Use the included [Makefile](Makefile) for common development tasks:

- `make dev` or `make dev-web` - Run the web version with hot reload
- `make dev-gl` - Run the Desktop OpenGL version with hot reload
- `make dev-dx` - Run the Windows DirectX version with hot reload
- `make build` - Build all platforms
- `make clean` - Clean build artifacts
- `make restore` - Restore NuGet packages

## Project Structure

- [`TheFarmerClone.Shared`](TheFarmerClone.Shared/) - Shared game logic
- [`TheFarmerCloneContent`](TheFarmerCloneContent/) - Game content including sprites, audio, and other assets
- [`TheFarmerClone.Android`](TheFarmerClone.Android/) - Android platform implementation
- [`TheFarmerClone.BlazorGL`](TheFarmerClone.BlazorGL/) - Web (Blazor + WebGL) platform implementation
- [`TheFarmerClone.DesktopGL`](TheFarmerClone.DesktopGL/) - Desktop OpenGL platform implementation
- [`TheFarmerClone.WindowsDX`](TheFarmerClone.WindowsDX/) - Windows DirectX platform implementation

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
