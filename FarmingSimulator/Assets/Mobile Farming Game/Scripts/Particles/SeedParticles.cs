using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SeedParticles : MonoBehaviour
{
    public static Action<Vector3[]> OnParticleCollisionAction;
    
    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        
        var collisionEvents = new List<ParticleCollisionEvent>();
        var collisionAmount = ps.GetCollisionEvents(other, collisionEvents);
        
        Vector3[] collisionPositions = new Vector3[collisionAmount];
        for (var i = 0; i < collisionAmount; i++)
            collisionPositions[i] = collisionEvents[i].intersection;
        
        OnParticleCollisionAction?.Invoke(collisionPositions);
    }
}
