
using UnityEngine;
using UnityEngine.UI;
public class UiUpdater : MonoBehaviour
{
    // Start is called before the first frame update

    public Text goldText;
    public Text woodText;
    public Text stoneText;
    public string[] toChangeTo;

    public string[] changeToChangeTo
    {
        set
        {
            toChangeTo = value;
        }
    }
    public void updateText()
    {
        goldText.text = toChangeTo[0];
        woodText.text = toChangeTo[1];
        stoneText.text = toChangeTo[2];
    }

    void Start()
    {
        toChangeTo = new string[] { "0", "0", "0" };
    }


}
