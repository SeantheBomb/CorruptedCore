using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Corrupted
{
    public static class CorruptedPhysics
    {
        public static RaycastHit[] RaycastAllAssisted(Vector3 position, Vector3 ray, float radius, LayerMask layer)
        {
            List<RaycastHit> hits = new List<RaycastHit>();

            float angle = CorruptedMath.GetAngleFromLengthAndWidth(radius, ray.magnitude / 2);

            hits.AddRange(Physics.RaycastAll(position, ray, ray.magnitude, layer));

            foreach (var hit in Physics.SphereCastAll(position, radius, ray, ray.magnitude, layer))
            {
                if (hits.Any((h) => h.transform == hit.transform))
                    continue;

                if (Vector3.Angle(ray, (hit.point - position)) > angle)
                    continue;

                hits.Add(hit);
            }

            return hits.ToArray();
        }

        public static bool RaycastAssisted(Vector3 position, Vector3 ray, float radius, LayerMask layer, out RaycastHit hit)
        {
            var hits = RaycastAllAssisted(position, ray, radius, layer);
            hit = hits.OrderBy((h) => h.distance).FirstOrDefault();
            return hits.Length > 0;
        }

        public static bool RaycastAssisted(Vector3 position, Vector3 ray, float radius, LayerMask layer, Transform ignoreChildren, out RaycastHit hit)
        {
            var hits = RaycastAllAssisted(position, ray, radius, layer);
            hits = hits.Where((h) => h.transform.IsChildOf(ignoreChildren) == false).ToArray();
            hit = hits.OrderBy((h) => h.distance).FirstOrDefault();
            return hits.Length > 0;
        }

        public static int RaycastLinearSweep(Vector3 source, Vector3 ray, Vector3 sweep, int count, out List<RaycastHit> hits, LayerMask layers, bool startOffset = false)
        {
            hits = new List<RaycastHit>();
            int result = 0;
            for (int i = 0; i < count; i++)
            {
                int index = i + (startOffset ? 1 : 0);
                Ray r = new Ray(source + (sweep * index), ray);
                if (Physics.Raycast(r, out var hit, ray.magnitude, layers, QueryTriggerInteraction.Ignore))
                {
                    if (Vector3.Dot(hit.normal, Vector3.up) > 0)//Obstacle is the floor
                        continue;
                    hits.Add(hit);
                    result++;
                    //DebugHelper.DrawRay(r.origin, ray, Color.red, 3f);
                }
                //else
                //DebugHelper.DrawRay(r.origin, ray, Color.gray, 3f);
            }
            return result;
        }

        public static Vector3 GetDeltaForce(this Rigidbody rigidbody, Vector3 force, bool forceMagnitude = false)
        {
            Vector3 deltaForce = force - rigidbody.linearVelocity;

            if (forceMagnitude)
                return deltaForce;
            else
                return Vector3.Project(deltaForce, force);
        }
    }
}
