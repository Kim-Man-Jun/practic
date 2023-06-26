using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTest : MonoBehaviour
{
    public class Car
    {
        public string name;
        public int year;

        public void PrintCarName()
        {
            Debug.Log(name);
        }
        public void PrintCarYear()
        {
            Debug.Log(year);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Car myCar = new Car();

        myCar.name = "BMW";
        myCar.year = 2020;

        myCar.PrintCarName();
        myCar.PrintCarYear();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
