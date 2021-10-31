using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class spawn_block : MonoBehaviour
{
    public GameObject[] TetrisBlocks;
    public int randomBlock_1 = 10;
    public int randomBlock_2 = 10;

    // Start is called before the first frame update
    void Start()
    {
        NewBlock();
    }

    void Update()
    {

    }

    public void NewBlock() {
        getRandom();
        Instantiate(TetrisBlocks[randomBlock_1], transform.position, Quaternion.identity);
    }

    private void getRandom() {
        if (randomBlock_1 == 10 && randomBlock_2 == 10) {
            randomBlock_1 = Random.Range(0, TetrisBlocks.Length);
            randomBlock_2 = Random.Range(0, TetrisBlocks.Length);
        } else {
            randomBlock_1 = randomBlock_2;
            randomBlock_2 = Random.Range(0, TetrisBlocks.Length);
        }
        
    }
}
