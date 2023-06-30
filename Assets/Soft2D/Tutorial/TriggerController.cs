using Taichi.Soft2D.Plugin;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public ETrigger trigger;
    public Text text;
    
    void Update()
    {
        bool isTriggered = trigger.QueryParticleOverlapping();
        text.text = isTriggered ? "Trigger is activated." : "Trigger is not activated.";
    }
}
