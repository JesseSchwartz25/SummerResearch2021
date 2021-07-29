using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float sleepenergy = 0.01f;

    // Start is called before the first frame update

    public GameObject horizontalBlock;
    public GameObject verticalBlock;
    public GameObject vBlockObj;
    public GameObject hBlockObj;
    public GameObject baseBlock;
    private GameObject previousBlock;
    public GameObject grabber;
    private GameObject firstBlock;
    private List<GameObject> BlocksOnLastLevel;
    private List<GameObject> BlocksOnThisLevel;

    //these are so the blocks look differnt from each other in the tower, they are loaded in the unity inspector
    public Material[] materials;
    public Material metalMat;
    private int matcount;
    private int blockCount;
    private float alternator = 0.5f;
    private float prevnumber;

    public addMass addMassScript;
    public static bool freeRotation;
    public float sleeptimer;
    public static List<Rigidbody> RBList;
    private int towerBlocksInt;
    private int blockCountToDelete;
    private int level;

    private void Awake()
    {
        RBList = new List<Rigidbody>();
    }

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

        matcount = 0;
        blockCount = 0;
        freeRotation = false;
        sleeptimer = 0;
        towerBlocksInt = 6;
        level = 0;

        addMassScript = GameObject.Find("addMassCube").GetComponent<addMass>();

        BlocksOnThisLevel = new List<GameObject>();
        BlocksOnLastLevel = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //on pressing space, add a new block to the tower, legally


            //testing having the grabber drop all items on space being pressed. did not fix bug 7
            //grabber.transform.GetChild(1).gameObject.GetComponent<HapticGrabber>().release();

            firstBlock = null;
            blockCountToDelete = blockCount;
            blockCount = 0;
            //level = 0;
            //setting to 0 for debugging

            Debug.Log("deleting " + blockCountToDelete + " blocks");

            for (int i = 0; i < baseBlock.transform.childCount; i++)
            {
                baseBlock.transform.GetChild(i).Translate(new Vector3(1000, -1000, 1000), Space.World);
                baseBlock.transform.GetChild(i).gameObject.layer = 0;

                //this is necesarry because of bug 7 in the doc.
                //without this, there is a weird interaction with the tactile device if it is touching a block that is deleted.
                Invoke("deleteOldBlocks", 0.05f);

                BlocksOnThisLevel.Clear();


            }

            previousBlock = null;
            prevnumber = 0f;

            for (int i = 0; i <towerBlocksInt; i++)
            {
                //addNewBlock();
                Invoke("addNewBlock", 0.1f);
                //if there are issues
                level++;
            }

            freeRotation = false;

            //for(int i = 0; i<RBList.Count; i++)
            //{
            //    if(RBList[i] != null)
            //    {
            //        Debug.Log(RBList[i].gameObject.name + " is at index " + i);
            //    }
            //}
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            //releasing the restrictions so that the tower can fall
            //sleeptimer is so that the rigidbodies do not fall asleep prematurely

            releaseRestrictions();
            freeRotation = true;
            sleeptimer = 0;
        }


        //keep the RB's awake for the first few seconds of their lives
        if (freeRotation && sleeptimer < 2)
        {
            previousBlock.GetComponent<Rigidbody>().WakeUp();
            firstBlock.GetComponent<Rigidbody>().WakeUp();
            sleeptimer += Time.deltaTime;
        }


    }

    //the blocks are deleted here because if they are deleted on the same frame that they are moved then there is a weird interaction with the tactile device
    //because of the way that invoke works, this needs to be its own function.
    //now works with the increased number of blocks in complex towers that have different numbers of blocks
    void deleteOldBlocks()
    {
        //for (int i = 0; i < blockCountToDelete; i++)
        //{    
        //    Destroy(baseBlock.transform.GetChild(i).gameObject);
        //}

        for(int i = 0; i < baseBlock.transform.childCount; i++)
        {
            if(baseBlock.transform.GetChild(i).gameObject.layer == 0)
            {
                Destroy(baseBlock.transform.GetChild(i).gameObject);
            }
        }
    }

    void releaseRestrictions()
    {
        for (int i = 0; i < baseBlock.transform.childCount; i++)
        {
            baseBlock.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }




    float[] generateRandomPos()
    {

        //setting up the X and Z directions for normalized randomness
        //use random numbers squared as the percentage to hang of the edge

        float randX = Random.value;
        float randZ = Random.value;

        float randxNorm = Random.value;
        float randzNorm = Random.value;

        //squaring to help normalize the distribution. COME BACK TO THIS IF THINGS DONT WORK OUT AS INTENDED!!!!

        randX *= Random.value;
        randZ *= Random.value;
        //changed this from squared to another random value to make more interesting distribution

        //randomizes if it moves in the + or - direction

        if (randxNorm >= 0.5f)
        {
            randxNorm = 1;
        }
        else
        {
            randxNorm = -1;
        }


        if (randzNorm >= 0.5f)
        {
            randzNorm = 1;
        }
        else
        {
            randzNorm = -1;
        }


        randX *= randxNorm;
        randZ *= randzNorm;

        float[] randpos = new float[2];
        randpos[0] = randX;
        randpos[1] = randZ;


        //definitely not the most efficient, but it gets the job done in O(1) so not something I'm worried about atm.

        return randpos;
    }

    //this script is meant to add a new block to the legal tower.
    void addNewBlock() 
    {


        //[7/26] need to add ability to spawn multiple blocks on the same level



        int blocksOnLevel = (int) (Random.value * 4) + 1;
        //Debug.Log(blocksOnLevel + " random integer calculated");


        BlocksOnLastLevel.Clear();


        foreach (var x in BlocksOnThisLevel)
        {
            BlocksOnLastLevel.Add(x);
            x.tag = "LastLevel";
        }

        BlocksOnThisLevel.Clear();
       // Debug.Log(BlocksOnLastLevel.Count);

        //testing with 3 instead of BlocksOnLevel to see if the towers build as they should. change back to blocksOnLevel when it works
        for (int i = 0; i < 3; i++)
        {
            //determine if the block will be vertical or horizontal

            float randint = Random.value;
            GameObject toBuild = horizontalBlock;
            if (randint >= alternator)
            {
                //this creates a new clone of the blocks which is not linked to the block that they are based off of in the scene
                //they are clones, but not connected like if we just did toBuild = verticalBlock
                //this caused some issues, mostly with material changes but it had the capability to cause unforeseen problems in the future so I dealt with it!
                toBuild = Instantiate(verticalBlock);
                Destroy(toBuild);
                alternator *= 1.4f;


            }
            else
            {
                toBuild = Instantiate(horizontalBlock);
                Destroy(toBuild);
                alternator /= 1.4f;
            }
            //  Debug.Log("pressed space, instantiating " + toBuild.name + " with material " + materials[matcount].name);
            toBuild.name = "Level" +  level + "_Block" + BlocksOnThisLevel.Count;
            blockCount++;

            //this transform and the other below are needed to capture the scale of the tower block because they are stored in the children rather than the logic objects which are the parents
            Transform toBuildChild = toBuild.transform.GetChild(0);



            //materials so that we can see the different blocks more easily
            Material prevMat = toBuild.GetComponentInChildren<Renderer>().material;

            toBuild.GetComponentInChildren<Renderer>().material = materials[matcount];
            matcount++;

            if (matcount >= materials.Length)
                matcount = 0;


            float[] randpos = generateRandomPos();

            

            bool rotated = false;
            //allowing for rotations of 90 degrees of the blocks, randomly
            if (Random.value >= 0.5f)
            {
                //trying rotation. if this doesnt work, the code below is more generalized and does work.
                toBuild.transform.Rotate(new Vector3(0, 90, 0));
                rotated = true;
                //swapping x and z scales to imitate a 90 degree shift while not having to alter the rest of the code to deal with rotations
                //toBuildChild.transform.localScale = new Vector3(toBuildChild.localScale.z, toBuildChild.localScale.y, toBuildChild.localScale.x);
            }



            if (BlocksOnLastLevel.Count > 0)
            {
                previousBlock = BlocksOnLastLevel[(int)(Random.value * BlocksOnLastLevel.Count)];
                //Debug.Log("Previous block is " + previousBlock.name);
            }








            /*
             * 
             * This is where we build the blocks. 
             * 
             * 
             */

            //instantiating the blocks into the world
            //if this is the first block, it can go anywhere
            if (BlocksOnLastLevel.Count == 0)//(previousBlock == null)
            {
                //this will collect allof the things that the new block will hit
                Collider[] colliders = Physics.OverlapBox(baseBlock.transform.position + new Vector3(randpos[0] / 2, baseBlock.transform.localScale.y * 0.5f + toBuildChild.lossyScale.y * 0.5f, randpos[1] / 2), toBuildChild.lossyScale / 2, toBuild.transform.rotation, 3); //layer mask of 3 for "block"

                foreach (var x in colliders)
                {
                    if (x.gameObject.transform.parent != null)
                    {
                        Debug.Log(toBuild.name + " is going to collide with " + x.gameObject.transform.parent.gameObject.name);

                    }
                }


                int iters = 0;

                while(colliders.Length != 0)
                {
                    randpos = generateRandomPos();
                    colliders = Physics.OverlapBox(baseBlock.transform.position + new Vector3(randpos[0] / 2, baseBlock.transform.localScale.y * 0.5f + toBuildChild.lossyScale.y * 0.5f, randpos[1] / 2), toBuildChild.lossyScale / 2, toBuild.transform.rotation, 3);
                    Debug.Log("looped " + iters);
                    iters++;
                    if (iters > 5)
                        break;
                }
                if(iters == 5)
                {
                    continue;
                }


                previousBlock = Instantiate(toBuild, baseBlock.transform.position + new Vector3(randpos[0]/2, baseBlock.transform.localScale.y * 0.5f + toBuildChild.localScale.y * 0.5f, randpos[1]/2), toBuild.transform.rotation);
                firstBlock = previousBlock;
                // Debug.Log("Spawning first block at " + previousBlock.transform.position.y);
            }
            else
            {
                Transform prevBlockChild = previousBlock.transform.GetChild(0);

                //equivocate to the scale of the blocks. added the 0.5 for more normalization to make less extreme towers
                //old version to the right, but I think the new version works pretty well.
                randpos[0] *= 0.8f * prevBlockChild.localScale.x * toBuildChild.localScale.x;//0.75f * toBuildChild.localScale.x * toBuildChild.localScale.x * toBuildChild.localScale.z;
                randpos[1] *= 0.8f * prevBlockChild.localScale.z * toBuildChild.localScale.z;//0.75f * toBuildChild.localScale.z * toBuildChild.localScale.x * toBuildChild.localScale.z;


                //need the scale to be correct because we are rotating, not altering scale.
                if (rotated)
                {
                    float temp = randpos[0];
                    randpos[0] = randpos[1];
                    randpos[1] = temp;
                }

                Collider[] colliders = Physics.OverlapBox(previousBlock.transform.position + new Vector3(randpos[0], toBuildChild.localScale.y * 0.5f + prevBlockChild.transform.localScale.y * 0.5f, randpos[1]), toBuild.transform.lossyScale / 2, toBuild.transform.rotation, 3);

                foreach (var x in colliders)
                {
                    if (x.gameObject.transform.parent != null)
                    {
                        Debug.Log(toBuild.name + " is going to collide with " + x.gameObject.transform.parent.gameObject.name);

                    }
                }


                int iters = 0;

                while (colliders.Length != 0)
                {
                    randpos = generateRandomPos();
                    randpos[0] *= 0.8f * prevBlockChild.localScale.x * toBuildChild.localScale.x;//0.75f * toBuildChild.localScale.x * toBuildChild.localScale.x * toBuildChild.localScale.z;
                    randpos[1] *= 0.8f * prevBlockChild.localScale.z * toBuildChild.localScale.z;//0.75f * toBuildChild.localScale.z * toBuildChild.localScale.x * toBuildChild.localScale.z;
                    colliders = Physics.OverlapBox(previousBlock.transform.position + new Vector3(randpos[0], toBuildChild.localScale.y * 0.5f + prevBlockChild.transform.localScale.y * 0.5f, randpos[1]), toBuild.transform.lossyScale / 2, toBuild.transform.rotation, 3);
                    Debug.Log("looped " + iters);
                    iters++;
                    if (iters > 5)
                        break;
                }
                if (iters == 5)
                {
                    continue;
                }

                prevnumber = toBuildChild.localScale.y * 0.5f + prevBlockChild.transform.localScale.y * 0.5f;
                previousBlock = Instantiate(toBuild, previousBlock.transform.position + new Vector3(randpos[0], toBuildChild.localScale.y * 0.5f + prevBlockChild.transform.localScale.y * 0.5f, randpos[1]), toBuild.transform.rotation);



                // Debug.Log("spawning block with difference: " + prevnumber + "  " + toBuildChild.localScale.y);

            }











            previousBlock.transform.SetParent(baseBlock.transform);

            //lowering the threshold for blocks to fall asleep. tower should not pause too prematurely anymore.
            //it still does pause, but almost always the towers are stable so it doesnt feel wrong.
            previousBlock.GetComponent<Rigidbody>().sleepThreshold = sleepenergy;

            //activate the Blockscript
            previousBlock.GetComponent<BlockScript>().enabled = true;

            previousBlock.tag = "CurrentBlock";


            //allowing for different masses of the blocks. Doing this after everything else becuase it otherwise doesnt affect anything in the chain of events besides the mass and it only happens sometimes if the button is pressed.

            if (addMassScript.getMassStatus() == 0)
            {
                //allow for new masses
                if (Random.value >= 0.8f)
                {
                    previousBlock.GetComponentInChildren<Renderer>().material = metalMat;
                    previousBlock.GetComponent<Rigidbody>().mass = 2.5f;
                }
            }



            //checking colliders for overlap. That is very bad and causes a lot of issues with the towers


            //returns an array of every collider that the spawnwed box is touching/inside of
            //Collider[] colliders = Physics.OverlapBox(previousBlock.transform.position, previousBlock.transform.GetChild(0).localScale / 2, previousBlock.transform.rotation);
            
            //I dont think there is a path forward with this. it has to be done when it is being spawned in otherwise there is just too much math for me


            //if (colliders != null)
            //{
            //    foreach(var x in colliders)
            //    {
            //        if (x.gameObject.transform.parent != null)
            //        {

            //            //we dont care if it's touching itself, that will happen for every block
            //            if (!x.gameObject.transform.parent.CompareTag("CurrentBlock") && !x.gameObject.transform.parent.CompareTag("Touchable"))
            //            {
                            
            //                //this means that it is overlapping with a tower block, which is a problem. we need to address this
            //                Vector3 closestpointonbounds = x.ClosestPointOnBounds(previousBlock.transform.position);
            //                Vector3 closestpoint = x.ClosestPoint(previousBlock.transform.position);

            //                Debug.Log(previousBlock.name + " is overlapping " + x.gameObject.transform.parent.name + " by " + (previousBlock.transform.position - closestpoint));

            //                //Rigidbody rb = previousBlock.GetComponent<Rigidbody>();
            //                //Debug.Log(x.bounds + "-" + x.gameObject.transform.parent.transform.position);

            //                //choose to move the block which is already the highest
            //                GameObject blockToMove = previousBlock;

            //                if(x.gameObject.transform.parent.transform.position.y > previousBlock.transform.position.y)
            //                {
            //                    blockToMove = x.gameObject.transform.parent.gameObject;
            //                }


            //               // blockToMove.transform.Translate((previousBlock.transform.position - closestpoint) / 2);

            //            }




            //        }
            //        else
            //        {
            //            //Debug.Log(previousBlock.name + " is overlapping " + x.gameObject.name);

            //            //this means that it is only overlapping with the base/plane, which should not be a problem for our blocks in the tower
            //        }

            //    }   

            //    //previousBlock.transform.Translate(new Vector3(movex, 0, movez));
            //    //Destroy(previousBlock);
            //}

            previousBlock.tag = "CurrentLevel";
            previousBlock.layer = 3;

            //adding the block to the list for the level
            BlocksOnThisLevel.Add(previousBlock);

        }








    }



}
