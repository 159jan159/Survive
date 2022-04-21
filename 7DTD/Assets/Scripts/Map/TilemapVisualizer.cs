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
    [SerializeField]
    private GameObject stonePrefab, nextFloorPrefab;

    public void paintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTales(floorPositions, floorTilemap, floorTile);
    }

    internal void initializeStones(Vector2Int position)
    {        
        Instantiate(stonePrefab, new Vector3Int(position.x,position.y,0),Quaternion.identity);
    }
    internal void initializeStairs(Vector2Int position)
    {
         Instantiate(nextFloorPrefab, new Vector3Int(position.x,position.y,0),Quaternion.identity);
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
