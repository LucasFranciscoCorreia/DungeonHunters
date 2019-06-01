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

    public Transform enemy;
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
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 worldPos) 
    {

        float percentX = (Mathf.Floor(worldPos.x) + gridWorld.x / 2) / gridWorld.x;
        float percentY = (Mathf.Floor(worldPos.y) + gridWorld.y / 2) / gridWorld.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        
        Debug.Log(percentX + " " + percentY);

        int x = Mathf.RoundToInt((gridX - 1) * percentX);
        int y = Mathf.RoundToInt((gridY - 1) * percentY);
        return grid[x, y];
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorld.x, gridWorld.y, 1));
        if (grid != null)
        {
            Node enemyNode = NodeFromWorldPoint(enemy.position);
            foreach (Node n in grid)
            {
                
                Gizmos.color = (n.walkable) ? Color.green : Color.red;
                if(enemyNode == n)
                {
                    Gizmos.color = Color.white;
                }
                Gizmos.DrawCube(n.pos, Vector2.one * (nodeDiam - .1f));
            }
        }
    }
}
