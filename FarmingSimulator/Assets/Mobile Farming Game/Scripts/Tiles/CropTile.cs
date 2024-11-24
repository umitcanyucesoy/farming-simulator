using System;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Tiles
{
    public class CropTile : MonoBehaviour
    {
        private enum State { Empty, Sown, Watered }
        private State _currentState;

        private void Start()
        {
            _currentState = State.Empty;
        }

        public bool IsEmpty()
        {
            return _currentState == State.Empty;
        }

        public void SowSeed()
        {
            _currentState = State.Sown;
            
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = transform.position;
            go.transform.localScale = Vector3.one * 0.5f;
        }
    }
}