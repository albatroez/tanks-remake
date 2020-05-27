using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    // public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        rigidbody = GetComponent<Rigidbody>();
    }

    IEnumerator EnemyDrop()
    {
       
        GameObject theEnemy = Resources.Load("TankFree_Green") as GameObject;
        while (enemyCount < 10)
        {
            xPos = Random.Range(1, 20);
            zPos = Random.Range(1, 20);
            var obj = Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            obj.GetComponent<Rigidbody>();
            enemyCount += 1;
            yield return new WaitForSeconds(5f);
            
        }
    }

}
