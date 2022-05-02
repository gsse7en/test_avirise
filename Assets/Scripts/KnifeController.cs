using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DynamicMeshCutter;

public class KnifeController : MonoBehaviour
{
    [SerializeField] private GameObject pivot;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject hudScreen;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI fpsText;
    private Vector3 pivotPosition;
    private int score = 0;
    private float deltaTime;
    private float angle = 0;
    private float deltaAngle = 0;
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
            deltaAngle = Input.GetAxis("Mouse X")*10;
            angle += deltaAngle;
            if (angle > 180) angle -= 180;
            if (angle < -180) angle += 180;
            transform.RotateAround(pivotPosition, Vector3.forward, deltaAngle);
        }
    }
    void GameOver()
    {
        PlayerPrefs.SetInt("GameState", 1);
        loseText.SetText("Score: " + score + " cuts");
        hudScreen.SetActive(false);
        loseScreen.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
        {
            //TODO:
            // -slow time on score multiplyer
            // -Debounce or WaitForSeconds


            if (collision.gameObject.tag == "Enemy")
            {
                PlayerPrefs.SetInt("GameState", 1);
                loseText.SetText("Score: " + score + " cuts");
                hudScreen.SetActive(false);
                loseScreen.SetActive(true);
            }
            else if (collision.gameObject.tag == "Element") {
                string colliderName = collision.gameObject.name;
                cutter.CutCollider(colliderName);
                score++;
                scoreText.SetText("Score: " + score + " cuts");
                PlayerPrefs.SetInt("Score", score);
            } else if (collision.gameObject.tag == "Mixed") {
                string colliderName = collision.gameObject.name;
                if (angle < -75 || angle > 60) 
                {
                    GameOver();
                    return;
                }
                if (angle > -15 && angle < 30) 
                {
                    GameOver();
                    return;
                }
                cutter.CutCollider(colliderName);
                score++;
                scoreText.SetText("Angle: " + angle + " deg");
                PlayerPrefs.SetInt("Score", score);
            }
        }
}
