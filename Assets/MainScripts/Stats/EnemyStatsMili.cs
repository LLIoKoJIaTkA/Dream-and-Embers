using UnityEngine;

namespace MainScripts.Stats
{
    public class EnemyStatsMili : MonoBehaviour
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        public float HealthPoint = 100f;

        /// <summary>
        /// Скорость enemy
        /// </summary>
        public float Speed = 13f;
        
        /// <summary>
        /// Множитель который позволяет резать скорость enemy
        /// </summary>
        private float _speedMultiplier = 0.05f;

        /// <summary>
        /// Область видимости enemy
        /// </summary>
        public float FieldOfView = 10f;
        
        /// <summary>
        /// Маска чтобы, enemy при виде hero агрился, для этого нужно повесить Layer на hero
        /// </summary>
        public LayerMask HeroMask;

        /// <summary>
        /// Урон наносимый противником
        /// </summary>
        public float Damage = 35f;

        /// <summary>
        /// Расстояние на котором противник атакует
        /// </summary>
        public float AttackRange = 2f;

        /// <summary>
        /// Время, которое враг должен подождать, прежде чем снова атаковать.
        /// </summary>
        public float AttackCooldown = 0.4f;

        /// <summary>
        /// Флаг который укзывает, будет ли enemy ходить по дефолтному пути, или надо будет задавать точки
        /// </summary>
        public bool WalkingTheDefaultPathByPoints = false;
        
    }
}