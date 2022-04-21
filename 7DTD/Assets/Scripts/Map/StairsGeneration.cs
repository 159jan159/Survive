using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsGeneration : MonoBehaviour
{
    public static void CreateStairs(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
            tilemapVisualizer.initializeStairs(GenerateStairs(floorPositions));
    }

    private static Vector2Int GenerateStairs(HashSet<Vector2Int> floorPositions)
    {
        Vector2Int stonesPosition = new Vector2Int();

        foreach (var position in floorPositions)
        {
            
            if (Random.Range(0,30) == 1)
            {
                stonesPosition = position;
            }
        }

        return stonesPosition;
    }
}
