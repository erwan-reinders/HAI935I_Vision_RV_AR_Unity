using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomBob : MonoBehaviour
{
    public GameObject prefab;
    public float minX = 0;
    public float maxX = 0;
    public float minZ = 0;
    public float maxZ = 0;

    public static int nbObjects = 1;

    void Start()
    {

        float y = 1;

        for (int i = 0; i < nbObjects; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
            Instantiate(prefab, randomPos, Quaternion.identity);
        }
    }
    void Update(){
        
    }


    
}