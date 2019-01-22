using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseUiBuilder : MonoBehaviour
{
    public House houseToUpdate;
    public Button addCitizen;

    public Transform citizen;

    public Text familyName;
    public Button workerOne;
    public Button workerTwo;
    public Button workerThree;
    public Button workerFour;
    public Button workerFive;
    public Button workerSix;
    public Button workerSeven;
    public Button workerEight;
    /*public Button workerNine;
    public Button workerTen;*/
    public List<Button> workers;
    private bool toShow;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        workers = new List<Button>() { workerOne, workerTwo, workerThree, workerFour, workerFive, workerSix, workerSeven, workerEight };
        toShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        showPanel();
        if (toShow)
        {
            foreach (Button button in workers)
            {
                button.gameObject.SetActive(false);
                button.onClick.RemoveAllListeners();
            }

            familyName.text = houseToUpdate.getFamilyName;
            for (int i = 0; i < houseToUpdate.getCitizens.Count; i++)
            {
                workers[i].gameObject.SetActive(true);
                workers[i].GetComponentInChildren<Text>().text = houseToUpdate.getCitizens[i].ToString();
                workers[i].onClick.AddListener(() => viewCitizen(houseToUpdate.getCitizens[i]));
            }
        }
    }

    public void addCitizenToHouse()
    {
        Instantiate(citizen);

        houseToUpdate.addCitizen(1, 1);
    }

    public void showPanel()
    {
        if (toShow)
            panel.gameObject.SetActive(true);
        else
            panel.gameObject.SetActive(false);
    }

    void viewCitizen(Citizen worker)
    {

    }

    public House newHomeToDisplay
    {
        set
        {
            toShow = !(toShow);
            Debug.Log(toShow);
            houseToUpdate = value;
        }
    }
}
