using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameState")>0) return;
        transform.Translate(-Vector3.forward * Time.deltaTime * 5);
    }
}
