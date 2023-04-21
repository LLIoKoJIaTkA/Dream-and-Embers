using MainScripts.Animation;
using Unity.VisualScripting;

namespace Scenes._1_Scene___Forest.Scripts.Enemy.FireWizard
{
    public class MedievalWarriorAnimation : MainAnimator
    {
        private States _currentState = States.Idle;
        
        private void Update()
        {
            StateAnimation = _currentState;
        }

        public void ChangeAnimation(States currentState)
        {
            _currentState = currentState;
        }
    }
}