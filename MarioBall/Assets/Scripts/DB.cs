using UnityEngine;
using UnityEngine.UI;

public class DB : MonoBehaviour {

    private static DB database;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text lifeText;

	private int level = 1;
	private int numOfLvl = 2;
    private int score = 0;
    private int life = 3;
	private bool gameEnd = false;

    /// <summary>
    /// Gets the database.
    /// </summary>
    /// <value>
    /// Returns database instance
    /// </value>
    public static DB Database
    {
        get
        {
            if (database == null)
                database = GameObject.FindObjectOfType<DB>();
            return database;
        }
    }

    public void Start()
    {
        if (database == null)
        {
            database = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (database != this)
            Destroy(gameObject);
    }

	/// <summary>
	/// Gets or sets a value indicating whether this game is end.
	/// </summary>
	/// <value><c>true</c> if game end; otherwise, <c>false</c>.</value>
	public bool GameEnd{
		get{ return gameEnd;}
		set{ gameEnd = value;}
	}

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "High Score: " + this.score;
    }

	public int getScore(){
		return score;
	}

    public void RemoveLife()
    {
        life -= 1;
        lifeText.text = "Life: " + life;
    }

    public int getLife()
    {
        return life;
    }

	public int NextLevel(){
		level++;
		if (level > numOfLvl)
			level = -1;
		return level;
	}

	public void DestroyDB()
	{
		Destroy (gameObject);
	}
}
