[Unity 2D] An enemy and followers chase the player: プレイヤーを追いかける敵 & フォロワー
====

Overview

## Description(1)

An enemy(red) chases the Player(white).
You can move the player with the cursor keys.
Enemy is instantinated from prefab.

敵（赤）が自機（白）を追いかけてきます。
自機はカーソルキーで操作できます。
敵はプレファブからインスタンス化して作成しています。

## Demo(1)

![alt tag](https://github.com/mizoe/Unity_Chase2D/blob/master/Unity_Chase2D.gif)

## Description(2)

In addition of (1), followers(blue) follows the Player.
Followers also chases the player, but the distance is limited up to fixed distance.
The speed of followers is same as player, declared as global variable "private static" in Player.cs.

(1)に加えて、自機のfollowers(青)があります。
followerは自機から一定の距離を保ちつつ、自機を追跡します。
followerの速度は自機と同じ値を使います。
自機の速度はPlayer.cs において private static でグローバル変数にしています。

## Demo(2)

![alt tag](https://github.com/mizoe/Unity_Chase2D/blob/master/Unity_Chase2D_ef.gif)

## Licence

GPLv3

## Author

[mizoe](https://github.com/mizoe)
