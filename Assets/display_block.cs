using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_block : MonoBehaviour
{
    public GameObject[] TetrisBlocks;
    private int temp = 0;
    private GameObject theNextBlock = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num = spawn_block.FindObjectOfType<spawn_block>().randomBlock_2;
        if (num < TetrisBlocks.Length && temp != num) {
            if (theNextBlock != null) {
                Destroy(theNextBlock);
            }
            theNextBlock = (GameObject)Instantiate(TetrisBlocks[num], new Vector3 (20, 15, 0), Quaternion.identity);
            temp = num;
                            
        }

        
    }
}
