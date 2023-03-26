using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulled : MonoBehaviour
{
    private float speed = 0.5f;
    public int damage = 25;
    void FixedUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.y += speed;
        transform.position = objectPosition;
        if(ScreenHelper.IsPositionOnScreen(transform.position) == false){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherColider) {
        GameObject otherObject = otherColider.gameObject;
        EnemyShip enemyScript = otherObject.GetComponent<EnemyShip>();
        if(enemyScript != null) {
            enemyScript.health -= damage;
            Destroy(gameObject);
            if(enemyScript.health <= 0){
                enemyScript.DestroyEnemy();
            }
        }
    }

}