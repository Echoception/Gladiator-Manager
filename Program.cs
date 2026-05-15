using Gladiator_Manager.BattleSystem;
using Gladiator_Manager.CustomTimer;
using Gladiator_Manager.DateSystem;
using Gladiator_Manager.Facilities;
using Gladiator_Manager.Gladiators;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.Shops;
using Gladiator_Manager.SystemCreators;
using Gladiator_Manager.Tourneys;

GladiatorCreator gladiatorCreator = new GladiatorCreator();

BattleHandler battleHandler = new BattleHandler();

GladiatorMarket gladiatorMarket = new GladiatorMarket();
gladiatorMarket.RandomiseGladiatorsForSale(gladiatorCreator);

MainMarket mainMarket = new MainMarket();

FacilityUpgrades facilityUpgrades = new();

Player player = new Player();

MainHub mainHub = new MainHub();

DateHandler dateHandler = new DateHandler();

UserInput userInput = new UserInput();

Accommodations accommodations = new Accommodations();
TrainingFields trainingFields = new TrainingFields();

Ctimer timer = new Ctimer(1);

AllTourneys allTourneys = new AllTourneys();
allTourneys.Rank1Tourneys.UnlockRank1Tourneys();



while(true)
{
    mainHub.DisplayMainHub(player, gladiatorMarket, battleHandler, userInput, dateHandler, accommodations, gladiatorCreator, mainMarket, allTourneys, timer, facilityUpgrades,
        trainingFields);
    Console.Clear();
}