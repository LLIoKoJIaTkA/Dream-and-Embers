using System;
using System.ComponentModel;
using UnityEngine;

namespace MainScripts.Animation
{
    public abstract class MainAnimator : MonoBehaviour
    {
        public enum States { Walk, Run, Jump }

        public States StateAnimation
        {
            get => (States)_animator.GetInteger("state");
            set
            {
                if (!Enum.IsDefined(typeof(States), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(States));
                _animator.SetInteger("state", (int)value);
            }
        }
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
    
}
