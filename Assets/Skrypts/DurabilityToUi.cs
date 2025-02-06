using TMPro;
using UnityEngine;

public class DurabilityToUi : MonoBehaviour
{
    [SerializeField] private BrickBreak bb;
    [SerializeField] private TextMeshProUGUI tmp;

    private void Update()
    {
        //tmp.text = Mathf.Round(bb.GetDurability()).ToString();
        if (tmp != null)
        {
            tmp.text = bb.GetDurability().ToString("N0");
        }
        else
        {
            Debug.Log("tmp is null. Make sure to assign the Text component in the Inspector.");
        }
    }
}
