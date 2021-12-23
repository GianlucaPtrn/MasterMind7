using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //ordinateur choisi sa combinaison à 4 chiffre// 
        static void ChoixCombi(out int[] combi)
        {
            combi = new int[4];
            Random rnd = new Random();
            for (int i = 0; i <= 3; i++)
            {
                int valeur = rnd.Next(1, 7);
                combi[i] = valeur;
            }
        }

        //créer un clone du tableau combi au tableau CloneCombi //
        static void Clonecombi(int[] combi, out int[] CloneCombi)
        {
            CloneCombi = new int[4];
            for(int y = 0; y <= combi.Length - 1; y++)
            {
                CloneCombi[y] = combi[y];
            }
            Console.WriteLine(CloneCombi);
        }

        //ajouter : Après avoir récupérer la combinaison, l’ordinateur transforme la chaîne de caractère en tableau//
        static void ChaineDeCaractereToTableau(out int[] propositionTableau)
        {
            propositionTableau = new int[4];

            for (int w = 0; w <= 3; w++)
            {
              Console.WriteLine($"Entrer votre nombre n{w}");
              propositionTableau[w] = int.Parse(Console.ReadLine());
            }
        }

        //affiche le nombre du joueur à entrer 
        static void AffichagechoixJoueur(int[] propositionTableau, out string resultPropositionTableau)
        {   
            resultPropositionTableau = "";
            for (int x = 0; x <= propositionTableau.Length - 1; x++)
            {
                resultPropositionTableau = resultPropositionTableau + propositionTableau[x];
            }
            Console.WriteLine(resultPropositionTableau);
        }

        //verifier les pions rouge 
        static void PionRouge(int[] propositionTableau, int[] combi, out int nombrePionRouge)
        {
            nombrePionRouge = 0;
            for (int i = 0; i <= 3; i++)
            {
                if (propositionTableau[i] == combi[i])
                {
                    nombrePionRouge++;
                    propositionTableau[i] = -1;
                    combi[i] = -2;
                }
            }
        }

        //verifier les pions blanc
        static void Pionblanc(int[] propositionTableau, int[] combi, out int nombrePionBlanc)
        {
            nombrePionBlanc = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (propositionTableau[i] == combi[j])
                    {
                        nombrePionBlanc++;
                        propositionTableau[i] = -1;
                    }
                }

            }

        }

        //Gestion du nombre de chances possible//
        //debut du programme//
        //L’ordinateur renvoie les résultats au joueur(boucle while qui comprend tout le programme sans modifier le code secret de base)//
        //propose d’entrer une nouvelle combinaison//
        static void Main(string[] args)
        {
            int[] combi;
            int[] CloneCombi;
            int[] propositionTableau;
            string restart = "oui";
            int nombrePionBlanc;
            int nombrePionRouge;
            int nbrchance = 2;

            string resultCombi;
            string resultPropositionTableau;
            ChoixCombi(out combi);

           /* if(nbrchance == 0)
            {
                restart = "non";
                Console.Clear();
                Console.WriteLine("Vous avez épuisé toutes vos chances");
            }*/
            if(nbrchance <= 0){
                Console.Clear();
                Console.WriteLine("Vous avez perdu !");
            }else{
                 while (restart == "oui")
                 {
                    nbrchance = nbrchance - 1;
                    Console.WriteLine(nbrchance);
                    Console.WriteLine("bonjour");
                    ChaineDeCaractereToTableau(out propositionTableau);
                    Clonecombi(combi, out CloneCombi);
                    Afficher(combi, out resultCombi);
                    AffichagechoixJoueur(propositionTableau, out resultPropositionTableau);
                    Console.WriteLine("Voulez vous retenté votre chance ? oui ou non");
                    restart = Console.ReadLine();

                 }
            }
        }
    }
}
