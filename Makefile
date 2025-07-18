# Default target
all: build
dev: dev-web

# Development targets (dotnet watch)
dev-gl:
	dotnet watch --project TheFarmerClone.DesktopGL

dev-dx:
	dotnet watch --project TheFarmerClone.WindowsDX

dev-web:
	dotnet watch --project TheFarmerClone.BlazorGL

# Build targets
build-gl:
	dotnet build TheFarmerClone.DesktopGL/TheFarmerClone.DesktopGL.csproj

build-dx:
	dotnet build TheFarmerClone.WindowsDX/TheFarmerClone.WindowsDX.csproj

build-web:
	dotnet build TheFarmerClone.BlazorGL/TheFarmerClone.BlazorGL.csproj

# Build all platforms
build: build-gl build-dx build-web

# Clean targets
clean:
	dotnet clean

# Restore packages
restore:
	dotnet restore

publish:
	dotnet publish TheFarmerClone.BlazorGL -c Release -o publish/web

.PHONY: all dev dev-gl dev-dx dev-web build build-gl build-dx build-web clean restore publish