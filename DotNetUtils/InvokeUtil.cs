using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetUtils
{
    public static class InvokeUtil
    {

        public enum CtorSelection
        {
            MostParams
        }

        public static T InvokeCtor<T, TDto>(TDto dto, CtorSelection ctorSelection = CtorSelection.MostParams)
        {
            var ctor = GetCtorInfo<T, TDto>();
            var ctorParams = ctor.GetParameters();
            var dtoProperties = typeof(TDto).GetProperties();

            var orderedProperties = new List<PropertyInfo>();
            foreach (var methodParameter in ctorParams)
            {
                try
                {
                    orderedProperties.Add(
                        dtoProperties.Single(
                            x => x.Name.Equals(methodParameter.Name, StringComparison.InvariantCultureIgnoreCase)));

                }
                catch
                {
                    throw new Exception(string.Format("There couldn't find property for method param {0}",
                                                      methodParameter));
                }

            }

            return (T)ctor.Invoke(orderedProperties.Select(x => x.GetValue(dto, null)).ToArray());
        }

        private static ConstructorInfo GetCtorInfo<T, Tdto>()
        {
            int maxParam = typeof(T).GetConstructors().Max(x => x.GetParameters().Count());
            var ctor = typeof(T).GetConstructors().FirstOrDefault(x => x.GetParameters().Count() == maxParam);
            return ctor;
        }

        public static void InvokeWithDto<TInstance, TDto>(this TInstance instance, string methodName, TDto dto)
        {
            var dtoProperties = typeof(TDto).GetProperties();
            var methods = typeof(TInstance).GetMethods()
                .Where(x => x.Name == methodName).ToList();
            var method = methods.Count() == 1 ? methods.Single() : methods.Single(x => x.GetParameters().Count() == dtoProperties.Count());
            var methodParameters = method.GetParameters();

            var orderedProperties = new List<PropertyInfo>();
            foreach (var methodParameter in methodParameters)
            {
                try
                {
                    orderedProperties.Add(
                        dtoProperties.Single(
                            x => x.Name.Equals(methodParameter.Name, StringComparison.InvariantCultureIgnoreCase)));

                }
                catch
                {
                    throw new Exception(string.Format("There couldn't find property for method param {0}",
                                                      methodParameter));
                }

            }
            method.Invoke(instance, orderedProperties.Select(x => x.GetValue(dto, null)).ToArray());

        }
    }
}