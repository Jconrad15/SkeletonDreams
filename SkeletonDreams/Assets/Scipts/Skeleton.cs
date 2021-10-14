using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonDreams
{
    public class Skeleton
    {

        public Skull Skull { get; set; }
        public Neck Neck { get; set; }


        /// <summary>
        /// Standard Skeleton Constructor.
        /// </summary>
        /// <param name="startPosition"></param>
        public Skeleton(Vector3 startPosition)
        {
            Skull = new Skull(startPosition);
            Neck = new Neck(Skull.NeckPos);

        }

    }
}