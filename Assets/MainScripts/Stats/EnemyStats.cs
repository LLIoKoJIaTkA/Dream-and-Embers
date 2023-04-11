using UnityEngine;

namespace MainScripts.Stats
{
    public class EnemyStats : MonoBehaviour
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        [HideInInspector] public float healthPoint { set; get; } = 100f;

        /// <summary>
        /// Количество жизней
        /// </summary>
        [HideInInspector] public float maxHealthPoint { set; get; } = 100f;
        
        /// <summary>
        /// Скорость enemy
        /// </summary>
        [HideInInspector] protected float speed { set; get; } = 13f;

        /// <summary>
        /// Множитель который позволяет резать скорость enemy
        /// </summary>
        [HideInInspector] protected float speedMultiplier { set; get; } = 0.05f;

        /// <summary>
        /// Область видимости enemy
        /// </summary>
        [HideInInspector] protected float fieldOfView { set; get; } = 10f;
        
        /// <summary>
        /// Маска чтобы, enemy при виде hero агрился, для этого нужно повесить Layer на hero
        /// </summary>
        [HideInInspector] protected LayerMask heroMask;

        /// <summary>
        /// Урон наносимый противником
        /// </summary>
        
        [HideInInspector] protected float _damage { set; get; } = 40f;

        /// <summary>
        /// Расстояние на котором противник атакует
        /// </summary>
        [HideInInspector] protected float attackRange { set; get; } = 2f;

        /// <summary>
        /// Время, которое враг должен подождать, прежде чем снова атаковать.
        /// </summary>
        [HideInInspector] protected float attackCooldown { set; get; } = 0.4f;

        /// <summary>
        /// Флаг который укзывает, будет ли enemy ходить по дефолтному пути, или надо будет задавать точки
        /// </summary>
        [HideInInspector] protected bool isWalkingTheDefaultPathByPoints { set; get; } = false;
    }
}