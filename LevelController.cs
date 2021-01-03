using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monster[] monsters;
    Friend[] friends;
    private void OnEnable()
    {
        monsters = FindObjectsOfType<Monster>();
        friends = FindObjectsOfType<Friend>();
    }

    private void Update()
    {
        if (MonsterAllDie())
        {
            GoToNextlevel();
        }
        if (FriendAllDie())
        {
            gameover();
        }
    }
    bool MonsterAllDie()
    {
        foreach (var item in monsters)
        {
            if (item.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
    bool FriendAllDie()
    {
        foreach (var item in friends)
        {
            if (item.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
    void GoToNextlevel()
    {
        StartCoroutine(GoToNextlevel3());
    }

    void gameover()
    {
        StartCoroutine(gameover2());
    }

    IEnumerator GoToNextlevel3()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator gameover2()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("lose");
    }
}
