using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement {

  
  //Method Explanation: Checks to see it desired location is allowed to be walked on
  public static bool isDesWalkable(Vector2Int des, ArrayList allowedWalkables) {
    return allowedWalkables.Contains(LevelMaster.LevelBackEnd.getE(des, false));
  }

  //Method Explanation: Will move foreground character to a desired location (within the current level)
  public static Vector2Int moveCharOnLevel(Vector2Int pos, Vector2Int des, char sym) { //Sym = symbol
    LevelMaster.LevelBackEnd.flipE(pos, true); //deletePlayer
    LevelMaster.LevelBackEnd.setE(des, sym, true); //add player
    return des;
  }
  


}
