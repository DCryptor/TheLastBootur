using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace deatherror
{
    [CreateAssetMenu(fileName = "New State", menuName = "deatherror/States/Fall")]
    public class Fall : StateData
    {
        public float speed;
        public bool lockDirection;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            IsGrounded(control);
            Move(control);
            Turn(control);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

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
        public void Move(CharacterControl control)
        {
            control.rb.velocity = new Vector3(control.rb.velocity.x, control.rb.velocity.y, control.direction.z * speed);
            control.anim.SetFloat("Magnitude", Mathf.Abs(control.direction.z));
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
    }
}
