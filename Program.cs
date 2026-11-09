
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string chemin = Path.Combine(Path.GetTempPath(), "fnumero.txt");

        List<string> clients = new List<string>();

        try
        {
            // Créer le fichier s'il n'existe pas
            if (!File.Exists(chemin))
                File.WriteAllText(chemin, "0;0;0");

            // Lire les compteurs
            string[] numeros = File.ReadAllText(chemin).Split(';');

            if (numeros.Length != 3 ||
                !int.TryParse(numeros[0], out int versement) ||
                !int.TryParse(numeros[1], out int retrait) ||
                !int.TryParse(numeros[2], out int information) ||
                versement < 0 || retrait < 0 || information < 0)
            {
                throw new FormatException();
            }

            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\n===== BANQUE =====");
                Console.WriteLine("1 - Versement");
                Console.WriteLine("2 - Retrait");
                Console.WriteLine("3 - Informations");
                Console.WriteLine("4 - Quitter");

                Console.WriteLine("\nChoisissez votre opération :");
                string choix = Console.ReadLine() ?? "";

                char lettre = ' ';
                int numero = 0;

                switch (choix)
                {
                    case "1":
                        lettre = 'V';
                        break;

                    case "2":
                        lettre = 'R';
                        break;

                    case "3":
                        lettre = 'I';
                        break;

                    case "4":
                        continuer = false;
                        continue;

                    default:
                        Console.WriteLine("Choix invalide !");
                        continue;
                }

                // Informations du client
                Console.WriteLine("Numéro de compte :");
                string compte = Console.ReadLine() ?? "";

                Console.WriteLine("Nom :");
                string nom = Console.ReadLine() ?? "";

                Console.WriteLine("Prénom :");
                string prenom = Console.ReadLine() ?? "";

                // Vérifier les informations
                if (string.IsNullOrWhiteSpace(compte) ||
                    string.IsNullOrWhiteSpace(nom) ||
                    string.IsNullOrWhiteSpace(prenom))
                {
                    Console.WriteLine("Les informations sont obligatoires !");
                    continue;
                }

                // Générer le numéro selon le service
                switch (lettre)
                {
                    case 'V':
                        numero = ++versement;
                        break;

                    case 'R':
                        numero = ++retrait;
                        break;

                    case 'I':
                        numero = ++information;
                        break;
                }

                // Générer le ticket
                string ticket = lettre + "-" + numero;


                int attente = numero - 1;

                if (attente == 0)
                {
                    Console.WriteLine("\nVotre numéro est " + ticket);
                    Console.WriteLine("Vous êtes le premier ! Aucun client n'attend avant vous.");
                }
                else
                {
                    Console.WriteLine("\nVotre numéro est " + ticket);
                    Console.WriteLine("Il y a " + attente + " personne(s) qui attend(ent) avant vous.");
                }

                // Ajouter le client
                clients.Add(
                    "Compte : " + compte +
                    " | Nom : " + nom +
                    " | Prénom : " + prenom +
                    " | Ticket : " + ticket
                );

                // Enregistrer les compteurs
                File.WriteAllText(
                    chemin,
                    versement + ";" + retrait + ";" + information
                );

                // Demander si un autre client arrive
                string reponse;

                do
                {
                    Console.WriteLine("\nVoulez-vous prendre un autre ticket ? (O/N)");
                    reponse = Console.ReadLine() ?? "";

                    if (!reponse.Equals("O", StringComparison.OrdinalIgnoreCase) &&
                        !reponse.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Réponse invalide ! Entrez O ou N.");
                    }

                } while (!reponse.Equals("O", StringComparison.OrdinalIgnoreCase) &&
                         !reponse.Equals("N", StringComparison.OrdinalIgnoreCase));

                if (reponse.Equals("N", StringComparison.OrdinalIgnoreCase))
                    continuer = false;
            }

            // Afficher la liste des clients
            Console.WriteLine("\n===== LISTE DES CLIENTS =====");

            foreach (string client in clients)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine("\nFin du programme.");
            Console.WriteLine("Fichier : " + chemin);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
        }
    }
}
