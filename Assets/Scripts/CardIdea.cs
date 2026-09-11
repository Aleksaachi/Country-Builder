using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Scriptable Objects/Card/Idea")]
public class CardIdea : CardBase
{
    public CardPool pool;

    public override bool Use()
    {
        CardRewardScreen.OpenRewardScreen(pool);
        return true;
    }
}
