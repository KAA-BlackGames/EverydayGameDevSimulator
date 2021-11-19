using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _gun.MoneyShot(Input.mousePosition);

        if (Input.GetMouseButtonDown(1))
            _gun.SlipperShot(Input.mousePosition);
    }
}
