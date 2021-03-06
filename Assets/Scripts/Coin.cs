using UnityEngine;

public class Coin : QuestionBlockItem
{
    public float force = 2.0f;
    const int COINS_TO_LEVEL_UP = 100;

    protected override void ItemSpecalizedBehavior()
    {
        if (ChangeUi.coin_count + 1 >= COINS_TO_LEVEL_UP)
        {
           Sounds.GetAudioSource(Sounds.AudioType.OneUp).Play();
            ChangeUi.life_count++;
            ChangeUi.coin_count = 0;
        }
        else
        {
            ChangeUi.coin_count++;
           Sounds.GetAudioSource(Sounds.AudioType.Coin).Play();
        }
        ChangeUi.scoreInc("Coin");
        Destroy( gameObject );
    }

    protected override void OnStart()
    {
        GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.x * force, 0, Random.insideUnitSphere.z * force,
            ForceMode.Impulse);
    }
}