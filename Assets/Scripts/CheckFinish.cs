using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckFinish : MonoBehaviour
{
    [SerializeField] private Transform knife;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject hudScreen;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Renderer rend;
    private float distance;
    void Start()
    {
        rend = GetComponent<Renderer>();
        distance = transform.position.z;
    }

    void Update()
    {
        if (knife.position.z +0.9*rend.bounds.size.z -distance + transform.position.z < 0)
        {
            PlayerPrefs.SetInt("GameState", 2);
            hudScreen.SetActive(false);
            winScreen.SetActive(true);
            scoreText.SetText("Score: " + PlayerPrefs.GetInt("Score") + " cuts");;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("GameState", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
