using UnityEngine;
using UnityEngine.InputSystem;

public class DropArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    Vector2 GetSize()
    {
        return GetComponent<RectTransform>().sizeDelta;
    }

    bool InBoundingBox(Vector2 pos)
    {
        bool value = false;
        Vector2 position = gameObject.transform.position;
        Vector2 size = GetSize();
        if (pos.x < position.x + (size.x / 2) && pos.x > position.x - (size.x / 2) &&
            pos.y < position.y + (size.y / 2) && pos.y > position.y - (size.y / 2))
        {
            value = true;
        }
        return value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.GetIsHolding())
        {
            Debug.Log(InBoundingBox(Mouse.current.position.ReadValue()).ToString());
            if (InBoundingBox(Mouse.current.position.ReadValue()))
            {
                Destroy(Player.instance.GetHeldObject().gameObject);
                
            }
        }
    }
}
