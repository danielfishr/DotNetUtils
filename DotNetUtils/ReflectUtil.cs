using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DotNetUtils
{
    public static class ReflectUtil
    {
        public static bool MethodHasAttribute<T1, T2>(Expression<Func<T1, object>> expression)
        {
            var type = typeof(T1);
            string name = GetMethodName(expression.Body);
            Type[] args = GetArgTypes(expression.Body).ToArray();
            var methodInfo = type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, args, null);
            var attributes = methodInfo.GetCustomAttributes(typeof(T2), true);
            return attributes.Any();
        }

        public static string GetMethodName(Expression expression)
        {
            var callExpression = expression as MethodCallExpression;
            if (callExpression != null)
            {
                var methodCallExpression = callExpression;
                return methodCallExpression.Method.Name;
            }
            throw new Exception("Could not determine member from " + expression);
        }

        public static IEnumerable<Type> GetArgTypes(Expression expression)
        {
            var callExpression = expression as MethodCallExpression;
            if (callExpression != null)
            {
                var methodCallExpression = callExpression;
                ReadOnlyCollection<Expression> args = methodCallExpression.Arguments;
                return args.Select(x => x.Type);
            }

            throw new Exception("Could not determine member from " + expression);
        }

        public static T GetProperty<T>(object obj, string name)
        {
            return (T)obj.GetType().GetProperties().First(x => x.Name == name).GetValue(obj, null);
        }

        public static bool HasProperty(object obj, string name)
        {
            return obj.GetType().GetProperties().Any(x => x.Name == name);
        }
    }
}