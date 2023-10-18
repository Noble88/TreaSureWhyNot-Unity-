using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
  public static Camera GameCamera;
  //private Transform endMarker = null; // create an empty gameobject and assign in inspector
  public bool canMove = true; //might need this to determine whether is free to 

  public static void CreateGameCamera(Vector3 cameraPosition, Quaternion cameraRotation ) { 
    GameCamera = new GameObject("Game Camera").AddComponent<Camera>();
    GameCamera.transform.position = cameraPosition; //Sets camera position
    GameCamera.transform.rotation = cameraRotation; //Sets camera rotation
  }
  
  #region Camera Actions
  public static IEnumerator MoveCamera(Vector3 position, Quaternion rotation, float time) {
    float startTime = Time.time;
    Vector3 startPosition = GameCamera.transform.position;
    Quaternion startRotation = GameCamera.transform.rotation;
    float journeyLength = Vector3.Distance(startPosition, position);

    while (Time.time - startTime < time) {
      float distanceCovered = (Time.time - startTime) * journeyLength / time;
      float fractionOfJourney = distanceCovered / journeyLength;
        
      //Interpolate position
      GameCamera.transform.position = Vector3.Lerp(startPosition, position, fractionOfJourney);

      //Interpolate rotation
      GameCamera.transform.rotation = Quaternion.Slerp(startRotation, rotation, fractionOfJourney);

      yield return null; // Yield to the next frame
    }
    // Ensure the object reaches the target position and rotation exactly
    GameCamera.transform.position = position;
    GameCamera.transform.rotation = rotation;
  }
  
  #endregion
  //BUG FIX SUGGESTION: Maybe make Camera its own script have
  
  //BUG (FIX IMMIDENTLY BEFORE DOING ANYTHING ELSE IN CLASS) the gameObject "GAME is influcing the camera transformation properties
    //adjust accordingly and redo the math for the camera in both player shoulder and level views

    public View(Camera viewCamera) { 
    GameCamera = viewCamera;
  }
    
    //---------------------------PASS HERE IS OLD CODE THAT NEEDS TO BE DELETE ONCE SALVAGED---------------------------------

    private void playerShoulder() { 
    /*
  #region Teleport to view
  moveToPlayer();
  
  #region Calculating Location 
  Vector2Int playerPos = GlobalData.Player.pos;
  Vector3 tilePos =GlobalData.LevelTilesGrid.Tiles[playerPos.y,playerPos.x].TileFloor.transform.position;
  //print("PLAYER POS: "+playerPos.ToString() +"  &  TILE POS = "+tilePos.ToString());
  Vector3 offset = new Vector3(0f,1.5f,-.25f);
  Vector3 des = new Vector3(tilePos[0]+offset[0],tilePos[1]+offset[1],tilePos[2]+offset[2]);
  #endregion

  camera.transform.position = des;

  canMove = true; player = false;
  #endregion
  /*
  float speed = 1f;
 
  */
    /*
    if (camera.transform.position.Equals(des)) {player = false; canMove = true; return;} 
    camera.transform.position = Vector3.Lerp( camera.transform.position, new Vector3(offset[0]+(1*playerPos.x),offset[1],offset[2]+-1*playerPos.y), Time.deltaTime*speed);
      //camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, new Quaternion(32,0,0,0), Time.deltaTime*speed);
      //print("Pos = "+camera.transform.position.ToString() );
      */
  }

  
  //TODO make rotations for level and player cameras.

  /*
  IEnumerator overPlayerShoulder() { //moves camera to look over bag
    //Example Math
     //TILE POS: 7.5,0    ,-14.5
     //NEW POS: 3.6,4.873,-15.21
     //NEW ROTATION: 32.609,0,0,0
    print("MOVING TO PLAYER");
    canMove = false;
    Transform endMarker = null;
    endMarker.position = new Vector3(6.13f,20f,-20.4f);
    Vector2Int playerPos = GlobalData.Player.pos;
    Vector3 tilePos =GlobalData.LevelTilesGrid.Tiles[playerPos.x,playerPos.y].TileFloor.transform.position;
    
    endMarker.rotation = new Quaternion(32,0,0,0);
    endMarker.position = new Vector3(tilePos[0] - 3.9f,tilePos[1] + 4.873f,tilePos[2] + .71f);
    
    camera.transform.position = Vector3.Lerp( camera.transform.position, endMarker.position, Time.deltaTime*2);
    camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, endMarker.rotation, Time.deltaTime*2);
    yield return new WaitForSeconds(Time.deltaTime*2);
    canMove = true;
    player = false;
  }
  */
 
  
}
