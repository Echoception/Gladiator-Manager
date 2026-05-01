using Gladiator_Manager.BattleSystem;
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

Player player = new Player();

MainHub mainHub = new MainHub();

DateHandler dateHandler = new DateHandler();

UserInput userInput = new UserInput();

Accommodations accommodations = new Accommodations();

AllTourneys allTourneys = new AllTourneys();
allTourneys.UnlockRank1Tourneys();


//dateHandler.DisplayDate();
//dateHandler.AdvanceWeek();
//dateHandler.DisplayDate();

while(true)
{
    mainHub.DisplayMainHub(player, gladiatorMarket, battleHandler, userInput, dateHandler, accommodations, gladiatorCreator, mainMarket, allTourneys);
    Console.Clear();
}