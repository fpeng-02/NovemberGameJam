using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionDoor : MonoBehaviour
{
    [SerializeField] private Vector3 closedPos;
    [SerializeField] private Vector3 openPos;
    [SerializeField] private GameObject clearCongrats;
    private GameObject potInfoSide;
    
    void Start()
    {
        transform.position = openPos;
        //clearCongrats = transform.GetChild(0).gameObject;
        clearCongrats.SetActive(false);
        potInfoSide = GameObject.Find("PotInfoSide");
    }

    public IEnumerator TransitionThenLoadScene(string sceneName)
    {
        yield return StartCoroutine(LerpPosition(closedPos, 0.5f));
        potInfoSide.SetActive(false);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone) yield return null;
        yield return StartCoroutine(LerpPosition(openPos, 0.5f));
    }

    public void unloadProxy(string sceneName)
    {
        StartCoroutine(TransitionThenUnloadScene(sceneName));
    }

    public IEnumerator TransitionThenUnloadScene(string sceneName)
    {
        clearCongrats.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(LerpPosition(closedPos, 0.5f));
        clearCongrats.SetActive(false);
        potInfoSide.SetActive(true);
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        while (!asyncUnload.isDone) { yield return null; }
        yield return StartCoroutine(LerpPosition(openPos, 0.5f));
        Player.playingMinigame = false;
    }

    public IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;

        while (time < duration) {
            Vector2 t = Vector2.Lerp(transform.position, targetPosition, time / duration);
            transform.position = new Vector3(t.x, t.y, -9);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
