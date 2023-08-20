using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    [Header("Move Info")]
    public float walkSpeed;
    public float runSpeed;
    public float rotateSpeed;
    public static bool runOnOff = false;

    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerWalkState walkState { get; private set; }
    public PlayerRunState runState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        walkState = new PlayerWalkState(this, stateMachine, "Walk");
        runState = new PlayerRunState(this, stateMachine, "Run");
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            runOnOff = !runOnOff;
        }
    }
}
