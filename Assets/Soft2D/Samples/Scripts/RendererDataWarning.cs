using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RendererDataWarning : MonoBehaviour
{
    public string warning = "Please configure the renderer data correctly before running this scene:\n\n" +
                            "1. Find the file location of 'Render Pipeline Asset' currently used by this project: Project Settings ->Quality -> Rendering -> Render Pipeline Asset.\n\n" + 
                            "2. Click that 'Render Pipline Asset' asset file and click '+' to add a renderer data into its  'Renderer List' in its Inspector window, select 'Kawase Blur Data' as the new renderer data.\n\n" +
                            "(Disable the 'WarningCanvas' object in the scene to close this message.)";
    public Text warningText;

    private void Start()
    {
        if (GraphicsSettings.renderPipelineAsset != null && GraphicsSettings.renderPipelineAsset.GetType().Name == "UniversalRenderPipelineAsset")
        {
            warningText.text = warning;
        }
    }
}
