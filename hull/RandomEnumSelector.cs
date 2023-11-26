using System;
using System.Collections.Generic;
using System.Linq;
using HullBreakerCompany.hull;

public abstract class RandomEnumSelector
{
    private static Random _random = new();
    public static List<GameEvents> GetRandomGameEvents()
    {
        var weights = ConfigManager.GetWeights();
        var gameEvents = new HashSet<GameEvents>();

        foreach (var weight in weights)
        {
            for (int i = 0; i < weight.Value; i++)
            {
                gameEvents.Add(weight.Key);
            }
        }

        var shuffledGameEvents = gameEvents.ToList();
        Shuffle(shuffledGameEvents);

        return shuffledGameEvents.Take(3).ToList();
    }

    private static List<T> GetWeightedRandomGameEvents<T>(Dictionary<T, int> weights, int count)
    {
        var totalWeight = weights.Where(x => x.Value > 0).Sum(x => x.Value);
        var selectedItems = new HashSet<T>();

        while (selectedItems.Count < count)
        {
            var randomNumber = _random.Next(totalWeight);
            foreach (var item in weights)
            {
                if (item.Value == 0)
                {
                    continue;
                }

                if (randomNumber < item.Value)
                {
                    selectedItems.Add(item.Key);
                    break;
                }
                randomNumber -= item.Value;
            }
        }

        return selectedItems.ToList();
    }

    private static void Shuffle<T>(IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = _random.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}