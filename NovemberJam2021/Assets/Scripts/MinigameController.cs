using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    public void EndMinigame(string sceneName)
    {
        TransitionDoor transitionDoor = GameObject.Find("TransitionDoor").GetComponent<TransitionDoor>();
        transitionDoor.unloadProxy(sceneName); // have to call a *function* and not start coroutine because this GO gets destroyed
    }
}
