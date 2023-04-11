using UnityEngine;
using UnityEngine.UI;
public class NPController
{
    //Serializable

    //Properties
    public NPModel Model    {   get; private set;   }
    public NPView View  {   get; private set;   }
    public bool IsQuestGiven    {   get{return m_questController.isAccepted;}   }
    public bool IsQuestComplete    {   get{return m_questController.isQuestComplete;}   }
    public bool IsGoalReached    {   get{return m_questController.isGoalReached;}   }
    public bool IsRewardCollected    {   get{return m_questController.isRewardCollected;}   }
    public Animator NPCAnimator{get;private set;}
    
    //Private
    private QuestController m_questController;
    //Methods
    public NPController(NPModel _model, NPView _view)
    {
        this.Model = _model;
        View = GameObject.Instantiate<NPView>(_view);
        this.View.SetController(this);
        this.Model.SetController(this);
        m_questController = GenerateQuest();
    }
    // Show Dialogue panel
    public void ShowDialogue()
    {
        DialogueView.Instance.ShowDialogue(this);
    }
    // Show the details of quest on Quest Window
    public void ShowQuest()
    {
        QuestSystem.Instance.ShowQuest(m_questController);
    }
    // Assign this specific quest to player controller
    // Acts as quest Service
    // can be put in a state machine to separate from other scripts
    public QuestController GenerateQuest()
    {
        QuestModel m_questModel = new QuestModel(Model.QuestData);
        QuestController m_quest = new QuestController(m_questModel);
        return m_quest;
    }
}

// can use dictionary instead of dialogue object
// Dictionary<DialogueType, string> Dialogue = new Dictionary<DialogueType, string>();

//NPC can Have states as in
//Dialogue State
//QuestGiver State
//static state
//Roaming State
//etc