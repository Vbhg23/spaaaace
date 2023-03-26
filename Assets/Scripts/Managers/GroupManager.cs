using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public GameObject firstOriginalGroup;
    public PassiveEnemyGroup CreateEmptyGroup() 
    {
        GameObject newGroup = Instantiate (firstOriginalGroup);
        PassiveEnemyGroup group = newGroup.GetComponent<PassiveEnemyGroup>();
        return group;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}