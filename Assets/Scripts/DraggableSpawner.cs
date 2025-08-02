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
        int cols = numOfDrags < dragsPerRow ? numOfDrags : dragsPerRow;
        float rows = Mathf.Ceil(numOfDrags / dragsPerRow);
        Debug.Log(rows.ToString());
        for (int i = 0; i < numOfDrags; i++)
        {
            if (rect == null)
            {
                rect = GetComponent<RectTransform>();
            }
            float xSection = ((rect.anchorMax.x - rect.anchorMin.x) * 1920) / cols;
            float ySection = ((rect.anchorMax.y - rect.anchorMin.y) * 1080) / (rows + 1);
            Vector2 pos = new Vector2((xSection * ((i % dragsPerRow) + 1)) - (xSection / 2), (ySection * Mathf.Ceil(i / dragsPerRow)) + (ySection / 2));
            GameObject draggable = Instantiate(draggablePrefab, gameObject.transform);
            Debug.Log(pos.ToString());
            draggable.transform.position = pos;
            draggable.GetComponent<Draggable>().SetStartPosition(pos);
        }
    }
}
