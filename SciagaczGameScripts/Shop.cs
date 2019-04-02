using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    AddPoints addPoints;
    MultipleCost multiple;
    ButtonClicer clicer;
    AddedPointPerSec addPPS;
    int currentItem;
    public bool isNewGame=false;
    public Text[] costText=new Text[5];
    public Text[] ownText=new Text[5];
    public float[] basicCost = new float[5];
    public float[] cost = new float[5];
    public int[] own = new int[5];
    public float[] addBasicPoint = new float[5];
    public float[] addPoint = new float[5];

    private void Start()
    {
        addPoints = FindObjectOfType<AddPoints>();
        multiple = FindObjectOfType<MultipleCost>();
        clicer = FindObjectOfType<ButtonClicer>();
        addPPS = FindObjectOfType<AddedPointPerSec>();

        addBasicPoint[0] = 1f;
        addBasicPoint[1] = 10f;
        addBasicPoint[2] = 40f;
        addBasicPoint[3] = 100f;
        addBasicPoint[4] = 1000f;

        basicCost[0] = 50f;
        basicCost[1] = 1000f;
        basicCost[2] = 5000f;
        basicCost[3] = 20000f;
        basicCost[4] = 50000f;

        for (int i = 0; i < 5; i++)
        {

            if(isNewGame)
            {
                PlayerPrefs.SetFloat("citem" + i, basicCost[i]);
                PlayerPrefs.SetInt("oitem" + i, 0);
                PlayerPrefs.SetFloat("pitem" + i, addBasicPoint[i]);
                PlayerPrefs.SetFloat("point", 0);

                isNewGame = false;
            }

            cost[i] = PlayerPrefs.GetFloat("citem" + i);
            if (cost[i] <= 40) cost[i] = basicCost[i];

            own[i] = PlayerPrefs.GetInt("oitem" + i);

            addPoint[i] = PlayerPrefs.GetFloat("pitem" + i);
            if (addPoint[i] <= addBasicPoint[i] || isNewGame) addPoint[i] = addBasicPoint[i];

            costText[i].text = "Cost: " + (int)cost[i];
            ownText[i].text = "Own: " + (int)own[i];
        }

        clicer.SetAddPoints(addPoint[0]);
    }

    public void BuyItem0()
    {
        currentItem = 0;

        if(addPoints.AddPoint(0)>=cost[currentItem])
        {
            addPoints.AddPoint(-cost[currentItem]);
            cost[currentItem] = multiple.NewCost((int)cost[currentItem]);
            own[currentItem]++;
            Debug.Log("dodawanie " + cost);

            if (addPoint[currentItem] > 3)
                addPoint[currentItem]=addPoint[currentItem]*1.1f+(currentItem/10);
            else
                addPoint[currentItem]++;

            clicer.SetAddPoints(addPoint[currentItem]);

            costText[currentItem].text = "Cost: " + cost[currentItem];
            ownText[currentItem].text = "Own: "+ own[currentItem];

            PlayerPrefs.SetFloat("citem" + currentItem, cost[currentItem]);
            PlayerPrefs.SetInt("oitem" + currentItem, own[currentItem]);
            PlayerPrefs.SetFloat("pitem" + currentItem, addPoint[currentItem]);
        }

        else
        {
            Debug.Log("za mało");
        }
    }

    public void BuyItem1()
    {
        currentItem = 1;

        if (addPoints.AddPoint(0) > cost[currentItem])
        {
            addPoints.AddPoint(-cost[currentItem]);
            cost[currentItem] = multiple.NewCost((int)cost[currentItem]);
            own[currentItem]++;
            Debug.Log("dodawanie " + cost);

            addPPS.AddPointToPull(addPoint[currentItem]);
            addPoint[currentItem] = addPoint[currentItem] * 1.2f + (currentItem / 10);

            costText[currentItem].text = "Cost: " + cost[currentItem];
            ownText[currentItem].text = "Own: " + own[currentItem];

            PlayerPrefs.SetFloat("citem" + currentItem, cost[currentItem]);
            PlayerPrefs.SetInt("oitem" + currentItem, own[currentItem]);
            PlayerPrefs.SetFloat("pitem" + currentItem, addPoint[currentItem]);
        }

        else
        {
            Debug.Log("za mało");
        }
    }

    public void BuyItem2()
    {
        currentItem = 2;

        if (addPoints.AddPoint(0) > cost[currentItem])
        {
            addPoints.AddPoint(-cost[currentItem]);
            cost[currentItem] = multiple.NewCost((int)cost[currentItem]);
            own[currentItem]++;
            Debug.Log("dodawanie " + cost);

            addPPS.AddPointToPull(addPoint[currentItem]);
            addPoint[currentItem] = addPoint[currentItem] * 1.2f + (currentItem / 10);

            costText[currentItem].text = "Cost: " + cost[currentItem];
            ownText[currentItem].text = "Own: " + own[currentItem];

            PlayerPrefs.SetFloat("citem" + currentItem, cost[currentItem]);
            PlayerPrefs.SetInt("oitem" + currentItem, own[currentItem]);
            PlayerPrefs.SetFloat("pitem" + currentItem, addPoint[currentItem]);
        }

        else
        {
            Debug.Log("za mało");
        }
    }

    public void BuyItem3()
    {
        currentItem = 3;

        if (addPoints.AddPoint(0) > cost[currentItem])
        {
            addPoints.AddPoint(-cost[currentItem]);
            cost[currentItem] = multiple.NewCost((int)cost[currentItem]);
            own[currentItem]++;
            Debug.Log("dodawanie " + cost);

            addPPS.AddPointToPull(addPoint[currentItem]);
            addPoint[currentItem] = addPoint[currentItem] * 1.2f + (currentItem / 10);

            costText[currentItem].text = "Cost: " + cost[currentItem];
            ownText[currentItem].text = "Own: " + own[currentItem];

            PlayerPrefs.SetFloat("citem" + currentItem, cost[currentItem]);
            PlayerPrefs.SetInt("oitem" + currentItem, own[currentItem]);
            PlayerPrefs.SetFloat("pitem" + currentItem, addPoint[currentItem]);
        }

        else
        {
            Debug.Log("za mało");
        }
    }

    public void BuyItem4()
    {
        currentItem = 4;

        if (addPoints.AddPoint(0) > cost[currentItem])
        {
            addPoints.AddPoint(-cost[currentItem]);
            cost[currentItem] = multiple.NewCost((int)cost[currentItem]);
            own[currentItem]++;
            Debug.Log("dodawanie " + cost);

            addPPS.AddPointToPull(addPoint[currentItem]);
            addPoint[currentItem] = addPoint[currentItem] * 1.2f + (currentItem / 10);

            costText[currentItem].text = "Cost: " + cost[currentItem];
            ownText[currentItem].text = "Own: " + own[currentItem];

            PlayerPrefs.SetFloat("citem" + currentItem, cost[currentItem]);
            PlayerPrefs.SetInt("oitem" + currentItem, own[currentItem]);
            PlayerPrefs.SetFloat("pitem" + currentItem, addPoint[currentItem]);
        }

        else
        {
            Debug.Log("za mało");
        }
    }

    private void Update()
    {
        if (isNewGame)
        {
            for (int i = 0; i < 5; i++)
            {

                PlayerPrefs.SetFloat("citem" + i, basicCost[i]);
                PlayerPrefs.SetInt("oitem" + i, 0);
                PlayerPrefs.SetFloat("pitem" + i, addBasicPoint[i]);
                PlayerPrefs.SetFloat("point", 0);

                costText[currentItem].text = "Cost: " + cost[currentItem];
                ownText[currentItem].text = "Own: " + own[currentItem];

            }

            addPoints.NewGamePoints();

            isNewGame = false;
        }
    }

}
