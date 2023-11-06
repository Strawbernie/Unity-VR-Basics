using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] gameObjects;
    public GameObject[] PipeWalls;
    int firstNumber;
    IEnumerator Start()
    {
        foreach (var obj in gameObjects)
        {
            obj.SetActive(false);
        }
        foreach (var pw in PipeWalls)
        {
            pw.SetActive(false);
        }
        int Delay = Random.Range(10, 20);
        yield return new WaitForSeconds(Delay);
        int value = Random.Range(1, 21);
        firstNumber = value;
        switch (value)
        {
            case 1:
                gameObjects[0].SetActive(true);
                break;
            case 2:
                gameObjects[1].SetActive(true);
                break;
            case 3:
                gameObjects[2].SetActive(true);
                break;
            case 4:
                gameObjects[3].SetActive(true);
                break;
            case 5:
                gameObjects[4].SetActive(true);
                break;
            case 6:
                gameObjects[5].SetActive(true);
                break;
            case 7:
                gameObjects[6].SetActive(true);
                break;
            case 8:
                gameObjects[7].SetActive(true);
                break;
            case 9:
                gameObjects[8].SetActive(true);
                break;
            case 10:
                gameObjects[9].SetActive(true);
                break;
            case 11:
                gameObjects[10].SetActive(true);
                break;
            case 12:
                gameObjects[11].SetActive(true);
                break;
            case 13:
                gameObjects[12].SetActive(true);
                break;
            case 14:
                gameObjects[13].SetActive(true);
                break;
            case 15:
                gameObjects[14].SetActive(true);
                break;
            case 16:
                gameObjects[15].SetActive(true);
                break;
            case 17:
                gameObjects[16].SetActive(true);
                break;
            case 18:
                gameObjects[17].SetActive(true);
                break;
            case 19:
                gameObjects[18].SetActive(true);
                break;
            case 20:
                gameObjects[19].SetActive(true);
                break;
            case 21:
                gameObjects[20].SetActive(true);
                break;
        }
        int wall = Random.Range(1, 5);
        switch (wall)
        {
            case 1:
                PipeWalls[0].SetActive(true);
                break;
            case 2:
                PipeWalls[1].SetActive(true);
                break;
            case 3:
                PipeWalls[2].SetActive(true);
                break;
            case 4:
                PipeWalls[3].SetActive(true);
                break;
        }
        StartCoroutine(ActivateObjects());
    }
    private IEnumerator ActivateObjects()
    {
        if (Difficulty.difficulty <= 1)
        {
            int Delay = Random.Range(35, 50);
            yield return new WaitForSeconds(Delay);
            int secondRandomNumber;
            do
            {
                secondRandomNumber = Random.Range(1, 21);
            } while (secondRandomNumber == firstNumber);
            switch (secondRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }
            int Delay2 = Random.Range(35, 50);
            yield return new WaitForSeconds(Delay2);
            int thirdRandomNumber;
            do
            {
                thirdRandomNumber = Random.Range(1, 21);
            } while (thirdRandomNumber == firstNumber || thirdRandomNumber == secondRandomNumber);
            switch (thirdRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }

        }
        else if (Difficulty.difficulty == 2)
        {
            int Delay = Random.Range(30, 45);
            yield return new WaitForSeconds(Delay);
            int secondRandomNumber;
            do
            {
                secondRandomNumber = Random.Range(1, 21);
            } while (secondRandomNumber == firstNumber);
            switch (secondRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }
            int Delay2 = Random.Range(30, 45);
            yield return new WaitForSeconds(Delay2);
            int thirdRandomNumber;
            do
            {
                thirdRandomNumber = Random.Range(1, 21);
            } while (thirdRandomNumber == firstNumber || thirdRandomNumber == secondRandomNumber);
            switch (thirdRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }
            int Delay3 = Random.Range(30, 45);
            yield return new WaitForSeconds(Delay);
            int fourthRandomNumber;
            do
            {
                fourthRandomNumber = Random.Range(1, 21);
            } while (fourthRandomNumber == firstNumber || fourthRandomNumber == secondRandomNumber || fourthRandomNumber == thirdRandomNumber);
            switch (fourthRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }


        }
        else if (Difficulty.difficulty == 3)
        {
            int Delay = Random.Range(25, 40);
            yield return new WaitForSeconds(Delay);
            int secondRandomNumber;
            do
            {
                secondRandomNumber = Random.Range(1, 21);
            } while (secondRandomNumber == firstNumber);
            switch (secondRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }
            int Delay2 = Random.Range(25, 40);
            yield return new WaitForSeconds(Delay2);
            int thirdRandomNumber;
            do
            {
                thirdRandomNumber = Random.Range(1, 21);
            } while (thirdRandomNumber == firstNumber || thirdRandomNumber == secondRandomNumber);
            switch (thirdRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }
            int Delay3 = Random.Range(25, 40);
            yield return new WaitForSeconds(Delay);
            int fourthRandomNumber;
            do
            {
                fourthRandomNumber = Random.Range(1, 21);
            } while (fourthRandomNumber == firstNumber || fourthRandomNumber == secondRandomNumber || fourthRandomNumber == thirdRandomNumber);
            switch (fourthRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }
            int Delay4 = Random.Range(25, 40);
            yield return new WaitForSeconds(Delay);
            int fifthRandomNumber;
            do
            {
                fifthRandomNumber = Random.Range(1, 21);
            } while (fifthRandomNumber == firstNumber || fifthRandomNumber == secondRandomNumber || fifthRandomNumber == thirdRandomNumber || fifthRandomNumber == fourthRandomNumber);
            switch (fifthRandomNumber)
            {
                case 1:
                    gameObjects[0].SetActive(true);
                    break;
                case 2:
                    gameObjects[1].SetActive(true);
                    break;
                case 3:
                    gameObjects[2].SetActive(true);
                    break;
                case 4:
                    gameObjects[3].SetActive(true);
                    break;
                case 5:
                    gameObjects[4].SetActive(true);
                    break;
                case 6:
                    gameObjects[5].SetActive(true);
                    break;
                case 7:
                    gameObjects[6].SetActive(true);
                    break;
                case 8:
                    gameObjects[7].SetActive(true);
                    break;
                case 9:
                    gameObjects[8].SetActive(true);
                    break;
                case 10:
                    gameObjects[9].SetActive(true);
                    break;
                case 11:
                    gameObjects[10].SetActive(true);
                    break;
                case 12:
                    gameObjects[11].SetActive(true);
                    break;
                case 13:
                    gameObjects[12].SetActive(true);
                    break;
                case 14:
                    gameObjects[13].SetActive(true);
                    break;
                case 15:
                    gameObjects[14].SetActive(true);
                    break;
                case 16:
                    gameObjects[15].SetActive(true);
                    break;
                case 17:
                    gameObjects[16].SetActive(true);
                    break;
                case 18:
                    gameObjects[17].SetActive(true);
                    break;
                case 19:
                    gameObjects[18].SetActive(true);
                    break;
                case 20:
                    gameObjects[19].SetActive(true);
                    break;
                case 21:
                    gameObjects[20].SetActive(true);
                    break;
            }
        }
    }
}
