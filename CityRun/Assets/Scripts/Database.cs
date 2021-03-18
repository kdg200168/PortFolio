using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    [SerializeField]
    public Text Text2;
    // Use this for initialization
    public int count = 0;
    void Start()
    {
            // Insert
            SqliteDatabase sqlDB = new SqliteDatabase("config.db");
            string query = "insert into test values('" + Timer.fastminute + "','" + Timer.fastettime + "')";
            sqlDB.ExecuteNonQuery(query);

            // Select
         //   string selectQuery = "select * from test";
          //  DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

            // Update
           // sqlDB.ExecuteQuery($"UPDATE test SET  name = {Timer.fastettime} WHERE id = 1");
         //   string name = "";
        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        name = (string)dr["name"];
       //         Debug.Log("name:" + name);
        //    }
        //    Text2.text = name;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.count == true)
        {
            if ( count == 0)
            {
                count++;

                // Insert
                SqliteDatabase sqlDB = new SqliteDatabase("config.db");
                string query = "insert into test values('" + Timer.fastminute + "','" + Timer.cleartime + "')";
                sqlDB.ExecuteNonQuery(query);

                // Select
                string selectQuery = "select minute,seconds from test";
                DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);
               
                string minute = "";
                string seconds = "";
                foreach (DataRow dr in dataTable.Rows)
                {
                    seconds = (string)dr["seconds"];
                    minute = (string)dr["minute"];
                  //  Debug.Log("time:" + minute + seconds);
                }
                // update
                sqlDB.ExecuteQuery($"UPDATE test SET  minute ={Timer.fastminute}, seconds ={Timer.cleartime} ");

              //  sqlDB.ExecuteQuery($"DELETE test FROM  name ");
                Text2.text =   minute + ":" + seconds;
                Debug.Log("time:" + minute + ":" + seconds);
            }
        }
        else if(Timer.count == false)
        {
            count = 0;
        }
    }
}