using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public List<GameObject> FloorPrefabs;

    public GameObject CoinPrefab;

    public GameObject GemPrefab;

    private int _allItemCount;

    private int _mapSize;

    private int _coinChance;

    private int _gemChance;

    void Start()
    {
        _mapSize = ProjectManager<GameInfoDto>.LoadFromFile().MapSize;

        _coinChance = ProjectManager<GameInfoDto>.LoadFromFile().CoinChance;

        _gemChance = ProjectManager<GameInfoDto>.LoadFromFile().GemChance;

        CreatePlatform();

        _allItemCount =  CreateItems(_gemChance, GemPrefab) + CreateItems(_coinChance, CoinPrefab);

        Debug.Log("Создано обьектов:" + _allItemCount);

        GameManager.instance.AllItemCount = _allItemCount;
    }

    void CreatePlatform()
    {
        Vector3 platformPosition = new Vector3(0, -1, 0);

        for (int i = 0; i < _mapSize; i++)
        {
            for (int j = 0; j < _mapSize; j++)
            {
                int randomPlatform = Random.Range(0, FloorPrefabs.Count);

                Instantiate(FloorPrefabs[randomPlatform], platformPosition, Quaternion.identity);

                platformPosition = platformPosition + new Vector3(1, 0, 0);
            }
            platformPosition = platformPosition + new Vector3(0, 0, 1);

            platformPosition.x = 0;
        }
    }

    /// <summary>
    /// Создает в случайных местах предметы.
    /// </summary>
    /// <param name="chanсe">Шанс создания обьекта = 1/chance.</param>
    /// <param name="prefab">Шаблон создаваемого обьекта.</param>
    /// <returns>Кол-во созданных обьектов.</returns>
    int CreateItems(int chanсe, GameObject prefab)
    {
        int itemCount = 0;
        
        while (itemCount == 0)
        {
            Vector3 itemPosition = new Vector3(0, -0.5f, 0);

            for (int i = 0; i < _mapSize; i++)
            {
                for (int j = 0; j < _mapSize; j++)
                {
                    if (Physics.OverlapSphere(itemPosition, -0.01f).Length == 0)
                    {
                        if (Random.Range(0, chanсe) == 0)
                        {
                            itemCount++;

                            Instantiate(prefab, itemPosition, Quaternion.identity);
                        }
                    }
                    else
                    {
                        Debug.Log("cantCreate = " + Physics.OverlapSphere(itemPosition, -0.01f)[0]);
                    }
                    itemPosition = itemPosition + new Vector3(1, 0, 0);
                }
                itemPosition = itemPosition + new Vector3(0, 0, 1);

                itemPosition.x = 0;
            }
        }
        return itemCount;
    }
}
