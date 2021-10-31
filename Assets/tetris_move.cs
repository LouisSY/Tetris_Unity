using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class tetris_move : MonoBehaviour
{
    public Vector3 routationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    // public bool pauseGame = false;


    private KeyCode left = KeyCode.LeftArrow;
    private KeyCode right = KeyCode.RightArrow;
    private KeyCode down = KeyCode.DownArrow;
    private KeyCode up = KeyCode.UpArrow;

    private KeyCode a = KeyCode.A;
    private KeyCode d = KeyCode.D;
    private KeyCode s = KeyCode.S;
    private KeyCode w = KeyCode.W;
    private KeyCode r = KeyCode.R;
    private KeyCode esc = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(left) || Input.GetKeyDown(a)) {
            transform.position += new Vector3(-1, 0, 0);
            if (!checkMove()) {
                transform.position -= new Vector3(-1, 0, 0);
            }
        } else if (Input.GetKeyDown(right) || Input.GetKeyDown(d)) {
            transform.position += new Vector3(1, 0, 0);
            if (!checkMove()) {
                transform.position -= new Vector3(1, 0, 0);
            }
        } else if (Input.GetKeyDown(up) || Input.GetKeyDown(w)) {
            transform.RotateAround(transform.TransformPoint(routationPoint), new Vector3(0, 0, 1), 90);
            if (!checkMove()) {
                transform.RotateAround(transform.TransformPoint(routationPoint), new Vector3(0, 0, 1), -90);
            }
        }

        if(Input.GetKeyDown(r)) {
            SceneManager.LoadScene(0);
        } else {
            if (Time.time - previousTime >= (Input.GetKey(down)||Input.GetKey(s)? fallTime/10 : fallTime)) {
                transform.position += new Vector3(0, -1, 0);
                if (!checkMove()) {
                    transform.position -= new Vector3(0, -1, 0);
                    addGrid();
                    checkLine();
                    this.enabled = false;
                    FindObjectOfType<spawn_block>().NewBlock();
                }
                previousTime = Time.time;

            }
        }

        if(Input.GetKeyDown(esc)) {
            Application.Quit();
        }
        
        
    }


    bool checkMove() {
        foreach(Transform block in transform) {
            int rounded_x = Mathf.RoundToInt(block.transform.position.x);
            int rounded_y = Mathf.RoundToInt(block.transform.position.y);

            if (rounded_x < 0 || rounded_x >= width || rounded_y < 0 || rounded_y >= height || grid[rounded_x, rounded_y] != null) {
                return false;
            }  
        }

        return true;
    }

    void checkLine() {
        for (int i = height - 1; i >= 0; i--) {
            if(hasLine(i)) {
                deleteLine(i);
                rowDownLine(i);
            }
        }
    }

    bool hasLine(int i) {
        for (int j = 0; j < width; j++) {
            if (grid[j, i] == null) {
                return false;
            }
        }
        return true;
    }

    void deleteLine(int i) {
        for (int j = 0; j < width; j++) {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void rowDownLine(int i) {
        for(int i_temp = i; i_temp < height; i_temp++) {
            for(int j = 0; j < width; j++) {
                if(grid[j, i_temp] != null) {
                    grid[j, i_temp - 1] = grid[j, i_temp];
                    grid[j, i_temp] = null;
                    grid[j, i_temp - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void addGrid() {
        foreach(Transform block in transform) {
            int rounded_x = Mathf.RoundToInt(block.transform.position.x);
            int rounded_y = Mathf.RoundToInt(block.transform.position.y);

            grid[rounded_x, rounded_y] = block;
        }

    }
}
