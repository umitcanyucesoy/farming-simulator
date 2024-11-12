using UnityEngine;

namespace Mobile_Farming_Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "Create", menuName = "Data/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public float moveSpeed;
    }
}