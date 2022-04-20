using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeGrid : MonoBehaviour
{
    private int xSize = 50;
    private int ySize = 50;
    private float GridSpaceSize = 1f; //will have to change to include scaling later

    private GameObject[,] grid;
    [SerializeField] private GameObject gridCellPrefab1;
    [SerializeField] private GameObject gridCellPrefab2;
    [SerializeField] private GameObject gridCellPrefab3;
    [SerializeField] private GameObject gridCellPrefab4;
    [SerializeField] private GameObject gridCellPrefab5;
    [SerializeField] private GameObject gridCellPrefab6;
    [SerializeField] private GameObject gridCellPrefab7;
    [SerializeField] private GameObject gridCellPrefab8;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[xSize, ySize];
        CreateGrid();
    }

    private void CreateGrid()
    {
        //2D grid
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                int randCount = Random.Range(1, 20);
                //float randRotate = Random.Range(0.0f, 360.0f);
                //Debug.Log("randCount: "+ randCount);
                if (randCount ==1)
                {
                    //random tree collection
                    int randPrefab = Random.Range(1, 8);
                    if (randPrefab == 1)
                    {
                        create_prefab(x, y, gridCellPrefab1);
                    }

                    else if (randPrefab == 2)
                    {
                        create_prefab(x, y, gridCellPrefab2);
                    }

                    else if (randPrefab == 3)
                    {
                        create_prefab(x, y, gridCellPrefab3);
                    }

                    else if (randPrefab == 4)
                    {
                        create_prefab(x, y, gridCellPrefab4);
                    }

                    else if (randPrefab == 5)
                    {
                        create_prefab(x, y, gridCellPrefab5);
                    }

                    else if (randPrefab == 6)
                    {
                        create_prefab(x, y, gridCellPrefab6);
                    }

                    else if (randPrefab == 7)
                    {
                        create_prefab(x, y, gridCellPrefab7);
                    }

                    else if (randPrefab == 8)
                    {
                        create_prefab(x, y, gridCellPrefab8);
                    }
                }

            }
        }
    }

    private void create_prefab(int x, int y, GameObject prefab_obj)
    {
        float randRotate = Random.Range(0.0f, 360.0f);
        grid[x, y] = Instantiate(prefab_obj, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
        grid[x, y].transform.parent = transform;
        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
        //Debug.Log("tree option 8 created");
    }

}
