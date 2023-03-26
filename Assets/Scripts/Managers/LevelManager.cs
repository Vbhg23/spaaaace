using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GroupManager groupManager;
    private PassiveEnemyGroup currentGroup;
    private int maxGroupUnit = 3;
    private int destroyedShipGroups = 0;
    private int destroyedGroups = 0;
    private AudioSource musyaka;
    public void Start()
    {
        destroyedGroups = 0;
        groupManager = GetComponent<GroupManager>();
        currentGroup = groupManager.CreateEmptyGroup();
        musyaka = GetComponent<AudioSource>();
        musyaka.Play();
    }

    public void Update()
    {
        if (currentGroup.alive == false) {
            Destroy(currentGroup);
            destroyedGroups +=1;
            if (destroyedGroups == maxGroupUnit) {
                SceneManager.LoadSceneAsync(SceneID.winSceneID);
            } else {
                currentGroup = groupManager.CreateEmptyGroup();
            }
        }
    }
}