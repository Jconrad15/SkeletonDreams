using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SkeletonDreams
{
    public class Neck : BoneSegment
    {

        private float length;
        private float width;

        public Neck(Vector3 startPosition)
        {
            XSize = 2;
            YSize = 5;

            length = Random.Range(0.1f, 0.5f);
            width = Random.Range(0.4f, 0.8f);

            // Create skull mesh
            BoneMesh = new Mesh();

            DetermineMeshVariables(out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

            float xMax = 0;
            float xMin = 0;
            float yMax = 0;
            float yMin = 0;
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].x > xMax)
                {
                    xMax = vertices[i].x;
                }
                if (vertices[i].x < xMin)
                {
                    xMin = vertices[i].x;
                }
                if (vertices[i].y > yMax)
                {
                    yMax = vertices[i].y;
                }
                if (vertices[i].y < yMin)
                {
                    yMin = vertices[i].y;
                }
            }

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].x = length * ((vertices[i].x - xMin) / (xMax - xMin));
                vertices[i].y = length * ((vertices[i].y - yMin) / (yMax - yMin));
            }

            SetBoneMesh(vertices, uv, triangles);

            //startPosition.y -= length;
            //startPosition.x = startPosition.x - (width / 2f);
            PlacedPos = startPosition;

        }

    }
}