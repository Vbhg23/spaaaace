using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemyGroup : MonoBehaviour
{
    public EnemyShip ship1;
    public EnemyShip ship2;
    public EnemyShip ship3;
    public EnemyShip ship4;
    public EnemyShip ship5;
    public EnemyShip ship6;
    public EnemyShip ship7;
    public EnemyShip ship8;
    public EnemyShip ship9;
    public bool alive = true;
    private float speed = 0.1f;
    private List<EnemyShip> ships = new List<EnemyShip>();
    private bool IsMovingLeft = true;
    private System.Random generatorChegoto = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);
        ships.Add(ship4);
        ships.Add(ship5);
        ships.Add(ship6);
        ships.Add(ship7);
        ships.Add(ship8);
        ships.Add(ship9);
        InvokeRepeating("FireInHole", 1.0f, 0.7f);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        ships.RemoveAll(item => item == null);
        ships.RemoveAll(item => item.health <= 0);
        if (ships.Count == 0) {
            alive = false;
            CancelInvoke();
            return;
        }
        if (IsMovingLeft == true) {
            float minX = MinX();
            float stepX = minX - speed;
            if(stepX < -12){
                IsMovingLeft = false;
            } else {
                transform.position = new Vector3(
                    transform.position.x - speed, 
                    transform.position.y, 
                    0
                );
            }
        } else if (IsMovingLeft == false) {
            float maxX = MaxX();
            float stepX = maxX + speed;
            if(stepX > 12){
                IsMovingLeft = true;
            } else {
                transform.position = new Vector3(
                    transform.position.x + speed, 
                    transform.position.y, 
                    0
                );
            }
        }
    }

    float MaxX() {
        int i = 0;
        float max = float.MinValue;
        while(i < ships.Count) {  
            if(ships[i].transform.position.x > max) {
                max = ships[i].transform.position.x;
            }
            i++;

        }
        return max;
    }
    float MinX() {
        int i = 0;
        float min = float.MaxValue;
        while(i < ships.Count){

            if(ships[i].transform.position.x < min) {
                min = ships[i].transform.position.x;
            }
            i++;

        }
        return min;
    }

    void FireInHole() {
        int randomIndex = generatorChegoto.Next(ships.Count);
        ships[randomIndex].ShootMePlease();
    }
}