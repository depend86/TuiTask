using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TuiTask.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> act)
        {
            foreach (var item in collection)
            {
                act(item);
                yield return item;
            }
        }

        public static Task ForEachAsync<T>(this IEnumerable<T> collection, int maxDegreeOfParallelism,
            Func<T, Task> act)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(collection).GetPartitions(maxDegreeOfParallelism)
                select Task.Run(async () =>
                {
                    using (partition)
                        while (partition.MoveNext())
                            await act(partition.Current);
                }));
        }
    }
}