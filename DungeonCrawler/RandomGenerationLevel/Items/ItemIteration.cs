using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIteration : MonoBehaviour
{
    public static ItemIteration instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadIteration(ref int iteration, int listCount)
    {
        if (ItemGeneratorController.instance.procentage && !ItemGeneratorController.instance.basicProcentage && !ItemGeneratorController.instance.basicNumber)
        {
            iteration = (int)listCount * ItemGeneratorController.instance.procentageAllAmount / 100;
        }
        else if (ItemGeneratorController.instance.number && !ItemGeneratorController.instance.basicProcentage && !ItemGeneratorController.instance.basicNumber)
        {
            iteration = NumberRandomIteration(ItemGeneratorController.instance.numberAllAmount, listCount);
            if (iteration > listCount) iteration = listCount;
        }
    }

    public void LoadBasicIteration(ref int[] iteration, int listCount)
    {
        if (ItemGeneratorController.instance.procentage && ItemGeneratorController.instance.basicProcentage)
        {
            int count = (int)listCount * ItemGeneratorController.instance.procentageAllAmount / 100;

            iteration[0] = (int)count * ItemGeneratorController.instance.procentageAllWeapon / 100;
            iteration[1] = (int)count * ItemGeneratorController.instance.procentageAllPotions / 100;
            iteration[2] = (int)count * ItemGeneratorController.instance.procentageAllCraftThingItems / 100;

            CheckIteration(ref iteration, count);
        }
        else if (ItemGeneratorController.instance.number && ItemGeneratorController.instance.basicProcentage)
        {
            int count = NumberRandomIteration(ItemGeneratorController.instance.numberAllAmount,listCount);

            iteration[0] = (int)count * ItemGeneratorController.instance.procentageAllWeapon / 100;
            iteration[1] = (int)count * ItemGeneratorController.instance.procentageAllPotions / 100;
            iteration[2] = (int)count * ItemGeneratorController.instance.procentageAllCraftThingItems / 100;

            CheckIteration(ref iteration, count);
        }

        else if (ItemGeneratorController.instance.procentage && ItemGeneratorController.instance.basicNumber)
        {
            int count = ItemGeneratorController.instance.procentageAllAmount;

            iteration[0] = NumberRandomIteration(ItemGeneratorController.instance.numberAllWeapon,count);
            iteration[1] = NumberRandomIteration(ItemGeneratorController.instance.numberAllPotions,count);
            iteration[2] = NumberRandomIteration(ItemGeneratorController.instance.numberAllCraftThing,count);

            CheckIteration(ref iteration, count);
        }

        else if (ItemGeneratorController.instance.number && ItemGeneratorController.instance.basicNumber)
        {
            int count = NumberRandomIteration(ItemGeneratorController.instance.numberAllAmount,listCount);

            iteration[0] = NumberRandomIteration(ItemGeneratorController.instance.numberAllWeapon, count);
            iteration[1] = NumberRandomIteration(ItemGeneratorController.instance.numberAllPotions, count);
            iteration[2] = NumberRandomIteration(ItemGeneratorController.instance.numberAllCraftThing, count);

            CheckIteration(ref iteration, count);
        }
    }

    public void LoadAdvenceIteration(ref int[] basicIteration,ref int[] advanceIteration, int listCount)
    {
        if (ItemGeneratorController.instance.advancedProcantage && (ItemGeneratorController.instance.basicProcentage||ItemGeneratorController.instance.basicNumber))
        { 
            LoadBasicIteration(ref basicIteration, listCount);

            int count = basicIteration[0];

            advanceIteration[0] = count * ItemGeneratorController.instance.procentageSwords / 100;
            advanceIteration[1] = count * ItemGeneratorController.instance.procentageAxes / 100;
            advanceIteration[2] = count * ItemGeneratorController.instance.procentageShields / 100;
            advanceIteration[3] = count * ItemGeneratorController.instance.procentageBowls / 100;

            count = basicIteration[1];
            advanceIteration[4] = count * ItemGeneratorController.instance.procentageLivePotions / 100;
            advanceIteration[5] = count * ItemGeneratorController.instance.procentageManaPotions / 100;

            count = basicIteration[2];
            advanceIteration[6] = count * ItemGeneratorController.instance.procentageOres / 100;

            CheckIteration(ref advanceIteration, count);
        }
        else if(ItemGeneratorController.instance.advanceNumber && (ItemGeneratorController.instance.basicProcentage || ItemGeneratorController.instance.basicNumber))
        {
            LoadBasicIteration(ref basicIteration, listCount);

            int count = basicIteration[0];

            advanceIteration[0] = NumberRandomIteration(ItemGeneratorController.instance.numberSwords, count);
            advanceIteration[1] = NumberRandomIteration(ItemGeneratorController.instance.numberAxes, count);
            advanceIteration[2] = NumberRandomIteration(ItemGeneratorController.instance.numberShields,count);
            advanceIteration[3] = NumberRandomIteration(ItemGeneratorController.instance.numberBowls,count);

            count = basicIteration[1];
            advanceIteration[4] = NumberRandomIteration(ItemGeneratorController.instance.numberLivePotions,count);
            advanceIteration[5] = NumberRandomIteration(ItemGeneratorController.instance.numberManaPotions,count);

            count = basicIteration[2];
            advanceIteration[6] = NumberRandomIteration(ItemGeneratorController.instance.numberOres,count);

            CheckIteration(ref advanceIteration, count);
        }
        else if (!(ItemGeneratorController.instance.basicProcentage || ItemGeneratorController.instance.basicNumber) && ItemGeneratorController.instance.advancedProcantage)
        {
            int count = 0;
            LoadIteration(ref count, listCount);

            advanceIteration[0] = count * ItemGeneratorController.instance.procentageSwords / 100;
            advanceIteration[1] = count * ItemGeneratorController.instance.procentageAxes / 100;
            advanceIteration[2] = count * ItemGeneratorController.instance.procentageShields / 100;
            advanceIteration[3] = count * ItemGeneratorController.instance.procentageBowls / 100;

            advanceIteration[4] = count * ItemGeneratorController.instance.procentageLivePotions / 100;
            advanceIteration[5] = count * ItemGeneratorController.instance.procentageManaPotions / 100;

            advanceIteration[6] = count * ItemGeneratorController.instance.procentageOres / 100;

            CheckIteration(ref advanceIteration, count);
        }
        else if (!(ItemGeneratorController.instance.basicProcentage || ItemGeneratorController.instance.basicNumber) && ItemGeneratorController.instance.advanceNumber)
        {
            int count = 0;
            LoadIteration(ref count, listCount);

            advanceIteration[0] = NumberRandomIteration(ItemGeneratorController.instance.numberSwords, count);
            advanceIteration[1] = NumberRandomIteration(ItemGeneratorController.instance.numberAxes, count);
            advanceIteration[2] = NumberRandomIteration(ItemGeneratorController.instance.numberShields, count);
            advanceIteration[3] = NumberRandomIteration(ItemGeneratorController.instance.numberBowls, count);

            advanceIteration[4] = NumberRandomIteration(ItemGeneratorController.instance.numberLivePotions, count);
            advanceIteration[5] = NumberRandomIteration(ItemGeneratorController.instance.numberManaPotions, count);

            advanceIteration[6] = NumberRandomIteration(ItemGeneratorController.instance.numberOres, count);

            CheckIteration(ref advanceIteration, count);
        }
    }


    int NumberRandomIteration(Vector3Int rand, int count)
    {
        int iteration = 0;
        if(rand.x>0)
        {
            iteration = rand.x;
            if (iteration > count) iteration = count;
            return iteration;
        }
        else if(rand.y>=0 && rand.z>=0)
        {
            int min = 0;
            int max = 0;

            if (rand.y <= rand.z)
            {
                min = rand.y;
                max = rand.z;
            }
            else if (rand.y >= rand.z)
            {
                min = rand.z;
                max = rand.y;
            }
            iteration = Random.Range(min, max);
            if (iteration > count) iteration = count;
            return iteration;
        }

        Debug.Log("Iteration Items Error");
        return ((int)(count*0.5f));
    }
    void CheckIteration(ref int[] iteration, int count)
    {
        int sum = 0;
        foreach (int i in iteration)
        {
            sum = sum + i;
        }

        if (count > sum)
        {
            for (int i = iteration.Length - 1; i >= 0; i--)
            {
                if (count == sum)
                    break;
                else if ((iteration[i] - 1) > 0)
                {
                    iteration[i]--;
                    sum--;
                }
                if (i == 0) i = iteration.Length;
            }
        }
        else if(count < sum)
        {
            for (int i = 0; i >= iteration.Length; i++)
            {
                if (count == sum)
                    break;
                else if ((iteration[i]+1)<count)
                {
                    iteration[i]++;
                    sum++;
                }
                if (i == iteration.Length-1) i = -1;
            }
        }
    }
}
