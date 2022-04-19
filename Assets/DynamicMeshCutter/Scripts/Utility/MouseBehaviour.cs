using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicMeshCutter
{
    public class MouseBehaviour : CutterBehaviour
    {
        public GameObject knife;
        public GameObject pivot;
        private Vector3 pivotPosition;
        private Transform knifeTrannsform;
        private bool _isDragging = false;

        private void Awake() 
        {
            pivotPosition = pivot.transform.position;  
            knifeTrannsform = knife.transform;
        }
        protected override void Update()
        {
            base.Update();
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
                knifeTrannsform.RotateAround(pivotPosition, Vector3.forward, Input.GetAxis("Mouse Y")*10);
            }
        }

    }

}