using Microsoft.EntityFrameworkCore;
using Homework10;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

//查询
app.MapGet("/", () => "Hello World!");

app.MapGet("/orders", async (OrderDb db) =>
    await db.Orders.ToListAsync());

app.MapGet("/orders/{id}", async (int id, OrderDb db) =>
    await db.Orders.FindAsync(id)
        is Order order
            ? Results.Ok(order)
            : Results.NotFound());

app.MapGet("/orders/{id}/detail", async (int id, OrderDb db) =>
    await db.Details.Where(t => t.OrderId == id).ToListAsync());

//增改
//订单
app.MapPost("/orders", async (Order inOrder, OrderDb db) =>
{
    if(await db.Orders.FindAsync(inOrder.Id) is Order order)
    {
        db.Orders.Update(inOrder);
        return Results.Ok();
    }
    else
    {
        db.Orders.Add(inOrder);
        await db.SaveChangesAsync();
        return Results.Created($"/orders/{inOrder.Id}", inOrder);
    }
});
//订单详情
app.MapPost("/orders/{id}/detail", async (int id, List<OrderDetail> orderDetails, OrderDb db) =>
{
    foreach (OrderDetail detail in orderDetails)
    {
        detail.OrderId = id;
        if (await db.Details.FindAsync(detail.OrderId, detail.ProductId) is OrderDetail oDetail)
        {
            db.Details.Update(detail);
        }
        else
        {
            db.Details.Add(detail);
        }
    }
    await db.SaveChangesAsync();
    return Results.Created($"/orders/{id}", db.Orders.FindAsync(id));
});

//删除订单
app.MapDelete("/orders/{id}", async (int id, OrderDb db) =>
{
    if (await db.Orders.FindAsync(id) is Order order)
    {
        db.Orders.Remove(order);
        await db.SaveChangesAsync();
        return Results.Ok(order);
    }

    return Results.NotFound();
});
//删除详情
app.MapDelete("/orders/{OrderId}/detail/{ProductId}", async (int OrderId, int ProductId, OrderDb db) =>
{
        if(await db.Details.FindAsync(OrderId, ProductId) is OrderDetail orderDetail)
        {
            db.Details.Remove(orderDetail);
        }
        else
        {
            await db.SaveChangesAsync();
            return Results.NotFound();
        }
    
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();


class OrderDb : DbContext
{
    public OrderDb(DbContextOptions<OrderDb> options)
        : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> Details => Set<OrderDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>()
            .HasKey(c => new { c.OrderId, c.ProductId });
    }
}
