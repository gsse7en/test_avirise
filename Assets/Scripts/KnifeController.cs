using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DynamicMeshCutter;

public class KnifeController : MonoBehaviour
{
    [SerializeField] private GameObject pivot;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI fpsText;
    private Vector3 pivotPosition;
    private int score = 0;
    private float deltaTime;
    private bool _isDragging = false;
    private PlaneBehaviour cutter;

    private void Awake() 
    {
        pivotPosition = pivot.transform.position;  
        cutter = GetComponent<PlaneBehaviour>();
        PlayerPrefs.SetInt("GameState", 0);
    }
    private void Update() {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.SetText(Mathf.Ceil(fps).ToString());
    }
    private void FixedUpdate()
    {
        // TODO
        // -Freeze move on lose
        // -Debounce or WaitForSeconds
        if (PlayerPrefs.GetInt("GameState") > 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }
        if (_isDragging)
        {
            transform.RotateAround(pivotPosition, Vector3.forward, Input.GetAxis("Mouse Y")*10);
        }
    }

    void OnCollisionEnter(Collision collision)
        {
            //TODO:
            // -fix canvases
            // -slow time on sore multiplyer
            // - move with leentween

            if (collision.gameObject.tag == "Enemy")
            {
                PlayerPrefs.SetInt("GameState", 1);
                loseText.SetText("Score: " + score + " cuts");
                loseScreen.SetActive(true);
            }
            else {
                string colliderName = collision.gameObject.name;
                cutter.CutCollider(colliderName);
                score++;
                scoreText.SetText("Score: " + score + " cuts");
            }
        }
}
