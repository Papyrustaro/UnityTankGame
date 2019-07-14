# はじめに
このファイルは戦車AI制作者にむけたものです。  
制作する人は必ず目を通してから作業してください。  
質問や要望があれば積極的にどうぞ^^  

# <a id="index" href="#index">目次</a>
- [作業の流れ](#section0)
- [作業上注意すること](#section1)
- [用意しているクラス](#section2)
    - [EnemyController](#section2_0)
    - [PutObject](#section2_1)
    - [EnemyShotManager](#section2_2)
- [参考文献](#sectiton3)

# <a id="section0" href="#section0">作業の流れ</a>

## 基本的な作業の流れ
作業は全て作業用ディレクトリ内でおこないます。  
あたらしく作るのは基本的には敵AI用のスクリプトのみです。  
スクリプト及び移動速度などのパラメータ調整によってひとつの敵が完成したら、  
新しいprefabとして保存しましょう。  
新しいprefabとして保存する場合はHierarchy上にある保存したいオブジェクトを、  
Project内の保存したい位置にドラッグ＆ドロップです。  
保存先には注意しましょう(上書き保存でなければ消せばいいだけですが)

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>

# <a id="section1" href="#section1">作業上注意すること</a>

## エディタ上で注意すべきこと
いかなる変更・保存も自分の作業用ディレクトリ内でおこなってください。  
自分の作業用ディレクトリ外の変更はしないでください。  
自分で作成・改変したものを新しいものとして保存することは問題ありません。

実行時に無限ループなどで動作不能になる場合があります。  
実行前に保存を忘れずに(コードが書けたら実行する前にちゃんと確かめましょう)  
万が一動作不能に陥った場合はそのままUnityを閉じてください。  

## コードを書く上で注意すべきこと
・クラス名が被らないように、製作者のイニシャルなど入れてください。  
・TriggerFunctionInterfaceを持つように(Monobehaviourの後ろに)  
・重くなる動作を頻繁に呼ばないようにしましょう。  
(例:Instatiate, Raycast, Find)

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>

# <a id="section2" href="#section2">用意しているクラス</a>

## <a id="section2_0" href="#section2_0">EnemyController</a>

### public変数
・(float)moveSpeed...Enemyの移動速度

### publicメソッド
・(void)Move(float x, float z)...x,zのベクトルを足した方向へ一定速度で移動  
・(void)MoveRight()...X軸正の方向に一定速度で移動
・MoveLeft(),MoveUp(),MoveDown()...省略

・(void)TurnCannon(float angle)...Cannonを、Z軸正方向(↑)を0として時計回りにangle回転  
・(void)TurnCannonAdd(float angle)...今のCannonの角度から時計回りにangle回転

・(bool)RaycastCannon()...Cannonの向いてる方向にRayを発射。最初に当たったオブジェクトをRaycastHit型変数hitに代入。(返り値...当たればtrue,当たらなければfalse)  
・RaycastRight()...X軸正方向(→)にRay発射。以下略。  
・RaycastLeft(),RaycastUp(),RaycastDown()...省略  
・(RaycastHit)GetRaycastHit()...格納しているRaycastHit型変数hitを返す。

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>

## <a id="section2_1" href="#section2_1">PutObject</a>

### public変数
・設置する各オブジェクト。
・(int)putAbleLandMineNum...ステージに同時における地雷の数

### publicメソッド
・Put?Prefab()...各オブジェクトをCannonの座標・向きに設置。以下の2点のみ注意が必要

・PutRemoteBombPrefab()...ステージにまだ爆弾がある場合にこのメソッドを呼ぶとその爆弾を爆発させる  
・PutWarpPrefab()...二回呼び出して、ワープのペアがいないと、ワープはできない。

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>

## <a id="section2_2" href="#section2_2">EnemyShotManager</a>

### public変数
・(GameObject)bulletPrefab...発射する弾のprefab  
・(int)ableBulletNum...フィールドに存在できる自分の弾の最大値  
・(float)shotInterval...発射してから次発射までの最短時間  

### publicメソッド
・(void)SetShotSpeed(float magni)...発射速度をmagni倍にする  
・(bool)Shot()...Cannonから弾を発射する。発射できる場合はtrue、できない場合はfalseを返す  

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>

# <a id="section3" href="#section3">参考文献</a>

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>
