using UnityEngine;

public class TestFunction : Function
{
    public override EFunctionType FunctionType => EFunctionType.EFT_Test;

    public override string Name => "Test( );";

    public override void Call()
    {
        Debug.Log("Called");
    }
}
