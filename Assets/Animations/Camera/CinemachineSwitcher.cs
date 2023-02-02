using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction action;
    private Animator animator;
    private bool playerCamera = true;

    void Start()
    {
        action.performed += ctx => SwitchState();
    }

    private void SwitchState()
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
}
