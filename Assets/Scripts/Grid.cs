using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
    public Vector2 gridWorld;
    public float nodeRadius;
    public LayerMask walkable;
    public Node[,] grid;
    public Tilemap walk;

    public float nodeDiam;
    public int gridX, gridY;
    private void Start()
    {
        nodeDiam = nodeRadius * 2;
        gridX = Mathf.RoundToInt(gridWorld.x / nodeDiam);
        gridY = Mathf.RoundToInt(gridWorld.y / nodeDiam);
        CreateGrid();
    }

    public void CreateGrid()
    {

        grid = new Node[gridX, gridY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorld.x / 2 - Vector3.up * gridWorld.y / 2;
        for (int i = 0; i < gridX; i++)
        {
            for (int j = 0; j < gridY; j++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (i * nodeDiam + nodeRadius) + Vector3.up * (j * nodeDiam + nodeRadius);
                if(walk.GetTile(new Vector3Int(Mathf.RoundToInt(Mathf.Floor(worldPoint.x)), Mathf.RoundToInt(Mathf.Floor(worldPoint.y)), Mathf.RoundToInt(Mathf.Floor(worldPoint.z)))))
                    grid[i, j] = new Node(true, worldPoint);
                else
                    grid[i, j] = new Node(false, worldPoint);
                //Debug.Log(walk.GetTile(new Vector3Int(Mathf.RoundToInt(worldPoint.x), Mathf.RoundToInt(worldPoint.y), Mathf.RoundToInt(worldPoint.z))));
                Debug.Log(new Vector3Int(Mathf.RoundToInt(Mathf.Floor(worldPoint.x)), Mathf.RoundToInt(Mathf.Floor(worldPoint.y)), Mathf.RoundToInt(Mathf.Floor(worldPoint.z))));

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorld.x, gridWorld.y, 1));
        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.green : Color.red;
                Gizmos.DrawCube(n.pos, Vector2.one * (nodeDiam - .1f));
            }
        }
    }
}
