using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RoundState
{

    //大地圖移動
    //進戰鬥

    //準備階段(ComobatPrepare)  例：遺物被動 要不要換牌
    //準備階段結束 例：自動護頓  

    //玩家動作階段
    //玩家結束 (保留卡牌)

    //怪物動作階段
    //怪物動作結束

    //回合結束前 ??敵人預告下一次大招的台詞?()
    //回合結束

    //Loop
    None = 0,
    RoundPrepare = 1,
    RoundEnter = 2,
    PlayerAction = 3,
    EnemeyAction = 4,
    RoundEnd = 5

}

public class CombatManager
{

    public int Round { get; set; } = 0;
    public int currentRoundState = 0;
    public List<PassiveItem> itemPassives = new List<PassiveItem>();



    // Start is called before the first frame update
    void RoundPrepare()
    {

        currentRoundState=1;
        //檢查被動
        //數值加成
        //發牌

    }

    void RoundStart()
    {

    }

    void PlayerAction()
    {

    }

    void EnemeyAction() { }

    void RoundEnd() { }

    public void ChangeState()
    {
        if( currentRoundState==( int ) RoundState.RoundEnd )
            Round+=1;
    }

    public int CurrentState()
    {
        return currentRoundState;
    }

}
