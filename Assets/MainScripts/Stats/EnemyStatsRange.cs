using UnityEngine;

namespace MainScripts.Stats
{
    public class EnemyStatsRange : MonoBehaviour
    {
        /// <summary>
        /// Количество жизней в данный момент
        /// </summary>
        private float _healthPoint = 75f;
        
        /// <summary>
        /// Количество жизней всего
        /// </summary>
        public float maxHealthPoint = 75f;
        
        /// <summary>
        /// Скорость enemy
        /// </summary>
        public float speed = 10f;
        
        /// <summary>
        /// Множитель который позволяет резать скорость enemy
        /// </summary>
        public float speedMultiplier = 0.05f;

        /// <summary>
        /// Область видимости enemy
        /// </summary>
        public float fieldOfView = 15f;
        
        /// <summary>
        /// Маска чтобы, enemy при виде hero агрился, для этого нужно повесить Layer на hero
        /// </summary>
        public LayerMask heroMask;

        /// <summary>
        /// Урон наносимый противником
        /// </summary>
        public float damage = 40f;

        /// <summary>
        /// Расстояние на котором противник атакует
        /// </summary>
        public float attackRange = 10f;

        /// <summary>
        /// Время, которое враг должен подождать, прежде чем снова атаковать.
        /// </summary>
        public float attackCooldown = 0.8f;
        
        /// <summary>
        /// Флаг который укзывает, будет ли enemy ходить по дефолтному пути, или надо будет задавать точки
        /// </summary>
        public bool WalkingTheDefaultPathByPoints = false;

        public float HealthPoint
        {
            get => _healthPoint;
            set => _healthPoint = value;
        }
    }
}
