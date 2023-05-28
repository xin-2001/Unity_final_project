using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float forwardSpeed; // 向前移動的速度
    public float diagonalSpeed; // 斜向移動的速度
    public float rotationSpeed; // 回正的旋轉速度

    private bool isMovingDiagonal = false; // 是否正在進行斜向移動
    private Vector3 targetPosition; // 目標位置
    private Quaternion targetRotation; // 目標旋轉

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isMovingDiagonal)
        {
            // 開始斜向移動
            isMovingDiagonal = true;
            targetPosition = transform.position + transform.TransformDirection(Vector3.forward + Vector3.left).normalized * diagonalSpeed;
            targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            StartCoroutine(MoveDiagonal());
        }

        if (Input.GetKeyDown(KeyCode.D) && !isMovingDiagonal)
        {
            // 開始斜向移動
            isMovingDiagonal = true;
            targetPosition = transform.position + transform.TransformDirection(Vector3.forward + Vector3.right).normalized * diagonalSpeed;
            targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            StartCoroutine(MoveDiagonal());
        }

        if (!isMovingDiagonal)
        {
            // 向前移動
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }

    private System.Collections.IEnumerator MoveDiagonal()
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
            //Debug.Log("1");
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
}
