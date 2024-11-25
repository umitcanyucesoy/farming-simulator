using System;
using Mobile_Farming_Game.Scripts.Data;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Tiles
{
    public enum CropTileState
    {
        Empty, 
        Sown, 
        Watered
    }
    
    public class CropTile : MonoBehaviour
    {
        private CropTileState _currentCropTileState;
        
        [Header("----- Elements ------")]
        [SerializeField] private Transform cropParent;
        

        private void Start()
        {
            _currentCropTileState = CropTileState.Empty;
        }

        public bool IsEmpty()
        {
            return _currentCropTileState == CropTileState.Empty;
        }

        public void SowSeed(CropData cropData)
        {
            _currentCropTileState = CropTileState.Sown;
            
            Crop crop = Instantiate(cropData.cropPrefab, transform.position,Quaternion.identity, cropParent);
        }
    }
}