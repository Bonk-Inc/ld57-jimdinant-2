using System;
using System.Collections.Generic;
using System.Linq;

static class ListExtention {

    public static T GetRandomWeighted<T>(this List<T> list, Func<T, int> getWeight){
        // TODO better implementation?
        var weights = list.Select(getWeight).ToArray();
        var maxWeight = weights.Sum();
        var chosenWeight = UnityEngine.Random.Range(0, maxWeight);
        var currentWeight = 0;
        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];
            var itemWeight = weights[i];
            currentWeight += itemWeight;
            if (currentWeight >= chosenWeight)
            {
                return item;
            }
        }
        return default!;
    }

}