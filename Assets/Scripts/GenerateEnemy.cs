using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    // public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount = 0;
    private int currentNumberOfEnemies = 0;
    public AudioSource audioSource;
    //private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(EnemyDrop());
        

    }

    IEnumerator EnemyDrop()
    {

        GameObject theEnemy = Resources.Load("TankFree_Green") as GameObject;
        yield return new WaitForSeconds(2f);

        while (enemyCount < 11)
        {
            audioSource.Play();
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 50);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            
            enemyCount += 1;
            yield return new WaitForSeconds(2f);
            
        }
    }

}
