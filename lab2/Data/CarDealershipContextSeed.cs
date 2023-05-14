using DAL.Entities;

namespace lab2.Data
{
    public static class CarDealershipContextSeed
    {
        public static async Task SeedAsync(CarDealershipContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                Color col = new Color{ Name = "Red" };
                context.Color.Add(col);

                if (context.ModelRange.Any())
                {
                    return;
                }

                var ranges = new ModelRange[]
                {
                new ModelRange{Name="RS Model"},
                new ModelRange{Name = "S Model"},
                new ModelRange{Name="Q Model"}

                };
                foreach (ModelRange m in ranges)
                {
                    context.ModelRange.Add(m);
                }
                await context.SaveChangesAsync();

                if (context.AutoModel.Any())
                {
                    return;
                }

                var models = new AutoModel[]
                {
                new AutoModel{Name="RSQ5", Id_modelrange=1},
                new AutoModel{Name = "A5", Id_modelrange = 1},
                new AutoModel{Name="Q8", Id_modelrange = 2}

                };
            foreach (AutoModel m in models)
                {
                    context.AutoModel.Add(m);
                }
                await context.SaveChangesAsync();

                var constructions = new Construction[]
                {
                new Construction { Name = "Sport",HorsePower = 249, Transmission="asd", EngineCapacity = 3, EngineType ="Дизель", Drive ="Полный", Id_model = 1, Id_colour = 1},
                new Construction { Name = "Ex",HorsePower = 249, Transmission="asd", EngineCapacity = 3, EngineType ="Дизель", Drive ="Полный" , Id_model = 2, Id_colour = 1}
                };
                foreach (Construction c in constructions)
                {
                    context.Construction.Add(c);
                }
                await context.SaveChangesAsync();

            var products = new Product[]
             {
                new Product { Name="Automobile", Id_constr = 1, Price=100000 },
                new Product { Name="Automobile2", Id_constr = 2, Price=100100 },
             };
                foreach (Product c in products)
                {
                    context.Product.Add(c);
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
