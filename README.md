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

## Description(3)

In addition of (2), followers(green) follows the Player.
Green follower controlled by feedback controller with rigidbody2d.AddForce().
Because the speed of blue followers(2) are just two status: zero or same as palyer.
This is impossible in the real world because it requires infinite force.
If we control the followers with AddForce(), the behavior will be same as real world.

Following two parameters are avaiable, and we can adjust the control power.
 - controlGainP: Gain for position. Proportional Gain.
 - controlGainD: Gain for velocity. Derivative Gain.

Because we do not have Integral Gain, the past errors will not be zero.

See also
[Wikipedia: PID Controller](http://en.wikipedia.org/wiki/PID_controller)

(2)に加えて、自機のfollowers(緑の球)があります。
followerは自機から一定の距離を保ちつつ、自機を追跡するのは(2)と同じですが、今度は rigidbody2d.AddForce() によりフィードバック制御します。
(2)のときは、followersの速度がゼロか自機と同じという２つの状態しかありませんので、動作がロボット的になります。
厳密には、現実世界ではありえない動作です。これを実現するには無限のフォースが必要になるためです。
AddForce() でフィードバック制御すれば、現実世界と同様の動作をさせることが可能です。

制御性能の調整はインスペクターウィンドウで次の二つのパラメータを調整します。
 - controlGainP: 位置に対するゲイン。比例(P)ゲイン。
 - controlGainD: 速度に対するゲイン。微分(D)ゲイン。

積分(I)ゲインがないため、残留偏差が残る制御系になっています。

(参考)
[Wikipedia: PID制御](http://ja.wikipedia.org/wiki/PID%E5%88%B6%E5%BE%A1)

## Demo(3)

![alt tag](https://github.com/mizoe/Unity_Chase2D/blob/master/Unity_Chase2D_control.gif)
## Licence

GPLv3

## Author

溝江 智徳[mizoe](https://github.com/mizoe)
