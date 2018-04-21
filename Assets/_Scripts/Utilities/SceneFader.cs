using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public static IEnumerator Fade(Color fromColor, Color toColor, float duration)
    {
        var canvasObject = Resources.Load<GameObject>("Prefabs/SceneTransitionCanvas");
        var canvasInstance = Instantiate(canvasObject, new Vector3(0,0,0), Quaternion.identity);
        var fadeImage = canvasInstance.GetComponent<RawImage>();

        var elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            fadeImage.color = Color.Lerp(fromColor, toColor, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        DestroyObject(canvasInstance, 1.0f);
    }
}
