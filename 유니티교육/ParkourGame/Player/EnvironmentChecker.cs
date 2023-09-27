using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnvironmentChecker : MonoBehaviour
{
    public Vector3 rayOffset = new Vector3(0, 0.2f, 0);
    public float raylength = 0.9f;
    public float heightRayLength = 6f;
    public LayerMask obstacleLayer;

    [Header("Check Ledge")]
    [SerializeField] float ledgeRayLength = 11f;
    [SerializeField] float ledgeRayHeightThreshold = 0.76f;

    [Header("Climbing Check")]
    [SerializeField] float climbingRayLength = 1.6f;
    [SerializeField] LayerMask climbingLayer;
    public int numberOfRays = 12;

    public ObstacleInfo CheckObstacle()
    {
        var hitData = new ObstacleInfo();

        var rayOrigin = transform.position + rayOffset;

        hitData.hitFound = Physics.Raycast(rayOrigin, transform.forward,
            out hitData.hitInfo, raylength, obstacleLayer);

        Debug.DrawRay(rayOrigin, transform.forward * raylength,
            (hitData.hitFound) ? Color.red : Color.green);

        if (hitData.hitFound)
        {
            var heightOrigin = hitData.hitInfo.point + Vector3.up * heightRayLength;
            hitData.heightHitFound = Physics.Raycast(heightOrigin, Vector3.down,
                out hitData.heightInfo, heightRayLength, obstacleLayer);

            Debug.DrawRay(heightOrigin, Vector3.down * heightRayLength,
                (hitData.heightHitFound) ? Color.blue : Color.green);
        }

        return hitData;
    }

    public bool CheckLedge(Vector3 movementDirection, out LedgeInfo ledgeInfo)
    {
        ledgeInfo = new LedgeInfo();

        if (movementDirection == Vector3.zero)
            return false;

        float ledgeOriginOffset = 0.5f;
        var ledgeOrigin = transform.position + movementDirection
            * ledgeOriginOffset + Vector3.up;

        if (Physics.Raycast(ledgeOrigin, Vector3.down, out RaycastHit hit,
            ledgeRayLength, obstacleLayer))
        {
            Debug.DrawRay(ledgeOrigin, Vector3.down * ledgeRayLength, Color.blue);


            var surfaceRaycastorigin = transform.position + movementDirection
                - new Vector3(0, 0.1f, 0);

            if (Physics.Raycast(surfaceRaycastorigin, -movementDirection,
                out RaycastHit surfaceHit, 2, obstacleLayer))
            {
                float Ledgeheight = transform.position.y - hit.point.y;

                if (Ledgeheight > ledgeRayHeightThreshold)
                {
                    ledgeInfo.angle = Vector3.Angle(transform.forward, surfaceHit.normal);
                    ledgeInfo.height = Ledgeheight;
                    ledgeInfo.surfacehit = surfaceHit;
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckClimbing(Vector3 climbDirection, out RaycastHit climbInfo)
    {
        climbInfo = new RaycastHit();

        if (climbDirection == Vector3.zero)
        {
            return false;
        }

        var climbOrigin = transform.position + Vector3.up * 1.5f;
        var climbOffset = new Vector3(0, 0.19f, 0);

        for (int i = 0; i < numberOfRays; i++)
        {
            Debug.DrawRay(climbOrigin + climbOffset * i, climbDirection, Color.red);

            if (Physics.Raycast(climbOrigin + climbOffset * i, climbDirection,
                out RaycastHit hit, climbingRayLength, climbingLayer))
            {
                climbInfo = hit;
                return true;
            }
        }

        return false;
    }
}

public struct ObstacleInfo
{
    public bool hitFound;
    public bool heightHitFound;
    public RaycastHit hitInfo;
    public RaycastHit heightInfo;
}

public struct LedgeInfo
{
    public float angle;
    public float height;
    public RaycastHit surfacehit;
}
