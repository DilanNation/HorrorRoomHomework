using UnityEngine;
using System.Collections;

public class LearnCoroutine : MonoBehaviour
{
    //      協程
    //      目的： 讓程式停下等待
    //      引用 using System.Collections
    //      定義 IEnumerator
    //      使用yield return
    //      使用StartCoroutine啟動

    private string  testDialogue = "這裡是什麼東西";

    private void Awake()
    {
        StartCoroutine(Test());

        StartCoroutine(ShowDialogue());
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
    }

    private IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator ShowDialogueUseFor()
    {
        for (int i = 0; i < testDialogue.Length; i++);
        {
            //print(testDialogue[0]);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
