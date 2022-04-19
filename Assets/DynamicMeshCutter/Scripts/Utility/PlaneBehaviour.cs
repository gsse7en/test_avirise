using UnityEngine;
using System.Collections;

namespace DynamicMeshCutter
{
    public class PlaneBehaviour : CutterBehaviour
    {
        public float DebugPlaneLength = 2;
        private bool isCut = false;
        private string colliderName = "";
        public void Cut()
        {
            var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var root in roots)
            {
                if (!root.activeInHierarchy)
                    continue;
                var targets = root.GetComponentsInChildren<MeshTarget>();
                foreach (var target in targets)
                {
                    if (colliderName.Contains(target.name))
                        Cut(target, transform.position, transform.forward, null, OnCreated);
                }
            }
        }

        void OnCreated(Info info, MeshCreationData cData)
        {
            MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
        }

        void OnCollisionEnter(Collision collision)
        {
            // if (collision.gameObject.tag == "Enemy") restartScreen.SetActive(true);
            // else {
                colliderName = collision.gameObject.name;
                Cut();
            // }
        }

    }
}