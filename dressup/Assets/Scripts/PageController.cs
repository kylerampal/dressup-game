using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    private int currentPage = 0;

    public void NextPage() {
        pages[currentPage].SetActive(false);
        currentPage = (currentPage+1) % pages.Length;
        pages[currentPage].SetActive(true);
    }

    public void PreviousPage() {
        pages[currentPage].SetActive(false);
        currentPage = (currentPage - 1 + pages.Length) % pages.Length;
        pages[currentPage].SetActive(true);
    }


    public void FirstPage() {
        pages[currentPage].SetActive(false);
        currentPage = 0 % pages.Length;
        pages[currentPage].SetActive(true);
    }

    public void LastPage() {
        pages[currentPage].SetActive(false);
        currentPage = pages.Length;
        pages[currentPage].SetActive(true);

    }
}
