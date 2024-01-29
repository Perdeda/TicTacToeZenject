using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GridManager : MonoBehaviour
{
    [Inject]
    GridGenerator gridGenerator;
    [Inject]
    AleFactory factory;
    Side currSideTurn = Side.crosses;
    Side[,] spaceArr = new Side[3, 3];
    private void Start()
    {
        gridGenerator.GenField(factory);
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                spaceArr[i, j] = Side.none;
            }
        }
    }
    
    public void FillSpace(int i,int j)
    {
        spaceArr[i,j] = currSideTurn;
        if (CheckWin(currSideTurn,spaceArr))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        SwitchSide();
    }
    public Side GetCurrSide()
    {
        return currSideTurn;
    }
    //bool CheckForWinner(Side[,] board)
    //{

    //    // Проверка по строкам и столбцам
    //    for (int i = 0; i < 3; i++)
    //    {
    //        if ((board[i, 0] == currSideTurn && board[i, 1] == currSideTurn && board[i, 2] == currSideTurn) ||
    //            (board[0, i] == currSideTurn && board[1, i] == currSideTurn && board[2, i] == currSideTurn))
    //        {
    //            return true;
    //        }
    //    }

    //    // Проверка по диагоналям
    //    if ((board[0, 0] == currSideTurn && board[1, 1] == currSideTurn && board[2, 2] == currSideTurn) ||
    //        (board[0, 2] == currSideTurn && board[1, 1] == currSideTurn && board[2, 0] == currSideTurn))
    //    {
    //        return true;
    //    }

    //    return false;
    //}
    public bool CheckWin(Side player, Side[,] board)
    {
        // Проверка по вертикали
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
            {
                Debug.Log("ALEEEENEPONYAAL" + row);
                return true;
            }
        }

        // Проверка по горизонтали
        for (int column = 0; column < 3; column++)
        {
            if (board[0, column] == player && board[1, column] == player && board[2, column] == player)
            {
                Debug.Log("ALEEEENEPONYAAL1");
                return true;
            }
        }

        // Проверка по диагонали
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            Debug.Log("ALEEEENEPONYAAL2");
            return true;
        }

        if (board[2, 0] == player && board[1, 1] == player && board[0, 2] == player)
        {
            Debug.Log("ALEEEENEPONYAAL3");
            return true;
        }

        return false;
    }
    void SwitchSide()
    {
        if (currSideTurn == Side.crosses)
            currSideTurn = Side.noughts;
        else
            currSideTurn = Side.crosses;
    }
}
