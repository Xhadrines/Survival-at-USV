// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using System.Collections.Generic;
using UnityEngine;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    // Clasa pentru stocarea dialogului.
    [System.Serializable]
    public class Dialog
    {
        // Lista de linii de dialog.
        [SerializeField] List<string> lines;

        // Proprietate pentru accesul la lista de linii de dialog.
        public List<string> Lines
        {
            get 
            { 
                return lines; 
            }
        }
    }
}
