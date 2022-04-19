using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicMeshCutter;

public class KnifeController : MonoBehaviour
{
    public GameObject pivot;
    private Vector3 pivotPosition;
    // private Transform knifeTrannsform;
    private bool _isDragging = false;
    private PlaneBehaviour cutter;

    private void Awake() 
    {
        pivotPosition = pivot.transform.position;  
        cutter = GetComponent<PlaneBehaviour>();
    }
    private void FixedUpdate()
    {
        // TODO
        // -Move to MonnoBehavior
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
            // -Make Score
            // -Make FPS
            // -Make Win
            // -Make Lose
            // -Bake Lights
            // -Adjust speed

            if (collision.gameObject.tag == "Enemy")
            {
                Debug.LogError("Hp--");
            }
            else {
                string colliderName = collision.gameObject.name;
                cutter.CutCollider(colliderName);
            }
        }
}
