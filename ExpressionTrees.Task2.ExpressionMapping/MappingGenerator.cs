using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees.Task2.ExpressionMapping
{
    public class MappingGenerator
    {
        public Mapper<TSource, TDestination> Generate<TSource, TDestination>()
        {
            var bindings = new List<MemberBinding>();

            var sourceType = typeof(TSource);
            var targetType = typeof(TDestination);

            var source = Expression.Parameter(sourceType);

            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties().ToDictionary(p => p.Name);

            foreach (var sourcePropertyName in sourceProperties.Select(p=>p.Name))
            {
                if(!targetProperties.ContainsKey(sourcePropertyName))
                {
                    continue;
                }

                bindings.Add(Expression.Bind(targetProperties[sourcePropertyName], Expression.Property(source, sourcePropertyName)));
            }

            var target = Expression.MemberInit(Expression.New(typeof(TDestination)), bindings);

            var mapFunction =
                Expression.Lambda<Func<TSource, TDestination>>(target, source);

            return new Mapper<TSource, TDestination>(mapFunction.Compile());
        }
    }
}
