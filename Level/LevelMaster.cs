using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelMaster : MonoBehaviour{
  public static LevelBuilder.Level LevelBackEnd = new LevelBuilder.Level(); //Current Level & 2D Space
  public static TileGrid LevelFrontEnd; //Contains visual objects (3D Space)
  
  public static Player Player = new Player(); //Player will always be in level thus belongs to Level Master


  public static void warmUpLevel() {
    LevelColor.reasignColorsAndModifyers();
  }
  
  
  //Method meant for loading the first level upon start up 
  public static void loadStartUpLevel(Vector2Int playerSpawn, string levelFilePath) { 
    Loader.loadNewLevel(false,GlobalData.curFilePath+levelFilePath); //loads
    //TODO: MAKE A IF STATMENT AND SEE IF HAVE DATA OF PLAYER LOCATION SAVED...
    Player.SpawnPlayers(playerSpawn);
    LevelFrontEnd.updateWholeGrid();
  }

  #region Enter the Level Game State

  public static void EnterLevelState() {
    //TODO: make a coroutine work with this moving camera
    //StartCoroutine(View.MoveCamera(new Vector3(10,20,-20f),Quaternion.Euler(60, 0, 0),1f));
    GameplayLoop.gameState = "Level";
  }
  #endregion
  
  public static void inputDirector(){
    switch (GameplayLoop.associatedKey) {
      case "UP" or "DOWN" or "LEFT" or "RIGHT":
        Player.movePlayer(); 
        break;
      
      //case "INTERACT":{run input objects}
      //case "Swap Tabs"  
    }
    
  }
}
