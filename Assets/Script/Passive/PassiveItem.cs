using UnityEngine;

public class PassiveItem :MonoBehaviour
{

    public PassiveData passive_info { get; set; }
    public PassiveItem(PassiveData data)
    {
        passive_info=data;
    }
    public SpriteRenderer Passive_Icon = null;


    private void OnEnable()
    {
        Passive_Icon.sprite=passive_info.Icon[0]; //放入圖片
        PassivnMachine.passiveList+=OnPassive;
    }

    private void OnDisable()
    {
        PassivnMachine.passiveList-=OnPassive; //解除監視
    }



    public void OnPassive(PassiveEvent eventType)
    {  //遺物被觸發處理方法

        if( passive_info.TriggerType!=eventType ) //廣播的的Type 不關我的事 忽略 
            return;

        if( passive_info.needTriggerCount==passive_info.TriggeredCount )
        {
            //TODO
            //玩家護頓

            //Debug.Log(string.Format("Player Add <Color=blue>Sheild {0}
            //</Color>",Data));
            ResetTriggerCount();
        }
        else
        {
            var m_log = string.Format("遺物=>{0} 觸動次數+1",this.GetType().Name);
            Debug.Log(m_log);
            passive_info.needTriggerCount+=1;
        }
    }
    void ResetTriggerCount()
    {
        passive_info.needTriggerCount=0;
    }

}
public enum PassiveEvent
{
    OnEnterBattlePrepare = 0,
    OnBattlePrepare = 1,
    OnExitBattlePrepare = 2,

    OnEnterPlayerAction = 3,
    OnPlayerAction = 4,
    OnExitPlayerAction = 5,

    OnEnterEnemyAction = 6,
    OnEnemyAction = 7,
    OnExitEnemyAction = 8,

    OnEnterRoundEnd = 9,
    OnExitRoundEnd = 10,

    DefaultType = -1

}