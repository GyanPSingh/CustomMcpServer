using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public static class OrderDetails
{
    [McpServerTool]
    [Description("Returns the details of an order given its ID.")]
    public static Order GetOrderDetails(int orderId)
    {
        // In a real application, you would retrieve
        // order details from a database or another
        // data source.

        return new Order
        {
            OrderId = orderId,
            CustomerName = "Mohit Kumar",
            ProductName = "Test Product",
            Quantity = 5,
            Price = 25.50m
        };
    }

    [McpServerTool]
    [Description("Checks whether an item is available in stock.")]
    public static bool IsItemAvailable(int itemId)
    {

        return itemId > 0;
    }
}

public record Order
{
    public int OrderId { get; init; }

    public string CustomerName { get; init; } = string.Empty;

    public string ProductName { get; init; } = string.Empty;

    public int Quantity { get; init; }

    public decimal Price { get; init; }
}