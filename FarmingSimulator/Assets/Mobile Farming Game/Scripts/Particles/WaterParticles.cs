using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Particles
{
    public class WaterParticles : MonoBehaviour
    {
        public static Action<Vector3[]> OnWaterParticlesSpawned;

        private void OnParticleCollision(GameObject other)
        {
            var ps = GetComponent<ParticleSystem>();
            var collisionEvents = new List<ParticleCollisionEvent>();
            var collisionAmount = ps.GetCollisionEvents(other, collisionEvents);
            
            var collisionPositions = new Vector3[collisionAmount];
            for (var i = 0; i < collisionAmount; i++)
                collisionPositions[i] = collisionEvents[i].intersection;
            
            OnWaterParticlesSpawned?.Invoke(collisionPositions);
        }
    }
}