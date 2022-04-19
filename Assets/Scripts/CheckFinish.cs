using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFinish : MonoBehaviour
{
    [SerializeField] private Transform knife;
    [SerializeField] private GameObject winScreen;

    private Renderer rend;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        distance = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (knife.position.z +0.9*rend.bounds.size.z -distance + transform.position.z < 0)
        {
            PlayerPrefs.SetInt("GameState", 2);
            winScreen.SetActive(true);
        }
    }
}
