using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [HideInInspector]
    public int levelCount = 0;

    public List<GameObject> prefabLevels;

    private GameObject firstLevel; //İlk oluşturulan prefab 
    [HideInInspector]
    public bool isCreated; //Prefab oluşturuluk oluşturulmadığı bilgisi

    public int randomLevel; //Randomlevel oluşturmak

    int randomValue; //Restart için random verisini tutuyoruz.

    void Start()
    {

        firstLevel = Instantiate(prefabLevels[0]);

    }

    void Update()
    {
        NextLevel();

    }

    public void RestartGame() //Gamamanacerda restart butanu ile bu metad çalışır.
    {

        for (int i = 0; i < prefabLevels.Count; i++)
        {

            if (levelCount == i && !isCreated)
            {

                DestroyPrefab();
                CreatePrefab();

            }
            if (!isCreated && levelCount >= prefabLevels.Count)
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

            if (levelCount == i && !isCreated && levelCount < prefabLevels.Count + 1)
            {

                DestroyPrefab();

                CreatePrefab();

            }

        }
        if (!isCreated && levelCount >= prefabLevels.Count)
        {

            CreatePrefabRandom();

        }

    }

    private void CreatePrefab()
    {
        Instantiate(prefabLevels[levelCount]);
        isCreated = true;
    }

    private void DestroyPrefab()
    {
        var clone = GameObject.FindGameObjectWithTag("Clone");
        Destroy(clone);
    }

    private void CreatePrefabRandom()
    {
        DestroyPrefab();

        Instantiate(prefabLevels[randomLevel]);
        randomValue = randomLevel; //Random'ın referansını CreatePrefabRandomRestart'a yolluyoruz.
        isCreated = true;
    }


    private void CreatePrefabRandomRestart()
    {
        DestroyPrefab();


        Instantiate(prefabLevels[randomValue]);
        isCreated = true;
    }

}

