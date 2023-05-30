using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class carController : MonoBehaviour
{

    public int tutorialIndex = -1;
    [Header("playerMovement")]
    public int currentLocation = 0;
    public float forwardSpeed; // 向前移動的速度
    public float diagonalSpeed; // 斜向移動的速度
    public float diagonaldebuff; //斜向移動補正
    public float rotationSpeed; // 回正的旋轉速度
    public bool isMovingDiagonal = false; // 是否正在進行斜向移動
    [Header("itemCounter")]
    public int starBuffCount = 0;
    private Vector3 targetPosition; // 目標位置
    private Quaternion targetRotation; // 目標旋轉
    private gameMaster gameMaster;
    private itemManager itemManager;
    private CharacterController _characterController;
    private void Start()
    {
        //_characterController = GetComponent<CharacterController>();
        itemManager = GameObject.FindObjectOfType<itemManager>();
        gameMaster = GameObject.FindObjectOfType<gameMaster>();
    }
    private void Update()
    {

        // debug
        //Debug.Log(currentLocation);
        // debug
        if (currentLocation < 2 && currentLocation > -2)
        {
            // =================================================================
            //移動判定
            if (Input.GetKeyDown(KeyCode.A) && !isMovingDiagonal)
            {
                turnLeft();
            }

            if (Input.GetKeyDown(KeyCode.D) && !isMovingDiagonal)
            {
                turnRight();
            }

            if (!isMovingDiagonal)
            {
                // 向前移動
                goStraight();
            }
            //移動判定
            // =================================================================

            // =================================================================
            //道具判定

            if (itemManager.isStar)
            {
                starBuff();
            }
            else
            {
                starDebuff();
            }

            //道具判定
            // =================================================================

        }
        else
        {
            if (currentLocation >= 2 && tutorialIndex < 0)
            {
                //撞到右邊的牆壁
                gameMaster.isInGame = false;

            }
            else if (currentLocation <= -2 && tutorialIndex < 0)
            {
                //撞到左邊的牆壁
                gameMaster.isInGame = false;
            }

        }

    }

    private IEnumerator MoveDiagonal()
    {
        float elapsedTime = 0f;
        float duration = 0.1f; // 斜向移動持續時間
        Quaternion startRotation = transform.rotation;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // 斜向移動
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            // 插值旋轉
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // 斜向移動
            float t = elapsedTime / duration;
            // 插值旋轉
            transform.rotation = Quaternion.Slerp(targetRotation, startRotation, t);

            yield return null;
        }

        // 完成斜向移動，回正為向前旋轉
        isMovingDiagonal = false;
    }
    private void turnLeft()
    {
        // 開始斜向移動
        isMovingDiagonal = true;
        targetPosition = transform.position + transform.TransformDirection(Vector3.forward + Vector3.left).normalized * diagonalSpeed * diagonaldebuff;
        targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        Debug.Log("targetPosition = " + targetPosition);
        Debug.Log("targetRotation = " + targetRotation);
        StartCoroutine(MoveDiagonal());
        currentLocation = currentLocation - 1;
    }
    private void turnRight()
    {
        // 開始斜向移動
        isMovingDiagonal = true;
        targetPosition = transform.position + transform.TransformDirection(Vector3.forward + Vector3.right).normalized * diagonalSpeed * diagonaldebuff;
        targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        Debug.Log("targetPosition = " + targetPosition);
        Debug.Log("targetRotation = " + targetRotation);
        StartCoroutine(MoveDiagonal());
        currentLocation = currentLocation + 1;
    }
    private void goStraight()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    private System.Collections.IEnumerator turnRight_delay()
    {
        yield return new WaitForSeconds(0.1f);
        turnRight();
        // 在這裡寫下要延遲執行的程式碼
        Debug.Log("Delayed action");
    }
    private void starBuff()
    {
        //吃到肉的加速度
        if (itemManager.isStar == true && starBuffCount == 0)
        {
            starBuffCount = 1;
            forwardSpeed = forwardSpeed * 2;
            Vector3 newScale = transform.localScale * 2.5f;
            transform.localScale = newScale;
        }

    }
    private void starDebuff()
    {
        //回歸吃到肉的加速度
        if (itemManager.isStar == false && starBuffCount == 1)
        {
            starBuffCount = 0;
            forwardSpeed = forwardSpeed / 2;
            Vector3 newScale = transform.localScale / 2.5f;
            transform.localScale = newScale;
        }

    }
}