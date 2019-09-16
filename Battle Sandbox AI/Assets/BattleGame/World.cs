using UnityEngine;
using System.Collections;

public class World
{
    /*World Class
     * Contains information about the static environment of the game. E.g. the boundaries, obstacles.
     * 1. World is constrained to be a square
     */

    public float size;

    public World(float size)
    {
        this.size = size;
    }
}
