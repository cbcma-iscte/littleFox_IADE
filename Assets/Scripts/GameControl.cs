    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class GameControl : MonoBehaviour
    {
        //public Vector3[] listHam;
        //private int time = 10;
        private int numberHams = 5;
        private int hasGrabbedHams = 0;

        
        public GameObject fox_player;
        public GameObject bear_enemy;
        public GameObject ham_food;

        public GameObject MenuPause;
        public GameObject MenuGameOver;
        public GameObject MenuWin;
        public GameObject notYet;

        private int lifes= 3;
        public Text life_text;
        public Text hams_text;

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale=1f;
            //Instantiate(bear_enemy,new Vector3(1410.8f,1039f,348f),Quaternion.identity);
            //Instantiate(bear_enemy,new Vector3(1452.2f,1039f,340.5f),Quaternion.identity);
            hamInstanciate();
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.timeScale==1f){
            if (Input.GetKey(KeyCode.Escape))
                pauseMenu();
                
        }
        }

        public void hamEated(){
            hasGrabbedHams++;
            hams_text.text= hasGrabbedHams + "/" + numberHams +"Hams";
            if(hasGrabbedHams==numberHams){
                hams_text.GetComponent<Text>().color = Color.green;
            }
        }

        void hamInstanciate()
{
    List<Vector3> posicoesSeguras = new List<Vector3>
    {
        new Vector3(1063.003f, 1039.046f, 344.4725f), // Posição 1
        new Vector3(1450.934f, 1039.046f, 335.7631f), // Posição 2
        new Vector3(1407.287f, 1039.046f, 352.5804f), // Posição 3
        new Vector3(1456.318f, 1039.046f, 366.9046f), // Posição 4
        new Vector3(1404.347f, 1039.046f, 323.936f),  // Posição 5
        new Vector3(1449.995f, 1039.046f, 356.7635f), // Posição 6
        new Vector3(1451.464f, 1039.046f, 348.1447f), // Posição 7
        new Vector3(1445.760f,1039.046f,373.3648f), // Posição 8
        new Vector3(1447.78f,  1039.046f, 319.86f),   // Posição 9
        new Vector3(1407.28f,  1039.046f, 370.815f)   // Posição 10
    };

    Quaternion rotationOfHam = Quaternion.Euler(9.632f, -360f, 0f);

    // 2. O loop vai correr 5 vezes (numberHams)
    for (int i = 0; i < numberHams; i++)
    {
        int randomIndex = Random.Range(0, posicoesSeguras.Count);
        
        Instantiate(ham_food, posicoesSeguras[randomIndex], rotationOfHam);
        
        posicoesSeguras.RemoveAt(randomIndex);
    }
}
        

        public void respawnPlayer(){
            lifes--;
            if(lifes==0){
                life_text.text= lifes + " lifes";
                gameOver();
                    
            }else{
            if(lifes==1){
            life_text.text= lifes + " life";
            life_text.GetComponent<Text>().color = Color.red;}
            else{life_text.text= lifes + " lifes";}
            
            } 
                
        }

        
        public void tentFinishGame(){
            if(hasGrabbedHams==numberHams){
                Time.timeScale=0f;
                winGame();
            }else{
                
                
                notYet.SetActive(true);  
                notYetPainel();
    
                
                
                
            }
        }

        void notYetPainel(){
        StartCoroutine(RemoveAfterSeconds(2, notYet));
        }
 
        IEnumerator RemoveAfterSeconds(int seconds, GameObject notYet){
            yield return new WaitForSeconds(seconds);
            notYet.SetActive(false);
        }

        public void pauseMenu(){
            MenuPause.SetActive(true);
            Time.timeScale=0f;
           
        }
        

        public void resumeGame(){
        Time.timeScale=1f;
        MenuPause.SetActive(false);
    }

        public void restartGame(){
        
        SceneManager.LoadScene("Game");
    }

        public void exitGame(){
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver(){
            Time.timeScale=0f;
            MenuGameOver.SetActive(true);
    }

    public void winGame(){
            Time.timeScale=0f;
            MenuWin.SetActive(true);
    }


    }
