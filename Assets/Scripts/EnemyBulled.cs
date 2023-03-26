using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBulled : MonoBehaviour
{
    private float speed = 0.5f;
    public int damage = 25;
    void FixedUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.y -= speed;
        transform.position = objectPosition;
        if(ScreenHelper.IsPositionOnScreen(transform.position) == false){
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
