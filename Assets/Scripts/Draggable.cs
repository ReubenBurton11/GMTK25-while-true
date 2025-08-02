using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    private RectTransform rect;
    private bool bHeld = false;
    public Vector2 dragOffset;
    private Vector2 startPosition;
    private Vector2 endPosition;
    public Vector2 mousePos;
    private float returnTime = 0.0f;

    [SerializeField] private float clickMargin = 0.0f;
    [SerializeField] private float returnSpeed = 1.0f;

    private void Start()
    {
        //replace when it feels right
        SetStartPosition(gameObject.transform.position);

        rect = GetComponent<RectTransform>();
    }

    Vector2 GetSize()
    {
        return rect.sizeDelta;
    }

    public void SetStartPosition(Vector2 pos)
    {
        startPosition = pos;
    }

    void SetEndPosition(Vector2 pos)
    {
        endPosition = pos;
    }

    public void Hold(Vector2 mousePosition)
    {
        bHeld = true;
        dragOffset = (Vector2)gameObject.transform.position - mousePosition;
    }

    public void Drop(bool beingPlaced = false)
    {
        bHeld = false;
        if (!beingPlaced)
        {
            SetEndPosition(gameObject.transform.position);
            returnTime = 0.0f;
        }
    }

    public bool InBoundingBox(Vector2 pos)
    {
        bool value = false;
        Vector2 position = gameObject.transform.position;
        Vector2 size = GetSize();
        if (pos.x < position.x + (size.x * (1 - rect.pivot.x)) + clickMargin && pos.x > position.x - (size.x * rect.pivot.x) - clickMargin &&
            pos.y < position.y + (size.y * (1 - rect.pivot.y)) + clickMargin && pos.y > position.y - (size.y * rect.pivot.y) - clickMargin)
        {
            value = true;
        }
        return value;
    }

    public void Update()
    {
        if (bHeld)
        {
            gameObject.transform.position = mousePos + dragOffset;
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
