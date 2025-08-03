using UnityEngine;
using TMPro;
using System.Linq;
using System;
using NUnit.Framework;

public class LineManager : MonoBehaviour
{
    private TMP_Text text;
    public int line = 0;
    private Draggable[] storedDraggables;
    private WhileLoop whileLoop;

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    public void AddLine(Draggable draggable)
    {
        if (whileLoop == null)
        {
            whileLoop = GetComponent<WhileLoop>();
        }
        string textValue = text.text;
        textValue = textValue.Remove(16 + line);
        text.text = textValue + "\n};";
        if (storedDraggables != null)
        {
            UsefulFunctions.Append(ref storedDraggables, draggable);
        }
        else
        {
            storedDraggables = new Draggable[1] { draggable };
        }
        whileLoop.AddFunction(draggable.GetComponent<Function>());
        line++;
    }

    public void RemoveLine(Draggable draggable)
    {
        string textValue = text.text;
        textValue = textValue.Remove(15 + line);
        text.text = textValue + "};";
        int num = Array.IndexOf(storedDraggables, draggable);
        UsefulFunctions.RemoveAt(ref storedDraggables, num);
        for (int i = num; i < storedDraggables.Length; i++)
        {
            storedDraggables[i].gameObject.transform.position = Player.instance.dropAreas[i].transform.position;
        }
        whileLoop.RemoveFunction(draggable.GetComponent<Function>());
        line--;
    }
}
