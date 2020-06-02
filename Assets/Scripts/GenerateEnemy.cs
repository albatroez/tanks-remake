using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    // public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount = 10;
    private int currentNumberOfEnemies = 0;
    //private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        
    }

    IEnumerator EnemyDrop()
    {

        GameObject theEnemy = Resources.Load("TankFree_Green") as GameObject;
        while (enemyCount < 11)
        {
            
            xPos = Random.Range(1, 20);
            zPos = Random.Range(1, 20);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            
            enemyCount += 1;
            yield return new WaitForSeconds(5f);
            
        }
    }

}
