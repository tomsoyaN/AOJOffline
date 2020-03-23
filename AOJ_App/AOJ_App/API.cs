using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;
using System.Net.Http;

using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
//using System.Web.Script.Serialization;


namespace AOJ_App
{

    class API
    {
        //Login
        private void Login()
        {

            string user, password;
            Console.WriteLine("username >>>");
            user = Console.ReadLine();
            Console.WriteLine("password >>>");
            password = Console.ReadLine();


            var task = Task.Run(() => {
                return Post_Login(user, password);
            });
            Console.WriteLine(task.Result);

        }

        async public Task<string> Post_Login(string id, string pass)
        {
            var parameters = new Dictionary<string, string>()
            {

            };
            var json = "{\"id\":\"" + id + "\",\"password\":\"" + pass + "\"}";
            Console.WriteLine(json); //json確認用の表示
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://judgeapi.u-aizu.ac.jp/session", content);
                return await response.Content.ReadAsStringAsync();

            }
        }

        //GET関数 Get(URI)で実行
        private void Get(string URI)
        {
            var task = Task.Run(() => {
                return GET(URI);
            });

            string[] numbers = new string[100];
            String str = task.Result;
            System.Console.WriteLine(task.Result);
            String[] result = str.Split(':');
            //String[] result1 = result.Split('":"');
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("{0}", result[i]);

            }
            Console.WriteLine(result);


        }
        async public Task<string> GET(string URI)
        {
            using (var client = new HttpClient())
            {
                var uri = $"" + URI + "";
                var response = await client.GetAsync(uri);
                return await response.Content.ReadAsStringAsync();
            }
        }

        //Submissions
        private void Submissions()
        {

            string problem_id, language, code;
            Console.WriteLine("Problem id>>> ITP1_1_A");
            problem_id = Console.ReadLine();
            Console.WriteLine("language >>> ");
            language = Console.ReadLine();
            Console.WriteLine("#include <iostream>\nusing namespace std;\nint main(void){\n cout << \"Hello World\" << endl;\n}");
            Console.WriteLine("your code >>>");
            code = Console.ReadLine();



            var task = Task.Run(() => {
                return Post_submission(problem_id, language, code);
            });
            System.Console.WriteLine(task.Result);



        }

        async public Task<string> Post_submission(string id, string language, string code)
        {
            var parameters = new Dictionary<string, string>()
            {

            };

            //var json =  "{"problemId":"" + id + ',"language":"' + language + '","sourceCode":' + code +'}';

            //var json = "{" +
            //"problemId"+":"+ "ITP1_1_A"+","+
            //"language"+":"+"C" + "," +
            //"sourceCode" + ":" +
            //"#include \nint main(){\n  printf(\"Hello World\\n\");\n  return 0;\n}" +
            //"}";

            var json = "{\"problemId\":\"ITP1_1_A\",\"language\":\"C++\",\"sourceCode\":\"#include <iostream>\\nusing namespace std;\\nint main(void){\\n    cout << \"Hello World\" << endl;\\n}\"}";
            Console.WriteLine(json); //json確認用の表示
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://judgeapi.u-aizu.ac.jp/submissions", content);
                return await response.Content.ReadAsStringAsync();

            }
        }


        public static void Main(string[] args)
        {
            API obj = new API();
            obj.Login();
            //obj.Get("https://judgeapi.u-aizu.ac.jp/challenges"); //challenges
            //obj.Get("https://judgeapi.u-aizu.ac.jp/courses?filter=true&lang=ja"); //Course
            //obj.Get("https://judgeapi.u-aizu.ac.jp//submission_records/recent"); //findRecentSubmissionRecords

            obj.Submissions();
        }
    }

}