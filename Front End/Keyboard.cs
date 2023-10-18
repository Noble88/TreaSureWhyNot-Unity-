using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {
  IDictionary<int, string> keyBindTranslator = new Dictionary<int, string>();

  void Update(){
    if(Input.GetKeyDown(KeyCode.W)){keyPressed("UP");}
    if(Input.GetKeyDown(KeyCode.A)){keyPressed("LEFT");}
    if(Input.GetKeyDown(KeyCode.D)){keyPressed("RIGHT");}
    if(Input.GetKeyDown(KeyCode.S)){keyPressed("DOWN"); }
    if (Input.GetKeyDown(KeyCode.B)){
      //print("PRESSED B & PLAYER=TRUE");
    }
    if (Input.GetKeyDown(KeyCode.L)) { keyPressed("L");
      LevelMaster.EnterLevelState();
    }
  }

  private void keyPressed(string key) {
    GameplayLoop.associatedKey = key;
    GameplayLoop.isNewKeyPressed = true;
  }
  
  //Player.transform.Translate(1f,0f,0f);;
}
