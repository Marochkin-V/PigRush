using UnityEngine;

public class PigBirdPoolsChecker : MonoBehaviour
{

    [SerializeField] private GameObject pigPool;
    [SerializeField] private GameObject birdPool;

    [SerializeField] private LevelEndHandler levelEndHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pigPool = GameObject.Find("PigPool");
        birdPool = GameObject.Find("BirdPool");

        levelEndHandler = GetComponent<LevelEndHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pigPool != null)
        {
            if (birdPool != null)
            {
                if (pigPool.transform.childCount == 0)
                {
                    levelEndHandler.LevelCompleted();
                }
                else if (birdPool.transform.childCount == 0)
                {
                    levelEndHandler.LevelFailed();
                }
            }
            else
            {
                Debug.Log("Bird Pool is missing on scene! Please, add BirdPool game object and move all birds in it");
            }
        }
        else
        {
            Debug.Log("Pig Pool is missing on scene! Please, add PigPool game object and move all pigs in it");
        }
    }
}
