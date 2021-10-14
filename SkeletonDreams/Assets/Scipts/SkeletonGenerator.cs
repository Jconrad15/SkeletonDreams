using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class SkeletonGenerator : MonoBehaviour
    {
        private List<GameObject> drawnGameObjects = new List<GameObject>();


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                DestroyLastSkeleton();
                GenerateSkeleton();
            }
        }

        /// <summary>
        /// Generates a new Skeleton.
        /// </summary>
        private void GenerateSkeleton()
        {
            Vector3 startPosition = new Vector3(0, 2, 0);

            Skeleton skeleton = new Skeleton(startPosition);

            drawnGameObjects = Drawing.DrawFullSkeleton(skeleton);
        }

        /// <summary>
        /// Destroys the GameObjects of the last Skeleton.
        /// </summary>
        private void DestroyLastSkeleton()
        {
            for (int i = 0; i < drawnGameObjects.Count; i++)
            {
                Destroy(drawnGameObjects[i]);
            }
            drawnGameObjects.Clear();
        }


    }
}