using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// Pretty much everything runs through this script
    /// 
    /// 
    /// </summary>

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
    public Material transparent;
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
    public int seed;
    float yLevel;
    bool readytobuild;
    Vector3 firstposition;

    public LayerMask mask;


    //for tower positioning:
    public bool fallLeft;
    public bool fallRight;
    public bool fallForward;
    public bool fallBackward;


    //for the gizmos
    bool m_HitDetect;
    Collider m_Collider;
    RaycastHit[] m_Hits;

    //for Data collection
    public string userName = "test";


    //for handbuilt towers
    public float[,] blocksPos = new float[300,2];
    public int[,] orientation = new int[300, 2];
    bool useHandmade = true;
    public int blocksIndex = 0;



    //singleton
    public static GameManager instance;
    private void Awake()
    {
        // The Singleton pattern.
        if (instance != null && instance != this)
        {
            // Enforce that there is only one GameManager.
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }



    void Start()
    {
        try
        {
            userName = GameObject.Find("NameObject").GetComponent<NameScript>().name;
        }
        catch
        {
            //nothing
        }


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

        //setting default values
        matcount = 0;
        blockCount = 0;
        freeRotation = false;
        sleeptimer = 0;
        towerBlocksInt = 3;
        level = 0;
        yLevel = 0;
        readytobuild = true;
        seed = 0;
        fallLeft = true;

        addMassScript = GameObject.Find("addMassCube").GetComponent<addMass>();

        BlocksOnThisLevel = new List<GameObject>();
        BlocksOnLastLevel = new List<GameObject>();

        mask = LayerMask.GetMask("Blocks");


        //building the handmade arrays :\
        blocksPos = GetComponent<TowerOrientations>().blocksPos;
        orientation = GetComponent<TowerOrientations>().orientation;


    }

    /// <summary>
    /// Debug controls and physics timer stuff
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //on pressing space, add a new block to the tower, legally

            buildTower();

        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            //releasing the restrictions so that the tower can fall
            //sleeptimer is so that the rigidbodies do not fall asleep prematurely

            towerFall();
        }


        //keep the RB's awake for the first few seconds of their lives
        //blocks used to fall asleep early causing the towers to not entirely fall over. this fixes that
        if (freeRotation && sleeptimer < 4 && previousBlock != null)
        {
            previousBlock.GetComponent<Rigidbody>().WakeUp();
            //firstBlock.GetComponent<Rigidbody>().WakeUp();
            sleeptimer += Time.deltaTime;
        }


    }

    /// <summary>
    /// the blocks are deleted here because if they are deleted on the same frame that they are moved then there is a weird interaction with the tactile device
    /// because of the way that invoke works, this needs to be its own function.
    /// now works with the increased number of blocks in complex towers that have different numbers of blocks
    /// </summary>

    void deleteOldBlocks()
    {
        for (int i = 0; i < baseBlock.transform.childCount; i++)
        {
            if (baseBlock.transform.GetChild(i).gameObject.layer == 0)
            {
                Destroy(baseBlock.transform.GetChild(i).gameObject);
            }
        }

        readytobuild = true;
    }

       
    /// this is for if you want the blocks to hang naturally or be held rigid when being grabbed by the user
    /// Not used much in the experiment
    void releaseRestrictions()
    {
        for (int i = 0; i < baseBlock.transform.childCount; i++)
        {
            baseBlock.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }



    /// <summary>
    /// Used in generating random towers. Not used when a user is playing
    /// </summary>
    /// <returns>
    /// Float array of random x and z positions
    /// </returns>
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

    /// <summary>
    /// retrieves the handbuilt positions of the towers
    /// 
    /// this will have to change when we implement the new towers for the experiment
    /// </summary>
    /// <returns></returns>
    float[] handbuildPos()
    {
        float[] handpos = new float[2];
        handpos[0] = blocksPos[blocksIndex, 0];
        handpos[1] = blocksPos[blocksIndex, 1];
        return handpos;
    }


    /// <summary>
    /// This script spawns new blocks. Very Important!! 
    /// </summary>
    void addNewBlock()
    {

        int blocksOnLevel = (int)(Random.value * 4) + 1;
        

        foreach (var x in BlocksOnThisLevel)
        {
            BlocksOnLastLevel.Add(x);
            x.tag = "LastLevel";
        }

        BlocksOnThisLevel.Clear();
        // Debug.Log(BlocksOnLastLevel.Count);

        //testing with 3 instead of BlocksOnLevel to see if the towers build as they should. change back to blocksOnLevel when it works
        for (int i = 0; i < 2; i++)
        {
            //determine if the block will be vertical or horizontal

            float randint = Random.value;
            GameObject toBuild = horizontalBlock;

            if (useHandmade && orientation[blocksIndex,0] == 1)
            {
                toBuild = Instantiate(verticalBlock);
                Destroy(toBuild);
            }
            else if (randint >= alternator && !useHandmade)
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
            toBuild.name = "Level" + level + "_Block" + BlocksOnThisLevel.Count;
            blockCount++;

            //this transform and the other below are needed to capture the scale of the tower block because they are stored in the children rather than the logic objects which are the parents
            Transform toBuildChild = toBuild.transform.GetChild(0);
            

            //materials so that we can see the different blocks more easily
            Material prevMat = toBuild.GetComponentInChildren<Renderer>().material;

            toBuild.GetComponentInChildren<Renderer>().material = materials[matcount];
            matcount++;

            if (matcount >= materials.Length)
                matcount = 0;

            float[] randpos;
            if (useHandmade)
            {
                randpos = handbuildPos();
            }
            else
            {
                randpos = generateRandomPos();
            }
            

            bool rotated = false;
            //allowing for rotations of 90 degrees of the blocks
            if (useHandmade && orientation[blocksIndex,1] == 1)
            {
                toBuild.transform.Rotate(new Vector3(0, 90, 0));
                rotated = true;
            }
            //random if not using handmade towers
            else if (Random.value >= 0.5f && !useHandmade)
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
            if (previousBlock == null)
            {
                previousBlock = Instantiate(toBuild, baseBlock.transform.position + new Vector3(0, baseBlock.transform.localScale.y * 0.5f + toBuildChild.localScale.y * 0.5f, 0), toBuild.transform.rotation);
                firstposition = previousBlock.transform.position;
                //Debug.Log("Spawning first block at " + previousBlock.transform.position.y);
            }
            else
            {
                

                //testing totally random values rather than based on a previous block:

                if (!useHandmade)
                {
                    randpos[0] = Random.Range(-0.5f, 0.5f) * Random.Range(0.1f, 1f);
                    randpos[1] = Random.Range(-0.5f, 0.5f) * Random.Range(0.1f, 1f);
                    //blocks are spawning randomly across the entire base with this, come back and normalize once the vertical building is working.
                }


                //PLACE LOW MOVE UP - NEW ALGORITHM.

                //spawn a block, random position but on the base block
                previousBlock = Instantiate(toBuild, baseBlock.transform.position + new Vector3(randpos[0], baseBlock.transform.localScale.y * 0.5f + toBuildChild.localScale.y * 0.5f + 0.002f, randpos[1]), toBuild.transform.rotation);
                Transform prevBlockChild = previousBlock.transform.GetChild(0);
                //contact offset
                previousBlock.GetComponentInChildren<Collider>().contactOffset = 0.001f;
                //capturing first block for gizmo testing
                firstBlock = previousBlock.gameObject;

                //check for overlaps
                bool overlap = Physics.CheckBox(previousBlock.transform.position, prevBlockChild.GetComponent<Collider>().bounds.extents, Quaternion.identity, mask);
                

                if (!overlap)
                {
                    //no overlap, placed on the baseblock
                    //Debug.Log(previousBlock.name + " placed on the baseblock");
                    
                }
                else //box overlaps and must be moved
                {
                    //if overlap, raycast up until a block is hit. iterate through the blocks hit until a legal position is found
                    RaycastHit[] raycastHits = Physics.BoxCastAll(previousBlock.transform.position, prevBlockChild.GetComponent<Collider>().bounds.extents, previousBlock.transform.up, Quaternion.identity, 100f, mask);

                    //for gizmo drawing
                    m_Hits = raycastHits;
                    //List<string> outhits = new List<string>();// previousBlock.GetComponent<BlockScript>().hitsList;

                    //for each in the [], check for legal status. if legal, break the loop and move the box there
                    foreach (RaycastHit hit in raycastHits)
                    {




                        //for reference list
                        //outhits.Add(hit.transform.gameObject.name);
                        previousBlock.GetComponent<BlockScript>().hitsList.Add(hit.transform.gameObject.name);

                        //if the hit is the baseblock, continue
                        if(hit.transform.name == "BaseBlock")
                        {
                            //this should never come up because of the layer mask
                            //Debug.Log("looping on base hit");
                            continue;
                        }


                        //Debug.Log(previousBlock.name + " raycast hit " + hit.transform.name);
                        Destroy(previousBlock);
                        //prevBlockChild.GetComponent<Renderer>().material = transparent;
                        previousBlock = Instantiate(toBuild, new Vector3(randpos[0], (toBuildChild.localScale.y * 0.5f) + (hit.transform.GetChild(0).transform.localScale.y * 0.5f) + hit.transform.position.y, randpos[1]), toBuild.transform.rotation);

                        //dont check for collisions on the block just placed on
                        hit.transform.gameObject.layer = 6;
                        hit.transform.GetChild(0).gameObject.layer = 6;

                        //check for new collisions
                        if (!Physics.CheckBox(previousBlock.transform.position, prevBlockChild.GetComponent<Collider>().bounds.extents, Quaternion.identity, mask))
                        {
                           // previousBlock.GetComponent<BlockScript>().hitsList = outhits;
                            //Debug.Log("block placed");
                            //reallow for the hit to be checked for hits
                            hit.transform.gameObject.layer = 3;
                            hit.transform.GetChild(0).gameObject.layer = 3;
                            break;
                            //the block is placed legally with no overlaps, we can leave it be
                        }
                        //allow the hit to be checked for collisions
                        hit.transform.gameObject.layer = 3;
                        hit.transform.GetChild(0).gameObject.layer = 3;
                    }
                }




                previousBlock.layer = 6;
                previousBlock.transform.GetChild(0).gameObject.layer = 6;





                
            }

            previousBlock.transform.SetParent(baseBlock.transform);

            //lowering the threshold for blocks to fall asleep. tower should not pause too prematurely anymore.
            //it still does pause, but almost always the towers are stable so it doesnt feel wrong.
            previousBlock.GetComponent<Rigidbody>().sleepThreshold = sleepenergy;

            //activate the Blockscript
            previousBlock.GetComponent<BlockScript>().enabled = true;

            previousBlock.tag = "CurrentBlock";


            //allowing for different masses of the blocks. Doing this after everything else becuase it otherwise doesnt affect anything in the chain of events besides the mass and it only happens sometimes if the button is pressed.

            //we are not using this for our current project. it works, though.


            //if (addMassScript.getMassStatus() == 0)
            //{
            //    //allow for new masses
            //    if (Random.value >= 0.8f)
            //    {
            //        previousBlock.GetComponentInChildren<Renderer>().material = metalMat;
            //        previousBlock.GetComponent<Rigidbody>().mass = 2.5f;
            //    }
            //}

            previousBlock.tag = "CurrentLevel";
            previousBlock.layer = 3;
            previousBlock.transform.GetChild(0).gameObject.layer = 3;

            //adding the block to the list for the level
            BlocksOnThisLevel.Add(previousBlock);





            //summary of how the blocks are built, starting low and moving up
            /*
             *instantiate block at the base
             * if it overlaps
             *  destroy
             *  send a raycast upwards
             *  reinstantiate at the new position
             *  check for collisions
             * 
             */


            blocksIndex++;



        }

    }

    float shiftLeft(float xVal)
    {
        return xVal + 0.05f * level;
    }

    float shiftRight(float xVal)
    {
        return xVal - 0.03f * level; ;
    }

    float shiftForward(float zVal)
    {
        return zVal + 0.03f * level; ;     
    }

    float shiftBackward(float zVal)
    {
        return zVal - 0.03f * level; ;
    }
    float[] steady(float[] randPos)
    {
        randPos[0] *= (1.3f - (level / 10.0f));//0.9f;
        randPos[1] *= (1.3f - (level / 10.0f)); ;
        return randPos;
    }


    /// <summary>
    /// This is the main structure of the program:
    /// 1: It safely deletes the old tower
    /// 2: spawns in a new tower
    /// </summary>
    public void buildTower()
    {


        //testing having the grabber drop all items on space being pressed. did not fix bug 7

        firstBlock = null;
        blockCountToDelete = blockCount;
        blockCount = 0;
        yLevel = baseBlock.transform.position.y + baseBlock.transform.localScale.y;
        //setting to 0 for debugging

        for (int i = 0; i < baseBlock.transform.childCount; i++)
        {
            baseBlock.transform.GetChild(i).Translate(new Vector3(1000, -1000, 1000), Space.World);
            baseBlock.transform.GetChild(i).gameObject.layer = 0;
            //set the blocks to the default layer so that they can be correctly deleted


            //this is necesarry because of bug 7 in the doc.
            //without this, there is a weird interaction with the tactile device if it is touching a block that is deleted.
            Invoke("deleteOldBlocks", 0.05f);

            BlocksOnThisLevel.Clear();
            level = 0; //this seems to work, probably because i adjusted the system that blocks are deleted

        }

        previousBlock = null;
        prevnumber = 0f;

        BlocksOnLastLevel.Clear();

        if (readytobuild)
        {
            //set the random seed
            //this is the best spot for it in my short testing.
            Random.InitState(seed);
            seed++;

            for (int i = 0; i < towerBlocksInt; i++)
            {
                addNewBlock();
                //Invoke("addNewBlock", 0.1f);
                //if there are issues
                level++;
            }

            freeRotation = false;

            readytobuild = false;
        }


    }


    /// <summary>
    /// This releases all rigidbody restrictions, causing the static towers to be affect by gravity again.
    /// It also set the sleeptimer to 0 so that the rigidbodies do not prematurely stop falling
    /// </summary>
    public void towerFall()
    {
        releaseRestrictions();
        freeRotation = true;
        sleeptimer = 0;
    }


}
