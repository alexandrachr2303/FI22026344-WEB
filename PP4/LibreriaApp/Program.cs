using LibreriaApp.Data;
using LibreriaApp.Services;

using var context = new LibreriaContext();
context.Database.EnsureCreated();

if (!context.Authors.Any())
{
    DataLoader.LoadCsvIfEmpty(context);
}
else
{
    TsvWriter.WriteFiles(context);
}
