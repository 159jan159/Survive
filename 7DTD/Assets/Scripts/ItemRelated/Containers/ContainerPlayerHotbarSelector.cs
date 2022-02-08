using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerHotbarSelector : MonoBehaviour
{
    private PlayerController player;
    private RectTransform myTransform;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 pos = new Vector2((player.getSelectedHotbarIndex()*50)-150, -5);
            myTransform.anchoredPosition = pos;
        }
    }
}
