using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Citizen : MonoBehaviour
{

    public string workerName;
    private int workSpeed;
    private Resources resource;
    private int level;
    //private int[] position;
    private Job job;
    private int movementSpeed;
    private int speed;
    private int woodCuttingXp;
    private bool isWorking;
    private float timePassed;
    public Renderer rend;
    public Rigidbody rb;
    public House home;
    private Job oldJob;

    Resource collisionInfoWork;
    Barn collisionInfoBarn;


    public Citizen(string name, int workSpeed, int level, House home)
    {
        workerName = name;
        this.workSpeed = workSpeed;
        this.level = level;
        //this.position = position;
        this.home = home;
        job = new Job("woodcutter");
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject == GameObject.FindGameObjectWithTag("House"))
        {
            if (job.getJobTitle == "idle")
            {
                //newJob("woodcutter", new int[] { 0, 0 });
                rend.enabled = false;
            }
        }
        else if (collisionInfo.gameObject == GameObject.FindGameObjectWithTag("Wood"))
        {
            if (job.getJobTitle == "woodcutter")
            {
                Debug.Log("hit a tree");
                isWorking = true;
                collisionInfoWork = collisionInfo.gameObject.GetComponent<Resource>();
                timePassed = 0;
            }
        }
        else if (collisionInfo.gameObject == GameObject.FindGameObjectWithTag("Barn"))
        {
            if (job.getJobTitle == "store")
            {
                Debug.Log("hit a barn");
                isWorking = true;
                collisionInfoBarn = collisionInfo.gameObject.GetComponent<Barn>();
                timePassed = 0;
            }
        }
    }

    public void work()
    {
        if (isWorking)
        {
            if (job.getJobTitle == "woodcutter")
            {
                if (timePassed >= collisionInfoWork.getJobTime(workSpeed))
                {
                    timePassed = 0;

                    int[] results = collisionInfoWork.gameObject.GetComponent<Resource>().interact();
                    if (results[0] - results[1] <= 0)
                    {
                        isWorking = false;
                        Destroy(collisionInfoWork.gameObject);
                    }
                    woodCuttingXp += results[1];
                    resource.updateResource(results[0], "wood", "amount");
                    Debug.Log(resource.getResourceInfo("wood")[0] + ":" + resource.getResourceInfo("wood")[1]);
                    if (resource.getResourceInfo("wood")[0] == resource.getResourceInfo("wood")[1])
                    {
                        newJob("store");
                        Debug.Log("Inventory full");
                    }
                }
            }

            else if (job.getJobTitle == "store")
            {
                if (timePassed >= 5)
                {
                    timePassed = 0;
                    int[] results = collisionInfoBarn.gameObject.GetComponent<Barn>().addResource(resource);
                    resource.updateResource(results);
                    newJob(oldJob.getJobTitle);

                }
            }
        }
        else if (job.getJobTitle == "woodcutter")
        {
            try
            {
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Wood").transform.position, speed * Time.deltaTime);

            }
            catch
            {
                newJob("store");
                oldJob = new Job("idle");
            }
        }
        else if (job.getJobTitle == "store")
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Barn").transform.position, speed * Time.deltaTime);

        else if (job.getJobTitle == "idle")
            foreach(GameObject gameobject in GameObject.FindGameObjectsWithTag("House"))
                if(gameobject.gameObject.GetComponent<House>() == home)
                    transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("House").transform.position, speed * Time.deltaTime);
    }

    public void newJob(string title)
    {
        isWorking = false;
        oldJob = job;
        Debug.Log(oldJob.getJobTitle);
        job = new Job(title);
        Debug.Log(oldJob.getJobTitle);
    }

    void Start()
    {
        //rb.AddForce(0, -3000 * Time.deltaTime, 0);
        job = new Job("woodcutter");
        workSpeed = 2;
        resource = new Resources(new int[] { 0, 5, 0 }, new int[] { 0, 5, 0 }, new int[] { 0, 100, 0 });
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        isWorking = false;
        speed = 10;
        timePassed = 0;
        woodCuttingXp = 0;
        home.addCitizen(this);
    }

        // Update is called once per frame
    void Update()
    {
        timePassed = timePassed + Time.deltaTime;
        work();
    }
    public override string ToString()
    {
        return workerName;
    }

}

