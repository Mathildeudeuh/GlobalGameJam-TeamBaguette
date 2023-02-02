using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction action;
    private Animator animator;
    private bool playerCamera = true;
    public CinemachineVirtualCamera vcam1; //Player
    public CinemachineVirtualCamera vcam2; //Cave


    void Start()
    {
        action.performed += ctx => SwitchState();
        //action.performed += ctx => SwitchPriority();
    }

    public void SwitchState()
    {
        if (playerCamera)
            animator.Play("CaveCamera");
        else
            animator.Play("PlayerCamera");
        playerCamera = !playerCamera;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
  /* private void SwitchPriority()
    {
        if (playerCamera)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }


        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }

        playerCamera = !playerCamera;
    }*/

}
