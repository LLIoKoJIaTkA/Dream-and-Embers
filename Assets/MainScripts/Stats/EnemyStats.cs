using UnityEngine;

namespace MainScripts.Stats
{
    public abstract class EnemyStats : MonoBehaviour
    {
        public float HealthPoint = 100f;
        
        /// <summary>
        /// Скорость enemy
        /// </summary>
        public float Speed = 10f;
        
        /// <summary>
        /// Множитель который позволяет резать скорость enemy
        /// </summary>
        public float SpeedMultiplier = 0.05f;

        /// <summary>
        /// Область видимости enemy
        /// </summary>
        public float FieldOfView = 10f;
        
        /// <summary>
        /// Маска чтобы, enemy при виде hero агрился, для этого нужно повесить Layer на hero
        /// </summary>
        public LayerMask _heroMask;
        
        public float speedMultiplier
        {
            get { return SpeedMultiplier; }
            set { SpeedMultiplier = value; }
        }

        public float fieldOfView
        {
            get { return FieldOfView; }
            set { FieldOfView = value; }
        }

    }
}
