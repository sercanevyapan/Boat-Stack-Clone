using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [HideInInspector]
    public int levelCount, randomLevel, randomValue;

    public List<GameObject> prefabLevels;

    private GameObject firstLevel; //İlk oluşturulan prefab 
    [HideInInspector]

    void Start()
    {

        firstLevel = Instantiate(prefabLevels[0]);

    }

    public void RestartGame() //Gamemanager'da restart butonu ile bu metod çalışır.
    {

        for (int i = 0; i < prefabLevels.Count; i++)
        {

            if (levelCount == i )
            {

                DestroyPrefab();
                CreatePrefab();

            }
            if (levelCount >= prefabLevels.Count)
            {

                CreatePrefabRandomRestart();

            }
        }
    }

    public void NextLevel() //Update fonksiyonu içinde çalışıyor Gamemanager nextlevel
                            //butonu ile isCreated false gelince method çalışıyor.
    {
        for (int i = 1; i < prefabLevels.Count; i++)
        {

            if (levelCount == i && levelCount < prefabLevels.Count + 1)
            {

                DestroyPrefab();

                CreatePrefab();

            }

        }
        if (levelCount >= prefabLevels.Count)
        {
   
            CreatePrefabRandom();

        }

    }

    private void CreatePrefab()
    {
        Instantiate(prefabLevels[levelCount]);
     
    }

    private void DestroyPrefab()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
       
    }

    private void CreatePrefabRandom()
    {
        DestroyPrefab();

        Instantiate(prefabLevels[randomLevel]);
        randomValue = randomLevel; //Random'ın referansını CreatePrefabRandomRestart'a yolluyoruz.
    
    }


    private void CreatePrefabRandomRestart()
    {
        DestroyPrefab();


        Instantiate(prefabLevels[randomValue]);
       
    }

}

