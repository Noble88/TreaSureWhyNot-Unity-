using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMethods : MonoBehaviour {
  
  public static string findDirectionFacing(Vector2Int pos, Vector2Int des){
    //NOTE: byte[0][0] is the top left of the grid
    if(pos.y==des.y && pos.x==des.x){return "N/A";}

    if(pos.y==des.y){ //if Y axis are aligned... (must have moved along the X axis)
      if(pos.x>des.x){return "LEFT";}
      else           {return "RIGHT";}
    }
    else if(pos.x==des.x){ //if X axis are aligned... (must have moved along the Y axis)
      if(pos.y>des.y){return "UP";}
      else           {return "DOWN";}
    }
    return "N/A";
  }

  public static Vector2Int findCords(Vector2Int pos, string key) {
    Vector2Int temp = new Vector2Int(pos.x, pos.y);
    switch (key) {
      case "UP"   : temp.y += -1; break;
      case "LEFT" : temp.x += -1; break;
      case "RIGHT": temp.x +=  1; break;
      case "DOWN" : temp.y +=  1; break;
    }
    return temp;
  }

  public static string doubleDigitMaker(int num) {
    if (num<0 && num>-10 ) { return "-0"+Math.Abs(num);}
    if (num>-1 && num<10){return "0"+num;}
    return num.ToString();
  }

  public static void GameStateSwitchChecker() {
  }
}
