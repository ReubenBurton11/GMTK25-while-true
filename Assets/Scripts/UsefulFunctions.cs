using System;
using UnityEngine;

public static class UsefulFunctions
{
    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        Array.Resize(ref arr, arr.Length - 1);
    }

    public static void Append<T>(ref T[] arr, T item)
    {
        Array.Resize(ref arr, arr.Length + 1);


        arr[arr.Length - 1] = item;
    }
}
