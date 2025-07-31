using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private bool bHolding;
    private Draggable HeldObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetIsHolding(bool value)
    {
        bHolding = value;
    }

    public bool GetIsHolding()
    {
        return bHolding;
    }

    public void SetHeldObject(Draggable obj)
    {
        HeldObject = obj;
    }

    public Draggable GetHeldObject()
    {
        if (HeldObject != null)
        {
            return HeldObject;
        }
        return new Draggable();
    }
}
