using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerData : MonoBehaviour
{
    private List<Citizen> workers;
    private Resources resources;
    private int level;
    public UiUpdater uiUpdater;

    public playerData(int startingWorkers, int startingLevel, int[] stoneInfo, int[] woodInfo, int[] goldInfo)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        workers = new List<Citizen>();
        //for (int i = 0; i < startingWorkers; i++)
        //addWorker(1,0,new int[] { 0, 0 });

        resources = new Resources(new int[] { 10, 100, 0 }, new int[] { 10, 100, 0 }, new int[] { 10, 100, 0 });
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        uiUpdater.changeToChangeTo = new string[] { resources.getResourceInfo("gold")[0].ToString(), resources.getResourceInfo("wood")[0].ToString(), resources.getResourceInfo("stone")[0].ToString() };
        uiUpdater.updateText();
        //check all the workers
    }

    public void addResourceGeneration(int changeAmount, string kind, string command)
    {
        resources.updateResource(changeAmount, kind, command);
    }

    /*public void addWorker(int workSpeed, int level, int[] startPosition)
    {
        workers.Add(new Citizen(getNewName(), workSpeed, level, ));
    }

    public void newWorker(string lastName, int workSpeed, int level, int[] startPosition)
    {
        workers.Add(new Citizen(getNewName(), workSpeed, level, startPosition));
    }*/

    public string getNewName()
    {
        string[] femaleFirstNames = new string[] { "a", "b" };
        string[] maleFirstNames = new string[] { "a", "b" };
        string[] lastNames = new string[] { "a", "b" };
        return (Random.value > 0.5) ? femaleFirstNames[new System.Random().Next(0, femaleFirstNames.Length)] : maleFirstNames[new System.Random().Next(0, femaleFirstNames.Length)] + " " + lastNames;
    }

    public Resources getResources => resources;
    //get amount of kind resource
    public int getResourceAmount(string kind) => resources.getResourceInfo(kind)[0];
}
