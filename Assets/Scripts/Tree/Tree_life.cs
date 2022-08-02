using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_life : MonoBehaviour
{
    [SerializeField]
    private float treeHealf;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject woodPrefab;

    [SerializeField]
    private ParticleSystem leafs;

    [SerializeField]
    private int totalWood;

    private bool isCut;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void onHit()
    {
        totalWood = Random.Range(1, 5);
        treeHealf--;
        anim.SetTrigger("isHit");
        leafs.Play();

        if (treeHealf <= 0)
        {
            for (int i = 0; i < totalWood; i++)
            {
                anim.SetTrigger("cut");
                Instantiate(
                    woodPrefab,
                    transform.position
                        + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f),
                    transform.rotation
                );
            }
        }

        isCut = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            onHit();
        }
    }
}
