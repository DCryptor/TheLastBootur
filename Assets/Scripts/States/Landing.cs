using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace deatherror
{
    [CreateAssetMenu(fileName = "New State", menuName = "deatherror/States/Landing")]
    public class Landing : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            control.rb.velocity = new Vector3(0f, 0f, 0f);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
