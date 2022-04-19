using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicMeshCutter
{

    public class MouseBehaviour : CutterBehaviour
    {
        public GameObject knife;
        public GameObject pivot;
        private bool _isDragging = false;

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
                knife.transform.RotateAround(pivot.transform.position, Vector3.forward, Input.GetAxis("Mouse Y")*10);
            }
        }

    }

}