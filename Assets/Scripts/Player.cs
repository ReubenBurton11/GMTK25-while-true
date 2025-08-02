using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;

    private Vector2 mousePos;
    private bool bHolding;
    private Draggable HeldObject;
    [SerializeField] private Draggable[] draggables;
    public DropArea[] dropAreas;

    private LineManager lineManager;

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

    private void Update()
    {
        mousePos = Mouse.current.position.ReadValue();

        //Input: Left Click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {          
            if (draggables.Length > 0)
            {
                for (int i = 0; i < draggables.Length; i++)
                {
                    if (draggables[i].InBoundingBox(mousePos))
                    {
                        HeldObject = draggables[i];
                        SetIsHolding(true);
                        Placer placer;                  
                        if (placer = HeldObject.GetComponent<Placer>())
                        {
                            if (placer.bPlaced)
                            {
                                placer.Displace();
                                lineManager.RemoveLine(HeldObject);
                            }
                        }
                        HeldObject.Hold(mousePos);
                        break;
                    }
                }
            }
        }

        //Input: Left Release
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (GetIsHolding())
            {
                SetIsHolding(false);
                Placer placer;
                bool placed = false;
                if (placer = HeldObject.GetComponent<Placer>())
                {
                    int line = lineManager == null ? 0 : lineManager.line;
                    if (dropAreas[line].InBoundingBox(mousePos))
                    {
                        HeldObject.Drop(true);
                        placer.Place(dropAreas[line].gameObject.transform.position);
                        placed = true;
                        if (lineManager == null)
                        {
                            lineManager = FindFirstObjectByType<LineManager>();
                        }
                        lineManager.AddLine(HeldObject);
                    }
                }
                if (!placed)
                {
                    HeldObject.Drop();
                }
            }
        }

        if (GetIsHolding())
        {
            HeldObject.mousePos = mousePos;
        }

    }

    public void ClearDraggables()
    {
        draggables = new Draggable[0];
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
