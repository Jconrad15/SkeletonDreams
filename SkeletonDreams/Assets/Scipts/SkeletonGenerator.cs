using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class SkeletonGenerator : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GenerateSkeleton();
            }
        }

        private void GenerateSkeleton()
        {
            Vector3 startPosition = new Vector3(0, 1, 0);
            Skull newSkull = new Skull(startPosition);

            GameObject skull_GO = new GameObject();
            MeshFilter skull_mf = skull_GO.AddComponent<MeshFilter>();
            skull_mf.mesh = newSkull.BoneMesh;
        }
    }
}