using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] VariableJoystick variableJoystick;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
   
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        Vector3 movement = new Vector3(variableJoystick.Horizontal, 0f, variableJoystick.Vertical);

        if (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0) {
           
            animator.SetBool("isRun", true);

            //Set anim speed
            if (Math.Abs(variableJoystick.Vertical) > Math.Abs(variableJoystick.Horizontal)) {
                animator.speed = Math.Abs(variableJoystick.Vertical);
            }
            else {
                animator.speed = Math.Abs(variableJoystick.Horizontal);
            }
            
        }
        else {
            animator.SetBool("isRun", false);
            animator.speed = Math.Abs(1);
        }
        transform.Translate(movement / moveSpeed);
        transform.Rotate(0f, variableJoystick.Horizontal * rotateSpeed, 0);
    }
}
