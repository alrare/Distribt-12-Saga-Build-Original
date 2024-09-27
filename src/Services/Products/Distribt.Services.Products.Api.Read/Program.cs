/*
using Distribt.Services.Products.BusinessLogic.DataAccess;

WebApplication app = DefaultDistribtWebApplication.Create(args, builder =>
{
    builder.Services.AddDistribtMongoDbConnectionProvider(builder.Configuration)
        .AddScoped<IProductsReadStore, ProductsReadStore>();
});


app.MapGet("product/{productId}", async (int productId, IProductsReadStore readStore)
    => await readStore.GetFullProduct(productId)); //TODO: result struct gives an error on minimal api?


DefaultDistribtWebApplication.Run(app);
*/


using Distribt.Services.Products.BusinessLogic.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDistribtMongoDbConnectionProvider(builder.Configuration)
//        .AddScoped<IProductsReadStore, ProductsReadStore>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();