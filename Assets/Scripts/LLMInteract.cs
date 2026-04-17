using UnityEngine;
using TMPro;
using StarterAssets;

public class NPCInteract : MonoBehaviour
{
    public GameObject interactPrompt;
    public GameObject chatUI;
    public string playerTag = "Player";

    private bool isPlayerNearby = false;
    private bool isChatOpen = false;
    private TMP_Text promptText;

    private void Start()
    {
        if (interactPrompt != null)
        {
            interactPrompt.SetActive(false);
            promptText = interactPrompt.GetComponent<TMP_Text>();
        }

        if (chatUI != null)
        {
            chatUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isPlayerNearby) return;

        if (!isChatOpen && Input.GetKeyDown(KeyCode.E))
        {
            OpenChat();
        }

        if (isChatOpen && Input.GetKeyDown(KeyCode.Escape))
        {

            CloseChat();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = true;

            if (interactPrompt != null)
            {
                interactPrompt.SetActive(true);
            }

            UpdatePromptText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = false;

            if (interactPrompt != null)
            {
                interactPrompt.SetActive(false);
            }

            CloseChat();
        }
    }

    private void OpenChat()
    {
        isChatOpen = true;

        if (chatUI != null)
        {
            chatUI.SetActive(true);
        }

        UpdatePromptText();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<ThirdPersonController>().enabled = false;

    }

    private void CloseChat()
    {
        isChatOpen = false;

        if (chatUI != null)
        {
            chatUI.SetActive(false);
        }

        UpdatePromptText();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<ThirdPersonController>().enabled = true;
    }

    private void UpdatePromptText()
    {
        if (promptText == null) return;

        if (isChatOpen)
            promptText.text = "[Esc] Close";
        else
            promptText.text = "[E] Talk";
    }
}