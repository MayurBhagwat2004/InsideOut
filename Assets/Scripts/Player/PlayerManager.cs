using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private bool dataSent;
    internal static PlayerManager instance;
    [SerializeField] private GameObject control;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI msg;
    private int score;
    public bool playerDied;

    void Start()
    {
        score = 0;
        if (instance == null)
        {
            instance = this;
            StartCoroutine(increaseScore());
        }
        else
        {
            Destroy(instance);
        }
        control.gameObject.SetActive(true);
        scorePanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerDied && !dataSent)
        {
            ShowDiedScreen();
        }
    }

    private IEnumerator increaseScore()
    {
        while (!playerDied)
        {
            yield return new WaitForSeconds(1);
            score++;
            scoreText.text = "Score: " + score;
        }
    }

    private void ShowDiedScreen()
    {
        dataSent = true;
        StartCoroutine(SendScore(
            "self_rewards", "346137", "student", "1-4262287011", "9322625439",
            "OmkarTadas", "sbs101", "IO", score.ToString(), "null", "null", "null",
            score.ToString(), "null", "null", "null"
        ));
        control.gameObject.SetActive(false);
        scorePanel.gameObject.SetActive(true);
    }

    private IEnumerator SendScore(
        string operation, string scMemberID, string memberType, string schoolID, string mobileNo,
        string userName, string gameID, string gameName, string exps, string level, string kills,
        string badges, string score, string img, string times, string times2)
    {
        yield return SendScoreToAPIAsync(
            operation, scMemberID, memberType, schoolID, mobileNo, userName,
            gameID, gameName, exps, level, kills, badges, score, img, times, times2
        ).AsIEnumerator();
        
    }


    async Task SendScoreToAPIAsync(
        string operation, string scMemberID, string memberType, string schoolID, string mobileNo,
        string userName, string gameID, string gameName, string exps, string level, string kills,
        string badges, string score, string img, string times, string times2)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://test.smartcookie.in/core/Version7/webservice_game.php");
        request.Headers.Add("Cookie", "PHPSESSID=ur0l8262kuk5ivoj4uq0ckstu0");

        var jsonContent = $@"
        {{
            ""operation"": ""{operation}"",
            ""SC_Member_ID"": ""{scMemberID}"",
            ""Member_type"": ""{memberType}"",
            ""School_id"": ""{schoolID}"",
            ""mobile_no"": ""{mobileNo}"",
            ""user_name"": ""{userName}"",
            ""game_id"": ""{gameID}"",
            ""game_name"": ""{gameName}"",
            ""exps"": ""{exps}"",
            ""level"": ""{level}"",
            ""kils"": ""{kills}"",
            ""badges"": ""{badges}"",
            ""score"": ""{score}"",
            ""img"": ""{img}"",
            ""times"": ""{times}"",
            ""times2"": ""{times2}""
        }}";

        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        request.Content = content;

        Debug.Log("The Score is :- " + score);
        if (int.Parse(score) > 0)
        {
            Debug.Log("Estimation Reward:- " + int.Parse(score) / 10);
        }
        else
        {
            Debug.Log("Estimation Reward :- 0");
        }
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                Debug.Log("Data submitted successfully " + responseBody);
                msg.text = "Score: " + score;
            }
            catch (HttpRequestException e)
            {
                control.gameObject.SetActive(true);
                scorePanel.gameObject.SetActive(false);
                Debug.LogError("Error: " + e.Message);
            }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            SceneManager.LoadScene(0);
        }
    }
}

public static class TaskExtensions
{
    public static IEnumerator AsIEnumerator(this Task task)
    {
        while (!task.IsCompleted)
        {
            yield return null;
        }
        if (task.IsFaulted)
        {
            throw task.Exception;
        }
    }
}