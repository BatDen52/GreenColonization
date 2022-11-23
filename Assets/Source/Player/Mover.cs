using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 600.0f;
    [SerializeField] private float _gravity = 20.0f;

    private Vector3 _moveDirection = Vector3.zero;
    private Animator _animator;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void Move(Vector3 targetPosition)
    {
        transform.LookAt(targetPosition, Vector3.up);

        if (Input.GetKey("w"))
            _animator.SetInteger("AnimationPar", 1);
        else
            _animator.SetInteger("AnimationPar", 0);

        _moveDirection = (targetPosition - transform.position).normalized;

        if (_controller.isGrounded == false)
            _moveDirection.y -= _gravity;

        _controller.Move(_moveDirection * _speed * Time.deltaTime);
    }
}
