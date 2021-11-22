using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TransitionDoor : MonoBehaviour
{
    [SerializeField] private Vector3 closedPos;
    [SerializeField] private Vector3 openPos;
    [SerializeField] private GameObject clearCongrats;
    [SerializeField] private GameObject createdFoodTMPGO;
    private GameObject potInfoSide;
    
    void Start()
    {
        transform.position = openPos;
        clearCongrats.SetActive(false);
        potInfoSide = GameObject.Find("PotInfoSide");
    }

    public void SetCreatedFoodText (string dishName, int recipePoints)
    {
        var createdFoodTMP = createdFoodTMPGO.GetComponent<TextMeshProUGUI>();
        createdFoodTMP.SetText($"Created {dishName}!\n\n +{recipePoints} points");
    }

    public IEnumerator TransitionToCreatedFood()
    {
        Debug.Log("hit!");
        createdFoodTMPGO.SetActive(true);
        yield return StartCoroutine(LerpPosition(closedPos, 0.5f));
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SetPlayingMinigame(true);
        while (!Input.GetKeyDown("space")) {
            yield return null;
        }
        player.SetPlayingMinigame(false);
        yield return StartCoroutine(LerpPosition(openPos, 0.5f));
        createdFoodTMPGO.SetActive(false);
        Debug.Log("done!");
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
