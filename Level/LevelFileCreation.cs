using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelFileCreation : Loader{
  
  //TODO: this class might not need static stuff as can create a new class object in gameloop and the empty from memory for this class is only needed at the start of game
  public static void createAllLevels() {
    createLivelyLeafs();
    createFarmenTump();
    createKnotCross();
    createChowderLake();
    createMountainSide();
    createRiverSide();
    createScatteredSides();
    createWetLands();
  }

  #region Helper Methods
  public static char[,] split3dArrayTo2d(char[,,] arr3d, int layer) {
    char[,] arr2d = new char[20, 20];
    for(byte y = 0; y<20;y++){
      for(byte x=0; x<20;x++) {
        arr2d[y, x] = arr3d[layer, y, x];
      }
    }
    return arr2d;
  }
  #endregion
  
  private static void createChowderLake(){
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    
    #region (0,-1) "Lake Cliff Side"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(0,-1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level LakeCliffSide = new LevelBuilder.Level(pos1, "Lake Cliff Side",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    LakeCliffSide.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (0,-2) "temp9"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(0,-2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp9 = new LevelBuilder.Level(pos1, "temp9",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp9.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (1,-1) "Center of Chowder Lake"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(1,-1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level CenterOfChowderLake = new LevelBuilder.Level(pos1, "Center of Chowder Lake",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    CenterOfChowderLake.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (1,-2) "Fisherman's Dock"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(1,-2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level FishermansDock = new LevelBuilder.Level(pos1, "Fisherman's Dock",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    FishermansDock.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    
    
    Loader.SaveLevelToFile(LakeCliffSide);
    Loader.SaveLevelToFile(temp9);
    Loader.SaveLevelToFile(CenterOfChowderLake);
    Loader.SaveLevelToFile(FishermansDock);
  }
  private static void createFarmenTump(){
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    
    #region (-1,0) "Temp1"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-1,0)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level Temp1 = new LevelBuilder.Level(pos1, "Temp1",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    Temp1.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (-1,1) "Crop Yard"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-1,1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level CropYard = new LevelBuilder.Level(pos1, "Crop Yard",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    CropYard.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (-2,0) "Boxed Cattle"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-2,0)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level BoxedCattle = new LevelBuilder.Level(pos1, "Boxed Cattle",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    BoxedCattle.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (-2,1) "Crop Field"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-2,1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level CropField = new LevelBuilder.Level(pos1, "Crop Field",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    CropField.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion

    Loader.SaveLevelToFile(Temp1);
    Loader.SaveLevelToFile(CropYard);
    Loader.SaveLevelToFile(BoxedCattle);
    Loader.SaveLevelToFile(CropField);
  }
  private static void createKnotCross(){
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    
    #region (2,0) "temp7"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(2,0)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp7 = new LevelBuilder.Level(pos1, "temp7",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp7.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (3,0) "temp8"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(3,0)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp8 = new LevelBuilder.Level(pos1, "temp8",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp8.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (2,1) "River Bulge"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(2,1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level RiverBulge = new LevelBuilder.Level(pos1, "River Bulge",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    RiverBulge.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (3,1) "Water Falling"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(3,1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level WaterFalling = new LevelBuilder.Level(pos1, "Water Falling",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    WaterFalling.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion

    Loader.SaveLevelToFile(temp7);
    Loader.SaveLevelToFile(temp8);
    Loader.SaveLevelToFile(RiverBulge);
    Loader.SaveLevelToFile(WaterFalling);
  }
  private static void createLivelyLeafs(){
    //THIS SECTION USES Y,X FOR NAMING FILES ONLY
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    byte[] levChngParent1,levChngParent2,levChngParent3,levChngParent4 = new byte[]{}; // pos to enter child level
    byte[] childSpawn1,childSpawn2,childSpawn3,childSpawn4 = new byte[]{}; // where the plyr ends up after enter child

    byte[] levChngChild1,levChngChild2,levChngChild3,levChngChild4 = new byte[]{}; // Child Level exit to parent
    byte[] parentSpawn1,parentSpawn2,parentSpawn3,parentSpawn4 = new byte[]{}; // where plyr ends up exit child
    
    
    #region (0,0) "Shiny Greens"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(0,0)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
                      (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level ShinyGreen = new LevelBuilder.Level(pos1, "Shiny Greens",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    ShinyGreen.setLevelBehvaior(true);
    #endregion
//forced to create the level as can't write and save to it & assign curLev cuz methods for GamePlay Objects won't work otherwise
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (1,0) "Nestled Nuz"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(1,0)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level NestledNuz = new LevelBuilder.Level(pos1, "Nestled Nuz",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    NestledNuz.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (0,1) "Shrubbed Shrubbery"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(0,1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level ShrubbedShrubbery = new LevelBuilder.Level(pos1, "Shrubbed Shrubbery",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    ShrubbedShrubbery.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (1,1) "Plainned Out Grass"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(1,1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level PlainnedOutGrass = new LevelBuilder.Level(pos1, "Plainned Out Grass",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    PlainnedOutGrass.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    
    Loader.SaveLevelToFile(ShinyGreen);
    Loader.SaveLevelToFile(NestledNuz);
    Loader.SaveLevelToFile(ShrubbedShrubbery);
    Loader.SaveLevelToFile(PlainnedOutGrass);
  }
  private static void createMountainSide(){
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    
    #region (2,2) "Riverous Mountain Base"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(2,2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level RiverousMountainBase = new LevelBuilder.Level(pos1, "Riverous Mountain Base",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    RiverousMountainBase.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (2,3) "Gazed Mountain Sided"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(2,3)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level GazedMountainSided = new LevelBuilder.Level(pos1, "Gazed Mountain Sided",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    GazedMountainSided.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (3,2) "insideMountain1"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(2,3)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level insideMountain1 = new LevelBuilder.Level(pos1, "insideMountain1",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    insideMountain1.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (3,3) "temp6"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(3,3)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp6 = new LevelBuilder.Level(pos1, "temp6",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp6.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion

    Loader.SaveLevelToFile(RiverousMountainBase);
    Loader.SaveLevelToFile(GazedMountainSided);
    Loader.SaveLevelToFile(insideMountain1);
    Loader.SaveLevelToFile(temp6);
  }
  private static void createRiverSide(){
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    
    #region (0,2) "Cattail Marsh"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(0,2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level CattailMarsh = new LevelBuilder.Level(pos1, "Cattail Marsh",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    CattailMarsh.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (0,3) "temp4"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(0,3)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp4 = new LevelBuilder.Level(pos1, "temp4",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp4.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (1,2) "River Leg"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(1,2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level RiverLeg = new LevelBuilder.Level(pos1, "River Leg",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    RiverLeg.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (1,3) "temp5"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(1,3)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp5 = new LevelBuilder.Level(pos1, "temp5",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp5.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion

    Loader.SaveLevelToFile(CattailMarsh);
    Loader.SaveLevelToFile(temp4);
    Loader.SaveLevelToFile(RiverLeg);
    Loader.SaveLevelToFile(temp5);
  }
  private static void createScatteredSides(){
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    
    #region (2,-1) "Eroded Rocks"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(2,-1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level ErodedRocks = new LevelBuilder.Level(pos1, "Eroded Rocks",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    ErodedRocks.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (3,-1) "temp10"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(3,-1)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp10 = new LevelBuilder.Level(pos1, "temp10",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp10.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (2,-2) "Jagged River Rocks"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(2,-2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level JaggedRiverRocks = new LevelBuilder.Level(pos1, "Jagged River Rocks",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    JaggedRiverRocks.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (3,-2) "temp11"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(3,-2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp11 = new LevelBuilder.Level(pos1, "temp11",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp11.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion

    Loader.SaveLevelToFile(ErodedRocks);
    Loader.SaveLevelToFile(temp10);
    Loader.SaveLevelToFile(JaggedRiverRocks);
    Loader.SaveLevelToFile(temp11);
  }
  private static void createWetLands(){
    string filePath = "";
    char[,,] LevelCharTiles = new char[2, 20, 20];
    ArrayList pos1, pos2, pos3, pos4 = new ArrayList();
    
    #region (-1,2) "Muddy Putty"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-1,2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level MuddyPutty = new LevelBuilder.Level(pos1, "Muddy Putty",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    MuddyPutty.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (-2,2) "temp2"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-2,2)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp2 = new LevelBuilder.Level(pos1, "temp2",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp2.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (-1,3) "temp3"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-1,3)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level temp3 = new LevelBuilder.Level(pos1, "temp3",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    temp3.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion
    #region (-2,3) "Melty Snow"
    #region Make Level Object
    pos1=new ArrayList{new Vector2Int(-2,3)};
    
    filePath = GlobalData.stockLevelsPath + (Loader.getPackagePath(pos1, new Vector2Int(0, 0))) + "\\" +
               (Loader.quickPosToString((Vector2Int)pos1[0])) + ".txt";
    LevelCharTiles = Loader.StockLevelAssetTranslator(filePath);
    
    LevelBuilder.Level MeltySnow = new LevelBuilder.Level(pos1, "Melty Snow",
      split3dArrayTo2d(LevelCharTiles,0),split3dArrayTo2d(LevelCharTiles,1));
    #endregion
    
    #region Level Behaviors
    MeltySnow.setLevelBehvaior(true);
    #endregion
    #region Add GamePlay Objects
    #endregion
    
    #endregion

    Loader.SaveLevelToFile(MuddyPutty);
    Loader.SaveLevelToFile(temp2);
    Loader.SaveLevelToFile(temp3);
    Loader.SaveLevelToFile(MeltySnow);
  }
  

  
}
