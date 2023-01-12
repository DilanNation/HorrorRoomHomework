using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class DialogueSystem : MonoBehaviour
{

    private UnityEvent onDialogueFinish;
    
    [SerializeField, Header("對話間隔"), Range(0, 0.1f)]
    private float dialogueIntervalTime = 0.05f;
    [SerializeField, Header("開頭對話")]
    private DialogueData dialogueOpening;
    [SerializeField, Header("對話按鍵")]
    private KeyCode dialogueKey = KeyCode.Space;


    private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);
    private CanvasGroup groupDialogue;
    private TextMeshProUGUI textName;
    private TextMeshProUGUI textContent;
    private GameObject goTriangle;


    private PlayerInput playerInput;

    private void Awake()
    {
        groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
        textName = GameObject.Find("名稱").GetComponent<TextMeshProUGUI>();
        textContent = GameObject.Find("對話文").GetComponent<TextMeshProUGUI>();
        goTriangle = GameObject.Find("對話完成圖示");
        goTriangle.SetActive(false);

        playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();
        

        StartDialogue(dialogueOpening);
    }

    public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
    {
        playerInput.enabled = false;
        StartCoroutine(FadeGroup());
        StartCoroutine(TypeEffect(data));
        onDialogueFinish =  _onDialogueFinish;
    }

///淡出淡入
    private IEnumerator FadeGroup(bool fadeIn = true)
    {
        float increase = fadeIn ? +0.1f : -0.1f;
        for (int i = 0; i < 10; i++)
        {
            groupDialogue.alpha += increase;
            yield return new WaitForSeconds(0.02f);
        }
    }

///打字效果
    private IEnumerator TypeEffect(DialogueData data)
    {
        textName.text = data.dialogueName;

        for (int j = 0; j < data.dialogueContent.Length; j++)
        {
            textContent.text = "";
            goTriangle.SetActive(false);

            string dialogue = data.dialogueContent[j];

            for (int i = 0; i < dialogue.Length; i++)
            {
                textContent.text += dialogue[i];
                yield return dialogueInterval;
            }
        }


        while (Input.GetKeyDown(dialogueKey))
        {
            yield return null;
            // 等待玩家輸入
        }

        StartCoroutine(FadeGroup(false));
        playerInput.enabled = true;
        onDialogueFinish?.Invoke();
        
    }
}
