using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 pos;

    public Node(bool walkable, Vector3 pos)
    {
        this.pos = pos;
        this.walkable = walkable;
    }
}
