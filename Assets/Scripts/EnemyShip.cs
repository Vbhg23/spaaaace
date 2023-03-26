using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int health = 50;
    public GameObject enemyBulledOriginal;
    public GameObject hpCatOriginal;
    public Animator spriteAnimator;
    private System.Random generatorRandoma = new System.Random();
    private AudioSource dedmosIsDead;
    public AudioClip sdohnut993;
    public void Start() {
        dedmosIsDead = GetComponent<AudioSource>();
    }
    public void ShootMePlease() {
        GameObject newBulled = Instantiate(enemyBulledOriginal);
        newBulled.transform.position = transform.position;
    }
    public void DestroyEnemy() {
        transform.parent = null;
        spriteAnimator.SetBool("DeimosIsDead", true);
        dedmosIsDead.PlayOneShot(sdohnut993);
    }

    public void OnAnimationOfDeathEnd() {
        double meetTheRandomIngeener = generatorRandoma.NextDouble();
        if (meetTheRandomIngeener > 0.25) {
            GameObject newHP = Instantiate (hpCatOriginal);
        newHP.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}