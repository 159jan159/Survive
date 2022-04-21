using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnteredDoor : MonoBehaviour
{
    public string whatSceneSwapTo;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("pyxo");
            SceneManager.LoadScene(whatSceneSwapTo);
            other.gameObject.transform.position = new Vector3(0,0,0);
        }
    }
}
