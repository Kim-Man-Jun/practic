using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Entity : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody rbody { get; private set; }

    Player player;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    protected virtual void Update()
    {

    }

    public void ZeroVelocity()
    {
        rbody.velocity = Vector2.zero;
    }

    public void SetVelocity(float _xVelocity, float _zVelocity)
    {
        Vector3 inputDir = new Vector3(_xVelocity, 0, _zVelocity);
        rbody.MovePosition(transform.position + inputDir * Time.deltaTime);
        transform.forward = Vector3.Lerp(transform.forward, inputDir, Time.deltaTime * player.rotateSpeed);
    }
}
