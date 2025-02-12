using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPoolChecker : MonoBehaviour
{

    private List<GameObject> birds = new List<GameObject>();

    [SerializeField] private int birdIndex = 0;

    private LevelEndHandler levelEndHandler;

    private bool isActive = true;

    private void Start()
    {
        levelEndHandler = GameObject.Find("GameManager").GetComponent<LevelEndHandler>();

        foreach (Transform child in transform)
        {
            birds.Add(child.gameObject);
        }

        isActive = true;
    }

    void Update()
    {
        if (isActive)
        {
            if (birdIndex < birds.Count)
            {
                if (birds[birdIndex].TryGetComponent<BirdStates>(out BirdStates bs))
                {
                    if (!bs.isReady)
                    {
                        StartCoroutine(DelayedBirdReadyUp(bs));
                    }
                    else if (bs.isLaunched)
                    {
                        birdIndex++;
                    }
                }
            }
            else
            {
                if (birds[birdIndex - 1].TryGetComponent<BirdStates>(out BirdStates bs))
                {
                    if (bs.isCrashed)
                    {
                        Invoke("CheckResults", 5f);
                        isActive = false;
                    }
                }
                else if (birds.Count == 0)
                {
                    Invoke("CheckResults", 5f);
                    isActive = false;
                }
            }
        }
    }

    private void CheckResults()
    {
        levelEndHandler.CheckResults();
    }

    IEnumerator DelayedBirdReadyUp(BirdStates bs)
    {
        yield return new WaitForSeconds(1f);
        bs.isReady = true;
    }
}
