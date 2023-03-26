using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpaceShip : MonoBehaviour
{
    private static float MAX_HP = 125;
    private float speed = 0.2f;
    private float health = MAX_HP;
    private int hitCount = 0;
    public GameObject Original;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;
    private List<GameObject> hpList = new List<GameObject>();
    private AudioSource zvuk;
    public AudioClip vistrelnut;
    void Start() {
        hpList.Add(hp1);
        hpList.Add(hp2);
        hpList.Add(hp3);
        hpList.Add(hp4);
        hpList.Add(hp5);
        zvuk = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D otherColider) {
        GameObject otherObject = otherColider.gameObject;
        EnemyBulled bulledScript = otherObject.GetComponent<EnemyBulled>();
        if (bulledScript != null) {
            health = health - bulledScript.damage;
            onHit();
            Destroy(otherObject);
            if (health <= 0) {
                 SceneManager.LoadSceneAsync(SceneID.deathSceneID);
                Destroy(gameObject);
            }
        }
        HPBonus bonusScript = otherObject.GetComponent<HPBonus>();
        if (bonusScript != null) {
            Destroy(otherObject);
            AddHP();
        }
    }
    void AddHP() {
        print("You get a HPCat! You take a HPCat in your pocket");
        health = MAX_HP;
        hitCount = 0;
        foreach(GameObject currentItem in hpList){
            currentItem.SetActive(true);
        }
    }
    void onHit() {
        hpList[hitCount].SetActive(false);
        hitCount += 1;
    }
    // Update is called once per frame
    void Update()
    {
        bool keyUp = Input.GetKeyUp(KeyCode.UpArrow);
        if (keyUp)
        {
            GameObject BulledClone;
            BulledClone = Instantiate(Original);
            BulledClone.transform.position = transform.position;
            zvuk.PlayOneShot(vistrelnut);
        }
    }

    void FixedUpdate() {
       bool keyUp = Input.GetKey(KeyCode.LeftArrow);
        if (keyUp)
        {
            Vector3 objectPosition = transform.position;
            objectPosition.x -= speed;
            transform.position = objectPosition;
        } 
        keyUp = Input.GetKey(KeyCode.RightArrow);
        if (keyUp)
        {
            Vector3 objectPosition = transform.position;
            objectPosition.x += speed;
            transform.position = objectPosition;
        }
    }
}