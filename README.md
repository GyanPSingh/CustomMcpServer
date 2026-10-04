# Custom MCP Server

A minimal Model Context Protocol (MCP) server built with .NET 10 and the `ModelContextProtocol` SDK. It communicates over standard input/output (stdio), so it can be launched by an MCP-compatible client as a local process.

## Requirements

- .NET SDK 10.0 or later

## Run locally

From the project directory, build or run the server:

```powershell
dotnet build
dotnet run
```

`dotnet run` starts the stdio server and waits for an MCP client. It is not an HTTP server and does not expose a web URL. Console logging is directed to standard error to keep standard output available for MCP messages.

## Available tools

| Tool | Input | Behavior |
| --- | --- | --- |
| `GetOrderDetails` | `orderId` (integer) | Returns an order with the supplied ID and fixed sample values: customer `Mohit Kumar`, product `Test Product`, quantity `5`, and price `25.50`. |
| `IsItemAvailable` | `itemId` (integer) | Returns `true` when the ID is greater than zero; otherwise returns `false`. This is a placeholder, not a real inventory lookup. |

Order details are currently hard-coded in `OrderDetails.cs`; connect the methods to a database or other data source to use real order and inventory records.

## Configure an MCP client

For a client that uses an MCP server configuration with stdio commands, register the project by running it with the .NET CLI. Replace the project path with the full path to this repository on your machine:

```json
{
	"servers": {
		"custom-mcp-server": {
			"type": "stdio",
			"command": "dotnet",
			"args": [
				"run",
				"--project",
				"C:\\path\\to\\CustomMcpServer\\CustomMcpServer.csproj"
			]
		}
	}
}
```

The configuration-file location and schema can vary by MCP client; use that client's documentation for where to place this entry.
