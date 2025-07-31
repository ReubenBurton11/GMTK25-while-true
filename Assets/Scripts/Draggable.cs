using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    private bool bHeld = false;
    private Vector2 dragOffset;
    private Vector2 size;

    private void Start()
    {
        size = GetComponent<RectTransform>().sizeDelta;
    }

    public void Hold()
    {
        bHeld = true;
        dragOffset = (Vector2)gameObject.transform.position - GetMousePosition();
    }

    void Drop()
    {
        bHeld = false;
    }

    Vector2 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }

    bool inBoundingBox(Vector2 pos)
    {
        bool value = false;
        Vector2 position = gameObject.transform.position;
        if (pos.x < position.x + size.x && pos.x > position.x &&
            pos.y < position.y && pos.y > position.y - size.y)
        {
            value = true;
        }
        return value;
    }

    public void Update()
    {
        if (!bHeld)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && inBoundingBox(GetMousePosition()))
            {
                Hold();
            }
        }
        if (bHeld)
        {
            gameObject.transform.position = GetMousePosition() + dragOffset;
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                Drop();
            }
        }
    }
}
