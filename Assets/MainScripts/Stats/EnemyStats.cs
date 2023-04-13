using UnityEngine;

namespace MainScripts.Stats
{
    public class EnemyStats : MonoBehaviour
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        public float healthPoint = 100f;

        /// <summary>
        /// Количество жизней
        /// </summary>
        public float maxHealthPoint = 100f;
        
        /// <summary>
        /// Скорость enemy
        /// </summary>
        public float speed = 13f;

        /// <summary>
        /// Множитель который позволяет резать скорость enemy
        /// </summary>
        public float speedMultiplier = 0.05f;

        /// <summary>
        /// Область видимости enemy
        /// </summary>
        public float fieldOfView = 10f;
        
        /// <summary>
        /// Маска чтобы, enemy при виде hero агрился, для этого нужно повесить Layer на hero
        /// </summary>
        public LayerMask heroMask;
        
        /// <summary>
        /// Маска чтобы, enemy при виде wall искал точки чтобы уйти от стены
        /// </summary>
        public LayerMask wallMask;

        /// <summary>
        /// Урон наносимый противником
        /// </summary>
        
        public float _damage = 40f;

        /// <summary>
        /// Расстояние на котором противник атакует
        /// </summary>
        public float attackRange = 2f;

        /// <summary>
        /// Время, которое враг должен подождать, прежде чем снова атаковать.
        /// </summary>
        public float attackCooldown = 0.4f;

        /// <summary>
        /// Флаг который укзывает, будет ли enemy ходить по дефолтному пути, или надо будет задавать точки
        /// </summary>
        public bool isWalkingTheDefaultPathByPoints = true;

        /// <summary>
        /// Количество точек
        /// </summary>
        public int countPoints = 3;

        /// <summary>
        /// Флаг который указывает, будет ли останавливаться Enemy на точках
        /// </summary>
        public bool isStayInPoint = true;
        
        /// <summary>
        /// Время остановки на точках
        /// </summary>
        public float timeStayInPoint = 5f;
    }
}