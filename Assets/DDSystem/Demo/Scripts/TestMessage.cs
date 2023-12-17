using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;

public class TestMessage : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        if(SceneManager.GetActiveScene().name=="Scene0")
        {
            dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/Sebastian, welcome."));

            dialogTexts.Add(new DialogData("As long as you pass the trials from the four continents and obtain the treasure chest, you can acquire the most precious \"one piece\" in this world."));

            dialogTexts.Add(new DialogData("After each trial, you will receive some clues about the treasure."));

            dialogTexts.Add(new DialogData("Now, Sebastian, my brave adventurer, are you ready to embark on this mysterious journey?"));

        }
        else if(SceneManager.GetActiveScene().name == "Scene1")
        {
            dialogTexts.Add(new DialogData("Mission: Fish out a boot from the pond."));
            
        }
        else if (SceneManager.GetActiveScene().name == "Scene2")
        {
            dialogTexts.Add(new DialogData("Mission: Rescue the kitten."));
        }
        else if (SceneManager.GetActiveScene().name == "Scene3")
        {
            dialogTexts.Add(new DialogData("Mission: Collect luminescent tree leaves."));
        }
        else if (SceneManager.GetActiveScene().name == "Scene4")
        {
            dialogTexts.Add(new DialogData("Mission: Retrieve the lost red scarf."));
        }
        else if (SceneManager.GetActiveScene().name == "Scene5")
        {
            dialogTexts.Add(new DialogData("Sebastian, congratulations! You have obtained the treasure!"));
        }
        //dialogTexts.Add(new DialogData("Just put the command in the string!", "Li", () => Show_Example(1)));

        //dialogTexts.Add(new DialogData("You can also change the character's sprite /emote:Sad/like this, /click//emote:Happy/Smile.", "Li",  () => Show_Example(2)));

        //dialogTexts.Add(new DialogData("If you need an emphasis effect, /wait:0.5/wait... /click/or click command.", "Li", () => Show_Example(3)));

        //dialogTexts.Add(new DialogData("Text can be /speed:down/slow... /speed:init//speed:up/or fast.", "Li", () => Show_Example(4)));

        //dialogTexts.Add(new DialogData("You don't even need to click on the window like this.../speed:0.1/ tada!/close/", "Li", () => Show_Example(5)));

        //dialogTexts.Add(new DialogData("/speed:0.1/AND YOU CAN'T SKIP THIS SENTENCE.", "Li", () => Show_Example(6), false));

        //dialogTexts.Add(new DialogData("And here we go, the haha sound! /click//sound:haha/haha.", "Li", null, false));

        //dialogTexts.Add(new DialogData("That's it! Please check the documents. Good luck to you.", "Sa"));

        DialogManager.Show(dialogTexts);
    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
