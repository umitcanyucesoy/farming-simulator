using Mobile_Farming_Game.Scripts.Tiles;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Data
{
    
    [CreateAssetMenu(fileName = "Scriptable Object", menuName = "Data/CropData", order = 0)]
    public class CropData : ScriptableObject
    {
        [Header("----- SETTINGS ------")]
        public Crop cropPrefab;
    }
}