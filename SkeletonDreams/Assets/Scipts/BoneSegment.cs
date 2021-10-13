using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class BoneSegment
    {
        public Mesh BoneMesh { get; protected set; }
        public float Length { get; protected set; }
        public float MaxWidth { get; protected set; }
        public Vector3[] ConnectionPoints { get; protected set; }


    }
}