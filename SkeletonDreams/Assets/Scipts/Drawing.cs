using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class Drawing : MonoBehaviour
    {

        /// <summary>
        /// Draw the full skeleton.
        /// </summary>
        /// <param name="skeleton"></param>
        public static List<GameObject> DrawFullSkeleton(Skeleton skeleton)
        {
            List<GameObject> drawnObjects = new List<GameObject>();
            
            drawnObjects.Add(DrawSkull(skeleton.Skull));

            drawnObjects.Add(DrawNeck(skeleton.Neck));

            return drawnObjects;
        }

        /// <summary>
        /// Draw the skull of the skeleton.
        /// </summary>
        /// <param name="skull"></param>
        public static GameObject DrawSkull(Skull skull)
        {
            // Create GameObject
            GameObject skull_GO = new GameObject("Skull");
            skull_GO.transform.position = skull.PlacedPos;

            // Create Mesh filter
            MeshFilter skull_mf = skull_GO.AddComponent<MeshFilter>();
            skull_mf.mesh = skull.BoneMesh;

            // Create Mesh Renderer
            MeshRenderer skull_mr = skull_GO.AddComponent<MeshRenderer>();
            skull_mr.material = Resources.Load<Material>("BasicMaterial");

            return skull_GO;
        }

        /// <summary>
        /// Draw the neck of the skeleton.
        /// </summary>
        /// <param name="neck"></param>
        /// <returns></returns>
        private static GameObject DrawNeck(Neck neck)
        {
            // Create GameObject
            GameObject neck_Go = new GameObject("Neck");
            neck_Go.transform.position = neck.PlacedPos;

            // Create Mesh filter
            MeshFilter neck_mf = neck_Go.AddComponent<MeshFilter>();
            neck_mf.mesh = neck.BoneMesh;

            // Create Mesh Renderer
            MeshRenderer neck_mr = neck_Go.AddComponent<MeshRenderer>();
            neck_mr.material = Resources.Load<Material>("BasicMaterial");

            return neck_Go;
        }
    }
}