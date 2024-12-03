using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mobile_Farming_Game.Scripts.Player
{
    public class PlayerToolSelector : MonoBehaviour
    {
        public enum Tool { None,Sow,Water,Harvest }
        public Tool currentTool;

        [Header("----- ELEMENTS ------")] 
        [SerializeField] private Image[] toolImages;
        [SerializeField] private Color selectedTool;
     
        [Header("----- ACTIONS ------")]
        public static Action<Tool> OnToolChanged;
        
        private void Start()
        {
            SelectTool(0);
        }
        
        public void SelectTool(int toolIndex)
        {
            currentTool = (Tool)toolIndex;
            for (var i = 0; i < toolImages.Length; i++)
            {
                toolImages[i].color = i == toolIndex ? selectedTool : Color.white;
            }
            
            OnToolChanged?.Invoke(currentTool);
        }
        
        public bool CanSow()
        {
            return currentTool == Tool.Sow;
        }
        
        public bool CanWater()
        {
            return currentTool == Tool.Water;
        }
        
        public bool CanHarvest()
        {
            return currentTool == Tool.Harvest;
        }
    }
}