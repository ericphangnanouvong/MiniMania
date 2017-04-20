using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TransitionManager : NetworkBehaviour
{
    public Text GameNameText;
    public Text GameDescriptionText;
    public Text PlayerOneScoreText;
    public Text PlayerTwoScoreText;

    private List<string> gameNameList;

    // Use this for initialization
    void Start()
    {
        //Add games to the list of games to be played.
        gameNameList = new List<string> { "Bang Game", "Balloon Game", "Vertical Platformer", "Parachute Drop" };

        PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        PlayerOneScoreText.text = "P1 Score: " + playerManager.playerOneScore;
        PlayerTwoScoreText.text = "P2 Score: " + playerManager.playerTwoScore;

        //Make server choose a game for players to play.
        if (isServer)
        {
            StartCoroutine(ChooseGame());
        }
    }

    //Makes server choose the game by iterating through a list of games.
    [Server]
    private IEnumerator ChooseGame()
    {
        float startCount = 0.1f;
        float selectionSlowerCount = 0.003f;
        int iterationsLeft = Random.Range(30, 50);
        string selectedGame = "";

        while (iterationsLeft-- > 0)
        {
            //Loops until a unique random game is selected to display different than previous selection.
            int random = 0;
            bool isSelectingGame = true;
            do
            {
                random = Random.Range(0, gameNameList.Count);
                string tempSelectedGame = gameNameList[random];
                if (selectedGame != tempSelectedGame)
                {
                    selectedGame = tempSelectedGame;
                    isSelectingGame = false;
                }
            } while (isSelectingGame);

            //Let clients know which game to display.
            RpcChangeGameText(selectedGame);

            //Continue displaying game names.
            //Slows the display in each iteration.
            startCount += selectionSlowerCount;
            yield return new WaitForSeconds(startCount);
        }

        //Game is selected.
        //Let clients display the correct game description text.
        RpcDisplayGameDescriptionText(selectedGame);

        //Change to the selected game scene.
        string sceneNameToLoad = "";
        switch (selectedGame)
        {
            case "Bang Game":
                sceneNameToLoad = "BangGameMultiplayer";
                break;
            case "Balloon Game":
                sceneNameToLoad = "BalloonGameMultiplayer";
                break;
            case "Vertical Platformer":
                sceneNameToLoad = "VerticalPlatformerMultiplayer";
                break;
            case "Parachute Drop":
                sceneNameToLoad = "ParachuteDropMultiplayer";
                break;

        }
        yield return new WaitForSeconds(5f);
        //MiniNetworkManager.singleton.ServerChangeScene(sceneNameToLoad);
        MiniNetworkManager.singleton.ServerChangeScene("BangGameMultiplayer");
    }

    //Tells clients to display the selected game text.
    [ClientRpc]
    private void RpcChangeGameText(string gameText)
    {
        GameNameText.text = gameText;
    }


    //Tells clients to display the selected games description text.
    [ClientRpc]
    private void RpcDisplayGameDescriptionText(string gameName)
    {
        string descriptionText = "";

        switch (gameName)
        {
            case "Bang Game":
                descriptionText = "Game Objective: Be the quickest player to shoot when the timer says BANG. Be careful not to shoot before BANG as" +
                       " doing so will cause you to miss with your only bullet." + "\n\nControls: Press A to shoot.";
                break;
            case "Balloon Game":
                descriptionText = "Game Objective: Shoot balloons the same colour as you to gain points, hitting any other balloons will cause you to lose points." +
                       "\n\nControls: Press A to shoot";
                break;
            case "Vertical Platformer":
                descriptionText = "Game Objective: Be the first player to climb to the top and reach a flag. Getting hit by a sawblade will cause you to" +
                       " start from the beginning." + "\n\nControls: Press A to jump. Use the joystick to move.";
                break;
            case "Parachute Drop":
                descriptionText = "Game Objective: Open your parachute as close to the ground as possible without crashing into the ground." +
                         "\n\nControls: Press A to open your parachute. Press Start to start the game";
                break;
            default:
                Assert.raiseExceptions = true;
                Debug.Assert(true, "There should not be a default text.");
                descriptionText = "default text";
                break;
        }

        GameDescriptionText.text = descriptionText;
    }
}
