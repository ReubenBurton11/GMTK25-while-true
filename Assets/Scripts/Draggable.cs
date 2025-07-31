using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    private bool bHeld = false;
    private Vector2 dragOffset;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float returnTime = 0.0f;

    [SerializeField] private float clickMargin = 0.0f;
    [SerializeField] private float returnSpeed = 1.0f;

    private void Start()
    {
        //replace when it feels right
        SetStartPosition(gameObject.transform.position);
    }

    Vector2 GetSize()
    {
        return GetComponent<RectTransform>().sizeDelta;
    }

    public void SetStartPosition(Vector2 pos)
    {
        startPosition = pos;
    }

    void SetEndPosition(Vector2 pos)
    {
        endPosition = pos;
    }

    public void Hold()
    {
        bHeld = true;
        dragOffset = (Vector2)gameObject.transform.position - GetMousePosition();
    }

    void Drop()
    {
        bHeld = false;
        SetEndPosition(gameObject.transform.position);
        returnTime = 0.0f;
    }

    Vector2 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }

    bool inBoundingBox(Vector2 pos)
    {
        bool value = false;
        Vector2 position = gameObject.transform.position;
        Vector2 size = GetSize();
        if (pos.x < position.x + (size.x / 2) + clickMargin && pos.x > position.x - (size.x / 2) - clickMargin &&
            pos.y < position.y + (size.y / 2) + clickMargin && pos.y > position.y - (size.y / 2) - clickMargin)
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

        if (returnTime >= 0.0f && returnTime <= 1.0f && !bHeld)
        {
            float progress = ((Vector2)gameObject.transform.position - startPosition).magnitude / (endPosition - startPosition).magnitude;
            Mathf.Clamp(progress, 0.4f, 1.0f);

            gameObject.transform.position = Vector2.Lerp(endPosition, startPosition, returnTime);
            returnTime += Time.deltaTime * progress * returnSpeed;
        }
    }
}
