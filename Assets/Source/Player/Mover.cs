using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 600.0f;
    [SerializeField] private float _gravity = 20.0f;

    private Animator _animator;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void FixedUpdate()
    {
        if (_controller.isGrounded == false)
        {
            _controller.Move(Vector3.down * _gravity * Time.deltaTime);
        }
    }

    public void Move(Vector3 targetPosition)
    {
        transform.LookAt(targetPosition, Vector3.up);

        _animator.SetInteger("AnimationPar", 1);

        Vector3 _moveDirection = (targetPosition - transform.position).normalized;
        _controller.Move(_moveDirection * _speed * Time.deltaTime);
    }

    public void Stop()
    {
        _animator.SetInteger("AnimationPar", 0);
    }
}
