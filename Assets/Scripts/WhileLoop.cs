using System;
using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    private Function[] functions = new Function[0];

    public void AddFunction(Function function)
    {
        UsefulFunctions.Append(ref functions, function);
    }

    public void RemoveFunction(Function function)
    {
        UsefulFunctions.RemoveAt(ref functions, Array.IndexOf(functions, function));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < functions.Length; i++)
        {
            functions[i].Call();
        }
    }
}
