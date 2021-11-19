using UnityEngine;
using UnityEngine.UI;

public class ProgressCountViewer : MonoBehaviour
{
    [SerializeField] private ReleasedProduct releasedProduct;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        releasedProduct.ChangeProgressEvent += ReleasedProductOnChangeProgressEvent;
    }
    
    private void OnDestroy()
    {
        releasedProduct.ChangeProgressEvent -= ReleasedProductOnChangeProgressEvent;
    }

    private void ReleasedProductOnChangeProgressEvent(float currentProgress)
    {
        _slider.value = currentProgress;
    }
}
