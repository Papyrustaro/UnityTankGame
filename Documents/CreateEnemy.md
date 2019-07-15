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
- [その他よく使うpublic変数](#section3)
    - [はじめに](#section3_0)
    - [UseSkill](#section3_1)
    - [DestroyByAttack](#section3_2)
    - [DestroyTimeAgo](#section3_3)
    - [RemoteController](#section3_4)
- [参考文献](#section4)
- [その他お知らせ](#section5)
    - [Enemyのメソッド](#section5_0)

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
・設置する各オブジェクト
・(int)putAbleLandMineNum...ステージに同時における地雷の数

### publicメソッド
・PutBatteryPrefab()...固定砲台設置  
・PutProtectDomePrefab()...防御ドーム設置  
・PutRemoteBombPrefab()...遠隔操作できる爆弾設置。爆弾がある場合にこの関数を呼ぶと、爆発させる関数に。  
・PutBombermanPrefab()...ボ〇バーマンのような爆弾設置  
・PutLaserPrefab()...レーザー発射するもの設置  
・PutWarpPrefab()...ワープの片方を設置。2つで1ペア  
・PutSwitchGatePrefab()...スイッチ付きゲート設置  
・PutLandMinePrefab()...地雷設置  

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

# <a id="section3" href="#section3">その他よく使うpublic変数</a>

## <a id="section3_0" href="#section3_0">はじめに</a>
public変数はインスペクタ上からいつでも値を書き換えることができます。  
自分の気に入る値にして、prefabとして新しく保存しましょう。  
UseSkillはデバックでお世話になるかもですね（笑）

## <a id="section3_1" href="#section3_1">UseSkill</a>
・(float)SkillInterval1,2...Skill1,2それぞれのスキルの再発動可能までの時間(s)  
・(int)SkillNum1,2...発動するスキル番号  
    0.移動速度アップ  
    1.弾の速度アップ  
    2.特殊弾発射  
    3.固定砲台設置  
    4.防御ドーム設置  
    5.リモートボム設置or爆発  
    6.ボ〇バーマン設置  
    7.レーザー設置  
    8.ワープ設置  
    9.スイッチゲート設置  

## <a id="section3_2" href="#section3_2">DestroyByAttack</a>
・(int)HP...消えるまでに必要な弾の個数。被弾すると1減る。  

## <a id="section3_3" href="#section3_3">DestroyTimeAgo</a>
・(int)DestroyTime...消えるまでにかかる秒数。  

## <a id="section3_4" href="#section3_4">RemoteController</a>
・(float)ForcePower...遠隔操作でかける力の大きさ。

# <a id="section4" href="#section4">参考文献</a>
<a href="https://codegenius.org/open/courses/24/sections/104">Code Genius(Unityの基礎)</a>

<a href="https://qiita.com/papyrustaro/items/904702e0c16c3d72df6b">Unityでよく使う実装方法まとめ</a>

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>

# <a id="section5" href="#section5">その他おしらせ</a>

## <a id="section5_0" href="#section5_0">Enemyのメソッド</a>
EnemyAI用のクラスに絶対に用意する衝突判定のメソッドについて軽く説明  

・BodyEnter...BodyのColliderに他のColliderが衝突した瞬間に呼ばれるメソッド  
・BodyExit...(省略)が触れていたものが離れた瞬間に呼ばれるメソッド  
・BodyStay...(省略)が触れ続けている間呼ばれ続けるメソッド(頻繁に呼ばれるため注意が必要)  
・NearEnter...EnemyのCannonにあるSphereColliderが衝突判定。これに衝突した瞬間に呼ばれるメソッド  
・NearExit...上に同じ  
・NearStay...上に同じ  

<p class="ec__link-index"><a href="#index">[↑ 目次へ]</a></p>
