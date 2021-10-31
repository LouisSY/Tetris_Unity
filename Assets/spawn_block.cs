using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class spawn_block : MonoBehaviour
{
    public GameObject[] TetrisBlocks;
    public int randomBlock_1 = 10;
    public int randomBlock_2 = 10;
    private bool pauseGame;
    // Start is called before the first frame update
    void Start()
    {
        if(!pauseGame) {
            NewBlock();
        } else {
            Thread.Sleep(1000);
        }
        
    }

    void Update()
    {
        // pauseGame = tetris_move.FindObjectOfType<tetris_move>().pauseGame;
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
