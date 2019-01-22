using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Resource : MonoBehaviour
{
    //private int[] position;
    private int objectLevel;
    private int[] resourceInfo;


    public Resource(int[] resourceInfo, int[] position)
    {
        resourceInfo = new int[] { resourceInfo[0], resourceInfo[1], resourceInfo[2] };//resourceLeft, resourcePerHarvest, workPerHarvest
        //position = new int[] {position[0], position[1]};
    }

    //public int[] getPosition => position;

    public float getJobTime(int workspeed) => (float)resourceInfo[2] / workspeed; 

    public int[] interact()
    {
        if (resourceInfo[0] - resourceInfo[1] >= 0) {
            resourceInfo[0] -= resourceInfo[1];
            return new int[] {resourceInfo[1], resourceInfo[2] };
        }
        else
        {
            return new int[] { resourceInfo[0], resourceInfo[2] };
        }

    }

    // Start is called before the first frame update   
    void Start()
    {
        //democode for testing
        resourceInfo = new int[] { 1, 1, 2 };//resourceLeft, resourcePerHarvest, workPerHarvest
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
