using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour {
    public float bgScrollSpeed = 10;

    public RectTransform bg1;
    public RectTransform bg2;

    float currentOffset = 0;
    Vector2 bg1Original;
    Vector2 bg2Original;

    void Start()
    {
        bg1Original = bg1.anchoredPosition;
        bg2Original = bg2.anchoredPosition;
    }

    void Update()
    {
        currentOffset += Time.deltaTime * bgScrollSpeed;
        Vector2 pos1 = bg1Original + Vector2.left * currentOffset;
        Vector2 pos2 = bg2Original + Vector2.left * currentOffset;

        bg1.anchoredPosition = pos1;
        bg2.anchoredPosition = pos2;

        if (currentOffset > bg1.sizeDelta.x)
        {
            currentOffset -= bg1.sizeDelta.x;
        }
    }
}
