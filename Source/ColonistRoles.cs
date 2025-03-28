namespace CapitalismVsSocialism;

public class ColonistRoles
{
    public static void AssignRoles(List<Colonist> colonists)
    {
        if (colonists == null || colonists.Count == 0)
        {
            Console.WriteLine("No colonists available to assign roles.");
            return;
        }

        // Randomly select an entrepreneur
        Random random = new Random();
        int entrepreneurIndex = random.Next(colonists.Count);
        Colonist entrepreneur = colonists[entrepreneurIndex];
        entrepreneur.IsEntrepreneur = true;

        Console.WriteLine($"Entrepreneur: {entrepreneur.Name}");

        // Assign the rest as workers
        List<Colonist> workers = new List<Colonist>();
        foreach (var colonist in colonists)
        {
            if (!colonist.IsEntrepreneur)
            {
                workers.Add(colonist);
                Console.WriteLine($"Worker: {colonist.Name}");
            }
        }

        // Simulate food gathering and payment
        GatherAndDistributeFood(entrepreneur, workers);
    }

    private static void GatherAndDistributeFood(Colonist entrepreneur, List<Colonist> workers)
    {
        int totalFoodGathered = 0;

        // Workers gather food in different ways
        foreach (var worker in workers)
        {
            int foodGathered = 0;
            string method = GetRandomFoodGatheringMethod();

            switch (method)
            {
                case "berries":
                    foodGathered = new Random().Next(3, 8); // Simulate gathering berries
                    Console.WriteLine($"{worker.Name} gathered {foodGathered} units of food by collecting berries.");
                    break;
                case "hunting":
                    foodGathered = new Random().Next(10, 20); // Simulate hunting
                    Console.WriteLine($"{worker.Name} gathered {foodGathered} units of food by hunting.");
                    break;
                case "animal farming":
                    foodGathered = new Random().Next(5, 15); // Simulate creating meat from animals
                    Console.WriteLine($"{worker.Name} gathered {foodGathered} units of food by farming animals.");
                    break;
                case "farming":
                    foodGathered = new Random().Next(7, 12); // Simulate farming plants
                    Console.WriteLine($"{worker.Name} gathered {foodGathered} units of food by farming plants.");
                    break;
            }

            totalFoodGathered += foodGathered;
        }

        // Transport food to entrepreneur's stockpile
        entrepreneur.PersonalStockpile.Resources += totalFoodGathered;
        Console.WriteLine($"All food transported to {entrepreneur.Name}'s stockpile. Total: {entrepreneur.PersonalStockpile.Resources} units.");

        // Pay workers with food
        int foodPerWorker = totalFoodGathered / workers.Count;
        foreach (var worker in workers)
        {
            worker.PersonalStockpile.Resources += foodPerWorker;
            entrepreneur.PersonalStockpile.Resources -= foodPerWorker;
            Console.WriteLine($"{worker.Name} received {foodPerWorker} units of food as payment.");
        }
    }

    private static string GetRandomFoodGatheringMethod()
    {
        string[] methods = { "berries", "hunting", "animal farming", "farming" };
        Random random = new Random();
        return methods[random.Next(methods.Length)];
    }
}
