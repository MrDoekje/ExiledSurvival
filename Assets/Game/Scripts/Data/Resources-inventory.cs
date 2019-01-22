using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources
{
    // Start is called before the first frame update
    public List<Material> materials;

    public class Material
    {
        private int amount;
        private int maxAmount;
        private int production;
        public string name;

        public int[] getNumbers => new int[] { amount, maxAmount, production };
     
        public Material(string name, int[] info)
        {
            amount = info[0];
            maxAmount = info[1];
            production = info[2];
            this.name = name;
        }

        public int updateMaterial(int[] newNumbers)
        {
            maxAmount = newNumbers[1];
            production = newNumbers[2];
            if (newNumbers[0] <= newNumbers[1])
            {
                amount = newNumbers[0];
                return 0;
            }
            else
            {
                amount = maxAmount;
                return newNumbers[0] - newNumbers[1];
            }
                
            
            
        }
    }

    public Resources(int[] stoneInfo, int[] woodInfo, int[] goldInfo)
    {
        materials = new List<Material>() {
            new Material("stone", stoneInfo),
            new Material("wood", woodInfo),
            new Material("gold", goldInfo)
        };
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Material material in materials)
            material.updateMaterial(new int[]
            {
              material.getNumbers[0] + material.getNumbers[1],
              material.getNumbers[1],
              material.getNumbers[2]
            });
    }

    public int updateResource(int toChange, string kind, string command)
    {

        foreach (Material material in materials)
            if (material.name == kind)
                {
                    int informationToChange = 0;

                    if (command == "amount")
                        informationToChange = 0;
                    else if (command == "maxAmount")
                        informationToChange = 1;
                    else if (command == "production")
                        informationToChange = 2;
                    else
                        return toChange;
                    int[] value = material.getNumbers;
                    value[informationToChange] += toChange;
                    return material.updateMaterial(value);
                }
        return toChange;
    }
    
    public void updateResource(int[] newNumbers)
    {
        for (int i = 0; i < 3; i++)
            materials[i].updateMaterial(new int[] { newNumbers[i], materials[i].getNumbers[1], materials[i].getNumbers[2] });
    }




    public int[] getResourceInfo(string kind) {
        foreach (Material material in materials)
            if (material.name == kind)
                return material.getNumbers;
        return new int[] { 0, 0, 0 };
    }
}
