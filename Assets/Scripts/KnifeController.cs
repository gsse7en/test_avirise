using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DynamicMeshCutter;

public class KnifeController : MonoBehaviour
{
    [SerializeField] private GameObject pivot;
    [SerializeField] private TextMeshProUGUI winScoreText;
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
            // -Make Win with score
            // -Make Lose
            // -Bake Lights
            // -Adjust speed
            // -unify scrore - use player prefs

            if (collision.gameObject.tag == "Enemy")
            {
                Debug.LogError("Hp--");
            }
            else {
                string colliderName = collision.gameObject.name;
                cutter.CutCollider(colliderName);
                score++;
                scoreText.SetText("Score: " + score + " cuts");
                winScoreText.SetText("Score: " + score + " cuts");
            }
        }
}
