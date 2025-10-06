using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject PersonalWindow;
    public GameObject InsuranceWindow;
    public GameObject CompanyWindow;
    public GameObject DesktopCanvas;

    private List<string> names = new List<string>();
    private List<string> DOBs = new List<string>();
    private List<string> CODs = new List<string>();
    private List<string> residences = new List<string>();
    private List<string> conditions = new List<string>();
    private List<string> habits = new List<string>();
    private List<string> occupations = new List<string>();
    private List<int> answers = new List<int>();

    // name
    [SerializeField] private TMP_Text personalFile_name;
    [SerializeField] private TMP_Text insuranceCard_name;

    // DOB
    [SerializeField] private TMP_Text personalFile_DOB;
    [SerializeField] private TMP_Text insuranceCard_DOB;

    // COD
    [SerializeField] private TMP_Text personalFile_COD;

    // Conditions
    [SerializeField] private TMP_Text personalFile_conditions;

    // residence
    [SerializeField] private TMP_Text personalFile_residence;

    //habits 
    [SerializeField] private TMP_Text personalFile_habits;


    // Animation
    [SerializeField] private Animator _camAnimator;
    [SerializeField] private Animator _fadeToBlack;



    private int day;
    private int client;

    private void Start()
    {
        //SwitchToDesktop();
        day = 1;
        client = 0;
        CreateLists();
        Debug.Log(names.Count);
        IterateGame();
        StartCoroutine(StartDay());
    }

    public void SwitchToPersonalWindow()
    {
        PersonalWindow.SetActive(true);
        InsuranceWindow.SetActive(false);
        CompanyWindow.SetActive(false);
    }

    public void SwitchToInsuranceWindow()
    {
        PersonalWindow.SetActive(false);
        InsuranceWindow.SetActive(true);
        CompanyWindow.SetActive(false);
    }

    public void SwitchToCompanyWindow()
    {
        PersonalWindow.SetActive(false);
        InsuranceWindow.SetActive(false);
        CompanyWindow.SetActive(true);
    }

    public void SwitchToDesktop()
    {
        PersonalWindow.SetActive(false);
        InsuranceWindow.SetActive(false);
        CompanyWindow.SetActive(false);
        DesktopCanvas.SetActive(true);
    }

    public void IterateGame()
    {
        client += 1;
        if(client <= 3)
        {
            SetClientInfo();
        }
        else if(day < 4)
        {
            // next day sequence
        }
        else
        {
            // game is over
            // final email
            // fade black
            // credits
        }
    }

    public void CreateLists()
    {
        // name
        names.Add("Andec, Ant");
        names.Add("Berry, Dingle");
        names.Add("Jinn, Dee");
        names.Add("Cautious, Clive");
        names.Add("Pepper, Doctor");
        names.Add("Fatimus, Reginald");
        names.Add("Barn-Easton, Olivia");
        names.Add("John Smith");

        // DOB
        DOBs.Add("10/03/1960");
        DOBs.Add("29/11/1972");
        DOBs.Add("11/07/2003");
        DOBs.Add("02/01/2000");
        DOBs.Add("09/06/1999");
        DOBs.Add("25/04/1960");
        DOBs.Add("09/11/1999");
        DOBs.Add("27/07/1940");
        DOBs.Add("01/01/2000");

        // COD
        CODs.Add("Fell off motorcycle while driving home and broke his neck on the roadside guard rail. He wasn’t wearing a helmet.");
        CODs.Add("Sudden Cardiac Arrest while watching the television in the evening.");
        CODs.Add("Died of sudden shock during an early-adulthood circumcision.");
        CODs.Add("Misread a warning sign and walked into a minefield.");
        CODs.Add("Captured by SAW himself and put to an extensive, gruesome death. Homicide.");
        CODs.Add("Bled out after an accident proceeding a chainsaw juggling challenge.");
        CODs.Add("Crushed by a car in the workshop, was wearing his PPE.");
        CODs.Add("Eaten by Sprinkles, her pet Grizzly Bear.");
        CODs.Add("Suffocated in a grain silo after roof gave way.");

        // Residence
        residences.Add("362 Dungay Creek Road, Australia-town");
        residences.Add("42 Crevasse Road, Creekplace");
        residences.Add("69 Clarence St, Penzance");
        residences.Add("60 Shoe Street, Bad Place Ville");
        residences.Add("5 Stupid-ugly Road, Silly City");
        residences.Add("16 Soda Street, Fizz-on-high");
        residences.Add("50 Weiner Street, Poor-man City");
        residences.Add("43 Grass Road, Milton Keynes");
        residences.Add("1, Street, Grainville");

        // conditions
        conditions.Add("Short Stature.");
        conditions.Add("None Known.");
        conditions.Add("Afraid of the dark, Can’t digest soy.");
        conditions.Add("OCD, Hypervigilance.");
        conditions.Add("Short-sighted, Overweight.");
        conditions.Add("Kidney Stones, Cognitive Decline.");
        conditions.Add("Insufferable, small cranium.");
        conditions.Add("Missing left eye  &  2nd Right toe.");
        conditions.Add("Missing left eye  &  2nd Right toe.");
        conditions.Add("None Known.");

        // Habits
        habits.Add("Jungle torment, biker.");
        habits.Add("Frequent Gym-goer, Vegan.");
        habits.Add("Historically accurate sword training.");
        habits.Add("Washing hands, Water skiing.");
        habits.Add("Gobbling profusely.");
        habits.Add("Paint sniffing, Carpentry.");
        habits.Add("Mistreating others.");
        habits.Add("Raising exotic animals, Long walks on the beach.");
        habits.Add("Eat, Sleep, Farm, Repeat.");

        // Occupation
        occupations.Add("Deliveroo Driver");
        occupations.Add("Journalist");
        occupations.Add("Games Designer");
        occupations.Add("Health Inspector");
        occupations.Add("Fitness Influencer");
        occupations.Add("Entrepreneur");
        occupations.Add("Car Mechanic");
        occupations.Add("Unlicensed Zoo-Keeper");
        occupations.Add("Farmer");

        // Answers
        // 0 = Deny, 1 = Accept
        answers.Add(0);
        answers.Add(1);
        answers.Add(1);
        answers.Add(0);
        answers.Add(1);
        answers.Add(0);
        answers.Add(1);
        answers.Add(0);
        answers.Add(1);
    }

    public void SetClientInfo()
    {
        personalFile_name.text = names[client];
        insuranceCard_name.text = names[client];

        personalFile_DOB.text = DOBs[client];
        insuranceCard_DOB.text = DOBs[client];

        personalFile_COD.text = CODs[client];

        personalFile_conditions.text = conditions[client];

        personalFile_residence.text = residences[client];

        personalFile_habits.text = habits[client]; 
    }

    public IEnumerator StartDay()
    {
        yield return new WaitForSeconds(3.0f);

        _camAnimator.SetTrigger("CamZoom");
        yield return new WaitForSeconds(0.5f);
        _fadeToBlack.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.0f);
        SwitchToDesktop();
    }

}

public class Client : MonoBehaviour
{
    public string fullname;
    public string DOB;
    public string COD;
    public string residence;
    public string conditions;
    public string habits;
    public string occupation;

    public void SetVariables(string _fullname, string _DOB, string _COD, string _residence, string _conditions, string _habits, string _occupation)
    {
        fullname = _fullname;
        DOB = _DOB;
        COD = _COD;
        residence = _residence;
        conditions = _conditions;
        habits = _habits;
        occupation = _occupation;
    }



}
