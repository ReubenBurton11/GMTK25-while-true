using UnityEngine;

public class DraggableSpawner : MonoBehaviour
{
    public int numOfDrags;
    private RectTransform rect;
    [SerializeField] private GameObject draggablePrefab;
    [SerializeField] private int dragsPerRow;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (rect == null)
        {
            rect = GetComponent<RectTransform>();
        }
        int cols = numOfDrags < dragsPerRow ? numOfDrags : dragsPerRow;
        float rows = Mathf.Ceil(numOfDrags / dragsPerRow);
        float xSection = ((rect.anchorMax.x - rect.anchorMin.x) * 1920) / cols;
        float ySection = ((rect.anchorMax.y - rect.anchorMin.y) * 1080) / (rows + 1);

        Draggable[] drags = new Draggable[numOfDrags];
        for (int i = 0; i < numOfDrags; i++)
        {
            Vector2 pos;
            if (Mathf.Ceil(i / dragsPerRow) >= rows)
            {
                cols = numOfDrags % dragsPerRow;
                xSection = ((rect.anchorMax.x - rect.anchorMin.x) * 1920) / cols;
            }
            pos = new Vector2((xSection * ((i % dragsPerRow) + 1)) - (xSection / 2), (ySection * (rows + 1)) - (ySection * Mathf.Ceil(i / dragsPerRow)) - (ySection / 2));
            GameObject draggable = Instantiate(draggablePrefab, gameObject.transform);
            draggable.transform.position = pos;
            drags[i] = draggable.GetComponent<Draggable>();
            drags[i].SetStartPosition(pos);
        }

        Player.instance.SetDraggables(drags);
    }
}
