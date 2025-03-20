using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Corrupted
{
    public static class CorruptedPhysics
    {
        public static RaycastHit[] RaycastAllAssisted(Vector3 position, Vector3 ray, float radius, LayerMask layer)
        {
            List<RaycastHit> hits = new List<RaycastHit>();

            hits.AddRange(Physics.RaycastAll(position, ray, ray.magnitude, layer));

            foreach (var hit in Physics.SphereCastAll(position, radius, ray, ray.magnitude, layer))
            {
                if (hits.Any((h) => h.transform == hit.transform))
                    continue;
                hits.Add(hit);
            }

            return hits.ToArray();
        }

        public static bool RaycastAssisted(Vector3 position, Vector3 ray, float radius, LayerMask layer, out RaycastHit hit)
        {
            var hits = RaycastAllAssisted(position, ray, radius, layer);
            hit = hits.FirstOrDefault();
            return hits.Length > 0;
        }
    }
}
