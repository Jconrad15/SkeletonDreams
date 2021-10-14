using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class BoneSegment
    {
        public Mesh BoneMesh { get; protected set; }
        public int YSize { get; protected set; }
        public int XSize { get; protected set; }
        public Vector3 PlacedPos { get; protected set; }

        /// <summary>
        /// Creates vertices, uvs, and triangles for the BoneMesh.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="uv"></param>
        /// <param name="triangles"></param>
        protected void DetermineMeshVariables(out Vector3[] vertices, out Vector2[] uv, out int[] triangles)
        {
            // Determine starting grid of Vertices
            vertices = new Vector3[(XSize + 1) * (YSize + 1)];
            uv = new Vector2[vertices.Length];
            for (int i = 0, y = 0; y <= YSize; y++)
            {
                for (int x = 0; x <= XSize; x++, i++)
                {
                    vertices[i] = new Vector3(x, y, 0);
                    uv[i] = new Vector2(x / XSize, y / YSize);
                }
            }

            // Determine starting grid of Triangles
            triangles = new int[XSize * YSize * 6];
            for (int ti = 0, vi = 0, y = 0; y < YSize; y++, vi++)
            {
                for (int x = 0; x < XSize; x++, ti += 6, vi++)
                {
                    triangles[ti] = vi;
                    triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                    triangles[ti + 4] = triangles[ti + 1] = vi + XSize + 1;
                    triangles[ti + 5] = vi + XSize + 2;
                }
            }
        }


        protected void SetBoneMesh(Vector3[] vertices, Vector2[] uv, int[] triangles)
        {
            BoneMesh.vertices = vertices;
            BoneMesh.uv = uv;
            BoneMesh.triangles = triangles;
            BoneMesh.RecalculateNormals();
        }


    }
}