using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Mushroom : MonoBehaviour
{
    private GameObject[] mushroomObj;
    private int xSize = 50;
    private int ySize = 50;
    private int bufferDist = 10;
    private float GridSpaceSize = 1f; //will have to change to include scaling later
    private GameObject[,] grid;
    private List<Vector3> mushroom_Dist = new List<Vector3>();
    private float maxDist; //audio cue distance for mushroom

    [SerializeField] private GameObject mushroomMonsterObj;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[xSize, ySize];
        maxDist = mushroomMonsterObj.GetComponent<AudioSource>().maxDistance + bufferDist;
        Debug.Log("mushroom audio distance: " + maxDist);
    }

    // Update is called once per frame
    void Update()
    {
        //var gos = GameObject[];
        //mushroomObj = GameObject.FindGameObjectsWithTag("Mushroom_Monster");
        //Debug.Log("Length of mushroomObj:" + mushroomObj.Length);
        checkMushroomNum();
    }

    private void checkMushroomNum()
    {
        bool isaddMushroom = true;
        mushroomObj = GameObject.FindGameObjectsWithTag("Mushroom");
        if(mushroomObj.Length < 5)
        {
            //assign x and y positions
            int x = Random.Range(1, xSize-5);
            int y = Random.Range(1, ySize-5);
            Vector3 new_pos = new Vector3(x * GridSpaceSize, 0, y * GridSpaceSize);

            //update mushroom position list
            if (mushroom_Dist.Count >= 5)
            {
                mushroom_Dist.RemoveAt(0);
            }

            //compare distance
            foreach (Vector3 pos in mushroom_Dist)
            {
                if(Vector3.Distance(pos, new_pos) < maxDist)
                {
                    isaddMushroom = false;
                }
                //else
                //{
                //    Debug.Log("Good Distance: " + Vector3.Distance(pos, new_pos));
                //}
            }

            //generate mushroom
            if (isaddMushroom)
            {
                grid[x, y] = Instantiate(mushroomMonsterObj, new_pos, Quaternion.identity);
                grid[x, y].transform.parent = transform;
                Debug.Log("new mushroom created");

                //add to the mushroom distance list
                mushroom_Dist.Add(grid[x, y].transform.position);
                Debug.Log("The list of mushroom positions" + mushroom_Dist.Count);
            }

            //Debug.Log("Distance to origin: " + Vector3.Distance(grid[x, y].transform.position, origin));

        }
    }
}
