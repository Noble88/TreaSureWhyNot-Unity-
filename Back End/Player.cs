using System;
using System.Collections;
using UnityEngine;

public class Player{
  public GameObject GamePlayer;
  public Vector2Int pos = new Vector2Int(1, 1); //pos = "Player Position" or just "Position"
  public char symFacingFG=' ',symFacingBG=' ';
  public ArrayList walkablesList = new ArrayList{',','░','∷',':'};
  public string directionFacing = "N/A";
  public char playerSymbol = '@';

  private void Start() {
    //LevelMaster.LevelBackEnd.setE(pos, playerSymbol, true);
  }
  
  public void SpawnPlayers(Vector2Int des){
    LevelMaster.LevelBackEnd.flipE(pos,true); //Remove Player
    pos = des; //Resigned Player Position
    LevelMaster.LevelBackEnd.setE(pos,'@',true); //Add Player (w/Updated Position)
  }
  
  public void movePlayer() {
    Vector2Int des = GlobalMethods.findCords(pos,GameplayLoop.associatedKey); // des = Destination
    directionFacing = GlobalMethods.findDirectionFacing(pos, des);
    //UnityEngine.Debug.Log("Facing ("+directionFacing+") MOVING PLAYER FROM ("+pos.x+","+pos.y+") to ("+des.x+","+des.y+")");
    
    #region Physical Collision
    /*Implement Live object collision detection method
     [checkIfPlayerHitLiveObject(des);] -> check if it live object first before anything ->
        why? : because don't want player to move during events*/
    if (isDesCharAllowedWalkable(des)) { //Will move player to a allowed walkable character
      pos = Movement.moveCharOnLevel(pos,des,playerSymbol);
      //TODO: DEBUG -> make it so knows that walk on a walkable surface
    }
    #endregion

    #region Level Switching Collision
    //POTENTIAL ERROR: doesn't check if new position is walkable or not
    if(canPlayerBorderLevelSwitch(des)) { //Checks if current level allows switching to another level is allowed
      LevelMaster.LevelBackEnd.flipE(pos, true); //removes player from current level
      LevelMaster.LevelBackEnd.borderLevelSwitch(); //Prepares the current level to do a "Border Level Switch"
      pos = posShiftBorderLevelSwitch(); //Update where play should be on the new level
      LevelMaster.LevelBackEnd.setE(pos, playerSymbol,true); //add player char to new level
      LevelMaster.LevelFrontEnd.updateWholeGrid(); //Updates the Level Tile Grid
    }
    //ADD SUBLEVEL SWITCHING
    #endregion
  }

  #region Collision Check Methods
  
  #region Physical Collisions
  //POTENTIAL ERROR: this method implies anything player walks on is ONLY a walkable
  public bool isDesCharAllowedWalkable(Vector2Int des) { //Checks to see if can walk on the character at the destination
    return walkablesList.Contains(LevelMaster.LevelBackEnd.getE(des, false));
  } // Checks if player can walk on destination  

  #endregion

  #region Level Switcher Collisions
  public bool canPlayerBorderLevelSwitch(Vector2Int des) {//Checks if level allows level swapping on boarder 
    //print("ATTEMPTED TO SEE IF PLAYER BORD LEV SIWTCH TRU & Direction: ("+getDirectionOfHitBorderLevel(des)+")  |  Lev state: ("+LevelMaster.LevelBackEnd.canBorderLevelSwitch+")");
    return !getDirectionOfHitBorderLevel(des).Equals("N/A") && LevelMaster.LevelBackEnd.canBorderLevelSwitch ;
  }

  #region Helper Methods
    
  public Vector2Int posShiftBorderLevelSwitch(){ //Finds the cordinates of where to place the player after boarder swapping
    switch(directionFacing){
      case "UP"   :return new Vector2Int( pos.x,pos.y+(20-3) );
      case "DOWN" :return new Vector2Int( pos.x,pos.y-(20-3) );
      case "LEFT" :return new Vector2Int(pos.x+(20-3),pos.y );
      case "RIGHT":return new Vector2Int(pos.x-(20-3),pos.y );
      default: {//"HUGE ERROR IN (PlayerData->levShiftPlyrPos) BAD DIRECTION"
        return new Vector2Int(pos.x,pos.y);}
    }
  }

  public string getDirectionOfHitBorderLevel(Vector2Int des){ //Returns direction according to where destination is 
    if      (des.y==0)     {return"UP";   }
    else if (des.y==(20-1)){return"DOWN"; }
    else if (des.x==0)     {return"LEFT"; }
    else if (des.x==(20-1)){return"RIGHT";}
    else{return "N/A";}
  }
  #endregion
  
  #endregion
  #endregion
  
  //unused code
  /*
  //PlayerCharacter was a gameobject in gameplay loop what it does is unknown
  public void moveInGamePlayer(){
    switch(directionFacing){
      case "UP"   : GameplayLoop.PlayerCharacter.transform.Translate(0f,0f,1f); break;
      case "LEFT" : GameplayLoop.PlayerCharacter.transform.Translate(-1f,0f,0f); break;
      case "RIGHT": GameplayLoop.PlayerCharacter.transform.Translate(1f,0f,0f); break;
      case "DOWN" : GameplayLoop.PlayerCharacter.transform.Translate(0f,0f,1f); break;
    }
  }
  */
  

}
