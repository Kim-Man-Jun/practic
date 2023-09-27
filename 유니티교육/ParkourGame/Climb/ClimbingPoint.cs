using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClimbingPoint : MonoBehaviour
{
    public List<Neighbour> neighbours;

    private void Awake()
    {
        var toWayClimbNeighbour = neighbours.Where(n => n.isPointToWay);

        foreach (var neighbour in toWayClimbNeighbour)
        {
            neighbour.climbingPoint?.CreatePointConnection(this, -neighbour.pointDirection,
                neighbour.connectionType, neighbour.isPointToWay);
        }
    }

    public void CreatePointConnection(ClimbingPoint climbingPoint, Vector2 pointDirection,
        ConnctionType connctionType, bool isPointToway)
    {
        var neighbour = new Neighbour()
        {
            climbingPoint = climbingPoint,
            pointDirection = pointDirection,
            connectionType = connctionType,
            isPointToWay = isPointToway
        };

        neighbours.Add(neighbour);
    }

    public Neighbour GetNeighbour(Vector2 climbDirection)
    {
        Neighbour neighbour = null;

        if (climbDirection.y != 0)
        {
            neighbour = neighbours.FirstOrDefault(n => n.pointDirection.y == climbDirection.y);
        }

        if (neighbour == null && climbDirection.x != 0)
        {
            neighbour = neighbours.FirstOrDefault(n => n.pointDirection.x == climbDirection.x);
        }

        return neighbour;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        foreach (var neighbour in neighbours)
        {
            if (neighbour.climbingPoint != null)
            {
                Debug.DrawLine(transform.position, neighbour.climbingPoint.transform.position,
                    (neighbour.isPointToWay) ? Color.green : Color.black);
            }
        }
    }
}

[System.Serializable]
public class Neighbour
{
    public ClimbingPoint climbingPoint;
    public Vector2 pointDirection;
    public ConnctionType connectionType;

    public bool isPointToWay = true;
}

public enum ConnctionType { Jump, Move }
