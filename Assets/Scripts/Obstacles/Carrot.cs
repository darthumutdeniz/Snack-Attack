using System.Collections;
using System.Threading;
using UnityEngine;

public class Carrot : Obsticle
{
    int oriantation;

    protected override void DoAtStart()
    {
        StartCoroutine(Rotate());
    }

    protected override void SetPosition()
    {
        int randomIndex = Random.Range(-1, 1);
        oriantation = 1 + 2 * randomIndex;
        Vector3 position = new Vector3(player.transform.position.x - oriantation * attackPattern.GetInitialDistanceFromPlayer(), player.transform.position.y);
        transform.position = position;
        transform.localScale = new Vector3(transform.localScale.x, oriantation, transform.localScale.z);
    }
    IEnumerator Rotate()
    {
        myrigidbody2D.angularVelocity = 360/waitAtStart;
        yield return new WaitForSeconds(waitAtStart);
        myrigidbody2D.angularVelocity = 0;
        transform.rotation = Quaternion.Euler(0, 0, 90);
        //transform.localScale = new Vector3(transform.localScale.x, oriantation, transform.localScale.z);
        myrigidbody2D.linearVelocityX = moveSpeed * oriantation;
    }

}
