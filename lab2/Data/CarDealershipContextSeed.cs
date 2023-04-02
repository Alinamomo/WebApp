using lab2.Models;

namespace lab2.Data
{
    public static class CarDealershipContextSeed
    {
        public static async Task SeedAsync(CarDealershipContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.AutoModel.Any())
                {
                    return;
                }

                var models = new AutoModel[]
                {
                new AutoModel{Name="RSQ5"},
                new AutoModel{Name = "A5"},
                new AutoModel{Name="Q8"}

                };
                foreach (AutoModel m in models)
                {
                    context.AutoModel.Add(m);
                }
                await context.SaveChangesAsync();

                var constructions = new Construction[]
                {
                new Construction { Id=25,Name = "Sport",HorsePower = 249, EngineCapacity = 3, EngineType ="Дизель", Drive ="Полный"},
                new Construction { Id=26,Name = "Ex",HorsePower = 249, EngineCapacity = 3, EngineType ="Дизель", Drive ="Полный" }
                };
                foreach (Construction c in constructions)
                {
                    context.Construction.Add(c);
                }
                await context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }
    }
}
