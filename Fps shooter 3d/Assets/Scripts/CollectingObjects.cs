using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingObjects : MonoBehaviour
{
    public GameObject cardCollected_text;

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            //other.gameObject.active = false;
            Destroy(other.gameObject);

            cardCollected_text.gameObject.active = true;

            StartCoroutine(playAnimation());
        }
    }

    private IEnumerator playAnimation()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("isCollected");

        Destroy(cardCollected_text, 5f);
    }
}
