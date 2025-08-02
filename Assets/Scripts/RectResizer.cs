using UnityEngine;
using TMPro;

public class RectResizer : MonoBehaviour
{
    private TMP_Text text;
    private RectTransform rect;
    private RectTransform childRect;

    [SerializeField] private float marginSize;
    [SerializeField] private bool textInChild = false;

    private void Update()
    {
        if (rect != null)
        {
            ResizeRect();
        }
    }

    void Start()
    {
        rect = GetComponent<RectTransform>();
        if (textInChild)
        {
            if (text = GetComponentInChildren<TMP_Text>())
            {
                childRect = GetComponentInChildren<RectTransform>();
                ResizeRect();
            }
        }
        else
        {
            if (text = GetComponent<TMP_Text>())
            {
                ResizeRect();
            }
        }
    }

    public void ResizeRect()
    {
        float margin = text.alignment == TextAlignmentOptions.Center ? marginSize : marginSize / 2;
        float size = text.preferredWidth + margin;
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        if (textInChild)
        {
            childRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        }
    }
}
