using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

public static class FunctionDict
{
    private static Dictionary<EFunctionType, Function> functions = new Dictionary<EFunctionType, Function>();

    private static bool bInitialised;

    private static void Initialise()
    {
        functions.Clear();

        var allFunctionTypes = Assembly.GetAssembly(typeof(Function)).GetTypes().Where(t => typeof(Function).IsAssignableFrom(t) && !t.IsAbstract);

        foreach ( var t in allFunctionTypes )
        {
            Function function = Activator.CreateInstance(t) as Function;

            functions.Add(function.FunctionType, function);
        }
        bInitialised = true;
    }

    public static Function GetFunction(EFunctionType functionType)
    {
        if (!bInitialised)
        {
            Initialise();
        }
        return functions[functionType];
    }
}
