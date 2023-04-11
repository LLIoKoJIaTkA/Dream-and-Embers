using MainScripts.Stats;

namespace Scenes._1_Scene___Forest.Scripts.Enemy.FireWizard
{
    public class FireWizardStats : EnemyStats
    {
        private void Awake()
        {
            _setFireWizardStats();
        }

        private void _setFireWizardStats()
        {
            isWalkingTheDefaultPathByPoints = true;
        }
    }
}