using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookmark_Open : MonoBehaviour
{
    [Header("Bookmarks"), Space(5)]
    [SerializeField] private GameObject _bookmarkPanel1;
    [SerializeField] private GameObject _bookmarkPanel2;
    [SerializeField] private GameObject _bookmarkPanel3;

    [Header("Sound Effect"), Space(5)]
    [SerializeField] private AudioClip _soundEffect1;
    [SerializeField] private AudioClip _soundEffect2;
    [SerializeField] private AudioSource _audioSource;
    
    public void OpenBookmark1()
    {
        _bookmarkPanel1.SetActive(true);
        _bookmarkPanel2.SetActive(false);
        _bookmarkPanel3.SetActive(false);

        int randomSoundEffect = Random.Range(1, 3);
        
        if (randomSoundEffect == 1)
        {
            _audioSource.PlayOneShot(_soundEffect1);
        }
        else
        {
            _audioSource.PlayOneShot(_soundEffect2);
        }
    }
    
    public void OpenBookmark2()
    {
        _bookmarkPanel1.SetActive(false);
        _bookmarkPanel2.SetActive(true);
        _bookmarkPanel3.SetActive(false);

        int randomSoundEffect = Random.Range(1, 3);

        if (randomSoundEffect == 1)
        {
            _audioSource.PlayOneShot(_soundEffect1);
        }
        else
        {
            _audioSource.PlayOneShot(_soundEffect2);
        }
    }
    
    public void OpenBookmark3()
    {
        _bookmarkPanel1.SetActive(false);
        _bookmarkPanel2.SetActive(false);
        _bookmarkPanel3.SetActive(true);

        int randomSoundEffect = Random.Range(1, 3);

        if (randomSoundEffect == 1)
        {
            _audioSource.PlayOneShot(_soundEffect1);
        }
        else
        {
            _audioSource.PlayOneShot(_soundEffect2);
        }
    }
}
