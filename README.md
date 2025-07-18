# The Farmer Clone

A clone of the legendary farming Flash game "The Farmer" by w_w.

Built with C# and the [KNI framework](https://github.com/kniEngine/kni).

## Development Status

📦 **Archived Project** - This project is no longer actively maintained.

## Getting Started

Use the included [Makefile](Makefile) for common development tasks:

- `make dev` or `make dev-web` – Run the web version (BlazorGL) with hot reload
- `make dev-gl` – Run the Desktop OpenGL version with hot reload
- `make dev-dx` – Run the Windows DirectX version with hot reload
- `make build` – Build all platforms (Web, DesktopGL, WindowsDX)
- `make build-web` – Build only the web version
- `make build-gl` – Build only the Desktop OpenGL version
- `make build-dx` – Build only the Windows DirectX version
- `make clean` – Clean all build artifacts
- `make restore` – Restore NuGet packages
- `make publish` – Publish the web version (BlazorGL) to `publish/web`

You need [Make](https://www.gnu.org/software/make/) and [.NET SDK](https://dotnet.microsoft.com/download) installed.

## Project Structure

- [`TheFarmerClone.Shared`](TheFarmerClone.Shared/) - Shared game logic
- [`TheFarmerCloneContent`](TheFarmerCloneContent/) - Game content including sprites, audio, and other assets
- [`TheFarmerClone.BlazorGL`](TheFarmerClone.BlazorGL/) - Web (Blazor + WebGL) platform implementation
- [`TheFarmerClone.DesktopGL`](TheFarmerClone.DesktopGL/) - Desktop OpenGL platform implementation
- [`TheFarmerClone.WindowsDX`](TheFarmerClone.WindowsDX/) - Windows DirectX platform implementation

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
