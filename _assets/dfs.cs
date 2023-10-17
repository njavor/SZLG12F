public bool El_lehet_e_jutni_melysegivel(int innen, int ide)
{
    int feher = 0, szurke = 1, fekete = 2;

    int[] szin = new int[szomszedsagi_lista.Length];

    Stack<int> tennivalok = new Stack<int>();
    tennivalok.Push(innen);
    szin[innen] = szurke;

    int feldolgozando;
    while (tennivalok.Count != 0)
    {
        feldolgozando = tennivalok.Pop();
        if (feldolgozando == ide)
            return true;
        szin[feldolgozando] = fekete;

        foreach (int szomszed in szomszedsagi_lista[feldolgozando])
            if (szin[szomszed] == feher)
            {
                tennivalok.Push(szomszed);
                szin[szomszed] = szurke;
            }
    }
    
    return false;
}