using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier
    {
        private int Tiernumber;

        public int[] info => new int[] { Tiernumber, getTierInfo()[0], getTierInfo()[1] };

        public void upgrade()
        {
            Tiernumber++;
        }

        void OnMouseOver()
        {

        }

        public int[] getTierInfo()
        {
            switch (Tiernumber)
            {
                case 1: return new int[] { 1000, 5 };
                case 2: return new int[] { 5000, 15 };
                case 3: return new int[] { 9999999, 20 };
                default: return new int[] { 9999999, 5 };
            }
        }
    }

