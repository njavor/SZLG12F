public int El_lehet_e_jutni_szelessegivel(int innen, int ide)
{
    int feher = 0, szurke = 1, fekete = 2;

    int[] szin = new int[szomszedsagi_lista.Length];

    Queue<int> tennivalok = new Queue<int>();
    tennivalok.Enqueue(innen);
    szin[innen] = szurke;

    int feldolgozando;
    while (tennivalok.Count != 0)
    {
        feldolgozando = tennivalok.Dequeue();
        if (feldolgozando == ide)
            return true;
        szín[feldolgozando] = fekete;

        foreach (int szomszed in szomszedsagi_lista[feldolgozando])
            if (szin[szomszed] == feher)
            {
                tennivalok.Enqueue(szomszed);
                szin[szomszed] = szurke;
            }
    }
    
    return false;
}