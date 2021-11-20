using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // not too sure if this is the best practice, but there's only one player anyway and the player should be the only thing "interacting"
    public abstract void OnInteract(Player player);   
}
