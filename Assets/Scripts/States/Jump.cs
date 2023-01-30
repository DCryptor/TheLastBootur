using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace deatherror
{
    [CreateAssetMenu(fileName = "New State", menuName = "deatherror/States/Jump")]
    public class Jump : StateData
    {
        public float jump;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            Jumping(control);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {


        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public void Jumping(CharacterControl control)
        {
            control.rb.velocity = new Vector3(control.rb.velocity.x, jump, control.rb.velocity.z);
        }
    }
}
