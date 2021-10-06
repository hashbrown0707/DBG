using System.Collections;
using UnityEngine;
public class PassiveData
{
    public Sprite[] Icon;
    public int id=0;
    public int Rank=0;
    public int needTriggerCount=0;
    public int TriggeredCount=0; //需觸發總數
    public string Description= "Default_Description";
    public PassiveEvent TriggerType = PassiveEvent.DefaultType;
    public int Plus_Shield=0;//增加護頓(基於卡牌)
    public int Plus_Damage=0; //增加傷害(基於卡牌)
    public int Heal_HP=0; //回血
    public int AllTarget_Damag=0; //全範圍傷害
    public bool canCollection { get; set; }
}
    