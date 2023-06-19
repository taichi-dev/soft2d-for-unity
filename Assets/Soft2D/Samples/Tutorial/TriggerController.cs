using Taichi.Soft2D.Plugin;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public ETrigger trigger;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        bool isTriggered = trigger.QueryParticles();
        text.text = isTriggered ? "Trigger is activated." : "Trigger is not activated.";
    }
}
