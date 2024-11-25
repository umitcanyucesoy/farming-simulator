using System;
using System.Collections.Generic;
using Mobile_Farming_Game.Scripts.Data;
using Mobile_Farming_Game.Scripts.Player;
using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Tiles
{
    public class CropField : MonoBehaviour
    {
        
        [Header("----- ELEMENTS ------")]
        [SerializeField] private Transform cropTilesParent;
        private readonly List<CropTile> _cropTiles = new List<CropTile>();
        
        [Header("----- SETTINGS ------")]
        [SerializeField] private CropData cropData;
        private CropTileState _cropFieldState;
        private int _tilesSown = 0;
        
        [Header("----- ACTIONS ------")]
        public static Action<CropField> OnFieldFullySown;

        private void Start()
        {
            _cropFieldState = CropTileState.Empty;
            StoreCropTiles();
        }

        private void StoreCropTiles()
        {
            for (int i = 0; i < cropTilesParent.childCount; i++)
                _cropTiles.Add(cropTilesParent.GetChild(i).GetComponent<CropTile>());
            
        }

        public void SeedsCollidedCallback(Vector3[] seedsPositions)
        {
            for (int i = 0; i < seedsPositions.Length; i++)
            {
                CropTile closestCropTile = GetClosestCropTile(seedsPositions[i]);
                
                if (closestCropTile == null) continue;
                if (!closestCropTile.IsEmpty()) continue;
                
                SowSeed(closestCropTile);
            }
        }

        private void SowSeed(CropTile cropTile)
        {
            cropTile.SowSeed(cropData);
            _tilesSown++;
            
            if (_tilesSown == _cropTiles.Count)
                FieldFullySown();
            
        }

        private void FieldFullySown()
        {
            _cropFieldState = CropTileState.Sown;
            OnFieldFullySown?.Invoke(this);
            Debug.Log("Field fully sown");
        }

        private CropTile GetClosestCropTile(Vector3 seedsPosition)
        {
            var minDistance = float.MaxValue;
            var closestCropTileIndex = -1;

            for (int i = 0; i < _cropTiles.Count; i++)
            {
                CropTile cropTile = _cropTiles[i];
                var distanceTileSeed = Vector3.Distance(cropTile.transform.position, seedsPosition);
                
                if (distanceTileSeed < minDistance)
                {
                    minDistance = distanceTileSeed;
                    closestCropTileIndex = i;
                }
            }
            
            if (closestCropTileIndex == -1) return null;
            
            return _cropTiles[closestCropTileIndex];
        }
        
         public bool IsEmpty()
        {
            return _cropFieldState == CropTileState.Empty;
        }
    }
}