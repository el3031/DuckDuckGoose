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
                int randCount = Random.Range(1, 10);
                float randRotate = Random.Range(0.0f, 360.0f);
                Debug.Log("randCount: "+ randCount);
                if (randCount ==1)
                {
                    //random tree collection
                    int randPrefab = Random.Range(1, 8);
                    if (randPrefab ==1)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab1, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        grid[x, y].transform.Rotate(0.0f, randRotate , 0.0f, Space.Self);
                        Debug.Log("tree option 1 created");
                    }
                    else if (randPrefab == 2)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab2, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
                        Debug.Log("tree option 2 created");
                    }
                    else if (randPrefab == 3)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab3, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
                        Debug.Log("tree option 3 created");
                    }
                    else if (randPrefab == 4)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab4, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
                        Debug.Log("tree option 4 created");
                    }
                    else if (randPrefab == 5)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab5, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
                        Debug.Log("tree option 5 created");
                    }
                    else if (randPrefab == 6)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab6, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
                        Debug.Log("tree option 6 created");
                    }
                    else if (randPrefab == 7)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab7, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
                        Debug.Log("tree option 7 created");
                    }
                    else if (randPrefab == 8)
                    {
                        grid[x, y] = Instantiate(gridCellPrefab8, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                        grid[x, y].transform.parent = transform;
                        grid[x, y].transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                        //grid[x, y].transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                        grid[x, y].transform.Rotate(0.0f, randRotate, 0.0f, Space.Self);
                        Debug.Log("tree option 8 created");
                    }

                    //grid[x, y].transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);


                    //grid[x, y] = Instantiate(gridCellPrefab1, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                    //Debug.Log("tree created");
                }
                //grid[x,y] = Instantiate(gridCellPrefab, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                //Instantiate(gridCellPrefab, new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize), Quaternion.identity);
                //treeGrid[x, y].transform.parent = transform;
                //Debug.Log("block created");
            }
        }
    }

}
