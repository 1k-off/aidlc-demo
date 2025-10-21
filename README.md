# Structure
- [dotnet-app-sample](./dotnet-app-sample/) - example dotnet app

# MCP settings examples
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