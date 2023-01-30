using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace deatherror
{
    [CreateAssetMenu(fileName = "New State", menuName = "deatherror/States/Idle")]
    public class Idle : StateData
    {
        public bool lockDirection;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            control.anim.SetFloat("Magnitude", Mathf.Abs(control.direction.z));
            Turn(control);
            IsGrounded(control);
            Jump(control);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public void Turn(CharacterControl control)
        {
            if (!lockDirection)
            {
                if (control.inputManager.MoveRight)
                {
                    control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }

                if (control.inputManager.MoveLeft)
                {
                    control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }
        }
        public void IsGrounded(CharacterControl control)
        {
            if (control.isGrounded)
            {
                control.anim.SetBool("Grounded", true);
            }
            else
            {
                control.anim.SetBool("Grounded", false);
            }
        }
        public void Jump(CharacterControl control)
        {
            if (control.inputManager.Jump)
            {
                control.inputManager.Jump = false;
                control.anim.SetTrigger("Jump");
            }
        }
    }
}
