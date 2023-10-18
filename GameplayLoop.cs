using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Coder Note: All vector3 are for 3D objects & vector2 are for 2D objects!!!
#region REVIEW AND REFACTOR CHECKLIST
/* Checked & Refactored: Loader | Tile | TileGrid | Player | Gameplay Loop | Level Builder |
 * Need to Check (In Order):  Movement | GlobalMethods |
 * NEED DUE BEFORE CONTINUE WRITING: Debugger | Color Class |
 * TODO: Make all private variables -> _name
 * TODO: Check to see if send the who gameobject when only certain data from obj is needed
 * TODO: make abstract class with namespace for globalmethods!!! (check example course for unity class)
 * TODO: Can change position by passing through gameobject.transoformation through parameters and inside method if change gameobject.transofmration will translate into game
 * TODO: Need ot make methods in side master classes called switch to in where it should activate all steps neccessary to switch the that gamestate
 * TODO: ASK TEACHER WHAT FILE FORMAT ShOULD I SAVE INFORMATION IN
 * 
 */
#endregion

public class GameplayLoop : MonoBehaviour{
  
  public static string associatedKey="N/A", key="N/A";
  public static string gameState = "LEVEL";
  public static bool isNewKeyPressed = false;
  
  void Start() {
    Debug.Log("START");

    #region Warm Up Classes
    View.CreateGameCamera(new Vector3(10,20,-20),Quaternion.Euler(60, 0, 0));
    
    LevelMaster.warmUpLevel();
    #endregion
    Loader.LoadLevels(true); //Remakes all the levels //TODO: REPALCE WHEN MAKING DEBUGGER CLASS
    
    #region Create and Declare TileGrids
    LevelMaster.LevelFrontEnd = //Level Tile Grid
      new TileGrid(new Vector2Int(20,20),1,"LEVEL",new Vector3(0,0,0));
    //Declare Bag
    //Declare Menu
    //Declare Map
    //Declare Quests
    #endregion
    
    #region Load Saved Data (If Any)
    LevelMaster.loadStartUpLevel(new Vector2Int(7,14),"\\Assets\\SavedData\\Levels\\LivelyLeafs\\0,0.txt");
      //Will load the last level saved on (if no saved data, goes to default level modified via parameters above
    //Load Bag
    //Load Quests
    #endregion
  }

  void Update(){
    //GlobalData.View.updater();
    
    if (isNewKeyPressed){ //Checks to see if a new key is pressed 
      inputDirector();
      associatedKey="N/A"; key = "N/A"; isNewKeyPressed = false; //After "inputDirector", Allows for another key input (resets vars)
    }
    
    LevelMaster.LevelFrontEnd.executeDisplayOfTileGrid();
    CompleteTick();
  }

  IEnumerator CompleteTick() { 
    yield return new WaitForSeconds(.025f);
  }
  
  
  public void inputDirector()
  {
    //GlobalMethods.GameStateSwitchChecker();
    /*
    switch(associatedKey){ //GLOBAL KEY BINDINGS
      case "MAP"     ->{}
      case "JOURNAL" ->{SideWndwBhvr.switchTabs("JOURNAL"); }
      case "TREASURE"->{SideWndwBhvr.switchTabs("TREASURE");}
      case "TOOL"    ->{SideWndwBhvr.switchTabs("TOOLS");   }
      case "PAUSE"   ->{PauseBhvr.togglePauseScreen(); PauseBhvr.justedPaused=true;}
    }
    */
    switch (gameState) {
      case "LEVEL": LevelMaster.inputDirector(); break;
      //case "SIDE WINDOW"->{SideWndwBhvr.inputDirector();}
      //case "PAUSE"-> {PauseBhvr.inputDirector();}
      //case "EVENT"->{if(!Events.relatedEvent.triggerEvent()){Events.deActivateEventState();}}
    }
  }
}

//can make a 
