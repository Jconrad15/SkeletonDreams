using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class Skull: BoneSegment
    {
        private float a;
        private float b;

        public Vector3 NeckPos { get; protected set; }

        /// <summary>
        /// Standard skull constructor
        /// </summary>
        public Skull(Vector3 startPosition)
        {
            XSize = 2;
            YSize = 30;

            a = Random.Range(0.4f, 1.2f);
            b = Random.Range(0.4f, 1.2f);

            PlacedPos = startPosition;

            // Create skull mesh
            BoneMesh = new Mesh();

            DetermineMeshVariables(out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

            ConvertToEllipse(vertices);

            SetBoneMesh(vertices, uv, triangles);

            Vector3 newVect = startPosition;
            newVect.y = newVect.y - ((a + b) / 2f);
            NeckPos = newVect;
        }

        /// <summary>
        /// Converts to polar coords and squishes to an psuedo ellipse shape.
        /// </summary>
        /// <param name="vertices"></param>
        private void ConvertToEllipse(Vector3[] vertices)
        {
            // Convert to polar coords to form an ellipse
            for (int i = 0; i < vertices.Length; i++)
            {
                float theta = (vertices[i].y / YSize) * 2f * Mathf.PI;
                float pointRadius = (vertices[i].x / XSize) * a * b;

                Vector3 tempVector;
                tempVector.x = (pointRadius /
                                Mathf.Sqrt((b * Mathf.Cos(theta)* Mathf.Cos(theta)) +
                                           (a * Mathf.Sin(theta) * Mathf.Sin(theta)))
                                * Mathf.Cos(theta));

                tempVector.y = (pointRadius /
                                Mathf.Sqrt(b * (Mathf.Cos(theta) * Mathf.Cos(theta)) +
                                          (a * Mathf.Sin(theta) * Mathf.Sin(theta)))
                                * Mathf.Sin(theta));
                tempVector.z = 0f;
                vertices[i] = tempVector;
            }
        }




    }
}