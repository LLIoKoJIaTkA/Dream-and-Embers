using UnityEngine;
using System;
using System.ComponentModel;
using MainScripts.Stats;

namespace MainScripts.Animation
{
    public class MainAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = FindObjectOfType<HeroStats>().gameObject.GetComponent<Animator>();
        }

        public enum States { Idle, Run, Jump, Attack, Walk }

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
    }    
}
