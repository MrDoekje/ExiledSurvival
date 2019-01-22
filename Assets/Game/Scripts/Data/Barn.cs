using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    public playerData playerData;

    private Tier tier;
    //Game object

    public int[] addResource(Resources resource)
    {
        int[] newNumbers = new int[] { 0, 0, 0 };
        int counter = 0;
        foreach (Resources.Material material in resource.materials)
        {

            newNumbers[counter] = playerData.getResources.updateResource(material.getNumbers[0], material.name, "amount");
            counter++;
        }
        return newNumbers;
            
    }

    public int increaseMaxStoreAmount(Resources playerResources)
    {
        if (playerResources.getResourceInfo("gold")[0] - tier.info[0] >= 0)
        {
            tier.upgrade();
            return tier.info[0];
        }
        else return 0;
    }

    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Canvas").GetComponent<playerData>();
    }

    public int increaseMaxStoreBy => tier.getTierInfo()[1] * 100;
}