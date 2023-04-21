using UnityEngine;
namespace MainScripts.Stats
{
    public class BossStats : MonoBehaviour
    {
        public float HealthPoint = 500f;
        
        /// <summary>
        /// Скорость enemy
        /// </summary>
        public float Speed = 10f;

        /// <summary>
        /// Множитель который позволяет резать скорость boss
        /// </summary>
        public float SpeedMultiplier = 0.05f;

        /// <summary>
        /// дамаг lightAttack
        /// </summary>
        public float lightAttack = 5f;
        
        /// <summary>
        /// дамаг mediumAttack
        /// </summary>
        public float mediumAttack = 10f;

        /// <summary>
        /// дамаг hardAttack
        /// </summary>
        public float hardAttack = 25f;

        /// <summary>
        /// Область видимости boss
        /// </summary>
        public float FieldOfView = 40f;
        
        /// <summary>
        /// Маска чтобы, boss при виде hero агрился, для этого нужно повесить Layer на hero
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
