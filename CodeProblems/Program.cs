using CodeProblems.Services;
using CodeProblems.Services.FurthestBuilding;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IMajorityElementService, MajorityElementService>();
        builder.Services.AddScoped<IFurthestBuildingService, FurthestBuildingService>();
        builder.Services.AddScoped<IFirstPalindromeService, FirstPalindromeService>();
        builder.Services.AddScoped<IFindTheWinnerService, FindTheWinnerService>();
        builder.Services.AddScoped<ICrawlFolderStructureService, CrawlFolderStructureService>();
        builder.Services.AddScoped<IAverageWaitingTimeService, AverageWaitingTimeService>();

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
    }
}