作成したもの

戦闘シーン(kanda/Scenes/Battle)
・主人公機のインポート
・簡単な最低限のUIの作成(HPバー、ゲームクリア、ゲームオーバー、スコア)
・ダメージ計算(ダメージはランダム、敵に当たると受ける)
・敵(ただの四角)(攻撃を当てるかぶつかると消える)
・敵を生み出す空間
・簡易な宇宙背景(アセット)
・敵がやられたときの爆発エフェクト(アセット)
・主人公機の操縦(矢印キー)(制限なし)
・通常攻撃(Enterキー)(銃弾の発射)
・勝利条件(すべての敵が消える)と敗北条件(体力が切れる)

以上(多分)

プログラム
・PlayerControl.cs(主人公機の処理をします)
・EnemyArea.cs(敵を生成する処理です)
・Enemy.cs(敵のプログラムです)
・Beam.cs(通常攻撃の処理です)
・SceneManager.cs(ゲームクリアやゲームオーバーを行います)
コメントは大体ChatGPTに書かせたので、わからなければ聞いてください。

Asset
・Vast Outer Space(背景の宇宙空間を作るように入れただけでまだ使ってないです)
・Starfield SkyBox(実際に使っている背景)
・JMO Assets(爆発処理)

今後の課題
・敵3Dモデルを入れたときの処理
・敵は一度攻撃を受けると爆発してしまうので、敵にもHP処理を与える
・UIの洗練(ゲームクリアがびがびなので)
・背景の洗練(いけるならAssets/Vast Outer Space/EXAMPLEのDEMO_SCENEぐらいやりたいなと個人的に思っております)
・攻撃のエフェクト、球のデザインの洗練(ただ球がはっしゃされるだけなので)
・操縦範囲の制限(今のままだと360°回転できてしまう)
・固有攻撃、必殺技(中身決まってないので決めましょう)
・勝利条件の変更(一体でも打ちのがすとそのまま一生終わらなくなります)
・キャラ入れるのならそれも(ダメージを食らったり、敵を倒したときに表示する)

戦闘シーンはこのくらいでしょうか？
何か気になったことあれば共有しましょう

ちなみにほかは何もやっていないので、ホーム画面やパーツ切り替えとかは・・・