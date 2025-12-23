using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Event/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public UnityAction<player> onBasicBarRaise;
    
    public void onRaise(player Player)
    {
        onBasicBarRaise?.Invoke(Player);
    }

}
