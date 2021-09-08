using System;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    void Execute(Character source, Character target, int value);
}

public enum EffectType
{
    Damage,
    Block
}

public static class EffectDictionary
{
    public static readonly Damage Damage = new Damage();
    public static readonly Block Block = new Block();

    public static readonly Dictionary<EffectType, IEffect> EffectDict = new Dictionary<EffectType, IEffect>()
    {
        { EffectType.Damage, Damage },
        { EffectType.Block, Block }
    };
}

[Serializable]
public class Damage : IEffect
{
    public void Execute(Character source, Character target, int value)
    {
        //之後傷害來源buff會有公式微調value ex.力量buff     
        //todo: FormulaController

        target.TakeDamage(value);
    }
}

[Serializable]
public class Block : IEffect
{
    public void Execute(Character source, Character target, int value)
    {
        int blockResult = target.block + value;   //一樣之後要有 FormulaController
        target.SetBlock(blockResult);
    }
}
