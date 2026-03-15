using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnd : MonoBehaviour
{
    string text01 = "Walking along the gravel path past the sugarcane fields, " +
        "I look up from my alternating steps. With nothing but the crunch of the " +
        "road breaking the silence, the events of the day run through my mind in a " +
        "cloudy haze. A sweet fragrance lingers on my grass-stained talons.\r\n";
    string text02 = "I cross another wreckage from the recent flood. My grandmother " +
        "taught me that the yearly rain was the world’s gift to our people, sustaining " +
        "our daily life. But seeing the destroyed fields and mangled infrastructure, I " +
        "can’t help but doubt her words. I try not to think of it as a bad omen.\r\n";
    string text03 = "I turn the corner and inhale deeply as a gust of wind blows past " +
        "me. The shade of the sugar stalks cools my skin and, up ahead, Macadamia " +
        "Village reflects amber in the evening sun.";
    string text04 = "Minutes later, I reach my front door. As I reach for my keys, " +
        "I hear someone call my name.\r\n";
    string text05 = "“Mrs. Crane!” A nasally voice called out, crinkling the air. " +
        "I sigh and force a smile.\r\n";
    string text06 = "“Ah, Mr. Baboon… what is it?”\r\n";
    string text07 = "“I hope your farm work went well today! Have you done your groceries " +
        "yet this week?” Grimes Baboon wrings his hands “Please, come by BaboonoMart " +
        "anytime for your shopping needs. I’m sure your lovely children need the " +
        "nutrition to grow strong.”\r\n";
    string text08 = "I really wish he wouldn’t talk about Jack and Jill to advertise his " +
        "store. Still, it’s true that I’ve yet to complete my shopping for the week. " +
        "“I’ll consider it.” I say, opening the door.\r\n";
    string text09 = "“I’m sure it’s what your husband would’ve wanted.”\r\n";
    string text10 = "“Good day, Mr. Baboon.” I spit curtly as I close the door behind me.\r\n";
    string text11 = "Ignoring Grimes’s protests receding behind the door, I walk to the " +
        "kitchen and take a look inside the pantry. Empty. I turn to leave but an old portrait " +
        "catches my eye.\r\n";
    string text12 = "Brushing a wing against it, I smile weakly at the four smiling figures.\r\n";
    string text13 = "I make my way to the kids’ room. Jack shouldn’t be home from school yet, " +
        "but Jill should be in the house. I gently open the door.\r\n";
    string text14 = "Inside, seven year-old Jill Crane lies collapsed on the floor.\r\n";
    ArrayList textList = new ArrayList();

    public GameObject Kyla;
    public GameObject Jack;
    public GameObject Jill;
    public GameObject TextboxFrame;
    
    [SerializeField] string textToScroll;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;

    bool textFinished = false;
    int eventPos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textList = new ArrayList() { text01, text02, text03, text04, text05, text06, text07, text08, text09, text10, text11, text12, text13, text14 };
        mainTextObject.SetActive(true);
        StartCoroutine(EventStarter());
    }

    // Update is called once per frame
    void Update()
    {
        textLength = ScrollText.charCount;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Spacebar pressed.");
            if (textFinished)
            {
                eventPos++;
                StartCoroutine(StartEvent());
                print("Event started.");
            }
        }
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(0.2f);
        Kyla.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * 30;
        Jack.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * 30;
        Jill.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * 30;
        TextboxFrame.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 500;
        yield return new WaitForSeconds(0.25f);
        Kyla.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Jack.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Jill.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(0.25f);
        TextboxFrame.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        textFinished = true;
    }

    IEnumerator StartEvent()
    {
        print("Inside StartEvent.");
        textFinished = false;
        textLength = 0;

        textToScroll = (string)textList[eventPos - 1];
        print(textToScroll);

        mainTextObject.GetComponent<TMPro.TMP_Text>().text = textToScroll;
        currentTextLength = textToScroll.Length;

        ScrollText.runTextPrint = true;
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        textFinished = true;
    }
}
