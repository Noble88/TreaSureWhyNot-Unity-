using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEditor;



public class TileGrid{
  public char[,,] CharacterGrid;// [0,#,#] = Foreground & [1,#,#] = Background
  public Tile[,] Tiles; //Holds all the tiles [Size is determined by "gridDimension"]
  public GameObject tileGridObject = new GameObject(); // Holds all the tile gameObjects [Used for organizational purposes & transformations]
  public Vector2Int gridDimensions; //Dimension for how long and wide grid will be
  
  public TileGrid(Vector2Int gridDimensions, int scale, string name, Vector3 position){
  #region Variable Assignment and Decleration
    tileGridObject.name = name; //assign tileGridObject a name
    this.gridDimensions = gridDimensions;
    Tiles = new Tile[gridDimensions.y,gridDimensions.x];
    CharacterGrid = new char[2,gridDimensions.y,gridDimensions.x];
  #endregion

    //1) Make Tile Objects and assign it to "Tiles"
    Vector3Int pos = new Vector3Int(0,0,0); //pos = position
    for(pos.z = 0;pos.z>(gridDimensions.y*-1); pos.z--){ //On 3rd dimension use z instead of y
      for (pos.x = 0; pos.x<gridDimensions.x; pos.x++) {
        Vector3 spawnPosition = pos + position; //Where Tile will spawn
        Tiles[(pos.z*-1),pos.x] = new Tile(spawnPosition, new Vector2Int(pos.x ,pos.z), name, tileGridObject); //Make Tile
      }
    }
    
    //2) Apply Scale, Position, & Offset globally to "Tiles" & TileGridObject 
      //TODO SCALING & POSITIONING CODE NOT WORKING
    Vector3 tileGridDefaultOffset = new Vector3(scale/2,0,-1*(scale/2));
    tileGridObject.transform.position = tileGridDefaultOffset; //Position Offset
    tileGridObject.transform.localScale = new Vector3(scale,scale,scale); //Applies Scale 
  }
  
  //Method: Modify Scale
  //Method: Change Position

  #region Updating Grid Methods
  //These methods will update the foreground & background accordingly
  public void updateWholeGrid() { //Will update all tiles on the grid
        //Should only use if more than half of the tiles need to be updated 
    Vector2Int pos = new Vector2Int(0,0);
    for (pos.y = 0; pos.y < gridDimensions.y; pos.y++) {
      for (pos.x = 0; pos.x < gridDimensions.x; pos.x++) {
        if (Tiles[pos.y, pos.x]==null) { Debug.Log("NULL TILE looking in ["+pos.x+","+pos.y+"]");}
        Tiles[pos.y, pos.x].updateBg(CharacterGrid, tileGridObject, pos);
        Tiles[pos.y, pos.x].updateFg(CharacterGrid, tileGridObject, pos);
      }
    }
  }
  
  public void executeDisplayOfTileGrid() { //Will check to see if a single tile has change and only change that tile
        //Why? -> a more efficient than updating all tiles ones that haven't changed
    Vector2Int pos = new Vector2Int(0,0);
    for (pos.y = 0; pos.y < gridDimensions.y; pos.y++) {
      for (pos.x = 0; pos.x < gridDimensions.x; pos.x++) {
        if (CharacterGrid[1, pos.y, pos.x] != LevelMaster.LevelBackEnd.getE(pos, false)) {
          Tiles[pos.y, pos.x].updateBg(CharacterGrid, tileGridObject, pos);
        }
        if (CharacterGrid[0, pos.y, pos.x] != LevelMaster.LevelBackEnd.getE(pos, true)) {
          Tiles[pos.y, pos.x].updateFg(CharacterGrid, tileGridObject, pos);
        }
      }
    }
  }
  #endregion
}
