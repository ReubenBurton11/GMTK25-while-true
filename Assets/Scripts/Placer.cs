using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Placer : MonoBehaviour
{
    private RectTransform rect;
    private Image image;
    private TMP_Text text;

    private string textValue;

    public bool bPlaced = false;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<TMP_Text>();
    }

    public void Place(Vector2 placePos)
    {
        bPlaced = true;
        rect.pivot = new Vector2(0, 0.5f);
        //image.enabled = false;
        text.alignment = TextAlignmentOptions.Left;
        textValue = text.text;
        text.text = "    " + textValue;
        gameObject.transform.position = placePos;
    }

    public void Displace()
    {
        image.enabled = true;
        text.text = textValue;
        rect.pivot = new Vector2(0.5f, 0.5f);
        text.alignment = TextAlignmentOptions.Center;
        bPlaced = false;
    }
}
