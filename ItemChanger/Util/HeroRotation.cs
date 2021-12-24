// Lifted from Flib's SkillUpgrades mod.
// Used to support vertical superdash and horizontal dive custom skills.
using System.Linq;
using Modding;
using UnityEngine;

namespace ItemChanger.Util
{
    public static class HeroRotation
    {
        public static void Hook()
        {
            On.HeroController.SetupGameRefs += CreatePolygonColliderForHero;
        }

        private static PolygonCollider2D HeroCollider;

        // Data for resetting
        private static Vector2[] OriginalPoints;
        private static Vector2 OriginalOffset;


        private static void CreatePolygonColliderForHero(On.HeroController.orig_SetupGameRefs orig, HeroController self)
        {
            orig(self);

            // Get Data
            Collider2D col2d = self.GetComponent<Collider2D>();
            Vector2 heropos = self.transform.position;
            Vector2 center = col2d.bounds.center;
            Vector2 extents = col2d.bounds.extents;
            OriginalOffset = col2d.offset;

            // Set Data
            PolygonCollider2D newCol2d = self.gameObject.AddComponent<PolygonCollider2D>();
            OriginalPoints = new Vector2[]
            {
                center + new Vector2(extents.x, extents.y) - heropos - OriginalOffset,
                center + new Vector2(extents.x, -extents.y) - heropos - OriginalOffset,
                center + new Vector2(-extents.x, -extents.y) - heropos - OriginalOffset,
                center + new Vector2(-extents.x, extents.y) - heropos - OriginalOffset
            };
            newCol2d.SetPath(0, OriginalPoints);
            newCol2d.offset = OriginalOffset;

            // Switch to our new collider
            ReflectionHelper.SetField<HeroController, Collider2D>(self, "col2d", newCol2d);
            HeroCollider = newCol2d;
            UnityEngine.Object.Destroy(col2d);
        }

        /// <summary>
        /// Rotate the hero counterclockwise by angle degrees
        /// </summary>
        /// <param name="hero">HeroController.instance</param>
        /// <param name="angle">Angle to rotate</param>
        /// <param name="respectFacingDirection">If true, instead rotate clockwise when the hero is facing right</param>
        public static void RotateHero(this HeroController hero, float angle, bool respectFacingDirection = true)
        {
            Transform t = HeroController.instance.vignette.transform.parent;
            HeroController.instance.vignette.transform.SetParent(null);

            float scale = hero.cState.facingRight ? -1 : 1;

            Vector2[] colliderBounds = HeroCollider.GetPath(0);
            float rotation = angle * (respectFacingDirection ? scale : 1);
            hero.transform.Rotate(0, 0, rotation);
            HeroCollider.SetPath(0, ApplyRotationToPoints(colliderBounds, -rotation * scale));

            HeroController.instance.vignette.transform.SetParent(t);
        }

        /// <summary>
        /// Set the hero rotation to be angle degrees counterclockwise. Equivalent to ResetHero() followed by RotateHero()
        /// </summary>
        /// <param name="hero">HeroController.instnce</param>
        /// <param name="angle">Angle to rotate</param>
        /// <param name="respectFacingDirection">If this is true, instead set it to be a clockwise rotation when the hero is facing right</param>
        public static void SetHeroRotation(this HeroController hero, float angle, bool respectFacingDirection = true)
        {
            ResetHero();
            hero.RotateHero(angle, respectFacingDirection);
        }

        /// <summary>
        /// Reset the knight's rotation
        /// </summary>
        public static void ResetHero()
        {
            if (HeroController.instance == null) return;

            HeroController.instance.transform.rotation = Quaternion.identity;
            HeroCollider.SetPath(0, OriginalPoints);
            HeroCollider.offset = OriginalOffset;

            HeroController.instance.wallPuffPrefab.transform.rotation = Quaternion.identity;
            HeroController.instance.vignette.transform.rotation = Quaternion.identity;
        }

        private static Vector2[] ApplyRotationToPoints(Vector2[] points, float rotation)
        {
            float radians = rotation * Mathf.PI / 180f;

            return points
                .Select(v => v + OriginalOffset)
                .Select(v => new Vector2(Mathf.Cos(radians) * v.x - Mathf.Sin(radians) * v.y, Mathf.Sin(radians) * v.x + Mathf.Cos(radians) * v.y))
                .Select(v => v - OriginalOffset)
                .ToArray();
        }
    }
}
