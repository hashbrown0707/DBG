using UnityEngine;

namespace CardSystem
{
    public interface ICard
    {
        GameObject gameObject { get; }
        void OnUse(Character target);
        void OnHover();
        void OnHoverExit();
    }

    public enum CardType
    {
        OneTarget,
        AllTarget
    }
}
