using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesGeneration : MonoBehaviour
{
    public static void CreateStones(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = GenerateStones(floorPositions);
        foreach (var position in basicWallPositions)
        {
            tilemapVisualizer.initializeStones(position);
        }
    }

    private static HashSet<Vector2Int> GenerateStones(HashSet<Vector2Int> floorPositions)
    {
        HashSet<Vector2Int> stonesPosition = new HashSet<Vector2Int>();

        foreach (var position in floorPositions)
        {
            
            if (Random.Range(0,15) == 1)
            {
                stonesPosition.Add(position);
            }
        }
        return stonesPosition;
    }
}
