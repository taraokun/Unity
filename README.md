## はじめに

　RollBallでは、邪魔な敵を退けゴールすることが目的のゲームです。  
　DangeonGameでは、ほとんど完成していませんがローグライクのゲームです。  

RollBall　……　Unityで制作したゲームのプログラム（迷路＋シューティング）  
 :  
 :…　meiro.unitypackage　実際のゲームのパッケージ  
 :  
 :…　Script　実際のプログラム  
 　:  
   :…　Game ゲーム部分のプログラム（Scene1　haruyasumi)  
   : :  
   : :…　BGMS.cs  
   : :　　BGMの操作  
   : :…　Bullet.cs  
   : :　　弾の衝突処理  
   : :…　Camera.cs  
   : :　　メインカメラの座標のコントロール  
   : :…　CameraController.cs  
   : :　　上空を見下ろすカメラとメインカメラの切り替え部分  
   : :…　Enemy.cs  
   : :　　敵のステータスの処理とプレイヤー発見などの処理  
   : :…　GameControl.cs  
   : :　　GUI部分の処理（ステータスや残り時間、retryボタンなど）  
   : :…　GoalPoint.cs  
   : :　　ゴール到達時の処理  
   : :…　Player.cs  
   : :　　プレイヤーのステータスの処理、弾の発射  
   : :…　RandomWalls.cs  
   : :　　ステージの壁をランダムに生成する。  
   : :…　RWall.cs  
   : :　　壁のダメージの管理も行う。  
   : :…　SubCamera.cs  
   :  　　プレイヤーの上空を見上げるカメラ  
   :
   :…　Title　タイトル画面のプログラム (Scene0 OP)  
     :…　ButtonController01.cs  
     :     タイトル画面のボタンの処理  
     :…　InputPlayerName.cs  
     :     入力された文字を保存する。  
     :…　MainController.cs  
           どのボタンが押されたか判定する。  




DangeonGame　……　Unityで制作途中のゲームの一部プログラム(ローグライク）  
 :  
 :…　Battle　ゲーム部分のプログラム  
 :     :  
 :     :…　CreateGUI.cs　味方のステータスを表示させる。（今後応用する予定）  
 :     :…　CsvColumnAttribute.cs　csvファイルを読み込むもの  
 :     :…　EnemyStatus.cs　csvファイルから読み込んだステータスの処理  
 :     :…　MiniMapCamera.cs　プレイヤーを追跡するカメラ  
 :     :…　PlayerStatus.cs　プレイヤのステータスの管理  
 :     :…　ThirdPersonCamera.cs　指定したオブジェクトの座標にカメラを移動する。  
 :     :…　UnityChanControlScriptWithRigidBody.cs　プレイヤーの一マス進む処理や、アニメーシ  :　　　　　　　　　　　　　　　　　　　　　　　　　ョンのコントロール  
 :  
 :…　Resources　データの保管として使うcsvファイル  
 :     :  
 :     :…　EnemyData.csv　敵のステータス情報  
 :  
 :…　DungeonDemo.unitypackage　実際のゲームのパッケージ  
 


