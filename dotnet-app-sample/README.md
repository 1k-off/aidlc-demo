# .NET 9 Web API Sample

This is a simple .NET 9 Web API sample application that demonstrates basic web service functionality with Docker support.

## Features

- Simple "Hello" endpoint at `/hello`
- Root endpoint at `/` with API information
- OpenAPI/Swagger documentation support
- Docker containerization
- Docker Compose support for easy development

## Prerequisites

- Docker installed on your system
- No need to install .NET SDK locally - everything runs in Docker containers

> **Note**: If port 8080 is already in use on your system, you can modify the port mapping in the Docker commands or docker-compose.yml file to use different ports (e.g., 5000:8080).

## Quick Start

### Using Docker Compose (Recommended)

1. Navigate to the project directory:
   ```bash
   cd dotnet-app-sample
   ```

2. Build and run the application:
   ```bash
   docker-compose up --build
   ```

3. Access the application:
   - API: http://localhost:8080
   - Hello endpoint: http://localhost:8080/hello
   - Swagger UI: http://localhost:8080/swagger
   - Root endpoint: http://localhost:8080/

### Using Docker Commands

1. Build the Docker image:
   ```bash
   docker build -t dotnet-app-sample .
   ```

2. Run the container:
   ```bash
   docker run -p 8080:8080 -p 8081:8081 dotnet-app-sample
   ```

## API Endpoints

- `GET /` - Root endpoint with API information and available endpoints
- `GET /hello` - Simple hello message with timestamp
- `GET /swagger` - OpenAPI/Swagger documentation (Development only)

### Example Responses

**GET /hello**
```json
{
  "message": "Hello from .NET 9 Web API!",
  "timestamp": "2025-10-21T16:12:58.2878322Z"
}
```

**GET /**
```json
{
  "message": "Welcome to .NET 9 Web API Sample!",
  "endpoints": ["/hello", "/swagger"]
}
```

## Development

### Building the project using Docker

```bash
# Restore dependencies
docker run --rm -v ${PWD}:/app -w /app mcr.microsoft.com/dotnet/sdk:9.0 dotnet restore DotnetAppSample/DotnetAppSample.csproj

# Build the project
docker run --rm -v ${PWD}:/app -w /app mcr.microsoft.com/dotnet/sdk:9.0 dotnet build DotnetAppSample/DotnetAppSample.csproj

# Run the project
docker run --rm -v ${PWD}:/app -w /app -p 8080:8080 mcr.microsoft.com/dotnet/sdk:9.0 dotnet run --project DotnetAppSample/DotnetAppSample.csproj
```

### Testing the API

```bash
# Test the hello endpoint
curl http://localhost:8080/hello

# Test the root endpoint
curl http://localhost:8080/
```

## CI/CD

This project includes GitHub Actions workflows for automated testing:

- **docker-build.yml**: Comprehensive build and test pipeline that:
  - Builds the Docker image
  - Tests image structure
  - Verifies application functionality
  - Tests all API endpoints
  - Runs on pull requests and pushes to main branches

- **docker-build-check.yml**: Minimal build validation that:
  - Simply builds the Docker image
  - Verifies the image was created successfully
  - Perfect for quick PR checks

Both workflows run automatically on pull requests and will fail if the Docker build is unsuccessful.

## Git Configuration

This project includes comprehensive `.gitignore` files to exclude unnecessary files from version control:

- **Root `.gitignore`**: Comprehensive ignore patterns for .NET, Visual Studio, Docker, and common development tools
- **Project `.gitignore`**: Focused ignore patterns specifically for the .NET application

### What's Ignored

- Build outputs (`bin/`, `obj/`, `out/`)
- Visual Studio cache files (`.vs/`, `*.user`)
- Package restore files (`project.lock.json`)
- Test results and coverage reports
- Temporary files and logs
- OS-specific files (`.DS_Store`, `Thumbs.db`)
- Editor configuration files (`.vscode/`, `.idea/`)
- Docker-related temporary files

## Kubernetes Deployment

This project includes Kubernetes manifests for deploying the application to a Kubernetes cluster.

### Prerequisites

- Kubernetes cluster (local or cloud)
- `kubectl` configured to connect to your cluster
- Docker image built and available in your cluster

### Deploy to Kubernetes

1. **Build the Docker image**:
   ```bash
   docker build -t dotnet-app-sample:latest .
   ```

2. **Deploy to Kubernetes**:
   ```bash
   kubectl apply -f deployment/k8s/
   ```

3. **Check deployment status**:
   ```bash
   kubectl get pods -l app=dotnet-app-sample
   kubectl get services -l app=dotnet-app-sample
   kubectl get hpa dotnet-app-sample-hpa
   ```

4. **Access the application**:
   ```bash
   kubectl port-forward svc/dotnet-app-sample-service 8080:80
   curl http://localhost:8080/hello
   ```

### Kubernetes Resources

- **Deployment**: Manages 3 replicas of the application with health checks
- **Service**: ClusterIP service exposing the application internally
- **HPA**: Horizontal Pod Autoscaler scaling between 2-10 pods based on CPU/memory usage

## Project Structure

```
dotnet-app-sample/
├── .github/
│   └── workflows/           # GitHub Actions workflows
│       ├── docker-build.yml # Comprehensive build pipeline
│       └── docker-build-check.yml # Minimal build check
├── deployment/
│   └── k8s/                # Kubernetes manifests
│       ├── deployment.yaml # Kubernetes deployment
│       ├── service.yaml    # Kubernetes service
│       └── hpa.yaml        # Horizontal Pod Autoscaler
├── DotnetAppSample/         # .NET project directory
│   ├── Program.cs          # Main application file
│   ├── DotnetAppSample.csproj # Project file
│   └── appsettings.json   # Configuration
├── Dockerfile             # Docker build instructions
├── docker-compose.yml     # Docker Compose configuration
├── .dockerignore         # Docker ignore file
├── .gitignore            # Git ignore file for .NET projects
└── README.md             # This file
```
