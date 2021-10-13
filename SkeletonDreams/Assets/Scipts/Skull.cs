using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class Skull: BoneSegment
    {
        private int resolution = 5;


        /// <summary>
        /// Standard skull constructor
        /// </summary>
        public Skull(Vector3 startPosition)
        {
            Length = 2f;
            MaxWidth = 0.5f;

            ConnectionPoints = new Vector3[1] { startPosition };

            // Create skull mesh
            BoneMesh = new Mesh();

            // Determine Vertices
            Vector3[] vertices = new Vector3[resolution * 2];

            Vector3 currentPos = startPosition;
            for (int i = 0; i < resolution; i++)
            {
                vertices[i] = new Vector3(currentPos.x - (MaxWidth/2f), currentPos.y, currentPos.z);
                vertices[i+1] = new Vector3(currentPos.x + (MaxWidth / 2f), currentPos.y, currentPos.z);

                currentPos = new Vector3(currentPos.x, currentPos.y + Length/resolution, currentPos.z);
            }
            BoneMesh.vertices = vertices;

            // Determine UV
            //Vector2[] UV = new Vector2[resolution * 2];




            // Determine Triangles
            int[] triangles = new int[resolution * 2 * 6];
            for (int ti = 0, vi = 0, y = 0; y < 2; y++, vi++)
            {
                for (int x = 0; x < resolution; x++, ti += 6, vi++)
                {
                    triangles[ti] = vi;
                    triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                    triangles[ti + 4] = triangles[ti + 1] = vi + resolution + 1;
                    triangles[ti + 5] = vi + resolution + 2;
                } 
            }
            BoneMesh.triangles = triangles;

            BoneMesh.RecalculateNormals();

        }



    }
}