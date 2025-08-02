using UnityEngine;
using UnityEngine.InputSystem;

public class DropArea : MonoBehaviour
{
    private RectTransform rect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    Vector2 GetSize()
    {
        return rect.sizeDelta;
    }

    public bool InBoundingBox(Vector2 pos)
    {
        bool value = false;
        Vector2 position = gameObject.transform.position;
        Vector2 size = GetSize();
        if (pos.x < position.x + (size.x * (1 - rect.pivot.x)) && pos.x > position.x - (size.x * rect.pivot.x) &&
            pos.y < position.y + (size.y * (1 - rect.pivot.y)) && pos.y > position.y - (size.y * rect.pivot.y))
        {
            value = true;
        }
        return value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
