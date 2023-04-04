using System.Numerics;

namespace MainScripts.GameObject
{
    public interface IEnemyObjects
    {
        public void Attack();

        public bool MoveByPointsAndMonitoring();

        public bool HeroFallIntoTheFieldOfView();

        public void RunToHeroAttack();
        
    }
}