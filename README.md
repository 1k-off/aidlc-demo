# Structure
- [dotnet-app-sample](./dotnet-app-sample/) - example dotnet app

# MCP servers

Run local docker mcp gateway:
```powershell
docker mcp gateway run
```

## GitHub
```powershell
docker run -i --rm -e GITHUB_PERSONAL_ACCESS_TOKEN=<your-token> -e GITHUB_TOOLSETS="all" ghcr.io/github/github-mcp-server
```

```json
{
  "mcpServers": {
    "github": {
      "command": "docker",
      "args": [
        "run",
        "-i",
        "--rm",
        "-e",
        "GITHUB_PERSONAL_ACCESS_TOKEN",
        "-e",
        "GITHUB_TOOLSETS",
        "ghcr.io/github/github-mcp-server"
      ],
      "env": {
        "GITHUB_PERSONAL_ACCESS_TOKEN": "YOUR_GITHUB_PAT",
        "GITHUB_TOOLSETS": "all"
      }
    }
  }
}
```

# Remote MCP settings examples
## Cursor mcp.json with MCP_DOCKER example
```json
{
  "mcpServers": {
    "MCP_DOCKER": {
      "command": "docker",
      "args": [
        "mcp",
        "gateway",
        "run"
      ],
      "env": {
        "LOCALAPPDATA": "C:\\Users\\bogda\\AppData\\Local",
        "ProgramFiles": "C:\\Program Files"
      }
    }
  }
}
```

## GitHub MCP server
```json
    "github": {
      "url": "https://api.githubcopilot.com/mcp/",
      "headers": {
        "Authorization": "Bearer <TOKEN>"
      }
    }
```

## Vercel MCP SERVER

```json
    "Vercel": {
      "url": "https://mcp.vercel.com",
      "headers": {}
    }
```