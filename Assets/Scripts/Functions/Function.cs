using UnityEngine;
using TMPro;

public abstract class Function : MonoBehaviour
{
    public abstract EFunctionType FunctionType { get; }
    public abstract string Name { get; }

    private TMP_Text text;

    public abstract void Call();

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        text.text = Name;
    }
}
