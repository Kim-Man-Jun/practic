using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float movementSpeed = 5f;
    public MainCameraController MCC;
    public float rotSpeed = 600f;
    Quaternion requiredRotation;
    bool playerControl = true;

    [Header("Player Animator")]
    public Animator animator;


    [Header("Player Collision & Gravity")]
    public CharacterController cc;
    public float surfaceCheckRadius = 0.3f;
    public Vector3 surfaceCheckOffset;
    public LayerMask surfaceLayer;
    bool onSurface;
    [SerializeField] float fallingSpeed;
    [SerializeField] Vector3 moveDir;

    private void Update()
    {
        PlayerMovement();

        if (!playerControl)
        {
            return;
        }

        if (onSurface)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += Physics.gravity.y * Time.deltaTime;
        }

        var velocity = moveDir * movementSpeed;
        velocity.y = fallingSpeed;

        SurfaceCheck();

    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        float movementAmout = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(Vertical));

        var movementInput = (new Vector3(horizontal, 0, Vertical)).normalized;

        var movementDirection = MCC.flatRotation * movementInput;

        cc.Move(movementDirection * movementSpeed * Time.deltaTime);

        if (movementAmout > 0)
        {
            requiredRotation = Quaternion.LookRotation(movementDirection);
        }

        movementDirection = moveDir;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation,
            rotSpeed * Time.deltaTime);

        animator.SetFloat("movementValue", movementAmout, 0.2f, Time.deltaTime);
    }

    void SurfaceCheck()
    {
        onSurface = Physics.CheckSphere(transform.TransformPoint(surfaceCheckOffset),
            surfaceCheckRadius, surfaceLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.TransformPoint(surfaceCheckOffset), surfaceCheckRadius);
    }

    public void SetControl(bool hasControl)
    {
        playerControl = hasControl;
        cc.enabled = hasControl;

        if (!hasControl)
        {
            animator.SetFloat("movementValue", 0f);
            requiredRotation = transform.rotation;
        }
    }
}
