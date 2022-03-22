## Dapper ##

## Let`s code ##

1. Install `Visual NuGet` extension to your VS Code
2. Copy week 4 homework to week 5
3. Install `Dapper` & `MySql.Data` package from NuGet
4. Add custom Dapper code

```csharp
// ### Create a new CustomDapperTypeMapper.cs file ###
using System.Reflection;
using Dapper;
using static Dapper.SqlMapper;

public class CustomDapperTypeMapper : ITypeMap
{
    private readonly List<FieldInfo> _fields;
    private readonly Type _type;
    public List<PropertyInfo> Properties { get; }
    private DefaultTypeMap defaultTypeMap;
    public CustomDapperTypeMapper(Type type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));

        _fields = GetSettableFields(type);
        Properties = GetSettableProps(type);
        _type = type;
        defaultTypeMap = new DefaultTypeMap(type);

    }
    internal static List<PropertyInfo> GetSettableProps(Type t)
    {
        return t
              .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
              .Where(p => GetPropertySetter(p, t) != null)
              .ToList();
    }

    internal static MethodInfo GetPropertySetter(PropertyInfo propertyInfo, Type type)
    {
        if (propertyInfo.DeclaringType == type) return propertyInfo.GetSetMethod(true);

        return propertyInfo.DeclaringType.GetProperty(
               propertyInfo.Name,
               BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
               Type.DefaultBinder,
               propertyInfo.PropertyType,
               propertyInfo.GetIndexParameters().Select(p => p.ParameterType).ToArray(),
               null).GetSetMethod(true);
    }

    internal static List<FieldInfo> GetSettableFields(Type t)
    {
        return t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToList();
    }
    public ConstructorInfo FindConstructor(string[] names, Type[] types)
    {
        var constructors = _type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (ConstructorInfo ctor in constructors.OrderBy(c => c.IsPublic ? 0 : (c.IsPrivate ? 2 : 1)).ThenBy(c => c.GetParameters().Length))
        {
            ParameterInfo[] ctorParameters = ctor.GetParameters();
            if (ctorParameters.Length == 0)
                continue; // we don't want default public ctor

            if (ctorParameters.Length != types.Length)
                continue;

            int i = 0;
            for (; i < ctorParameters.Length; i++)
            {
                if (!string.Equals(ctorParameters[i].Name, names[i], StringComparison.OrdinalIgnoreCase))
                    break;

                var unboxedType = Nullable.GetUnderlyingType(ctorParameters[i].ParameterType) ?? ctorParameters[i].ParameterType;
                if ((unboxedType != types[i] && !SqlMapper.HasTypeHandler(unboxedType))
                    && !(unboxedType.IsEnum && Enum.GetUnderlyingType(unboxedType) == types[i])
                    && !(unboxedType == typeof(char) && types[i] == typeof(string))
                    && !(unboxedType.IsEnum && types[i] == typeof(string)))
                {
                    break;
                }
            }

            if (i == ctorParameters.Length)
                return ctor;
        }

        return null;
    }

    public ConstructorInfo FindExplicitConstructor()
    {
        return null;
    }

    public IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
    {
        return defaultTypeMap.GetConstructorParameter(constructor, columnName);
    }

    public IMemberMap GetMember(string columnName)
    {
        return defaultTypeMap.GetMember(columnName);
    }
}
```


```csharp
// ### add this to the end of `Program.cs` ###

SqlMapper.TypeMapProvider = t => new CustomDapperTypeMapper(t);
```

5. Implement MealRepository methods. Take inspiration from Dapper Demo project.
    - Add meal
    - Get one meal
    - List all meals
    - Delete (for those who have it in week 4 homework)

6. Register  `MealRepository` instead of `InMemoryMealRepository` in your `Program.cs`

7. Try running and calling endpoints from the Swagger