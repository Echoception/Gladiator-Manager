using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Gladiators
{
    internal class GladiatorNames
    {
        private List<string> _nameList = ["Aemilius", "Agrippa", "Albius", "Amatus", "Amuilius", "Ancus", "Annius", "Antonius", "Appius", "Aquilius", "Ascanius", "Asinius", "Atticus",
                                          "Attilius", "Augustus", "Aulus", "Aurelius", "Aurelianus", "Benedictus", "Brutus", "Cato", "Caecilius", "Caelestinus", "Caelius", "Calvus",
                                          "Camillus", "Candidus", "Cassius", "Claudius", "Clemens", "Cocceius", "Cornelius", "Cornelius", "Costantius", "Crassus", "Crispinus", "Decius",
                                          "Decimus", "Donatus", "Drusus", "Duilius", "Emilius", "Fabuis", "Fabricius", "Farkas", "Faustus", "Felix", "Flavius", "Florius", "Fulvius", "Gabinius",
                                          "Galerius", "Gaius", "Gellius", "Hadrianus", "Helius", "Hennius", "Horatius", "Hortensius", "Iginus", "Isidorus", "Iulius", "Iulianus", "Iustus",
                                          "Lepidus", "Linus", "Livius", "Lucuis", "Magnus", "Manlius", "Marcellus", "Marcus", "Maruis", "Maximus", "Mauritius", "Octavius", "Ovidius",
                                          "Paulus", "Patricius", "Petrus", "Pius", "Pompeius", "Publius", "Quartus", "Quintus", "Remus", "Romanus", "Romulus", "Rufus", "Salvus", "Sergius",
                                          "Sirius", "Terentius", "Titus", "Tullius", "Ursus", "Valerius", "Varus", "Virgilius"];

        public List<string> NameList => _nameList;


        public string GetRandomName()
        {
            string result = "";
            Random dice = new Random();

            result = NameList[dice.Next(0, NameList.Count)];

            return result;
        }

    }
}
