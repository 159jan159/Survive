using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSoringLayer : MonoBehaviour
{
    [SerializeField]
    private int soringOrderBase = 5000;
    [SerializeField]
    private int offset = 0;
    private Renderer myRenderer;
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(soringOrderBase - transform.position.y - offset);
    }
}
