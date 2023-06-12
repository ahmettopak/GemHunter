using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] VariableJoystick variableJoystick;
    [SerializeField] float moveSpeed;
    

    Rigidbody _rigidbody;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>(); 
        _rigidbody= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        #region Animation
        if (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0) {

            animator.SetBool("isRun", true);
            
            //Set anim speed
            animator.speed = (Math.Abs(variableJoystick.Vertical) > Math.Abs(variableJoystick.Horizontal)) 
                ? Math.Abs(variableJoystick.Vertical) 
                : Math.Abs(variableJoystick.Horizontal);

        }
        else {
            animator.SetBool("isRun", false);
            animator.speed = Math.Abs(1);
        } 
        #endregion

    }

    private void FixedUpdate() {
        Vector3 direction = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
        Move(direction);
    }

    private void Move(Vector3 direction) {

        //Move
        _rigidbody.velocity = direction * moveSpeed * Time.fixedDeltaTime;

        //Roatate
        transform.rotation = (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0) ? Quaternion.LookRotation(direction, Vector3.up) : default;
    }
}
