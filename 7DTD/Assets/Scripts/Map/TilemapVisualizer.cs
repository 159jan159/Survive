using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTileMap;
    [SerializeField]
    private TileBase floorTile, wall;

    public void paintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTales(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTales(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile){
        foreach (var position in positions)
        {
            paintSingleTile(tilemap,tile, position);
        }
    }

    internal void paintSingleBacisWall(Vector2Int position)
    {
        paintSingleTile(wallTileMap, wall, position);
    }

    private void paintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }
}
