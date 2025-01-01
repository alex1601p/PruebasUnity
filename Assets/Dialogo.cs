using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public class Dialogo : MonoBehaviour

{
    private PlayerInput playerInput;
    private bool PlayerTrigger; //Detecta cuando el BoxCollider del NPC detecta el del jugador
    private bool DialogueStart; //Boleando para saber si se esta ejecutando un dialogo o no
    private int LineIndex; //Indica cual linea de dialogo se esta ejecutando
    [SerializeField,TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText; 
    [SerializeField] private float Seconds;

    public void InteractionNPC(InputAction.CallbackContext context) //Si se activa, pero no hara nada si esta cerca del jugador
    {
	if(PlayerTrigger && context.started) //Solo se activa cuando se detecta cerca cel NPC correspondiente y la fase aplicada es Started 
	{
		if(!DialogueStart) //Inicia dialogo cuando no se tenga uno presente
		{
			StartDialogue();
		}
		else if (DialogueText.text == dialogueLines[LineIndex]) //Se activa cuando presentamos 
		{
			ShowNextLine(); //Presentamos la siguiente linea con esta subrutina
		}
	}
    }


    private void StartDialogue()
    {
	DialogueStart = true;
	DialoguePanel.SetActive(true); 
	LineIndex = 0; //Esto debido a que se esta comenzando el dialogo
	StartCoroutine(ShowLine());
    }	

    private void ShowNextLine()
    {
	LineIndex++;
	if (LineIndex < dialogueLines.Length)
	{
		StartCoroutine(ShowLine());
	}
	else
	{
		DialogueStart = false;
		DialoguePanel.SetActive(false);
	}
    }

    private IEnumerator ShowLine()
    {
	DialogueText.text = string.Empty;
	foreach(char ch in dialogueLines[LineIndex])
	{
		DialogueText.text += ch;
		yield return new WaitForSeconds(Seconds);
	}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
	if (collision.gameObject.CompareTag("Player"))
	{
		PlayerTrigger = true;
	}
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
	if (collision.gameObject.CompareTag("Player"))
         {
        	PlayerTrigger = false;
         }
    }

}
