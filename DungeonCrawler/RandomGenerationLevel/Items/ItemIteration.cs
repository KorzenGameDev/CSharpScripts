using UnityEngine;

public class ItemIteration : MonoBehaviour
{
    public static ItemIteration instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadBasicIteration(ref int iteration, int listCount)
    {
        if (ItemGeneratorController.instance.basicProcentage && !ItemGeneratorController.instance.advanceProcentage && !ItemGeneratorController.instance.advanceNumber)
        {
            iteration = (int)listCount * ItemGeneratorController.instance.procentageAllAmount / 100;
        }
        else if (ItemGeneratorController.instance.basicNumber && !ItemGeneratorController.instance.advanceProcentage && !ItemGeneratorController.instance.advanceNumber)
        {
            iteration = NumberRandomIteration(ItemGeneratorController.instance.numberAllAmount, listCount);
            if (iteration > listCount) iteration = listCount;
        }
    }

    public void LoadAdvanceIteration(ref int[] iteration, int listCount)
    {
        if (ItemGeneratorController.instance.basicProcentage && ItemGeneratorController.instance.advanceProcentage)
        {
            int count = (int)listCount * ItemGeneratorController.instance.procentageAllAmount / 100;

            iteration[0] = (int)count * ItemGeneratorController.instance.procentageAllWeapon / 100;
            iteration[1] = (int)count * ItemGeneratorController.instance.procentageAllPotions / 100;
            iteration[2] = (int)count * ItemGeneratorController.instance.procentageAllCraftThingItems / 100;

            CheckIteration(ref iteration, count);
        }
        else if (ItemGeneratorController.instance.basicNumber && ItemGeneratorController.instance.advanceProcentage)
        {
            int count = NumberRandomIteration(ItemGeneratorController.instance.numberAllAmount,listCount);

            iteration[0] = (int)count * ItemGeneratorController.instance.procentageAllWeapon / 100;
            iteration[1] = (int)count * ItemGeneratorController.instance.procentageAllPotions / 100;
            iteration[2] = (int)count * ItemGeneratorController.instance.procentageAllCraftThingItems / 100;

            CheckIteration(ref iteration, count);
        }

        else if (ItemGeneratorController.instance.basicProcentage && ItemGeneratorController.instance.advanceNumber)
        {
            int count = ItemGeneratorController.instance.procentageAllAmount;

            iteration[0] = NumberRandomIteration(ItemGeneratorController.instance.numberAllWeapon,count);
            iteration[1] = NumberRandomIteration(ItemGeneratorController.instance.numberAllPotions,count);
            iteration[2] = NumberRandomIteration(ItemGeneratorController.instance.numberAllCraftThing,count);

            CheckIteration(ref iteration, count);
        }

        else if (ItemGeneratorController.instance.basicNumber && ItemGeneratorController.instance.advanceNumber)
        {
            int count = NumberRandomIteration(ItemGeneratorController.instance.numberAllAmount,listCount);

            iteration[0] = NumberRandomIteration(ItemGeneratorController.instance.numberAllWeapon, count);
            iteration[1] = NumberRandomIteration(ItemGeneratorController.instance.numberAllPotions, count);
            iteration[2] = NumberRandomIteration(ItemGeneratorController.instance.numberAllCraftThing, count);

            CheckIteration(ref iteration, count);
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
