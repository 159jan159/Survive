using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStayForSceneSwap : MonoBehaviour
{
    private static bool exisits;
    // Start is called before the first frame update
    void Start()
    {
        if (!exisits)
        {
            exisits = true;
            DontDestroyOnLoad(transform.gameObject);
        }else
        {
            Destroy(gameObject);
        }
        
    }
}
