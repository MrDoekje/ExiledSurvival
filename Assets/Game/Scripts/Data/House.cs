using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    private List<Citizen> citzens;
    private Tier tier;
    
    private string familyName;

    //Game object



    void Start()
    {
        tier = new Tier();
        familyName = getNewLastName();
        citzens = new List<Citizen>();
    }

    public string getFamilyName => familyName;

    public List<Citizen> getCitizens => citzens;

    void OnMouseDown()
    {
        Debug.Log(this);
        GameObject.Find("HouseUI").gameObject.GetComponent<HouseUiBuilder>().newHomeToDisplay = this;
    }



    public void addCitizen(int workSpeed, int level)
    {
        Debug.Log(citzens.Count);
        if (citzens.Count < tier.getTierInfo()[1])
            citzens.Add(new Citizen(getNewFirstName(), workSpeed, level, this));
    }

    public void addCitizen(Citizen citizen)
    {
            citzens.Add(citizen);
            
    }

    public int increaseMaxCitizens(Resources playerResources)
    {
        if (playerResources.getResourceInfo("gold")[0] - tier.info[0] >= 0)
        {
            tier.upgrade();
            return tier.info[0];
        }
        else return 0;
    }

    public string getNewLastName()
    {
        string[] lastNames = new string[] { "Heuvel", "Visser", "Van Den" };
        return lastNames[new System.Random().Next(0, lastNames.Length)];
    }

    public string getNewFirstName()
    {

        string[] femaleFirstNames = new string[] { "a", "b" };
        string[] maleFirstNames = new string[] { "a", "b" };
        return (Random.value > 0.5) ? femaleFirstNames[new System.Random().Next(0, femaleFirstNames.Length)] : maleFirstNames[new System.Random().Next(0, femaleFirstNames.Length)];
    }
}
