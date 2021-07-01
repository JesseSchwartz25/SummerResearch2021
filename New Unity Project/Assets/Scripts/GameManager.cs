using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject horizontalBlock;
    public GameObject verticalBlock;
    public GameObject vBlockObj;
    public GameObject hBlockObj;
    public GameObject baseBlock;
    private List<GameObject> blocks;
    private int blocksIndex;
    private GameObject previousBlock;
    public GameObject grabber;




    void Start()
    {

        //this is to get the sizes of the cubes, generalized in case the sizes change. these will be used later on to make sure that cubes are placed "legally" in the tower building process

        hBlockObj = GameObject.Find("HorizontalBlock");
        float hoZ = hBlockObj.transform.localScale.z;
        float hoY = hBlockObj.transform.localScale.y;
        float hoX = hBlockObj.transform.localScale.x;
        Debug.Log(hoZ);


        vBlockObj = GameObject.Find("VerticalBlock");
        float veX = vBlockObj.transform.localScale.x;
        float veY = vBlockObj.transform.localScale.y;
        float veZ = vBlockObj.transform.localScale.z;


        blocksIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //on pressing space, add a new block to the tower, legally
            addNewBlock();
        }
    }

    //this script is meant to add a new block to the legal tower.
    void addNewBlock() 
    {

        //determine if the block will be vertical or horizontal
        float randint = Random.value;
        GameObject toBuild = horizontalBlock;
        if(randint >= 0.5f)
        {
            toBuild = verticalBlock;
        }
        Debug.Log("pressed space, instantiating " + toBuild.name);


        //if this is the first block, it can go anywhere
        if(previousBlock == null)
        {
            previousBlock = Instantiate(toBuild, baseBlock.transform.position + new Vector3(0, 0.15f, 0), toBuild.transform.rotation);
        }
        else
        {
            previousBlock = Instantiate(toBuild, previousBlock.transform.position + new Vector3(0, toBuild.transform.localScale.y*.5f, 0), toBuild.transform.rotation);
        }

    }

}
